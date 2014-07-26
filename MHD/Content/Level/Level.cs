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
using MHD.Content.Level.Data;

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

        public static string DataToXML(Root root)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Root));
            StringWriter textWriter = new StringWriter();
            serializer.Serialize(textWriter, root);
            return textWriter.ToString();
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
                if (node.Text != "UID" && !text.EndsWith(".cs")) valueNode.Tag = true;
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

        public static Root XMLToData(string filename, bool isFile = true)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Root));
            if (isFile)
            {
                using (FileStream stream = File.Open(filename, FileMode.OpenOrCreate))
                {
                    return (Root)serializer.Deserialize(stream);
                }
            }
            else
            {
                StringReader textReader = new StringReader(filename); 
                return (Root)serializer.Deserialize(textReader);
            }
        }

    }

    public class Manager
    {

        public Root data;
        public string LevelScript;
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

        public void Update()
        {
            data = (Data.Root)Converter.NodeToData(treeView.Nodes[0].Nodes);
        }

        public void SetInit()
        {
            treeView.CollapseAll();
            treeView.Nodes[0].Nodes[0].EnsureVisible();
            treeView.Nodes[0].Nodes[1].EnsureVisible();
            treeView.Nodes[0].Nodes[2].EnsureVisible();
            treeView.SelectedNode = treeView.Nodes[0];
            treeView.Focus();
        }

    }

}
