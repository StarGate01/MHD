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
using DefaultColors = MHD.Content.ResourceManagers.Static.DefaultColors;

#endregion

namespace MHD.Gameplay.UI
{

    public class HUD : Geometry.Entity
    {

        private String[] centerStrings = new String[4] { "", "", "", "" };

        public String[] CenterStrings
        {
            get { return centerStrings; }
            set { centerStrings = value; }
        }

        public HUD()
            : base()
        {
            Translation = new Vector2(0.5f, 0.5f);
        }

        #region Gameloop

        public override void Update(TimeSpan totalGameTime, TimeSpan timeSinceLastFrame, Input.InputProvider inputProvider, ref Matrix3x2 viewTransform)
        {

            base.Update(totalGameTime, timeSinceLastFrame, inputProvider, ref viewTransform);
        }

        public override void Render(RenderTarget renderTarget2D, Matrix3x2 viewTransform)
        {
            Matrix3x2 oldTransform = renderTarget2D.Transform;
            renderTarget2D.Transform = DynamicTransform * viewTransform *
              Matrix3x2.Translation(renderTarget2D.Size.Width / 2, renderTarget2D.Size.Height / 2);
            TextFormat format = (TextFormat)ContentManager.Get("text_inner");
            SolidColorBrush color = (SolidColorBrush)ContentManager.Get("color");
            renderTarget2D.DrawEllipse(new Ellipse(Vector2.Zero, 120, 120), color);
            renderTarget2D.DrawRectangle(new Rectangle(-70, -70, 140, 140), color);
            renderTarget2D.DrawLine(new Vector2(-100, 0), new Vector2(100, 0), color);
            renderTarget2D.DrawLine(new Vector2(0, -100), new Vector2(0, 100), color);
            format.TextAlignment = SharpDX.DirectWrite.TextAlignment.Trailing;
            renderTarget2D.DrawText(centerStrings[0], format, new Rectangle(-50, -82, 48, 14), color);
            renderTarget2D.DrawText(centerStrings[2], format, new Rectangle(-50, 72, 48, 14), color);
            format.TextAlignment = SharpDX.DirectWrite.TextAlignment.Leading;
            renderTarget2D.DrawText(centerStrings[1], format, new Rectangle(3, -82, 48, 14), color);
            renderTarget2D.DrawText(centerStrings[3], format, new Rectangle(3, 72, 48, 14), color);
            renderTarget2D.Transform = oldTransform;
            base.Render(renderTarget2D, viewTransform);
        }

        #endregion

        #region Lifecycle management

        public override void Initialize()
        {
            ContentManager.Add("text_inner", new Content.ResourceManagers.Static.BasicTextFormat() { Name = "Courier New", Size = 10, FontWeight = FontWeight.Light }, Content.ContentManager.DefaultResourceManagers.BasicTextFormatToTextFormat);
            ContentManager.Add("color", DefaultColors.UI.Text, Content.ContentManager.DefaultResourceManagers.ColorToSolidColorBrush);
            base.Initialize();
        }

        public override void LinkContent(RenderTarget renderTarget2D)
        {
            base.LinkContent(renderTarget2D);
            ((TextFormat)ContentManager.Get("text_inner")).ParagraphAlignment = ParagraphAlignment.Near;
        }

        #endregion

    }

}
