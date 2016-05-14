using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Reveries
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
            routes.MapRoute("Home", "", new { Controller = "Home", Action = "Index" });
            routes.MapRoute("User", "Profile/{username}", new { Controller = "User", Action = "Index", username = UrlParameter.Optional });
            routes.MapRoute("Login", "Login", new { Controller = "User", Action = "Login" });
            routes.MapRoute("Logout", "Logout", new { Controller = "User", Action = "Logout" });
            routes.MapRoute("Register", "Register", new { Controller = "User", Action = "Register" });
            routes.MapRoute("Search", "Search", new { Controller = "Home", Action = "Search" });
            routes.MapRoute("SearchCards", "SearchCards", new { Controller = "Home", Action = "SearchCards" });
            routes.MapRoute("UserReveries", "UserReveries", new { Controller = "User", Action = "UserReveries" });
            routes.MapRoute("EditProfile", "EditProfile", new { Controller = "User", Action = "EditProfile" });
            routes.MapRoute("HomeReveries", "HomeReveries", new { Controller = "Home", Action = "HomeReveries" });
            routes.MapRoute("AddComment", "AddComment", new { Controller = "Reveries", Action = "AddComment" });
            routes.MapRoute("DeleteComment", "DeleteComment", new { Controller = "Reveries", Action = "DeleteComment" });
            routes.MapRoute("EditComment", "EditComment", new { Controller = "Reveries", Action = "EditComment" });
            routes.MapRoute("EditReverie", "EditReverie", new { Controller = "Reveries", Action = "EditReverie" });
            routes.MapRoute("DeleteReverie", "DeleteReverie", new { Controller = "Reveries", Action = "DeleteReverie" });
            routes.MapRoute("RegisterComplete", "RegisterComplete", new { Controller = "User", Action = "RegisterComplete" });
            routes.MapRoute("Follow", "Follow", new { Controller = "Reveries", Action = "Follow" });
            routes.MapRoute("unFollow", "unFollow", new { Controller = "Reveries", Action = "unFollow" });
            routes.MapRoute("Like", "Like", new { Controller = "Reveries", Action = "Like" });
            routes.MapRoute("Unlike", "Unlike", new { Controller = "Reveries", Action = "Unlike" });
        }
    }
}
