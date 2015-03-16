using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCPluginFramework
{
    public class MvcPluginHttpApplication : System.Web.HttpApplication
    {
        private string _pluginPath;
        private DirectoryCatalog _catalog;
        private CompositionContainer _container;

        [ImportMany]
        protected Lazy<IControllerPlugin, IControllerPluginMetadata>[] ControllerPlugins = null;

        [ImportMany]
        protected Lazy<IWidgetPlugin,IWidgetPluginMetadata>[] WidgetPlugins = null;

        public IWidgetPlugin GetWidgetPlugin(string name)
        {
            if (!WidgetPlugins.Any())
            {
                return null;
            }

            var wp = WidgetPlugins.FirstOrDefault(w => w.Metadata.Name == name).Value;

            return wp;
        }

        public MvcPluginHttpApplication()
        {
            _pluginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
            this._catalog = new DirectoryCatalog(_pluginPath);
            this._container = new CompositionContainer(_catalog);
            _container.ComposeParts(this);

            ControllerBuilder.Current.SetControllerFactory(new ControllerPluginFactory(ControllerPlugins));
        }

    }
}
