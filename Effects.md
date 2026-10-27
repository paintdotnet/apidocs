---
uid: Effects
summary: *content
---
# Effects

## Getting Started
Create a "Class Library" project in Visual Studio. Set it to use the same version of .NET that Paint.NET uses. If you're not sure which version of .NET you need to use, go to Paint.NET's Settings, then Diagnostics, then scroll down to the "Runtime" section. This is easy to change later so don't fret about getting it wrong.

Next, add a Nuget package reference for the [`Paint.NET.Plugin.SDK`](https://www.nuget.org/packages/Paint.NET.Plugin.SDK/) package. It will bring in all the necessary reference assemblies for building plugins. Using `"*-*"` for the package reference version will make sure you're always using the latest version of the SDK. You'll always have access to the latest APIs, and won't be able to accidentally use any obsolete or deprecated APIs.

## Sample Effects Project
The [effect samples on GitHub](https://github.com/paintdotnet/PdnV5EffectSamples/) can be used as a template to get started. Just copy it, change the name of the `.csproj` file, and update its `<RootNamespace>` property to something appropriate.
