﻿using System.Web.Mvc;
using System.Web.Routing;

namespace PairingTest.Web.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //for asynchronous index action ,change "action=IndexAsync"
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Questionnaire", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}