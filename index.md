---
uid: Index
summary: *content
---
# Paint.NET Plugin API Documentation
Here you will find documentation and reference material for Paint.NET plugin development.

Currently this is mostly a simple reference of namespaces, classes, etc. This will eventually expand to include articles detailing the _process_ of writing a plugin (creating a Visual Studio project, or using CodeLab, what assemblies to reference, etc.). Over time, more documentation will be added to individual classes, methods, etc. Some of them already have good documentation, but most have nothing.

Here are some useful links to start:
- [Plugins](https://forums.getpaint.net/forum/7-plugins-publishing-only/) section of the Paint.NET Forum, for publishing and downloading plugins
- [Installing Additional Plugins](https://getpaint.net/doc/latest/InstallPlugins.html) documentation for users of plugins
- [Plugin Developer's Central](https://forums.getpaint.net/forum/17-plugin-developers-central/) section of the Paint.NET Forum, for information, discussion, and questions about plugin development
- PdnV5SampleEffects
  - This will show you the right way to set up a Visual Studio project (look at the .csproj!), and how to write either a [`BitmapEffect`](xref:PaintDotNet.Effects.BitmapEffect) or a [`GpuEffect`](xref:PaintDotNet.Effects.Gpu.GpuEffect).
  - GitHub source code: https://github.com/paintdotnet/PdnV5EffectSamples
- CodeLab, by BoltBait
  - This is a good and (very!) popular way to write a classic/legacy effect that runs on the CPU and has a standard UI.
  - Website: https://boltbait.com/pdn/codelab/
  - Forum page with discussion: https://forums.getpaint.net/topic/121344-codelab-v68-for-paintnet-50-updated-january-22-2023/
  - GitHub source code: https://github.com/BoltBait/CodeLab
- Plugin Dev channel on the Paint.NET Discord Server
  - Invitation link: https://discord.gg/wQhWmqDP

Articles or other information that are on the TODO list:
- How to create a Visual Studio project for plugin development
- Programming guide for FileType plugins
- Programming guide for BitmapEffect plugins
- Programming guide for GpuEffect plugins
- How to use IndirectUI to create a standard UI for your Effect or FileType
  - How to add tabs to your UI (new for 5.0)
- How to provide PluginSupportInfo, and why you should do it
- Always increment the assembly version when releasing an update to your plugin
- How to package a plugin with .deps.json, how it should be installed by the end-user, etc.
- How to use `il-repack` to avoid multi-DLL plugins (e.g. if using nuget packages), and avoid need for .deps.json in the first place
- How to use `illink` so that you can pull in a huge dependency like TerraFX.Interop.Windows and trim it down to only what you actually use
- etc.