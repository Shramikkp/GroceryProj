using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GroceryPR
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            // NEW ROUTE FOR YOUR AREA
            config.Routes.MapHttpRoute(
                name: "API Area Default",
                routeTemplate: "api/{area}/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
