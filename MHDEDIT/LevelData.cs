using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDEDIT.Level
{

    public class Root
    {

        public Meta Meta;
        public Player Player;
        public Object[] Objects;
        public Resource[] Resources;

    }

    public class Meta
    {
        public int Version;
        public string Name;
        public Objective Objective;
    }

    public class Objective
    {
        public Condition Condition;
        public string SuccessMessage;
        public string FailureMessage;
    }

    public class Condition
    {
        public TouchObjectCondition TouchObjectCondition;
        public ScriptCondition ScriptCondition;
    }

    public class TouchObjectCondition
    {
        public bool Enabled;
        public int ObjectUID;
    }

    public class ScriptCondition
    {
        public bool Enabled;
    }

    public class Player
    {
        StartPosition StartPosition;
        float StartRotation;
        float StartEnergy;
    }

    public class StartPosition
    {
        public float X;
        public float Y;
    }

    public class Object
    {

    }

    public class Resource
    {

    }

}
