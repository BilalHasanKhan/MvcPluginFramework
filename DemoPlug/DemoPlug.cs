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
        private readonly IController _controller = new DemoPlugController();

        public IController Controller
        {
            get { return _controller; }
        }

        public string[] ViewLocations
        {
            get { throw new NotImplementedException(); }
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
