---
uid: API
summary: *content
---
# Paint.NET Plugin API Class Reference
This is an index of the namespaces and members that are accessible for Paint.NET plugins.

The following DLLs should be referenced by plugins:
- All plugins
  - `PaintDotNet.Base.dll`
  - `PaintDotNet.ComponentModel.dll`
  - `PaintDotNet.Core.dll`
  - `PaintDotNet.Fundamentals.dll`
  - `PaintDotNet.Framework.dll`
  - `PaintDotNet.Primitives.dll`
  - `PaintDotNet.PropertySystem.dll`
  - `PaintDotNet.Windows.dll`
  - `PaintDotNet.Windows.Core.dll`
  - `PaintDotNet.Windows.Framework.dll`
- Effect plugins
  - `PaintDotNet.Effects.Core.dll`
- GPU Effect plugins
  - `PaintDotNet.Effects.Gpu.dll`
- FileTypes
  - `PaintDotNet.Data.dll`

> **NOTE:** In order to properly generate documentation for extension methods, the Paint.NET assemblies have to be merged into one DLL. Thus, all elements (not just extension method classes) will say they are from `PaintDotNet.Merged.dll`. If you can't find a particular class or extension method in your development environment (IntelliSense is missing, and/or compiler errors), check to make sure you are referencing all of the relevant assemblies listed above.

> **NOTE:** Paint.NET's DLLs are not licensed for use in other applications. You may not embed them in your own software or redistribute them.