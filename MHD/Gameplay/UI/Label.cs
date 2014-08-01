#region Using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.Direct2D1;
using SharpDX.DirectInput;
using SharpDX.DirectWrite;

#endregion

namespace MHD.Gameplay.UI
{

    class Label : Geometry.Entity
    {

        #region Private attributes

        private string bitmapPath;
        private string text;
        private Content.ResourceManagers.Static.BasicTextFormat textFormat;
        private Color strokeColor;
        private float strokeWidth;
        private Color backColor;
        private Color textColor;
        private bool useDefaultRenderer;

        #endregion

        #region Public properties

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        #endregion

        public Label(Rectangle bounds, float rotation, Color[] colors, float strokew, string text, Content.ResourceManagers.Static.BasicTextFormat textFormat, Color textColor)
            : this(null, bounds, rotation, colors, strokew, text, textFormat, textColor)
        {
        }

        public Label(Rectangle bounds, float rotation, string text)
            : this(bounds, rotation, null, 0, text, null, new Color())
        {
        }

        public Label(string path, Rectangle bounds, float rotation, Color[] colors, float strokew, string etext, Content.ResourceManagers.Static.BasicTextFormat etextFormat, Color etextColor)
            : base(rotation)
        {
            Bounds = Geometry.Static.Operations.RectangleToPath(ref bounds, out translation);
            text = etext;
            if (colors != null)
            {
                useDefaultRenderer = false;
                backColor = colors[0];
                textColor = etextColor;
                strokeColor = colors[1];
                strokeWidth = strokew;
                textFormat = etextFormat;
                bitmapPath = path;
            }
            else
            {
                useDefaultRenderer = true;
                backColor = Color.Transparent;
                textColor = Content.ResourceManagers.Static.DefaultColors.UI.Text;
                strokeColor = Color.Transparent;
                strokeWidth = 0;
                bitmapPath = path;
                textFormat = new Content.ResourceManagers.Static.BasicTextFormat()
                {
                    Name = "Courier New",
                    Size = 20
                };
            }
        }

        public override void Initialize()
        {
            if (bitmapPath != null) ContentManager.Add("image", bitmapPath, Content.ContentManager.DefaultResourceManagers.StringToBitmap);
            ContentManager.Add("backcolor", backColor, Content.ContentManager.DefaultResourceManagers.ColorToSolidColorBrush);
            ContentManager.Add("textcolor", textColor, Content.ContentManager.DefaultResourceManagers.ColorToSolidColorBrush);
            ContentManager.Add("strokecolor", strokeColor, Content.ContentManager.DefaultResourceManagers.ColorToSolidColorBrush);
            ContentManager.Add("textformat", textFormat, Content.ContentManager.DefaultResourceManagers.BasicTextFormatToTextFormat);
            base.Initialize();
        }

        public override void LinkContent(RenderTarget renderTarget2D)
        {
            base.LinkContent(renderTarget2D);
            ((TextFormat)ContentManager.Get("textformat")).ParagraphAlignment = ParagraphAlignment.Center;
            ((TextFormat)ContentManager.Get("textformat")).TextAlignment = SharpDX.DirectWrite.TextAlignment.Center;
        }

        public override void Render(RenderTarget renderTarget2D, Matrix3x2 viewTransform)
        {
            Matrix3x2 oldTransform = renderTarget2D.Transform;
            renderTarget2D.Transform = DynamicTransform * viewTransform;
            renderTarget2D.FillGeometry(Bounds, (SolidColorBrush)ContentManager.Get("backcolor"));
            renderTarget2D.DrawGeometry(Bounds, (SolidColorBrush)ContentManager.Get("strokecolor"), strokeWidth);
            if (bitmapPath != null) renderTarget2D.DrawBitmap((Bitmap)ContentManager.Get("image"), Bounds.GetBounds(), 1.0f, BitmapInterpolationMode.Linear, null);
            renderTarget2D.DrawText(text, (TextFormat)ContentManager.Get("textformat"), Bounds.GetBounds(), (SolidColorBrush)ContentManager.Get("textcolor"), DrawTextOptions.Clip);
            renderTarget2D.Transform = oldTransform;
            base.Render(renderTarget2D, viewTransform);
        }

    }

}
