﻿using System.Web.Mvc;
using System.Web.Routing;

namespace UniversalShopingApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Contact", action = "FirstPage", id = UrlParameter.Optional }
            );
        }
    }
}
