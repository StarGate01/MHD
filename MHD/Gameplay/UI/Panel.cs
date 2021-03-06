﻿#region Using statements

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
    public class Panel : Content.IResourceusing, Render.IRenderable
    {

        #region Attributes

        public Content.ContentManager contentManager;
        public List<Geometry.Entity> gameObjects = new List<Geometry.Entity>();
        public Render.Game ParentGame;

        #endregion

        #region Lifecycle management

        public Panel(Render.Game parent)
        {
            ParentGame = parent;
            contentManager = new Content.ContentManager();
        }

        public virtual void Initialize()
        {
            gameObjects.ForEach(el => el.Initialize());
        }

        public virtual void LoadContent()
        {
            contentManager.LoadAll();
            gameObjects.ForEach(el => el.LoadContent());
        }

        public virtual void UnloadContent()
        {
            contentManager.Dispose();
            gameObjects.ForEach(el => el.Dispose());
        }

        public virtual void LinkContent(RenderTarget renderTarget2D)
        {
            contentManager.LinkAll(renderTarget2D);
            gameObjects.ForEach(el => el.LinkContent(renderTarget2D));
        }

        public virtual void UnlinkContent()
        {
            contentManager.UnlinkAll();
            gameObjects.ForEach(el => el.UnlinkContent());
        }

        #endregion

        #region Gameloop

        public virtual void Update(TimeSpan totalGameTime, TimeSpan timeSinceLastFrame, Input.InputProvider inputProvider, ref Matrix3x2 viewTransform)
        {
            if (inputProvider.KeyboardState.IsPressed(Key.F11) && !inputProvider.KeyboardStateOld.IsPressed(Key.F11)) ParentGame.ToggleFullscreen();
            foreach (Geometry.Entity obj in gameObjects)
            {
                obj.Update(totalGameTime, timeSinceLastFrame, inputProvider, ref viewTransform);
            }
        }

        public virtual void Render(RenderTarget renderTarget2D, Matrix3x2 viewTransform)
        {
            foreach (Geometry.Entity obj in gameObjects)
            {
                obj.Render(renderTarget2D, viewTransform);
            }
        }

        #endregion

    }
}
