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
using System.IO.Compression;
using System.Resources;

#endregion

namespace MHD.Content.Level
{


    public class Level
    {

        public Data.Root Data;
        public Dictionary<string, Gameplay.Objects.GameObject> RunableObjects = new Dictionary<string,Gameplay.Objects.GameObject>();
        public ILevelScript LevelScript;

        public Level(string filename)
        {
            Assembly levelAsm = Assembly.LoadFile(filename);
            ResourceReader reader = new ResourceReader(levelAsm.GetManifestResourceStream("resources.resx"));
            byte[] compressedData = new byte[0];
            string compressedDataType = "";
            reader.GetResourceData("level.xml.gzip", out compressedDataType, out compressedData);
            int gzipOffset = 0;
            for (int i = 0; i < compressedData.Length; i++) if (compressedData[i] == 31 && compressedData[i + 1] == 139 && compressedData[i + 2] == 8) { gzipOffset = i; break; }
            Data = Converter.XMLToData(Encoding.UTF8.GetString(Compression.Decompress(compressedData.Skip(gzipOffset).ToArray())), false);
            foreach(Type type in levelAsm.GetTypes())
            {
                if (type.Name == "LevelScript")
                {
                    LevelScript = (Content.Level.ILevelScript)Activator.CreateInstance(type);
                }
                else
                {
                    string uid = type.Name.Substring(13).Replace('_', '-');
                    Content.Level.Data.Object obj = Data.Objects.First(el => el.UID == uid);
                    Gameplay.Objects.GameObject runableObject = (Gameplay.Objects.GameObject)Activator.CreateInstance(type, new object[] {
                        Geometry.Static.Operations.PointsToPath(obj.Geometry.Points.Select<Content.Level.Data.Point, SharpDX.Point>(el => new SharpDX.Point((int)el.X, (int)el.Y)).ToArray()),
                        obj.StartRotation,
                        new Gameplay.Objects.GameObject.ColorInfo() { 
                            FillColor = new SharpDX.Color(obj.Geometry.FillColor.R, obj.Geometry.FillColor.G, obj.Geometry.FillColor.B, obj.Geometry.FillColor.A),
                            StrokeColor = new SharpDX.Color(obj.Geometry.StrokeColor.R, obj.Geometry.StrokeColor.G, obj.Geometry.StrokeColor.B, obj.Geometry.StrokeColor.A),
                            StrokeWidth = obj.Geometry.StrokeWidth,
                        },
                    });
                    runableObject.translation = new Vector2(obj.StartPosition.X, obj.StartPosition.Y);
                    RunableObjects.Add(obj.UID, runableObject);
                }
            }
        }

    }

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
            string fieldName = objType.Name;
            bool value = false;
            if (rootInfo != null && !bool.TryParse(rootInfo.ToString(), out value)) fieldName = ((FieldInfo)rootInfo).Name;
            TreeNode node;
            if (!objType.IsPrimitive && !objType.Equals(typeof(string)))
            {
                if (rootInfo != null)
                {
                    if (objType.Equals(typeof(Player))) { node = new TreeNode(fieldName, 4, 4); }
                    else if (objType.IsGenericType && objType.GetGenericTypeDefinition() == typeof(List<>))
                    {
                        Type itemType = objType.GetGenericArguments()[0];
                        Type constructedListType = typeof(List<>).MakeGenericType(itemType);
                        IList listInstance = (IList)Activator.CreateInstance(constructedListType, new object[] { obj });
                        node = new TreeNode(fieldName, 0, 1);
                        foreach (object obj2 in listInstance)
                        {
                            node.Nodes.Add(DataToNode(obj2, true));
                        }
                        return node;
                    }
                    else { node = new TreeNode(fieldName, 3, 3); }
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
                if (bool.TryParse(rootInfo.ToString(), out value) && value)
                {
                    node = new TreeNode(obj.ToString(), 7, 7);
                }
                else
                {
                    node = new TreeNode(fieldName, 3, 3);
                    string text = obj.ToString();
                    int imageIndex = 7;
                    if (text.EndsWith(".cs")) imageIndex = 9;
                    TreeNode valueNode = new TreeNode(text, imageIndex, imageIndex);
                    if (node.Text != "UID" && !text.EndsWith(".cs")) valueNode.Tag = true;
                    node.Nodes.Add(valueNode);
                }
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
                    if (!itemType.IsPrimitive && !itemType.Equals(typeof(string)))
                    {
                        ((IList)data).Add(NodeToData(node.Nodes, Activator.CreateInstance(itemType)));
                    }
                    else
                    {
                         ((IList)data).Add(Convert.ChangeType((object)node.Text, itemType));
                    }
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
        public Dictionary<string, string> ObjectScripts;
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
            treeView.Nodes[0].Nodes[2].Expand();
            treeView.SelectedNode = treeView.Nodes[0];
            treeView.Focus();
        }

    }

    public class Compression
    {

        public static byte[] Compress(byte[] buffer)
        {
            MemoryStream memoryStream = new MemoryStream();
            using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
            {
                gZipStream.Write(buffer, 0, buffer.Length);
            }
            memoryStream.Position = 0;
            byte[] compressedData = new byte[memoryStream.Length];
            memoryStream.Read(compressedData, 0, compressedData.Length);
            byte[] gZipBuffer = new byte[compressedData.Length + 4];
            Buffer.BlockCopy(compressedData, 0, gZipBuffer, 4, compressedData.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gZipBuffer, 0, 4);
            return gZipBuffer;
        }


        public static byte[] Decompress(byte[] gZipBuffer)
        {
            using (var memoryStream = new MemoryStream())
            {
                int dataLength = BitConverter.ToInt32(gZipBuffer, 0);
                memoryStream.Write(gZipBuffer, 0, gZipBuffer.Length);
                byte[] buffer = new byte[dataLength];
                memoryStream.Position = 0;
                using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                {
                    gZipStream.Read(buffer, 0, buffer.Length);
                }
                return buffer;
            }
        }

    }

}
