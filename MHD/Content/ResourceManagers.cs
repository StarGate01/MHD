#region Using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.Direct2D1;
using SharpDX.DirectWrite;

#endregion

namespace MHD.Content.ResourceManagers
{

    #region Base class

    public class ResourceManager : IDisposable
    {

        public virtual void Load(object resourceSource) { }

        public virtual void Link(RenderTarget renderTarget2D) { }

        public virtual object Get() { return null; }

        public virtual void Unlink() { }

        public virtual void Dispose() { }

    }

    #endregion

    #region Managers

    public class BitmapManager : ResourceManager
    {
        private System.Drawing.Bitmap gdiBitmap;
        private Bitmap bitmap;

        public override void Load(object resourceSource)
        {
            gdiBitmap = (System.Drawing.Bitmap)System.Drawing.Image.FromFile((string)resourceSource);
        }

        public override void Link(RenderTarget renderTarget2D)
        {
            bitmap = Static.Operations.LoadBitmapFromGDIBitmap(renderTarget2D, gdiBitmap);
        }

        public override object Get()
        {
            return bitmap;
        }

        public override void Unlink()
        {
            bitmap.Dispose();
        }

        public override void Dispose()
        {
            gdiBitmap.Dispose();
        }

    }

    public class BitmapBrushManager : ResourceManager
    {
        private System.Drawing.Bitmap gdiBitmap;
        private BitmapBrush bitmapBrush;

        public override void Load(object resourceSource)
        {
            gdiBitmap = (System.Drawing.Bitmap)System.Drawing.Image.FromFile((string)resourceSource);
        }

        public override void Link(RenderTarget renderTarget2D)
        {
            bitmapBrush = new BitmapBrush(renderTarget2D, Static.Operations.LoadBitmapFromGDIBitmap(renderTarget2D, gdiBitmap), 
                 new BitmapBrushProperties() { ExtendModeX = ExtendMode.Wrap, ExtendModeY = ExtendMode.Wrap, InterpolationMode = BitmapInterpolationMode.Linear });
        }

        public override object Get()
        {
            return bitmapBrush;
        }

        public override void Unlink()
        {
            bitmapBrush.Dispose();
        }

        public override void Dispose()
        {
            gdiBitmap.Dispose();
        }

    }

    public class SolidColorBrushManager : ResourceManager
    {

        private object color;
        private SolidColorBrush brush;

        public override void Load(object resourceSource)
        {
            color = (Color)resourceSource;
        }

        public override void Link(RenderTarget renderTarget2D)
        {
            brush = new SolidColorBrush(renderTarget2D, (Color)color);
        }

        public override object Get()
        {
            return brush;
        }

        public override void Unlink()
        {
            brush.Dispose();
        }

    }

    public class TextFormatManager : ResourceManager
    {

        private TextFormat format;

        public override void Load(object resourceSource)
        {
            Static.BasicTextFormat bformat = ((Static.BasicTextFormat)resourceSource);
            format = new TextFormat(Static.Operations.textFactory, bformat.Name, bformat.FontWeight, bformat.FontStyle, bformat.FontStretch, bformat.Size);
        }

        public override object Get()
        {
            return format;
        }

        public override void Dispose()
        {
            format.Dispose();
        }

    }

    #endregion

}
