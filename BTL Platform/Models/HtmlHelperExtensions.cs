using Microsoft.AspNetCore.Mvc.Rendering;

namespace BTL_Platform.Models
{
    public static class HtmlHelperExtensions
    {
        public static string ActiveClass(this IHtmlHelper htmlHelper, string route)
        {
            var routeData = htmlHelper.ViewContext.RouteData;
            
            var pageRoute = routeData.Values["page"];

            return route == pageRoute ? "active" : "";
        }
    }
}
