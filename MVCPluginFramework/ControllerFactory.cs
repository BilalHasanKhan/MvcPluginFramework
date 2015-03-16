using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Web.SessionState;
using System.Web.Routing;

namespace MVCPluginFramework
{
    class ControllerPluginFactory : IControllerFactory
    {
        private IEnumerable<Lazy<IControllerPlugin, IControllerPluginMetadata>> _controllerPlugins;
        private DefaultControllerFactory _defaultControllerFactory = new DefaultControllerFactory();

        public ControllerPluginFactory(IEnumerable<Lazy<IControllerPlugin, IControllerPluginMetadata>> controllerPlugins)
        {
            _controllerPlugins = controllerPlugins;
        }

        public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            var controllerPlugin = _controllerPlugins.FirstOrDefault(w => w.Metadata.Name == controllerName);

            

            if (controllerPlugin == null)
            {
                return _defaultControllerFactory.CreateController(requestContext, controllerName);
            }

            return controllerPlugin.Value.Controller;
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }

    }
}
