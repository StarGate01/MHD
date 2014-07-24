#region Using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.Direct2D1;
using SharpDX.DXGI;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

#endregion

namespace MHD.Content.ResourceManagers.Static
{

    public class BasicTextFormat
    {

        public string Name;
        public float Size;
        public SharpDX.DirectWrite.FontWeight FontWeight = SharpDX.DirectWrite.FontWeight.Normal;
        public SharpDX.DirectWrite.FontStyle FontStyle = SharpDX.DirectWrite.FontStyle.Normal;
        public SharpDX.DirectWrite.FontStretch FontStretch = SharpDX.DirectWrite.FontStretch.Normal;

    }

    class Operations
    {

        #region Geometry handling

        public static SharpDX.Direct2D1.Factory factory2D = new SharpDX.Direct2D1.Factory();

        #endregion

        #region Bitmap handling

        public static Bitmap LoadBitmapFromGDIBitmap(RenderTarget renderTarget, System.Drawing.Bitmap gdiBitmap)
        {
            var sourceArea = new System.Drawing.Rectangle(0, 0, gdiBitmap.Width, gdiBitmap.Height);
            var bitmapProperties = new BitmapProperties(new SharpDX.Direct2D1.PixelFormat(Format.R8G8B8A8_UNorm, AlphaMode.Premultiplied));
            var size = new System.Drawing.Size(gdiBitmap.Width, gdiBitmap.Height);
            int stride = gdiBitmap.Width * sizeof(int);
            using (var tempStream = new DataStream(gdiBitmap.Height * stride, true, true))
            {
                var bitmapData = gdiBitmap.LockBits(sourceArea, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                for (int y = 0; y < gdiBitmap.Height; y++)
                {
                    int offset = bitmapData.Stride * y;
                    for (int x = 0; x < gdiBitmap.Width; x++)
                    {
                        byte B = Marshal.ReadByte(bitmapData.Scan0, offset++);
                        byte G = Marshal.ReadByte(bitmapData.Scan0, offset++);
                        byte R = Marshal.ReadByte(bitmapData.Scan0, offset++);
                        byte A = Marshal.ReadByte(bitmapData.Scan0, offset++);
                        int rgba = R | (G << 8) | (B << 16) | (A << 24);
                        tempStream.Write(rgba);
                    }
                }
                gdiBitmap.UnlockBits(bitmapData);
                tempStream.Position = 0;
                return new Bitmap(renderTarget, new SharpDX.Size2(size.Width, size.Height), tempStream, stride, bitmapProperties);
            }
        }

        #endregion

        #region Text handling

        public static SharpDX.DirectWrite.Factory textFactory = new SharpDX.DirectWrite.Factory();

        #endregion

    }

    class DefaultColors
    {

        public static Color UIgreen = new Color(87, 255, 0, 255);

    }

}
