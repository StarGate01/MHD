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
    public class Cursor : Geometry.Entity
    {

        private float offsetAdd = 0;
        private float offsetCounter = 0;
        private bool wasDown = false;
        private StrokeStyle lineStyle;

        #region Gameloop

        public Cursor()
            : base()
        {
            lineStyle = new StrokeStyle(
                Content.ResourceManagers.Static.Operations.factory2D, new StrokeStyleProperties() { 
                    StartCap = CapStyle.Triangle, 
                    EndCap = CapStyle.Triangle });
        }

        public override void Update(TimeSpan totalGameTime, TimeSpan timeSinceLastFrame, Input.InputProvider inputProvider, ref Matrix3x2 viewTransform)
        {
            Rotation = (float)totalGameTime.TotalMilliseconds / 1000;
            if (inputProvider.MouseState.Buttons[0])
            {
                if (offsetAdd > 0) offsetAdd -= 0.09f * (float)timeSinceLastFrame.TotalMilliseconds;
                wasDown = true;
            }
            else
            {
                if (wasDown)
                {
                    if (offsetAdd < 10)
                    {
                        offsetAdd += 0.09f * (float)timeSinceLastFrame.TotalMilliseconds;
                    }
                    else
                    {
                        wasDown = false;
                        offsetCounter = 250 * (float)Math.PI;
                    }
                }
                else
                {
                    offsetAdd = ((float)Math.Sin(offsetCounter / 500) + 1) * 5;
                    offsetCounter += (float)timeSinceLastFrame.TotalMilliseconds;
                }
            }

            Translation = inputProvider.MousePositionAbsolute;
            base.Update(totalGameTime, timeSinceLastFrame, inputProvider, ref viewTransform);
        }

        public override void Render(RenderTarget renderTarget2D, Matrix3x2 viewTransform)
        {
            Matrix3x2 oldTransform = renderTarget2D.Transform;
            renderTarget2D.Transform = DynamicTransform;
            for (int i = 0; i < 3; i++)
            {
                renderRotatedLine(Vector2.Zero, 20 + offsetAdd, 5 + offsetAdd, (float)(Math.PI * 2 * i) / 3, renderTarget2D, (SolidColorBrush)ContentManager.Get("color"));
            }
            renderTarget2D.FillEllipse(new Ellipse(Vector2.Zero, 2, 2), (SolidColorBrush)ContentManager.Get("color"));
            renderTarget2D.Transform = oldTransform;
            base.Render(renderTarget2D, viewTransform);
        }

        private void renderRotatedLine(Vector2 position, float length, float offset, float angle, RenderTarget renderTarget2D, SolidColorBrush brush)
        {
            renderTarget2D.DrawLine(
                new Vector2(
                    (float)Math.Cos(angle) * offset,
                    (float)Math.Sin(angle) * offset),
                new Vector2(
                    (float)Math.Cos(angle) * length,
                    (float)Math.Sin(angle) * length),
                brush, 2, lineStyle);
        }

        #endregion

        #region Lifecycle management

        public override void Initialize()
        {
            ContentManager.Add("color", DefaultColors.UIgreen, Content.ContentManager.DefaultResourceManagers.ColorToSolidColorBrush);
            base.Initialize();
        }

        #endregion

    }
}
