using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TestMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Student1",
                url: "AungTest/{action}",
                defaults: new { controller = "Student", action = "Index"}
                );

            routes.MapRoute(
                name: "StudentGetView",
                url: "student/{action}",
                defaults: new { controller = "Student", action = "GetView" }
                );

            routes.MapRoute(
                name: "StudentList",
                url: "student/{action}",
                defaults: new { controller = "Student", action = "getEmployeeList" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
