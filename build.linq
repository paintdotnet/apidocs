<Query Kind="Program">
  <NuGetReference>ILRepack.Lib</NuGetReference>
  <Namespace>ILRepacking</Namespace>
</Query>

int Main(string[] args)
{
    string dllSourceDir = args[0];
    string[] additionalDocfxParams = args.Skip(1).ToArray();
    try
    {
        return MainImpl(dllSourceDir, additionalDocfxParams);
    }
    catch (Exception ex)
    {
        Console.WriteLine("*** ERROR: Unhandled exception");
        Console.WriteLine(ex.ToString());
        return ex.HResult;
    }
}

private static int MainImpl(string dllSourceDir, IEnumerable<string> additionalDocfxParams)
{
    string stagingDir = Path.Combine(Path.GetTempPath(), $"PDNBuildApiDocs{Guid.NewGuid()}");
    if (!Directory.Exists(stagingDir))
    {
        Directory.CreateDirectory(stagingDir);
    }

    Console.WriteLine($"Building staging directory: {stagingDir}");

    // Copy PDN files. Don't care about sub-dirs, so no need for a recursive copy directory.
    CopyDirectoryNonRecursive(dllSourceDir, stagingDir);

    // Copy .NET assemblies, this helps merging and docs generation go smoother
    CopyDirectoryNonRecursive(@$"C:\Program Files\dotnet\shared\Microsoft.NETCore.App\{Environment.Version}", stagingDir);
    CopyDirectoryNonRecursive(@$"C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App\{Environment.Version}", stagingDir);

    Console.WriteLine("Finished building staging directory");
    Console.WriteLine();

    // Merge PDN assemblies. This helps docfx to not bungle up extension method classes w/ same names. See: https://github.com/paintdotnet/apidocs/issues/1
    Console.WriteLine("Merging assemblies:");
    string outputFile = Path.Combine(stagingDir, "PaintDotNet.Merged.dll");
    MergeAssemblies(stagingDir, outputFile);
    Console.WriteLine("Finished merging assemblies");
    Console.WriteLine();
    
    // Generate docs via docfx
    Console.WriteLine("Generating docs ...");
    
    IReadOnlyDictionary<string, string> templateReplacementMap = new Dictionary<string, string>()
    {
        { "AssemblySourceDir", stagingDir.Replace("\\", "/") }
    };
    
    ProcessTemplatedFile("docfx.template.json", "docfx.json", templateReplacementMap);

    string[] docfxArgs = additionalDocfxParams.Prepend("docfx.json").ToArray();
    string docfxCommandLine = CreateCommandLineFromArgs(docfxArgs);

    ProcessStartInfo docfxStartInfo = new ProcessStartInfo("docfx", docfxCommandLine);
    docfxStartInfo.UseShellExecute = false;
    using Process docfxProcess = Process.Start(docfxStartInfo);
    docfxProcess.WaitForExit();
    if (docfxProcess.ExitCode != 0)
    {
        Console.WriteLine($"Error: docfx exited with code {docfxProcess.ExitCode}");
        return docfxProcess.ExitCode;
    }

    Console.WriteLine("Finished building docs");

    // Clean up
    Console.Write("Cleaning up...");
    Directory.Delete(stagingDir, true);
    Console.WriteLine();

    return 0;
}

private static void MergeAssemblies(string sourceDir, string outputFile)
{
    // Sorted from lower layer to top layer
    string[] dllFileNames =
        new string[]
        {
            // Included because the docs seem to work better w/ this (fixes some "inheritdoc" docfx mistakes)
            // And we put this at the top so that if a class is defined here as internal, with the same name
            // as a lower level assembly that is defined as public, then we'll notice that the class goes
            // missing when we look at the diff of generated files.
            "paintdotnet.dll", 
            
            "PaintDotNet.ComponentModel.dll",
            "PaintDotNet.Fundamentals.dll",
            "PaintDotNet.Primitives.dll",
            "PaintDotNet.PropertySystem.dll",
            "PaintDotNet.Collections.dll",
            "PaintDotNet.Runtime.dll",
            "PaintDotNet.ObjectModel.dll",
            "PaintDotNet.Windows.dll",
            "PaintDotNet.Windows.Core.dll",
            "PaintDotNet.Windows.Framework.dll",
            "PaintDotNet.UI.dll",
            "PaintDotNet.Base.dll",            
            "PaintDotNet.Core.dll",
            "PaintDotNet.Framework.dll",
            "PaintDotNet.Data.dll",
            "PaintDotNet.Effects.Core.dll",
            "PaintDotNet.Effects.Gpu.dll",            
        };

    RepackOptions options = new RepackOptions()
    {
        OutputFile = outputFile,
        InputAssemblies = dllFileNames.Select(n => Path.Combine(sourceDir, n)).ToArray(),
        SearchDirectories = new string[]
        {
            sourceDir,
            @$"C:\Program Files\dotnet\shared\Microsoft.NETCore.App\{Environment.Version}",
            @$"C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App\{Environment.Version}"
        },
        TargetKind = ILRepack.Kind.Dll,
        UnionMerge = true,
        XmlDocumentation = true
    };

    // See: https://github.com/gluck/il-repack/issues/263
    string[] allowedDuplicateTypes =
        new string[]
        {
            "Microsoft.CodeAnalysis.EmbeddedAttribute",
            "System.Runtime.CompilerServices.IsByRefLikeAttribute",
            "System.Runtime.CompilerServices.IsUnmanagedAttribute",
            "System.Runtime.CompilerServices.NullableAttribute",
            "System.Runtime.CompilerServices.NullableContextAttribute",
            "System.Runtime.CompilerServices.RefSafetyRulesAttribute",
    };

    foreach (string allowedDuplicateType in allowedDuplicateTypes)
    {
        options.AllowedDuplicateTypes.Add(allowedDuplicateType, allowedDuplicateType);
    }

    ILRepack repack = new ILRepack(options);
    repack.Repack();
}

private static void CopyDirectoryNonRecursive(string sourceDir, string targetDir)
{
    foreach (string sourceFilePath in Directory.EnumerateFiles(sourceDir, "*.*"))
    {
        string sourceFileName = Path.GetFileName(sourceFilePath);
        string targetFilePath = Path.Combine(targetDir, sourceFileName);
        Console.Write($"Copying {sourceFileName} ...");
        File.Copy(sourceFilePath, targetFilePath, true);
        Console.WriteLine();
    }
}

private static void ProcessTemplatedFile(
    string inputFileName, 
    string outputFileName,
    IReadOnlyDictionary<string, string> replacementMap)
{
    string inputText = File.ReadAllText(inputFileName);
    string outputText = ProcessTemplatedText(inputText, replacementMap);
    File.WriteAllText(outputFileName, outputText);
}

private static string ProcessTemplatedText(
    string templatedText,
    IReadOnlyDictionary<string, string> replacementMap)
{
    string result = templatedText;

    foreach (string parameterName in replacementMap.Keys)
    {
        string value = replacementMap[parameterName];
        result = ReplaceTemplateParameter(result, parameterName, value);
    }

    return result;
}

private static string ReplaceTemplateParameter(string templatedText, string parameterName, string value)
{
    return templatedText.Replace($"{{${parameterName}$}}", value, StringComparison.OrdinalIgnoreCase);
}

public static string CreateCommandLineFromArgs(IEnumerable<string> args)
{
    string[] escapifiedArgs = EscapifyArgs(args).ToArray();
    string commandLine = string.Join(" ", escapifiedArgs);
    return commandLine;
}

public static IEnumerable<string> EscapifyArgs(IEnumerable<string> args)
{
    foreach (string arg in args)
    {
        yield return EscapifyArg(arg);
    }
}

public static string EscapifyArg(string arg)
{
    StringBuilder resultBuilder = new StringBuilder();

    bool quotes = false;
    for (int i = 0; i < arg.Length; ++i)
    {
        if (char.IsWhiteSpace(arg[i]))
        {
            quotes = true;
            break;
        }
    }

    if (quotes)
    {
        resultBuilder.Append('\"');
    }

    for (int i = 0; i < arg.Length; ++i)
    {
        char c = arg[i];
        if (c == '\"')
        {
            // double-quotes
            resultBuilder.Append('\"');
        }
        else if (quotes && c == '\\' && i == arg.Length - 1)
        {
            // make sure backslash at end doesn't escapify the ending quote
            resultBuilder.Append('\\');
        }

        resultBuilder.Append(c);
    }

    if (quotes)
    {
        resultBuilder.Append('\"');
    }

    return resultBuilder.ToString();
}