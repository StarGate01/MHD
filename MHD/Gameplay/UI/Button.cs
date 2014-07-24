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

    class Button : Geometry.Entity
    {

        [Flags]
        public enum ButtonState
        {
            Nothing = 0,
            Hover = 1,
            Down = 2
        }

        #region Private attributes

        private string bitmapPath;
        private Color backColor;
        private Color hoverColor;
        private Color activeColor;
        private ButtonState state;
        private ButtonState stateOld;

        #endregion

        #region Public properties

        public ButtonState State
        {
            get { return state; }
        }

        public ButtonState StateOld
        {
            get { return stateOld; }
        }

        #endregion

        public Button(string path, Rectangle bounds, float rotation, Color[] colors)
            : base(rotation)
        {
            Bounds = Geometry.Static.Operations.RectangleToPath(ref bounds, out translation);
            bitmapPath = path;
            backColor = colors[0];
            hoverColor = colors[1];
            activeColor = colors[2];
            state = stateOld = ButtonState.Nothing;
        }

        public override void Initialize()
        {
            ContentManager.Add("image", bitmapPath, Content.ContentManager.DefaultResourceManagers.StringToBitmap);
            ContentManager.Add("backcolor", backColor, Content.ContentManager.DefaultResourceManagers.ColorToSolidColorBrush);
            ContentManager.Add("hovercolor", hoverColor, Content.ContentManager.DefaultResourceManagers.ColorToSolidColorBrush);
            ContentManager.Add("activecolor", activeColor, Content.ContentManager.DefaultResourceManagers.ColorToSolidColorBrush);
            base.Initialize();
        }

        public override void Update(TimeSpan totalGameTime, TimeSpan timeSinceLastFrame, Input.InputProvider inputProvider, Matrix3x2 worldTransform, Matrix3x2 viewTransform)
        {
            stateOld = state;
            if (Bounds.FillContainsPoint(inputProvider.MousePositionAbsolute, DynamicTransform * viewTransform * worldTransform, Bounds.FlatteningTolerance))
            {
                state |= ButtonState.Hover;
                if(inputProvider.MouseState.Buttons[0])
                {
                    state |= ButtonState.Down;
                }
                else
                {
                    state &= ~ButtonState.Down;
                }
            }
            else
            {
                state &= ~ButtonState.Hover;
                state &= ~ButtonState.Down;
            }
            base.Update(totalGameTime, timeSinceLastFrame, inputProvider, worldTransform, viewTransform);
        }

        public override void Render(RenderTarget renderTarget2D, Matrix3x2 viewTransform)
        {
            Matrix3x2 worldTransform = renderTarget2D.Transform;
            renderTarget2D.Transform = DynamicTransform * viewTransform * worldTransform;
            if(state.HasFlag(ButtonState.Hover))
            {
                if (state.HasFlag(ButtonState.Down))
                {
                    renderTarget2D.FillGeometry(Bounds, (SolidColorBrush)ContentManager.Get("activecolor"));
                }
                else
                {
                    renderTarget2D.FillGeometry(Bounds, (SolidColorBrush)ContentManager.Get("hovercolor"));
                }
            }
            else
            {
                renderTarget2D.FillGeometry(Bounds, (SolidColorBrush)ContentManager.Get("backcolor"));
            }
            renderTarget2D.DrawBitmap((Bitmap)ContentManager.Get("image"), Bounds.GetBounds(), 1.0f, BitmapInterpolationMode.Linear, null);
            renderTarget2D.Transform = worldTransform;
            base.Render(renderTarget2D, viewTransform);
        }

    }

}
