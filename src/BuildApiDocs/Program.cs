/////////////////////////////////////////////////////////////////////////////////
// paint.net                                                                   //
// Copyright (C) dotPDN LLC, Rick Brewster, and contributors.                  //
// All Rights Reserved.                                                        //
/////////////////////////////////////////////////////////////////////////////////

using ILRepacking;
using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace PaintDotNet.BuildApiDocs;

public static class Program
{
    // args[0] = source dir w/ PDN binaries

    public static int Main(string[] args)
    {
        try
        {
            //return MainImpl(args);
            return MainImpl(@"D:\src\pdn\src\PaintDotNet\bin\Release");
        }
        catch (Exception ex)
        {
            Console.WriteLine("*** ERROR: Unhandled exception");
            Console.WriteLine(ex.ToString());
            return ex.HResult;
        }
    }

    private static int MainImpl(params string[] args)
    {
        string sourceDir = args[0];
        /MetadataAggregator[0]/src
        string docfxJsonText = File.ReadAllText(@"D:\src\github\rickbrew\apidocs\docfx.json");
        JsonDocument jsonDoc = JsonDocument.Parse(docfxJsonText);

        string stagingDir = Path.Combine(Path.GetTempPath(), $"PDNBuildApiDocs{Guid.NewGuid()}");
        if (!Directory.Exists(stagingDir))
        {
            Directory.CreateDirectory(stagingDir);
        }

        Console.WriteLine($"Staging directory: {stagingDir}");

        // Copy PDN files. Don't care about sub-dirs, so no need for a recursive copy directory.
        CopyDirectoryNonRecursive(sourceDir, stagingDir);

        // Copy .NET assemblies, this helps merging and docs generation go smoother
        CopyDirectoryNonRecursive(@$"C:\Program Files\dotnet\shared\Microsoft.NETCore.App\{Environment.Version}", stagingDir);
        CopyDirectoryNonRecursive(@$"C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App\{Environment.Version}", stagingDir);

        // Merge PDN assemblies. This helps docfx to not bungle up extension method classes w/ same names. See: https://github.com/paintdotnet/apidocs/issues/1
        string outputFile = Path.Combine(stagingDir, "PaintDotNet.Merged.dll");
        MergeAssemblies(stagingDir, outputFile);

        // Generate docs via docfx

        return 0;
    }

    private static void MergeAssemblies(string sourceDir, string outputFile)
    {
        string[] dllFileNames = 
            new string[]
            {
                "paintdotnet.dll", // included because the docs seem to work better w/ this (fixes some "inheritdoc" docfx mistakes)
                "PaintDotNet.Base.dll",
                "PaintDotNet.Collections.dll",
                "PaintDotNet.ComponentModel.dll",
                "PaintDotNet.Core.dll",
                "PaintDotNet.Data.dll",
                "PaintDotNet.Effects.Core.dll",
                "PaintDotNet.Effects.Gpu.dll",
                "PaintDotNet.Framework.dll",
                "PaintDotNet.Fundamentals.dll",
                "PaintDotNet.ObjectModel.dll",
                "PaintDotNet.Primitives.dll",
                "PaintDotNet.PropertySystem.dll",
                //"PaintDotNet.Resources.dll",
                "PaintDotNet.Runtime.dll",
                //"PaintDotNet.SystemLayer.dll",
                //"PaintDotNet.Systrace.dll",
                "PaintDotNet.UI.dll",
                "PaintDotNet.Windows.dll",
                "PaintDotNet.Windows.Core.dll",
                "PaintDotNet.Windows.Framework.dll"
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
}