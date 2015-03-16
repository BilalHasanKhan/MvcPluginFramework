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
             var innerTagBuilder = new TagBuilder("li");
             innerTagBuilder.AddCssClass("active");
             innerTagBuilder.InnerHtml = widgetName;

             var tagBuilder = new TagBuilder("ul");
             tagBuilder.AddCssClass("breadcrumb");
             tagBuilder.InnerHtml = innerTagBuilder.ToString(TagRenderMode.Normal);

             return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.Normal)); 
         }
    }
}
