using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VLUTransfer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
              name: "index page",
              url: "Post/Index/{page}",
              defaults: new { controller = "Post", action = "Index", id = UrlParameter.Optional }
             );
            routes.MapRoute(
            name: "User Post",
            url: "user/post/{id}/{page}",
            defaults: new { controller = "Post", action = "UserPost", id = UrlParameter.Optional }
        );

            routes.MapRoute(
            name: "User Register",
            url: "user/register/{id}/{page}",
            defaults: new { controller = "Post", action = "UserRegister", id = UrlParameter.Optional }
        );
            routes.MapRoute(
            name: "Post Register",
            url: "post/register/{id}/{page}",
            defaults: new { controller = "Post", action = "PostRegister", id = UrlParameter.Optional }
        );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
