#region Using statements

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MHDEDIT.Util;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.SharpDevelop.Dom;

#endregion

namespace MHDEDIT.Compile
{

    public class ScriptFile
    {

        #region private Attributes

        private static Dictionary<string, IProjectContent> m_standardReferences;
        private ObservableCollection<string> m_referencedAssemblies;
        private string m_scriptContent;
        private ProjectContentRegistry m_contentRegistry;
        private IFilterStrategy m_filterStrategy;
        private IProjectContent m_projectContent;
        private TextDocument m_codeDocument;

        #endregion

        #region Public properties

        public ObservableCollection<string> ReferencedAssemblies
        {
            get { return m_referencedAssemblies; }
        }

        public string ScriptContent
        {
            get { return m_codeDocument.Text; }
            set
            {
                m_scriptContent = value;
                m_codeDocument = new TextDocument(new StringTextSource(m_scriptContent));
            }
        }

        public IFilterStrategy FilterStrategy
        {
            get { return m_filterStrategy; }
        }

        public IProjectContent ProjectContent
        {
            get { return m_projectContent; }
        }

        public TextDocument CodeDocument
        {
            get { return m_codeDocument; }
        }

        #endregion

        public ScriptFile(string text)
        {
            m_standardReferences = new Dictionary<string, IProjectContent>();
            m_contentRegistry = new ProjectContentRegistry();
            m_filterStrategy = new NonFilterStrategy();
            m_projectContent = new DefaultProjectContent();
            m_referencedAssemblies = new ObservableCollection<string>();
            m_referencedAssemblies.CollectionChanged += OnReferencedAssembliesCollectionChanged;
            //m_referencedAssemblies.Add("mscorlib.dll");
            //m_referencedAssemblies.Add("Microsoft.CSharp.dll");
            //m_referencedAssemblies.Add("System.dll");
            //m_referencedAssemblies.Add("System.Core.dll");
            //m_referencedAssemblies.Add("System.Data.dll");
            //m_referencedAssemblies.Add("System.Linq.dll");
            //m_referencedAssemblies.Add("System.Reflection.dll");
            //m_referencedAssemblies.Add("System.IO.dll");
            //m_referencedAssemblies.Add("SharpDX.dll");
            //m_referencedAssemblies.Add("SharpDX.Direct3D11.dll");
            //m_referencedAssemblies.Add("SharpDX.Direct2D1.dll");
            //m_referencedAssemblies.Add("SharpDX.DirectInput.dll"); 
            //m_referencedAssemblies.Add("MHD.exe");
            ScriptContent = text;
        }

        private static IProjectContent ParseReferencedAssembly(string assemblyName, ProjectContentRegistry registry)
        {
            try
            {
                assemblyName = Path.GetFileNameWithoutExtension(assemblyName);
                foreach (Assembly actAssembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    if (actAssembly.GetName().Name == assemblyName)
                    {
                        IProjectContent result = registry.GetProjectContentForReference(assemblyName, actAssembly.Location);
                        return result;
                    }
                }
                Assembly loadedAssembly = Assembly.Load(assemblyName);
                if (loadedAssembly != null) return registry.GetProjectContentForReference(assemblyName, loadedAssembly.Location);
            }
            catch { return null; }
            return null;
        }

        private async void OnReferencedAssembliesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if ((e.NewItems != null) && (e.NewItems.Count > 0))
            {
                foreach (string actNewItem in e.NewItems)
                {
                    if (!m_standardReferences.ContainsKey(actNewItem))
                    {
                        string asyncLoadedContentName = actNewItem;
                        IProjectContent asyncLoadedContent = await Task.Factory.StartNew<IProjectContent>(() =>
                        {
                            return ParseReferencedAssembly(asyncLoadedContentName, m_contentRegistry);
                        });
                        if (asyncLoadedContent != null)
                        {
                            m_standardReferences[asyncLoadedContentName] = asyncLoadedContent;
                            m_projectContent.AddReferencedContent(asyncLoadedContent);
                        }
                    }
                }
            }
        }

    }

}
