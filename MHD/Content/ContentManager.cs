#region Using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.Direct2D1;

#endregion

namespace MHD.Content
{

    public class ContentManager : IDisposable
    {

        public enum DefaultResourceManagers : int
        {
            StringToBitmap,
            StringToBitmapBrush,
            ColorToSolidColorBrush,
            BasicTextFormatToTextFormat
        }

        #region Private attributes

        private Dictionary<string, Tuple<object, Content.ResourceManagers.ResourceManager>> resources = new Dictionary<string, Tuple<object, ResourceManagers.ResourceManager>>();
        private Dictionary<DefaultResourceManagers, Type> defaultResourceManagersAssocs = new Dictionary<DefaultResourceManagers, Type>()
        {
            {DefaultResourceManagers.StringToBitmap, typeof(ResourceManagers.BitmapManager)},
            {DefaultResourceManagers.StringToBitmapBrush, typeof(ResourceManagers.BitmapBrushManager)},
            {DefaultResourceManagers.ColorToSolidColorBrush, typeof(ResourceManagers.SolidColorBrushManager)},
            {DefaultResourceManagers.BasicTextFormatToTextFormat, typeof(ResourceManagers.TextFormatManager)}
        };

        #endregion

        #region Lifecycle management

        public void AddCustom(string name, object source, ResourceManagers.ResourceManager resourceManager)
        {
            if (!resources.ContainsKey(name))
            {
                resources.Add(name, new Tuple<object, Content.ResourceManagers.ResourceManager>(source, resourceManager));
            }
            else throw new InvalidOperationException();
        }

        public void Add(string name, object source, DefaultResourceManagers defaultResourceManager) 
        {
            if (!resources.ContainsKey(name))
            {
                if (Enum.IsDefined(typeof(DefaultResourceManagers), defaultResourceManager))
                {
                    resources.Add(name, new Tuple<object, Content.ResourceManagers.ResourceManager>(source, (Content.ResourceManagers.ResourceManager)Activator.CreateInstance(defaultResourceManagersAssocs[defaultResourceManager])));
                }
                else throw new IndexOutOfRangeException();
            }
            else throw new InvalidOperationException();
        }

        public void LoadAll()
        {
            foreach (KeyValuePair<string, Tuple<object, Content.ResourceManagers.ResourceManager>> resourceToLoad in resources)
            {
                resourceToLoad.Value.Item2.Load(resourceToLoad.Value.Item1);
            }
        }

        public void UnloadAll()
        {
            foreach (KeyValuePair<string, Tuple<object, Content.ResourceManagers.ResourceManager>> resourceToLoad in resources)
            {
               resourceToLoad.Value.Item2.Dispose();
            }
        }

        public void LinkAll(RenderTarget renderTarget2D)
        {
            foreach (KeyValuePair<string, Tuple<object, Content.ResourceManagers.ResourceManager>> resourceToLoad in resources)
            {
               resourceToLoad.Value.Item2.Link(renderTarget2D);
            }
        }

        public void UnlinkAll()
        {
            foreach (KeyValuePair<string, Tuple<object, Content.ResourceManagers.ResourceManager>> resourceToLoad in resources)
            {
                resourceToLoad.Value.Item2.Unlink();
            }
        }

        public object Get(string name)
        {
            return resources[name].Item2.Get();
        }

        public ResourceManagers.ResourceManager Access(string name)
        {
            return resources[name].Item2;
        }

        public void Dispose()
        {
            UnloadAll();
        }

        #endregion

    }

}
