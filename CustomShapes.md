---
uid: CustomShapes
summary: *content
---
# Custom Shapes

Paint.NET supports Custom Shapes as a form of declarative plugin - code is not involved! The object model is intentionally identical to [WPF geometry](xref:System.Windows.Media.Geometry), with only a few caveats, and is compatible with XAML files created for WPF as long as you change the namespace and wrap the geometry object in a `<SimpleGeometryShape>` element.

The object model for Custom Shapes is contained in the [PaintDotNet.Shapes](xref:PaintDotNet.Shapes) and [PaintDotNet.UI.Media](xref:PaintDotNet.UI.Media) namespaces.

Links:
- [Plugins - Shapes section of the Paint.NET forum](https://forums.getpaint.net/forum/48-shapes/). Download custom shapes plugins.
- [How to make custom shapes](https://forums.getpaint.net/topic/32101-how-to-make-custom-shapes-for-paintnet-406/) tutorial by BoltBait
- [ShapeMaker plugin by The Dwarf Horde](https://forums.getpaint.net/topic/110677-shapemaker-by-the-dwarf-horde-v1704-may-21-2022/)

## Differences from WPF Geometry
While the Custom Shapes object model is essentially identical to WPF's Geometry object model, there are a few differences:

Added:
- [PolyCurveSegment](xref:PaintDotNet.UI.Media.PolyCurveSegment)
  - This is a [PathSegment](xref:PaintDotNet.UI.Media.PathSegment) that draws a curve going through each given point. Also known as a [spline](https://en.wikipedia.org/wiki/Spline_(mathematics)).
  - These can be used within a [PathGeometry](xref:PaintDotNet.UI.Media.PathGeometry), similar to [PolyLineSegment](xref:PaintDotNet.UI.Media.PolyLineSegment) or [PolyBezierSegment](xref:PaintDotNet.UI.Media.PolyBezierSegment).
- [FlattenedGeometry](xref:PaintDotNet.UI.Media.FlattenedGeometry)
  - This is a declarative equivalent to the imperative [Geometry.GetFlattenedPathGeometry](https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.geometry.getflattenedpathgeometry) (WPF) or [IGeometry.Simplify](xref:PaintDotNet.Direct2D1.IGeometry.Simplify*) (Direct2D) methods.
  - It is primarily useful for increasing the tesellation resolution of curves that, for whatever reason, appear "too pointy". This happens when Direct2D does not use enough line segments to approximate a curve.
  - You could also use this to reduce tessellation resolution, forcing a curve to appear "low-res" or "pointy." (use a value larger than 1 for the [FlatteningTolerance](xref:PaintDotNet.UI.Media.FlattenedGeometry.FlatteningTolerance) property).
  - This is used by the built-in Ellipse shape to improve its rendering quality (a very low flattening tolerance of 0.0001 is used).
- [OutlinedGeometry](xref:PaintDotNet.UI.Media.OutlinedGeometry)
  - This is a declarative equivalent to the imperative [Geometry.GetOutlinedPathGeometry](https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.geometry.getoutlinedpathgeometry) (WPF) or [IGeometry.Outline](xref:PaintDotNet.Direct2D1.IGeometry.Outline*) (Direct2D) methods.
- [WidenedGeometry](xref:PaintDotNet.UI.Media.WidenedGeometry)
  - This is a declarative equivalent to the imperative [Geometry.GetWidenedPathGeometry](https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.geometry.getwidenedpathgeometry) (WPF) or [IGeometry.Widen](xref:PaintDotNet.Direct2D1.IGeometry.Widen*) (Direct2D) methods.
  - Widening is often referred to as "stroking." You can use this to create the 2-dimensional stroked outline of a 1-dimensional line or curve.
  
Removed:
- [StreamGeometry](https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.streamgeometry) does not exist
  - `StreamGeometry` is primarily used in code, not in XAML, and does not exist for Custom Shapes.
  - You can, however, use [Path Markup syntax](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/graphics-multimedia/path-markup-syntax) to initialize any property of type [Geometry](xref:PaintDotNet.UI.Media.Geometry).
  - For example: `<SimpleGeometryShape Geometry="F1 M 21,142 L 160,22 L 300,142 L 300,318 L 21,318 Z" />`
