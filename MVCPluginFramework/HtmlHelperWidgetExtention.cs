using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCPluginFramework
{
    public static class HtmlHelperWidgetExtention
    {
         public static IHtmlString Widget(this HtmlHelper htmlHelper, string widgetName)
         {
             MvcPluginHttpApplication app = HttpContext.Current.ApplicationInstance as MvcPluginHttpApplication;
             var widget = app.GetWidgetPlugin(widgetName);
             if (widget == null)
             {
                 return new MvcHtmlString("");
             }

             return widget.GetHtml;
         }
    }
}
