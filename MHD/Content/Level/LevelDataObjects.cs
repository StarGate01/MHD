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
        public string ObjectUID = "guid";
    }

    public class ScriptCondition
    {
        public bool Enabled = false;
        public string Script = "level.cs";
    }

    public class Player
    {
        public Point StartPosition = new Point();
        public float StartRotation = 0;
        public float StartEnergy = 1;
    }

    public class Point
    {
        public float X = 0;
        public float Y = 0;
    }

    public class Object
    {
        public string UID = Guid.NewGuid().ToString();
        public Point StartPosition = new Point();
        public float StartRotation = 0;
        public string Script = "";
        public Geometry Geometry = new Geometry();
    }

    public class Geometry
    {
        public Color FillColor = new Color();
        public Color StrokeColor = new Color();
        public float StrokeWidth = 1;
        public List<Point> Points = new List<Point>();
    }

    public class Color
    {
        public byte R = 255;
        public byte G = 255;
        public byte B = 255;
        public byte A = 255;
    }

}
