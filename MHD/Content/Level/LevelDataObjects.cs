using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MHD.Content.Level.Data
{

    public class Root
    {
        public Meta Meta = new Meta();
        public Player Player = new Player();
        public List<Object> Objects = new List<Object>();
    }

    public class Meta
    {
        public int Version = 1;
        public List<string> References = new List<string>();
        public string Name = "level";
        public Objective Objective = new Objective();
    }

    public class Objective
    {
        public Condition Condition = new Condition();
        public string SuccessMessage = "success";
        public string FailureMessage = "failure";
    }

    public class Condition
    {
        public TouchObjectCondition TouchObjectCondition = new TouchObjectCondition();
        public ScriptCondition ScriptCondition = new ScriptCondition();
    }

    public class TouchObjectCondition
    {
        public bool Enabled = true;
        public string ObjectUID = "";
    }

    public class ScriptCondition
    {
        public bool Enabled = true;
        public string Script = "level.cs";
    }

    public class Player
    {
        public StartPosition StartPosition = new StartPosition();
        public float StartRotation = 0;
        public float StartEnergy = 1;
    }

    public class StartPosition
    {
        public float X = 0;
        public float Y = 0;
    }

    public class Object
    {
        public string UID = Guid.NewGuid().ToString();
        public StartPosition StartPosition = new StartPosition();
        public float StartRotation = 0;
        public string Script = "";
        public Geometry Geometry = new Geometry();
    }

    public class Geometry
    {
        public Color FillColor = new Color();
        public Color StrokeColor = new Color();
        public int StrokeWidth = 1;
        public List<System.Drawing.PointF> Points = new List<System.Drawing.PointF>();
    }

    public class Color
    {
        public byte R = 0;
        public byte G = 0;
        public byte B = 0;
        public byte A = 255;
    }

}
