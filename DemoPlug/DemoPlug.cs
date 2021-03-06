﻿using MVCPluginFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using System.Web.Optimization;

namespace PluginSample
{

    [Export(typeof(IControllerPlugin))]
    [ControllerPluginMetadata("DemoPlug","Demo Plugin", "1.0.0.0")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DemoPlug : IControllerPlugin
    {
        public IController Controller
        {
            get { return new DemoPlugController(); }
        }

        public string[] ViewLocations
        {
            get
            {
                return new string[] {"~/Plugins/{1}/{0}.cshtml"};
            }
        }

        public void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/new.css"));
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
