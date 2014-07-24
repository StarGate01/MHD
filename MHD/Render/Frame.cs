#region Using statements

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using SharpDX;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.Direct2D1;
using SharpDX.DXGI;
using SharpDX.Windows;

using Device = SharpDX.Direct3D11.Device;
using Factory = SharpDX.DXGI.Factory;
using Resource = SharpDX.Direct3D11.Resource;

#endregion

namespace MHD.Render
{

    public abstract class Frame : IDisposable, Content.IResourceusing
    {

        #region  Private attributes

        private RenderForm renderWindow;
        private bool isFullscreen;
        private bool isAutoResizing = false;
        private System.Drawing.Rectangle windowBounds;
        private SwapChain swapChain;
        private Factory factory;
        private Device device;
        private DeviceContext context;
        private Texture2D backBuffer;
        private RenderTargetView renderView;
        private RenderTarget renderTarget2D;
        private TimeSpan lastFrameTime;
        private SwapChainDescription swapChainDescription;

        #endregion

        #region Public properties

        public Device Device
        {
            get
            {
                return device;
            }
        }

        public DeviceContext DeviceContext
        {
            get
            {
                return context;
            }
        }

        public RenderTargetView RenderView
        {
            get
            {
                return renderView;
            }
        }

        public RenderTarget RenderTarget2D
        {
            get
            {
                return renderTarget2D;
            }
            set
            {
                renderTarget2D = value;
            }
        }

        public System.Windows.Forms.Form RenderWindow
        {
            get
            {
                return renderWindow;
            }
        }


        #endregion


        #region Window handling

        public Frame()
        {
            renderWindow = new RenderForm("MHD");
            renderWindow.ClientSize = new System.Drawing.Size(800, 450);
            renderWindow.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            renderWindow.MaximizeBox = false;
            System.Windows.Forms.Cursor.Hide();
            renderWindow.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            renderWindow.SizeChanged += renderWindow_SizeChanged;
            windowBounds = renderWindow.Bounds;
            swapChainDescription = new SwapChainDescription()
            {
                BufferCount = 1,
                ModeDescription = new ModeDescription(renderWindow.ClientSize.Width, renderWindow.ClientSize.Height, new Rational(60, 1), Format.B8G8R8A8_UNorm),
                IsWindowed = true,
                OutputHandle = renderWindow.Handle,
                SampleDescription = new SampleDescription(1, 0),
                SwapEffect = SwapEffect.Discard,
                Usage = Usage.RenderTargetOutput,
            };
            SetupDevice();
        }

        public void renderWindow_SizeChanged(object sender, EventArgs e)
        {
            if (!isAutoResizing)
            {
                UnlinkContent();
                SetupDevice();
                LinkContent(renderTarget2D);
            }
        }

        public void ToggleFullscreen(bool reloadDevice = true)
        {
            isAutoResizing = true;
            isFullscreen = !isFullscreen;
            if (isFullscreen)
            {
                renderWindow.TopMost = true;
                windowBounds = renderWindow.Bounds;
                renderWindow.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                renderWindow.Bounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            }
            else
            {
                renderWindow.TopMost = false;
                renderWindow.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                renderWindow.Bounds = windowBounds;
            }
            renderWindow.BringToFront();
            isAutoResizing = false;
            UnlinkContent();
            SetupDevice();
            LinkContent(renderTarget2D);
        }

        #endregion

        #region Device handling

        private void SetupDevice()
        {
            swapChainDescription.ModeDescription = new ModeDescription(renderWindow.ClientSize.Width, renderWindow.ClientSize.Height, new Rational(60, 1), Format.B8G8R8A8_UNorm);
            Device.CreateWithSwapChain(DriverType.Hardware, DeviceCreationFlags.BgraSupport, swapChainDescription, out device, out swapChain);
            context = device.ImmediateContext;
            using (var surface = Resource.FromSwapChain<Texture2D>(swapChain, 0).QueryInterface<Surface>())
            {
                renderTarget2D = new RenderTarget(Content.ResourceManagers.Static.Operations.factory2D, surface, new RenderTargetProperties(new PixelFormat(Format.Unknown, AlphaMode.Premultiplied)));
            }
            factory = swapChain.GetParent<Factory>();
            factory.MakeWindowAssociation(renderWindow.Handle, WindowAssociationFlags.IgnoreAll);
            backBuffer = Texture2D.FromSwapChain<Texture2D>(swapChain, 0);
            renderView = new RenderTargetView(device, backBuffer);
            context.Rasterizer.SetViewport(0, 0, renderWindow.ClientSize.Width, renderWindow.ClientSize.Height);
            context.OutputMerger.SetTargets(renderView);
        }

        #endregion


        #region Lifecycle management

        #region Content management

        public virtual void Initialize()
        {

        }

        public virtual void LoadContent()
        {
            LinkContent(renderTarget2D);
        }

        public virtual void UnloadContent()
        {
            UnlinkContent();
        }

        public virtual void LinkContent(RenderTarget renderTarget2D)
        {

        }

        public virtual void UnlinkContent()
        {

        }

        #endregion

        public void Run(bool startFullscreen = false)
        {
            var clock = new Stopwatch();
            clock.Start();
            this.lastFrameTime = clock.Elapsed;
            Initialize();
            LoadContent();
            if (startFullscreen) ToggleFullscreen();
            RenderLoop.Run(renderWindow, () =>
            {
                TimeSpan timeSinceLastFrame = clock.Elapsed - this.lastFrameTime;
                this.lastFrameTime = clock.Elapsed;
                Update(clock.Elapsed, timeSinceLastFrame);
                BeginFrame();
                Draw(clock.Elapsed, timeSinceLastFrame);
                EndFrame();
            });
            UnloadContent();
        }

        #region Gameloop

        public virtual void Update(TimeSpan totalGameTime, TimeSpan timeSinceLastFrame)
        {

        }
       
        public virtual void BeginFrame()
        {
            DeviceContext.ClearRenderTargetView(RenderView, Color.Black);
        }

        public virtual void Draw(TimeSpan totalGameTime, TimeSpan timeSinceLastFrame)
        {

        }

        public virtual void EndFrame()
        {
            swapChain.Present(0, PresentFlags.None);
        }

        #endregion

        public void Dispose()
        {
            renderView.Dispose();
            renderTarget2D.Dispose();
            backBuffer.Dispose();
            context.ClearState();
            context.Flush();
            device.Dispose();
            context.Dispose();
            swapChain.Dispose();
            factory.Dispose();
        }

        #endregion

    }

}
