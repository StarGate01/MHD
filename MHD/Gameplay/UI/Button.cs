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
        public enum ButtonEventType
        {
            Up,
            Down,
            Enter,
            Leave
        }

        public class ButtonEventArgs : EventArgs
        {
            public ButtonEventType Type;
        }
        public delegate void ButtonHandler(Button sender, ButtonEventArgs e);
        public event ButtonHandler Action;

        #region Private attributes

        private string bitmapPath;
        private string text;
        private Content.ResourceManagers.Static.BasicTextFormat textFormat;
        private Color strokeColor;
        private float strokeWidth;
        private Color backColor;
        private Color hoverColor;
        private Color activeColor;
        private Color textColor;
        private bool useDefaultRenderer;
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

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        #endregion

        public Button(Rectangle bounds, float rotation, Color[] colors, float strokew, string text, Content.ResourceManagers.Static.BasicTextFormat textFormat, Color textColor)
            : this(null, bounds, rotation, colors, strokew, text, textFormat, textColor)
        {
        }

        public Button(Rectangle bounds, float rotation, string text)
            : this(bounds, rotation, null, 0, text, null, new Color())
        {
        }

        public Button(string path, Rectangle bounds, float rotation, Color[] colors, float strokew, string etext, Content.ResourceManagers.Static.BasicTextFormat etextFormat, Color etextColor)
            : base(rotation)
        {
            Bounds = Geometry.Static.Operations.RectangleToPath(ref bounds, out translation);
            text = etext;
            if (colors != null)
            {
                useDefaultRenderer = false;
                backColor = colors[0];
                hoverColor = colors[1];
                activeColor = colors[2];
                textColor = etextColor;
                strokeColor = colors[3];
                strokeWidth = strokew;
                textFormat = etextFormat;
                bitmapPath = path;
            }
            else
            {
                useDefaultRenderer = true;
                backColor = Content.ResourceManagers.Static.DefaultColors.UI.Background;
                hoverColor = Content.ResourceManagers.Static.DefaultColors.UI.BackgroundHover;
                activeColor = Content.ResourceManagers.Static.DefaultColors.UI.BackgroundHover;
                textColor = Content.ResourceManagers.Static.DefaultColors.UI.Text;
                strokeColor = Content.ResourceManagers.Static.DefaultColors.UI.Text;
                strokeWidth = 3;
                bitmapPath = path;
                textFormat = new Content.ResourceManagers.Static.BasicTextFormat()
                {
                    Name = "Courier New",
                    Size = 20
                };
            }
            state = stateOld = ButtonState.Nothing;
        }

        public override void Initialize()
        {
            if (bitmapPath != null) ContentManager.Add("image", bitmapPath, Content.ContentManager.DefaultResourceManagers.StringToBitmap);
            ContentManager.Add("backcolor", backColor, Content.ContentManager.DefaultResourceManagers.ColorToSolidColorBrush);
            ContentManager.Add("hovercolor", hoverColor, Content.ContentManager.DefaultResourceManagers.ColorToSolidColorBrush);
            ContentManager.Add("activecolor", activeColor, Content.ContentManager.DefaultResourceManagers.ColorToSolidColorBrush);
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

        public override void Update(TimeSpan totalGameTime, TimeSpan timeSinceLastFrame, Input.InputProvider inputProvider, ref Matrix3x2 viewTransform)
        {
            stateOld = state;
            if (Bounds.FillContainsPoint(inputProvider.MousePositionAbsolute, DynamicTransform * viewTransform, Bounds.FlatteningTolerance))
            {
                state |= ButtonState.Hover;
                if (inputProvider.MouseState.Buttons[0])
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
            base.Update(totalGameTime, timeSinceLastFrame, inputProvider, ref viewTransform);
            if (Action != null)
            {
                if (!stateOld.HasFlag(ButtonState.Down) && state.HasFlag(ButtonState.Down)) Action(this, new ButtonEventArgs() { Type = ButtonEventType.Down });
                if (stateOld.HasFlag(ButtonState.Down) && !state.HasFlag(ButtonState.Down)) Action(this, new ButtonEventArgs() { Type = ButtonEventType.Up });
                if (!stateOld.HasFlag(ButtonState.Hover) && state.HasFlag(ButtonState.Hover)) Action(this, new ButtonEventArgs() { Type = ButtonEventType.Enter });
                if (stateOld.HasFlag(ButtonState.Hover) && !state.HasFlag(ButtonState.Hover)) Action(this, new ButtonEventArgs() { Type = ButtonEventType.Leave });
            }
        }

        public override void Render(RenderTarget renderTarget2D, Matrix3x2 viewTransform)
        {
            Matrix3x2 oldTransform = renderTarget2D.Transform;
            renderTarget2D.Transform = DynamicTransform * viewTransform;
            if (state.HasFlag(ButtonState.Hover))
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
            renderTarget2D.DrawGeometry(Bounds, (SolidColorBrush)ContentManager.Get("strokecolor"), strokeWidth);
            if (bitmapPath != null) renderTarget2D.DrawBitmap((Bitmap)ContentManager.Get("image"), Bounds.GetBounds(), 1.0f, BitmapInterpolationMode.Linear, null);
            renderTarget2D.DrawText(text, (TextFormat)ContentManager.Get("textformat"), Bounds.GetBounds(), (SolidColorBrush)ContentManager.Get("textcolor"), DrawTextOptions.Clip);
            renderTarget2D.Transform = oldTransform;
            base.Render(renderTarget2D, viewTransform);
        }

    }

}
