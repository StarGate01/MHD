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

namespace MHD
{

    public class Game : Render.Frame
    {

        #region Private attributes

        private Content.Level.Level level;
        private Input.InputProvider inputProvider;
        private Content.ContentManager contentManager;
        private Matrix3x2 worldTransform = Matrix3x2.Identity;
        private float scale = 1;
        private Matrix3x2 viewTransform = Matrix3x2.Identity;
        private List<Geometry.Entity> gameObjects = new List<Geometry.Entity>();
        private Gameplay.UI.Cursor cursor;
        private Gameplay.UI.HUD hud;
        private Gameplay.Objects.Player player;
        //private Gameplay.UI.Button testBtn;
        //private Gameplay.Objects.GameObject testGO;

        #endregion


        #region Content management

        public override void Initialize()
        {
            inputProvider = new Input.InputProvider(RenderWindow);
            contentManager = new Content.ContentManager();

            cursor = new Gameplay.UI.Cursor();
            gameObjects.Add(cursor);
            hud = new Gameplay.UI.HUD();
            gameObjects.Add(hud);
            player = new Gameplay.Objects.Player();
            gameObjects.Add(player);

            level = new Content.Level.Level("C:\\Users\\Christoph\\Desktop\\testlevel.dll");
            gameObjects.AddRange(level.RunableObjects.Values);

            //testBtn = new Gameplay.UI.Button(
            //    "Content\\Image\\menu.png",
            //    new Rectangle(200, 200, 100, 100),
            //    (float)(-Math.PI / 16),
            //    new Color[] { 
            //        Color.LightGray, 
            //        Color.Yellow, 
            //        Color.Orange 
            //    });
            //gameObjects.Add(testBtn);

            //testGO = new Gameplay.Objects.GameObject(
            //    Geometry.Static.Operations.RectangleToPath(new Rectangle(-300, 200, 100, 100)),
            //    (float)Math.PI / 8,
            //    new Gameplay.Objects.GameObject.ColorInfo
            //    {
            //        FillColor = Color.Blue,
            //        StrokeColor = Color.Silver,
            //        StrokeWidth = 3
            //    });
            //gameObjects.Add(testGO);

            gameObjects.ForEach(el => el.Initialize());
            base.Initialize();
        }

        public override void LoadContent()
        {
            contentManager.Add("fps_text", new Content.ResourceManagers.Static.BasicTextFormat() { Name = "Courier New", Size = 24 }, Content.ContentManager.DefaultResourceManagers.BasicTextFormatToTextFormat);
            contentManager.Add("fps_textColor", Color.LightGray, Content.ContentManager.DefaultResourceManagers.ColorToSolidColorBrush);
            contentManager.Add("background_image", "Content\\Image\\background.png", Content.ContentManager.DefaultResourceManagers.StringToBitmapBrush);
            contentManager.LoadAll();
            gameObjects.ForEach(el => el.LoadContent());
            base.LoadContent();
        }

        public override void UnloadContent()
        {
            contentManager.Dispose();
            gameObjects.ForEach(el => el.Dispose());
            base.UnloadContent();
        }

        public override void LinkContent(RenderTarget renderTarget2D)
        {
            contentManager.LinkAll(RenderTarget2D);
            gameObjects.ForEach(el => el.LinkContent(renderTarget2D));
            scale = renderTarget2D.Size.Width / 1300;
            base.LinkContent(null);
        }

        public override void UnlinkContent()
        {
            contentManager.UnlinkAll();
            gameObjects.ForEach(el => el.UnlinkContent());
            base.UnlinkContent();
        }

        #endregion

        #region Gameloop

        public override void Update(TimeSpan totalGameTime, TimeSpan timeSinceLastFrame)
        {
            if (RenderWindow.Focused)
            {

                hud.CenterStrings[0] = player.Velocity.ToString("0.0000");
                hud.CenterStrings[1] = player.TurningVelocity.ToString("0.0000");
                hud.CenterStrings[2] = player.VirtualPosition.X.ToString("0.00");
                hud.CenterStrings[3] = player.VirtualPosition.Y.ToString("0.00");

                viewTransform = Matrix3x2.Scaling(scale);

                #region Key handling

                if (inputProvider.KeyboardState.IsPressed(Key.Up)) scale += (float)timeSinceLastFrame.TotalMilliseconds * 0.001f;
                if (inputProvider.KeyboardState.IsPressed(Key.Down)) scale -= (float)timeSinceLastFrame.TotalMilliseconds * 0.001f;

                if (inputProvider.KeyboardState.IsPressed(Key.F11) && !inputProvider.KeyboardStateOld.IsPressed(Key.F11)) base.ToggleFullscreen();
                if (inputProvider.KeyboardState.IsPressed(Key.Escape) && !inputProvider.KeyboardStateOld.IsPressed(Key.Escape)) Environment.Exit(0);

                //if (testBtn.State.HasFlag(Gameplay.UI.Button.ButtonState.Down) && !testBtn.StateOld.HasFlag(Gameplay.UI.Button.ButtonState.Down)) System.Windows.Forms.MessageBox.Show("ok");

                gameObjects.ForEach(el => el.Update(totalGameTime, timeSinceLastFrame, inputProvider, worldTransform, viewTransform));
                inputProvider.Update();

                #endregion

            }
            base.Update(totalGameTime, timeSinceLastFrame);
        }

        public override void Draw(TimeSpan totalGameTime, TimeSpan timeSinceLastFrame)
        {
            if (RenderWindow.Focused)
            {
                RenderTarget2D.BeginDraw();
                RenderTarget2D.Transform = Matrix3x2.Identity;
                worldTransform = Matrix3x2.Translation(player.VirtualPosition) *
                    Matrix3x2.Rotation(-player.VirtualRotation + ((float)Math.PI / 2)) *
                    Matrix3x2.Translation(RenderTarget2D.Size.Width / 2, RenderTarget2D.Size.Height / 2);
                ((BitmapBrush)contentManager.Get("background_image")).Transform = viewTransform * worldTransform;
                RenderTarget2D.FillRectangle(new Rectangle(0, 0, (int)RenderTarget2D.Size.Width, (int)RenderTarget2D.Size.Height), (BitmapBrush)contentManager.Get("background_image"));
                RenderTarget2D.Transform = worldTransform;
                //testBtn.Render(RenderTarget2D, viewTransform);
                //testGO.Render(RenderTarget2D, viewTransform);
                gameObjects.ForEach(el => el.Render(RenderTarget2D, viewTransform));
                RenderTarget2D.Transform = Matrix3x2.Identity;
                player.Render(RenderTarget2D, viewTransform);
                hud.Render(RenderTarget2D, viewTransform);
                RenderTarget2D.DrawText(timeSinceLastFrame.TotalMilliseconds.ToString() + " ms", (TextFormat)contentManager.Get("fps_text"), new RectangleF(10, 10, 200, 100), (SolidColorBrush)contentManager.Get("fps_textColor"));
                cursor.Render(RenderTarget2D, viewTransform);
                RenderTarget2D.Flush();
                RenderTarget2D.EndDraw();
            }
            base.Draw(totalGameTime, timeSinceLastFrame);
        }

        #endregion

    }

}
