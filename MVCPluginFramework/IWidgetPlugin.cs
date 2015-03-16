using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MVCPluginFramework
{
    public interface IWidgetPlugin
    {
        
        IHtmlString GetHtml { get; }
    }

    public interface IWidgetPluginMetadata
    {
        string Name { get; }
        string Description { get; }
        string Version { get; }
    }

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class)]
    public class WidgetPluginMetadata : ExportAttribute
    {
        public WidgetPluginMetadata(string name, string description, string version)
            : base(typeof(IWidgetPluginMetadata))
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
