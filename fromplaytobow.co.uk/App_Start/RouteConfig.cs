using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Utils;

namespace fromplaytobow.co.uk
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
         
            routes.MapRouteWithName(
              "AboutEdit",
              "About/{idname}/Edit",
              new { controller = "Page", action = "EditPageContent", idname = UrlParameter.Optional },
              null
            );

            routes.MapRouteWithName(
               "LessonEdit",
                "Lesson/{idname}/Edit",
               new { controller = "Page", action = "EditPageContent", idname = UrlParameter.Optional },
               null
           );

            routes.MapRouteWithName(
                  "GradesEdit",
                   "Grade/{idname}/Edit",
                   new { controller = "Page", action = "EditPageContent", idname = UrlParameter.Optional },
                    null
              );

            routes.MapRouteWithName(
               "ContactEdit",
                "Contact/Edit",
                new { controller = "Page", action = "EditPageContent", idname = "contact" },
               null
           );

            routes.MapRouteWithName(
                  "NewsEdit",
                   "News/{idname}",
                   new { controller = "Page", action = "GetPageContent", idname = UrlParameter.Optional },
               null
              );

            routes.MapRouteWithName(
                "News",
                 "News/{idname}/Edit",
                 new { controller = "Page", action = "EditPageContent", idname = UrlParameter.Optional },
               null
            );


            routes.MapRouteWithName(
              "Contact",
               "Contact",
               new { controller = "Page", action = "GetPageContent", idname = "contact" },
               null
          );

            routes.MapRouteWithName(
                 "About",
                  "About/{idname}",
                  new { controller = "Page", action = "GetPageContent", idname = "contact" },
               null
             );

            routes.MapRouteWithName(
              "Lesson",
               "Lesson/{idname}",
               new { controller = "Page", action = "GetPageContent", idname = UrlParameter.Optional },
               null
          );
                       
            routes.MapRouteWithName(
               "Grades",
                "Grade/{idname}",
                new { controller = "Page", action = "GetPageContent", idname = UrlParameter.Optional },
               null
           );

            routes.MapRouteWithName(
                "Default",
                 "{controller}/{action}/{id}",
                 new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               null
            );
        }
    }
}