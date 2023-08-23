No articles yet, but here are some useful links to start:
- PdnV5SampleEffects
  - This will show you the right way to set up a Visual Studio project (look at the .csproj!), and how to write either a [`BitmapEffect`](xref:PaintDotNet.Effects.BitmapEffect) or a [`GpuEffect`](xref:PaintDotNet.Effects.Gpu.GpuEffect).
  - GitHub source code: https://github.com/paintdotnet/PdnV5EffectSamples
- CodeLab, by BoltBait
  - This is a good and (very!) popular way to write a classic/legacy effect that runs on the CPU and has a standard UI.
  - Website: https://boltbait.com/pdn/codelab/
  - Forum page with discussion: https://forums.getpaint.net/topic/121344-codelab-v68-for-paintnet-50-updated-january-22-2023/
  - GitHub source code: https://github.com/BoltBait/CodeLab
- Plugin Developer's Central
  - This is a section on the Paint.NET forum where you can read about and discuss plugin development.
  - Link: https://forums.getpaint.net/forum/17-plugin-developers-central/
- Plugin Dev channel on the Paint.NET Discord Server
  - Invitation link: https://discord.gg/wQhWmqDP

TODO:
- How to create a Visual Studio project for plugin development
- Programming guide for FileType plugins
- Programming guide for BitmapEffect/GpuEffect plugins
- Programming guide for Custom Shape (XAML) plugins
- How to package a plugin with .deps.json, how it should be installed by the end-user, etc.
- How to use linking to avoid multi-DLL plugins (if using nuget packages), and avoid need for .deps.json in the first place
- etc.
