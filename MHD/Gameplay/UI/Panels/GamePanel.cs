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
    class GamePanel : Panel
    {

        #region Private attributes

        private Content.Level.Level level;
        private float scale = 1;
        private Gameplay.UI.HUD hud;
        private Gameplay.Objects.Player player;
        private Gameplay.UI.Button testBtn;
        private float FPS = 0;

        #endregion

        public GamePanel(Render.Game parent)
            : base(parent)
        {
        }

        #region Content management

        public override void Initialize()
        {
            contentManager.Add("fps_text", new Content.ResourceManagers.Static.BasicTextFormat() { Name = "Courier New", Size = 24 }, Content.ContentManager.DefaultResourceManagers.BasicTextFormatToTextFormat);
            contentManager.Add("fps_textColor", Color.LightGray, Content.ContentManager.DefaultResourceManagers.ColorToSolidColorBrush);
            contentManager.Add("background_image", "Content\\Image\\background.png", Content.ContentManager.DefaultResourceManagers.StringToBitmapBrush);

            hud = new Gameplay.UI.HUD();
            player = new Gameplay.Objects.Player();

            testBtn = new Gameplay.UI.Button(
                new Rectangle(200, 200, 100, 100),
                (float)(-Math.PI / 16),
                new Color[] { 
                    Color.LightGray, 
                    Color.Yellow, 
                    Color.Orange 
                },
                "TEST",
                new Content.ResourceManagers.Static.BasicTextFormat()
                {
                    Name = "Arial",
                    Size = 20
                },
                Color.Silver);
            testBtn.Action += testBtn_Action;
            gameObjects.Add(testBtn);

            level = new Content.Level.Level("C:\\Users\\Christoph\\Desktop\\level.dll");
            gameObjects.AddRange(level.RunableObjects.Values);

            player.Initialize();
            hud.Initialize();
            base.Initialize();
        }

        public override void LoadContent()
        {
            player.LoadContent();
            hud.LoadContent();
            base.LoadContent();
        }

        public override void UnloadContent()
        {
            player.Dispose();
            hud.Dispose();
            base.UnloadContent();
        }

        public override void LinkContent(RenderTarget renderTarget2D)
        {
            player.LinkContent(renderTarget2D);
            hud.LinkContent(renderTarget2D);
            scale = renderTarget2D.Size.Width / 1300;
            base.LinkContent(renderTarget2D);
        }

        public override void UnlinkContent()
        {
            player.UnlinkContent();
            hud.UnlinkContent();
            base.UnlinkContent();
        }

        #endregion

        #region Button events

        void testBtn_Action(Gameplay.UI.Button sender, Gameplay.UI.Button.ButtonEventArgs e)
        {
            if (e.Type == Gameplay.UI.Button.ButtonEventType.Down) System.Windows.Forms.MessageBox.Show("OK");
        }

        #endregion

        #region Gameloop

        public override void Update(TimeSpan totalGameTime, TimeSpan timeSinceLastFrame, Input.InputProvider inputProvider, Matrix3x2 worldTransform, Matrix3x2 viewTransform)
        {
            hud.CenterStrings[0] = player.Velocity.ToString("0.0000");
            hud.CenterStrings[1] = player.TurningVelocity.ToString("0.0000");
            hud.CenterStrings[2] = player.VirtualPosition.X.ToString("0.00");
            hud.CenterStrings[3] = player.VirtualPosition.Y.ToString("0.00");

            viewTransform = Matrix3x2.Scaling(scale);
            FPS = (float)timeSinceLastFrame.TotalMilliseconds;

            #region Key handling

            if (inputProvider.KeyboardState.IsPressed(Key.F11) && !inputProvider.KeyboardStateOld.IsPressed(Key.F11)) ParentGame.ToggleFullscreen();
            if (inputProvider.KeyboardState.IsPressed(Key.Escape) && !inputProvider.KeyboardStateOld.IsPressed(Key.Escape)) Environment.Exit(0);

            player.Update(totalGameTime, timeSinceLastFrame, inputProvider, worldTransform, viewTransform);
            hud.Update(totalGameTime, timeSinceLastFrame, inputProvider, worldTransform, viewTransform);
            foreach (Geometry.Entity obj in gameObjects)
            {
                obj.Update(totalGameTime, timeSinceLastFrame, inputProvider, worldTransform, viewTransform);
            }
            inputProvider.Update();

            #endregion

            base.Update(totalGameTime, timeSinceLastFrame, inputProvider, worldTransform, viewTransform);
        }

        public override void Render(RenderTarget renderTarget2D, Matrix3x2 viewTransform)
        {
            ParentGame.worldTransform = Matrix3x2.Translation(player.VirtualPosition) *
                Matrix3x2.Rotation(-player.VirtualRotation + ((float)Math.PI / 2)) *
                Matrix3x2.Translation(renderTarget2D.Size.Width / 2, renderTarget2D.Size.Height / 2);
            ((BitmapBrush)contentManager.Get("background_image")).Transform = viewTransform * ParentGame.worldTransform;
            renderTarget2D.FillRectangle(new Rectangle(0, 0, (int)renderTarget2D.Size.Width, (int)renderTarget2D.Size.Height), (BitmapBrush)contentManager.Get("background_image"));
            renderTarget2D.Transform = ParentGame.worldTransform;
            base.Render(renderTarget2D, viewTransform);
            renderTarget2D.Transform = Matrix3x2.Identity;
            player.Render(renderTarget2D, viewTransform);
            hud.Render(renderTarget2D, viewTransform);
            renderTarget2D.DrawText(FPS + " ms", (TextFormat)contentManager.Get("fps_text"), new RectangleF(10, 10, 200, 100), (SolidColorBrush)contentManager.Get("fps_textColor"));
        }

        #endregion

    }
}
