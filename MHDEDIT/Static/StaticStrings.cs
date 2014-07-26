﻿using System;
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

namespace MHD.Content.Level.Data.Scrips
{

    public class ObjectScript_{%UID%}: MHD.Gameplay.Objects.GameObject
    {

        public string UID = " + "\"{%UID%}\"" + @";

        public ObjectScript_{%UID%}(PathGeometry bounds, float rotation, MHD.Gameplay.Objects.GameObject.ColorInfo color): base(bounds, rotation, color) {}

        public override void Update(TimeSpan totalGameTime, TimeSpan timeSinceLastFrame, MHD.Input.InputProvider inputProvider, Matrix3x2 worldTransform, Matrix3x2 viewTransform)
        {
        
            base.Update(totalGameTime, timeSinceLastFrame, inputProvider, worldTransform, viewTransform);
        }

        public override void Render(RenderTarget renderTarget2D, Matrix3x2 viewTransform)
        {
        
            base.Render(renderTarget2D, viewTransform);
        }

    }

}";

        public static string EmptyLevelScriptCode = @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using MHD;

namespace MHD.Content.Level.Data.Scrips
{

    public class LevelScript: MHD.Content.Level.ILevelScript
    {

    	private MHD.Content.Level.Data.Root data;
    	
        public MHD.Content.Level.Data.Root GetData()
        {
            try
            {
				Assembly assembly = Assembly.GetExecutingAssembly();
				StreamReader streamReader = new StreamReader(assembly.GetManifestResourceStream(" + "\"level.xml.gzip\"" + @"));
				data = MHD.Content.Level.Converter.XMLToData(MHD.Content.Level.Compression.DecompressString(streamReader.ReadToEnd()));
				return data;
            }
            catch
            {
            	data = null;
            }
            return data;
        }
    
        public MHD.Content.Level.Data.Object GetObject(string UID)
        {
            return data.Objects.Find(el => el.UID == UID);
        }

    }

}";

    }
}
