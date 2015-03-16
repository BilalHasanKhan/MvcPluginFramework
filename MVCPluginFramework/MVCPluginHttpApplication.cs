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
