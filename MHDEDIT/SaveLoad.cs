using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace MHDEDIT
{

    public class SaveLoad
    {

        private static StreamWriter sr;

        public static void Save(TreeView treeView, string filename)
        {
            sr = new StreamWriter(filename, false, System.Text.Encoding.UTF8);
            sr.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            sr.WriteLine("<" + treeView.Nodes[0].Text + ">");
            foreach (TreeNode node in treeView.Nodes) saveNode(node.Nodes);
            sr.WriteLine("</" + treeView.Nodes[0].Text + ">");
            sr.Close();
        }

        private static void saveNode(TreeNodeCollection tnc)
        {
            foreach (TreeNode node in tnc)
            {
                if (node.Nodes.Count > 0)
                {
                    sr.WriteLine("<" + node.Text + ">");
                    saveNode(node.Nodes);
                    sr.WriteLine("</" + node.Text + ">");
                }
                else
                {
                    if (node.Name == "Objects") sr.WriteLine("<Objects>empty</Objects>");
                    else sr.WriteLine(System.Net.WebUtility.UrlEncode(node.Text));
                }
            }
        }

        public static void Load(ref TreeView treeView, string filename)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filename);
            treeView.Nodes.Clear();
            treeView.Nodes.Add(new TreeNode(xDoc.DocumentElement.Name));
            TreeNode tNode = new TreeNode();
            tNode = (TreeNode)treeView.Nodes[0];
            tNode.ImageIndex = 2;
            tNode.SelectedImageIndex = 2;
            addTreeNode(xDoc.DocumentElement, tNode);
            treeView.ExpandAll();
        }

        private static void addTreeNode(XmlNode xmlNode, TreeNode treeNode)
        {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList xNodeList;
            if (xmlNode.HasChildNodes)
            {
                xNodeList = xmlNode.ChildNodes;
                for (int x = 0; x <= xNodeList.Count - 1; x++)
                {
                    xNode = xmlNode.ChildNodes[x];
                    treeNode.Nodes.Add(new TreeNode(xNode.Name));
                    tNode = treeNode.Nodes[x];
                    tNode.ImageIndex = 3;
                    tNode.SelectedImageIndex = 3;
                    if (xNode.Name == ("Player")) { tNode.ImageIndex = 4; tNode.SelectedImageIndex = 4; }
                    if (xNode.Name == ("Objective")) { tNode.ImageIndex = 5; tNode.SelectedImageIndex = 5; }
                    if (xNode.Name == ("Objects")) { tNode.ImageIndex = 0; tNode.SelectedImageIndex = 1; }
                    addTreeNode(xNode, tNode);
                }
            }
            else
            {
                treeNode.Text = xmlNode.OuterXml.Trim();
                if (treeNode.Text == "placeholder") treeNode.Name = treeNode.Text;
                treeNode.ImageIndex = 7;
                treeNode.SelectedImageIndex = 7;
            }
        }

    }

}
