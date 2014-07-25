#region Using statements

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using System.Linq.Expressions;
using System.Diagnostics;
using SharpDX;
using SharpDX.Direct2D1;

#endregion

namespace MHD.Content.Level
{

    public class Converter
    {

        public static void DataToXML(Root root, string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Root));
            using (FileStream stream = File.Create(filename))
            {
                serializer.Serialize(stream, root);
            }
        }

        public static TreeNode DataToNode(object obj, object rootInfo = null)
        {
            Type objType = obj.GetType();
            TreeNode node;
            if (!objType.IsPrimitive && !objType.Equals(typeof(string)))
            {
                if (rootInfo != null)
                {
                    if (objType.Equals(typeof(Player))) { node = new TreeNode(objType.Name, 4, 4); }
                    else if (objType.IsGenericType && objType.GetGenericTypeDefinition() == typeof(List<>))
                    {
                        Type itemType = objType.GetGenericArguments()[0];
                        Type constructedListType = typeof(List<>).MakeGenericType(itemType);
                        IList listInstance = (IList)Activator.CreateInstance(constructedListType, new object[] { obj });
                        node = new TreeNode(((FieldInfo)rootInfo).Name, 0, 1);
                        foreach (object obj2 in listInstance)
                        {
                            node.Nodes.Add(DataToNode(obj2, true));
                        }
                        return node;
                    }
                    else { node = new TreeNode(objType.Name, 3, 3); }
                }
                else node = new TreeNode("Level", 2, 2);
                foreach (FieldInfo info in objType.GetFields())
                {
                    FieldInfo childProperty = objType.GetField(info.Name);
                    object childValue = childProperty.GetValue(obj);
                    node.Nodes.Add(DataToNode(childValue, childProperty));
                }
            }
            else
            {
                node = new TreeNode(((FieldInfo)rootInfo).Name, 3, 3);
                string text = obj.ToString();
                int imageIndex = 7;
                if (text.EndsWith(".cs")) imageIndex = 9;
                TreeNode valueNode = new TreeNode(text, imageIndex, imageIndex);
                if (node.Text != "UID") valueNode.Tag = true;
                node.Nodes.Add(valueNode);
            }
            return node;
        }

        public static object NodeToData(TreeNodeCollection nodes, object data = null)
        {
            if (data == null) data = new Root();
            Type dataType = data.GetType();
            if (dataType.IsGenericType && dataType.GetGenericTypeDefinition() == typeof(List<>))
            {
                Type itemType = dataType.GetGenericArguments()[0];
                foreach (TreeNode node in nodes)
                {
                    ((IList)data).Add(NodeToData(node.Nodes, Activator.CreateInstance(itemType)));
                }
                return data;
            }
            foreach (TreeNode node in nodes)
            {
                FieldInfo field = data.GetType().GetField(node.Text);
                if (!field.FieldType.IsPrimitive && !field.FieldType.Equals(typeof(string)))
                {
                    field.SetValue(data, NodeToData(node.Nodes, field.GetValue(data)));
                }
                else
                {
                    try
                    {
                        field.SetValue(data, Convert.ChangeType(node.Nodes[0].Text, field.FieldType));
                    }
                    catch (FormatException)
                    {
                        throw new Exception("Wrong format at " + node.Nodes[0].FullPath + Environment.NewLine + "Must be of type " + field.FieldType.Name.ToString());
                    }
                }
            }
            return data;
        }

        public static Root XMLToData(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Root));
            using (FileStream stream = File.Open(filename, FileMode.OpenOrCreate))
            {
                return (Root)serializer.Deserialize(stream);
            }
        }

    }

    public class Manager
    {

        public Root data;
        private TreeView treeView;

        public Manager(ref TreeView view)
        {
            treeView = view;
        }

        public void Refresh()
        {
            treeView.SuspendLayout();
            treeView.Nodes.Clear();
            treeView.Nodes.Add(Converter.DataToNode(data));
            treeView.ResumeLayout();
        }

    }

    #region Data classes

    public class Root
    {
        public Meta Meta = new Meta();
        public Player Player = new Player();
        public List<Object> Objects = new List<Object>();
    }

    public class Meta
    {
        public int Version = 1;
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
        public string Name = "object";
        public StartPosition StartPosition = new StartPosition();
        public float StartRotation = 0;
        public string Script = "script.cs";
        public Geometry Geometry = new Geometry();
    }

    public class Geometry
    {
        public List<System.Drawing.Point> Points = new List<System.Drawing.Point>();
    }

    #endregion

}
