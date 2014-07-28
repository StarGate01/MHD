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

namespace MHD.Gameplay.Objects
{
    public class GameObject : Geometry.Entity
    {

        public struct ColorInfo
        {
            public Color FillColor;
            public Color StrokeColor;
            public float StrokeWidth;
            public StrokeStyle StrokeStyle;
        }

        #region Attributes

        public readonly ColorInfo InitialColors;

        #endregion

        public GameObject(PathGeometry bounds, float rot, ColorInfo color)
            : base(bounds, rot)
        {
            InitialColors = color;
        }

        #region Gameloop

        public override void Update(TimeSpan totalGameTime, TimeSpan timeSinceLastFrame, Input.InputProvider inputProvider, Matrix3x2 worldTransform, Matrix3x2 viewTransform)
        {
            base.Update(totalGameTime, timeSinceLastFrame, inputProvider, worldTransform, viewTransform);
        }

        public override void Render(RenderTarget renderTarget2D, Matrix3x2 viewTransform)
        {
            Matrix3x2 worldTransform = renderTarget2D.Transform;
            renderTarget2D.Transform = DynamicTransform * viewTransform * worldTransform;
            renderTarget2D.FillGeometry(Bounds, (SolidColorBrush)ContentManager.Get("fillcolor"));
            renderTarget2D.DrawGeometry(Bounds, (SolidColorBrush)ContentManager.Get("strokecolor"), InitialColors.StrokeWidth, InitialColors.StrokeStyle);
            renderTarget2D.Transform = worldTransform;
            base.Render(renderTarget2D, viewTransform);
        }

        #endregion

        #region Lifecycle management

        public override void Initialize()
        {
            ContentManager.Add("fillcolor", InitialColors.FillColor, Content.ContentManager.DefaultResourceManagers.ColorToSolidColorBrush);
            ContentManager.Add("strokecolor", InitialColors.StrokeColor, Content.ContentManager.DefaultResourceManagers.ColorToSolidColorBrush);
            base.Initialize();
        }

        public virtual void RefreshContent(RenderTarget renderTarget2D)
        {
            ContentManager.UnlinkAll();
            ContentManager.Access("fillcolor").Load(InitialColors.FillColor);
            ContentManager.Access("fillcolor").Load(InitialColors.FillColor);
            ContentManager.LinkAll(renderTarget2D);
        }

        #endregion

    }

}
