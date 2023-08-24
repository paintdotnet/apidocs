---
uid: PaintDotNet.UI.Media
summary: *content
---
This namespace contains classes used when creating Custom Shape plugins in XAML. 

They are not useful for other types of plugins, which should use either [Direct2D geometry](xref:PaintDotNet.Direct2D1.IGeometry) or [WPF geometry](xref:System.Windows.Media.Geometry). You can convert between those two formats with the [IGeometry.ToWpfGeometry](xref:PaintDotNet.Direct2D1.GeometryExtensions.ToWpfGeometry) and [IDirect2DFactory.FromWpfGeometry](xref:PaintDotNet.Direct2D1.Direct2DFactoryExtensions.FromWpfGeometry) extension methods.