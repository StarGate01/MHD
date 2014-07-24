#region Using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.Direct2D1;

#endregion

namespace MHD.Content
{

    public interface IResourceusing
    {

        void Initialize();

        void LoadContent();

        void UnloadContent();

        void LinkContent(RenderTarget renderTarget2D);

        void UnlinkContent();

    }
}
