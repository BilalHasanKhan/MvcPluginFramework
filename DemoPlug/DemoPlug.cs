using MVCPluginFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;

namespace PluginSample
{

    [Export(typeof(IControllerPlugin))]
    [ControllerPluginMetadata("DemoPlug","Demo Plugin", "1.0.0.0")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DemoPlug : IControllerPlugin
    {
        private readonly Lazy<IController> _controller = new Lazy<IController>(() => new DemoPlugController());

        public IController Controller
        {
            get { return _controller.Value; }
        }

        public string[] ViewLocations
        {
            get
            {
                return new string[] {"~/Plugins/{1}/{0}.cshtml"};
            }
        }

        public void InitializePlugin()
        {
            throw new NotImplementedException();
        }
    }
    

    public class DemoPlugController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
