#region Using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;
using SharpDX.DirectInput;
using SharpDX.Direct3D11;
using SharpDX.Direct2D1;

#endregion

namespace MHD.Gameplay.Objects
{
    class Player : Geometry.Entity
    {

        #region Private attributes

        private Vector2 virtualPosition;
        private float virtualRotation;
        private Rectangle nose;
        private float velocity;
        private float turningVelocity;

        #endregion

        #region Public properties

        public float Velocity
        {
            get { return velocity; }
        }

        public float TurningVelocity
        {
            get { return turningVelocity; }
        }

        public Vector2 VirtualPosition
        {
            get { return virtualPosition; }
            set { virtualPosition = value; }
        }

        public float VirtualRotation
        {
            get { return virtualRotation; }
            set { virtualRotation = value; }
        }

        #endregion

        public Player()
            : base(-(float)Math.PI / 2)
        {
            Rectangle baseRect = new Rectangle(0, 0, 50, 50);
            Bounds = Geometry.Static.Operations.RectangleToPath(ref baseRect, out translation);
            virtualPosition = new Vector2(0, 0);
            virtualRotation = (float)Math.PI / 2;
            velocity = 0;
            turningVelocity = 0;
            nose = new Rectangle(0, -5, 25, 10);
        }

        #region Gameloop

        public override void Update(TimeSpan totalGameTime, TimeSpan timeSinceLastFrame, Input.InputProvider inputProvider, Matrix3x2 worldTransform, Matrix3x2 viewTransform)
        {
            float accel = 0.003f;
            float breakAccel = 0.0015f;
            float maxVel = 0.3f;
            float moveAmount = 0;
            if (inputProvider.KeyboardState.IsPressed(Key.W) && velocity < maxVel) velocity += accel * (float)timeSinceLastFrame.TotalMilliseconds;
            if (inputProvider.KeyboardState.IsPressed(Key.S) && velocity > -maxVel) velocity -= accel * (float)timeSinceLastFrame.TotalMilliseconds;
            if (velocity > 0)
            {
                velocity -= breakAccel * (float)timeSinceLastFrame.TotalMilliseconds;
                if (velocity < 0) velocity = 0;
            }
            if (velocity < 0)
            {
                velocity += breakAccel * (float)timeSinceLastFrame.TotalMilliseconds;
                if (velocity > 0) velocity = 0;
            }
            moveAmount = velocity * (float)timeSinceLastFrame.TotalMilliseconds;

            float accelTurn = 0.00005f;
            float breakAccelTurn = 0.000025f;
            float maxVelTurn = 0.005f;
            float turnAmount = 0;
            if (inputProvider.KeyboardState.IsPressed(Key.D) && turningVelocity < maxVelTurn) turningVelocity += accelTurn * (float)timeSinceLastFrame.TotalMilliseconds;
            if (inputProvider.KeyboardState.IsPressed(Key.A) && turningVelocity > -maxVelTurn) turningVelocity -= accelTurn * (float)timeSinceLastFrame.TotalMilliseconds;
            if (turningVelocity > 0)
            {
                turningVelocity -= breakAccelTurn * (float)timeSinceLastFrame.TotalMilliseconds;
                if (turningVelocity < 0) turningVelocity = 0;
            }
            if (turningVelocity < 0)
            {
                turningVelocity += breakAccelTurn * (float)timeSinceLastFrame.TotalMilliseconds;
                if (turningVelocity > 0) turningVelocity = 0;
            }
            turnAmount = turningVelocity * (float)timeSinceLastFrame.TotalMilliseconds;

            virtualPosition.X += (float)Math.Cos((double)virtualRotation) * moveAmount;
            virtualPosition.Y += (float)Math.Sin((double)virtualRotation) * moveAmount;
            virtualRotation += turnAmount;

            Translation = new Vector2(0, -20 * velocity);
            Rotation = 20 * turningVelocity - ((float)Math.PI / 2);
            base.Update(totalGameTime, timeSinceLastFrame, inputProvider, worldTransform, viewTransform);
        }

        public override void Render(RenderTarget renderTarget2D, Matrix3x2 viewTransform)
        {
            Matrix3x2 worldTransform = renderTarget2D.Transform;
            renderTarget2D.Transform = DynamicTransform * viewTransform *
                Matrix3x2.Translation(renderTarget2D.Size.Width / 2, renderTarget2D.Size.Height / 2) *
                renderTarget2D.Transform;
            renderTarget2D.FillGeometry(Bounds, (SolidColorBrush)ContentManager.Get("backcolor"));
            renderTarget2D.DrawGeometry(Bounds, (SolidColorBrush)ContentManager.Get("linecolor"), 2);
            renderTarget2D.FillRectangle(nose, (SolidColorBrush)ContentManager.Get("linecolor"));
            renderTarget2D.Transform = worldTransform;
            base.Render(renderTarget2D, viewTransform);
        }

        #endregion

        #region Lifecycle management

        public override void Initialize()
        {
            ContentManager.Add("backcolor", new Color(170, 47, 47, 255), Content.ContentManager.DefaultResourceManagers.ColorToSolidColorBrush);
            ContentManager.Add("linecolor", new Color(220, 220, 220, 255), Content.ContentManager.DefaultResourceManagers.ColorToSolidColorBrush);
            base.Initialize();
        }

        #endregion

    }
}
