using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LibraryWebSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Book",
                url: "Books",
                defaults: new { controller = "Book", action = "Book" }
            );
            routes.MapRoute(
                name: "Category",
                url: "Categories",
                defaults: new { controller = "Category", action = "Category" }
            );
            routes.MapRoute(
                name: "Authors",
                url: "Authors",
                defaults: new { controller = "Author", action = "Author"}
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
