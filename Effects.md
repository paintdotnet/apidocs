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

The project file can also be used as a template for FileType plugins, you'll just be writing different code.

## Useful Links
Here are some useful links to get started with effect plugin development:
- [Plugins](https://forums.paint.net.net/forum/7-plugins-publishing-only/) section of the Paint.NET Forum, for publishing and downloading plugins
- [Installing Additional Plugins](https://paint.net/doc/latest/InstallPlugins.html) documentation for users of plugins
- [Plugin Developer's Central](https://forums.paint.net/forum/17-plugin-developers-central/) section of the Paint.NET Forum, for information, discussion, and questions about plugin development
- PdnV5SampleEffects
  - This will show you the right way to set up a Visual Studio project (look at the .csproj!), and how to write either a [`BitmapEffect`](xref:PaintDotNet.Effects.BitmapEffect) or a [`GpuEffect`](xref:PaintDotNet.Effects.Gpu.GpuEffect).
  - GitHub source code: https://github.com/paintdotnet/PdnV5EffectSamples
- CodeLab, by BoltBait
  - This is a good and (very!) popular way to write an effect plugin. Works for both BitmapEffect (CPU) and GpuEffect (GPU).
  - Website: https://boltbait.com/pdn/codelab/
  - Forum page with discussion: https://forums.paint.net/topic/121344-codelab-v68-for-paintnet-50-updated-january-22-2023/
  - GitHub source code: https://github.com/BoltBait/CodeLab
- Plugin Dev channel on the Paint.NET Discord Server
  - Invitation link: https://discord.gg/6V3Ace9SBg
