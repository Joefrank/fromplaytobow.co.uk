using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace fromplaytobow.co.uk
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "AboutEdit",
              url: "About/{idname}/Edit",
              defaults: new { controller = "Page", action = "EditPageContent", idname = UrlParameter.Optional }
          );

            routes.MapRoute(
               name: "LessonEdit",
               url: "Lesson/{idname}/Edit",
               defaults: new { controller = "Page", action = "EditPageContent", idname = UrlParameter.Optional }
           );

            routes.MapRoute(
                  name: "GradesEdit",
                  url: "Grade/{idname}/Edit",
                  defaults: new { controller = "Page", action = "EditPageContent", idname = UrlParameter.Optional }
              );

            routes.MapRoute(
               name: "ContactEdit",
               url: "Contact/Edit",
               defaults: new { controller = "Page", action = "EditPageContent", idname = "contact" }
           );

            routes.MapRoute(
                  name: "NewsEdit",
                  url: "News/{idname}",
                  defaults: new { controller = "Page", action = "GetPageContent", idname = UrlParameter.Optional }
              );

            routes.MapRoute(
                name: "News",
                url: "News/{idname}/Edit",
                defaults: new { controller = "Page", action = "EditPageContent", idname = UrlParameter.Optional }
            );


            routes.MapRoute(
              name: "Contact",
              url: "Contact",
              defaults: new { controller = "Page", action = "GetPageContent", idname = "contact" }
          );

            routes.MapRoute(
                 name: "About",
                 url: "About/{idname}",
                 defaults: new { controller = "Page", action = "GetPageContent", idname = "contact" }
             );

            routes.MapRoute(
              name: "Lesson",
              url: "Lesson/{idname}",
              defaults: new { controller = "Page", action = "GetPageContent", idname = UrlParameter.Optional }
          );
                       
            routes.MapRoute(
               name: "Grades",
               url: "Grade/{idname}",
               defaults: new { controller = "Page", action = "GetPageContent", idname = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}