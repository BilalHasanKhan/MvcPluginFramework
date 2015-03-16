using MVCPluginFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DemoWidget
{
    [Export(typeof(IWidgetPlugin))]
    [WidgetPluginMetadata("DemoWidget","Demo Widget","1.0.0.0")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DemoWidget: IWidgetPlugin
    {
        public IHtmlString GetHtml
        {
            get
            {
                var innerTagBuilder = new TagBuilder("li");
                innerTagBuilder.AddCssClass("active");
                innerTagBuilder.InnerHtml = "Hello";

                var tagBuilder = new TagBuilder("ul");
                tagBuilder.AddCssClass("breadcrumb");
                tagBuilder.InnerHtml = innerTagBuilder.ToString(TagRenderMode.Normal);

                return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.Normal)); 
            }
        }
    }
}
