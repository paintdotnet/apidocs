---
uid: Plugins.CustomShapes
summary: *content
---
# Custom Shapes

Paint.NET supports Custom Shapes as a form of declarative plugin -- code is not involved! The object model is intentionally identical to [WPF geometry](xref:System.Windows.Media.Geometry), and is compatible with XAML files created for WPF as long as you change the namespace and wrap the geometry object in a `<SimpleGeometryShape>` element.

The object model for Custom Shapes is contained in the [PaintDotNet.Shapes](xref:PaintDotNet.Shapes) and [PaintDotNet.UI.Media](xref:PaintDotNet.UI.Media) namespaces.

Links:
- [Plugins - Shapes section of the Paint.NET forum](https://forums.getpaint.net/forum/48-shapes/). Download custom shapes plugins.
- [How to make custom shapes](https://forums.getpaint.net/topic/32101-how-to-make-custom-shapes-for-paintnet-406/) tutorial by BoltBait
- [ShapeMaker plugin by The Dwarf Horde](https://forums.getpaint.net/topic/110677-shapemaker-by-the-dwarf-horde-v1704-may-21-2022/)