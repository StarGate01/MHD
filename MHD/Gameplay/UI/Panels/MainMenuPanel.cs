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

        #endregion

        public MainMenuPanel(Render.Game parent)
            : base(parent)
        {
        }

        #region Content management

        public override void Initialize()
        {
            testBtn = new Gameplay.UI.Button(
              new Rectangle(200, 200, 200, 50),
              (float)(-Math.PI / 16),
              "Start game");
            testBtn.Action += testBtn_Action;
            gameObjects.Add(testBtn);
            gameObjects.Add(new Gameplay.UI.Label(
              new Rectangle(600, 200, 500, 50),
              (float)(Math.PI / 16),
              "move-hack-destroy V2.0"));
            base.Initialize();
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
            base.Render(renderTarget2D, viewTransform);
        }

        #endregion

    }
}
