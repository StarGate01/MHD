using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDEDIT.Static
{
    class StaticStrings
    {

        public static string EmptyObjectScriptCode = @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.Direct2D1;
using SharpDX.DirectInput;
using SharpDX.DirectWrite;
using MHD;

public class ObjectScript_{%UID%}: MHD.Gameplay.Objects.GameObject
{

    public ObjectScript(PathGeometry bounds, float rotation, MHD.Gameplay.Objects.GameObject.ColorInfo color): base(bounds, rotation, color) {}

    public void Update(TimeSpan totalGameTime, TimeSpan timeSinceLastFrame, MHD.Input.InputProvider inputProvider, Matrix3x2 worldTransform, Matrix3x2 viewTransform)
    {
        
        base.Update(totalGameTime, timeSinceLastFrame, inputProvider, worldTransform, viewTransform);
    }

    public void Render(RenderTarget renderTarget2D, Matrix3x2 viewTransform)
    {
        
        base.Render(renderTarget2D, viewTransform);
    }

}";

        public static string EmptyLevelScriptCode = @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MHD;

public class LevelScript: MHD.Content.Level.ILevelScript
{

    public MHD.Content.Level.Data.Root GetData()
    {
        
    }
    
    public MHD.Gameplay.Objects.GameObject GetObject(string UID)
    {
        
    }

}";

    }
}
