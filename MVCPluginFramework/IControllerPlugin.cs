using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Optimization;

namespace MVCPluginFramework
{
    public interface IControllerPlugin
    {
        IController Controller { get; }
        string[] ViewLocations { get; }

        void RegisterBundles(BundleCollection bundles);
        void InitializePlugin();
    }

    public interface IControllerPluginMetadata
    {
        string Name { get;}
        string Description { get;}
        string Version { get; }
    }

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class)]
    public class ControllerPluginMetadata : ExportAttribute
    {
        public ControllerPluginMetadata(string name, string description, string version) : base (typeof(IControllerPluginMetadata))
        {
            Name = name;
            Description = description;
            Version = version;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Version { get; private set; }

    }
}
