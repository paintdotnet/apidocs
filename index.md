---
uid: Index
summary: *content
---
# Paint.NET Plugin API Documentation
Here you will find documentation and reference material for Paint.NET plugin development.

Currently this is mostly a simple reference of namespaces, classes, etc. This will eventually expand to include articles detailing the _process_ of writing a plugin (creating a Visual Studio project, or using CodeLab, what assemblies to reference, etc.). Over time, more documentation will be added to individual classes, methods, etc. Some of them already have good documentation, but most have nothing.

## Useful Links
Here are some useful links to get started with plugin development:
- [Plugins](https://forums.paint.net.net/forum/7-plugins-publishing-only/) section of the Paint.NET Forum, for publishing and downloading plugins
- [Installing Additional Plugins](https://paint.net/doc/latest/InstallPlugins.html) documentation for users of plugins
- [Plugin Developer's Central](https://forums.paint.net/forum/17-plugin-developers-central/) section of the Paint.NET Forum, for information, discussion, and questions about plugin development
- PdnV5SampleEffects
  - This will show you the right way to set up a Visual Studio project (look at the .csproj!), and how to write either a [`BitmapEffect`](xref:PaintDotNet.Effects.BitmapEffect) or a [`GpuEffect`](xref:PaintDotNet.Effects.Gpu.GpuEffect).
  - GitHub source code: https://github.com/paintdotnet/PdnV5EffectSamples
- PdnSampleFileTypes
  - This will show you the right way to set up a Visual Studio project, and how to write a simple [`FileType`](xref:PaintDotNet.FileTypes.FileType) with a loader and a saver.
- CodeLab, by BoltBait
  - This is a good and (very!) popular way to write an effect plugin. Works for both BitmapEffect (CPU) and GpuEffect (GPU).
  - Website: https://boltbait.com/pdn/codelab/
  - Forum page with discussion: https://forums.paint.net/topic/121344-codelab-v68-for-paintnet-50-updated-january-22-2023/
  - GitHub source code: https://github.com/BoltBait/CodeLab
- Plugin Dev channel on the Paint.NET Discord Server
  - Invitation link: https://discord.gg/6V3Ace9SBg
