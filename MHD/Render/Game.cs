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

namespace MHD.Render
{

    public class Game : Frame
    {

        #region Private attributes

        private Input.InputProvider inputProvider;
        public Matrix3x2 worldTransform = Matrix3x2.Identity;
        public Matrix3x2 viewTransform = Matrix3x2.Identity;
        private Dictionary<string, Gameplay.UI.Panel> panels = new Dictionary<string, Gameplay.UI.Panel>();
        private Gameplay.UI.Panel activePanel;
        private Gameplay.UI.Cursor cursor;

        #endregion

        #region Content management

        public override void Initialize()
        {
            inputProvider = new Input.InputProvider(RenderWindow);
            cursor = new Gameplay.UI.Cursor();
            cursor.Initialize();
            panels.Add("game", new Gameplay.UI.Panels.GamePanel(this));
            panels.Values.ToList().ForEach(el => el.Initialize());
            activePanel = panels["game"];
            base.Initialize();
        }

        public override void LoadContent()
        {
            cursor.LoadContent();
            panels.Values.ToList().ForEach(el => el.LoadContent());
            base.LoadContent();
        }

        public override void UnloadContent()
        {
            cursor.Dispose();
            panels.Values.ToList().ForEach(el => el.UnloadContent());
            base.UnloadContent();
        }

        public override void LinkContent(RenderTarget renderTarget2D)
        {
            cursor.LinkContent(renderTarget2D);
            panels.Values.ToList().ForEach(el => el.LinkContent(renderTarget2D));
            base.LinkContent(null);
        }

        public override void UnlinkContent()
        {
            cursor.UnlinkContent();
            panels.Values.ToList().ForEach(el => el.UnlinkContent());
            base.UnlinkContent();
        }

        #endregion
        
        #region Gameloop

        public override void Update(TimeSpan totalGameTime, TimeSpan timeSinceLastFrame)
        {
            if (RenderWindow.Focused)
            {
                cursor.Update(totalGameTime, timeSinceLastFrame, inputProvider, worldTransform, viewTransform);
                activePanel.Update(totalGameTime, timeSinceLastFrame, inputProvider, worldTransform, viewTransform);
            }
            base.Update(totalGameTime, timeSinceLastFrame);
        }

        public override void Draw(TimeSpan totalGameTime, TimeSpan timeSinceLastFrame)
        {
            if (RenderWindow.Focused)
            {
                RenderTarget2D.BeginDraw();
                activePanel.Render(RenderTarget2D, viewTransform);
                cursor.Render(RenderTarget2D, viewTransform);
                RenderTarget2D.Flush();
                RenderTarget2D.EndDraw();
            }
            base.Draw(totalGameTime, timeSinceLastFrame);
        }

        #endregion

    }

}
