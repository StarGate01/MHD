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

namespace MHD.Geometry
{

    public class Entity : Render.IRenderable, Content.IResourceusing, IDisposable
    {

        #region Attributes

        private Content.ContentManager contentManager;
        private float rotation = 0;
        public Vector2 translation = new Vector2(0, 0);
        private PathGeometry bounds;

        #endregion

        #region Properties

        public PathGeometry Bounds
        {
            get { return bounds; }
            set { bounds = value; }
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public Vector2 Translation
        {
            get { return translation; }
            set { translation = value; }
        }

        public Matrix3x2 DynamicTransform
        {
            get { return Matrix3x2.Rotation(rotation) * Matrix3x2.Translation(translation); }
        }

        public Content.ContentManager ContentManager
        {
            get { return contentManager; }
        }

        #endregion

        public Entity(PathGeometry bnds, float rot)
        {
            bounds = bnds;
            rotation = rot;
            contentManager = new Content.ContentManager();
        }
        public Entity(float rot)
            : this(new PathGeometry(Content.ResourceManagers.Static.Operations.factory2D), rot)
        {
        }
        public Entity()
            : this(0)
        {
        }

        #region Gameloop

        public virtual void Update(TimeSpan totalGameTime, TimeSpan timeSinceLastFrame, Input.InputProvider inputProvider, Matrix3x2 worldTransform, Matrix3x2 viewTransform)
        {
        }

        public virtual void Render(RenderTarget renderTarget2D, Matrix3x2 viewTransform)
        {
        }

        #endregion

        #region Lifecycle management

        public virtual void Initialize()
        {
        }

        public virtual void LoadContent()
        {
            contentManager.LoadAll();
        }

        public virtual void UnloadContent()
        {
            contentManager.UnloadAll();
        }

        public virtual void LinkContent(RenderTarget renderTarget2D)
        {
            contentManager.LinkAll(renderTarget2D);
        }

        public virtual void UnlinkContent()
        {
            contentManager.UnlinkAll();
        }

        public virtual void Dispose()
        {
            contentManager.Dispose();
        }

        #endregion

    }

}
