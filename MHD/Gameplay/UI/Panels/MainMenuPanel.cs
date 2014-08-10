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

namespace MHD.Gameplay.UI.Panels
{
    class MainMenuPanel : Panel
    {

        #region Private attributes

        private Gameplay.UI.Button testBtn;
        private float scale = 1;

        #endregion

        public MainMenuPanel(Render.Game parent)
            : base(parent)
        {
        }

        #region Content management

        public override void Initialize()
        {
            contentManager.Add("background_image", "Content\\Image\\background_dark.png", Content.ContentManager.DefaultResourceManagers.StringToBitmapBrush);
            testBtn = new Gameplay.UI.Button(
              new Rectangle(200, 200, 200, 50),
              (float)(-Math.PI / 16),
              "Start game", 
              30);
            testBtn.Action += testBtn_Action;
            gameObjects.Add(testBtn);
            gameObjects.Add(new Gameplay.UI.Label(
              new Rectangle(600, 200, 500, 50),
              (float)(Math.PI / 16),
              "move-hack-destroy V2.0",
              20));
            base.Initialize();
        }

        public override void LinkContent(RenderTarget renderTarget2D)
        {
            scale = renderTarget2D.Size.Width / 1300;
            base.LinkContent(renderTarget2D);
        }

        #endregion

        #region Button events

        void testBtn_Action(Gameplay.UI.Button sender, Gameplay.UI.Button.ButtonEventArgs e)
        {
            if (e.Type == Button.ButtonEventType.Down) ParentGame.activePanel = ParentGame.panels["game"];
        }

        #endregion

        #region Gameloop

        public override void Update(TimeSpan totalGameTime, TimeSpan timeSinceLastFrame, Input.InputProvider inputProvider, ref Matrix3x2 viewTransform)
        {
            viewTransform = Matrix3x2.Identity;
            if (inputProvider.KeyboardState.IsPressed(Key.Escape) && !inputProvider.KeyboardStateOld.IsPressed(Key.Escape)) Environment.Exit(0);

            foreach (Geometry.Entity obj in gameObjects)
            {
                obj.Update(totalGameTime, timeSinceLastFrame, inputProvider, ref viewTransform);
            }
            inputProvider.Update();
            base.Update(totalGameTime, timeSinceLastFrame, inputProvider, ref viewTransform);
        }

        public override void Render(RenderTarget renderTarget2D, Matrix3x2 viewTransform)
        {
            renderTarget2D.Transform = Matrix3x2.Identity;
            ((BitmapBrush)contentManager.Get("background_image")).Transform = Matrix3x2.Scaling(scale);
            renderTarget2D.FillRectangle(new Rectangle(0, 0, (int)renderTarget2D.Size.Width, (int)renderTarget2D.Size.Height), (BitmapBrush)contentManager.Get("background_image"));
            base.Render(renderTarget2D, Matrix3x2.Identity);
        }

        #endregion

    }
}
