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
               name: "GradesEdit",
               url: "Grade/{idname}/Edit",
               defaults: new { controller = "Page", action = "EditPageContent", pagename = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Grades",
               url: "Grade/{idname}",
               defaults: new { controller = "Page", action = "GetPageContent", pagename = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "News",
              url: "News/{pagename}",
              defaults: new { controller = "Page", action = "GetNewsContent", pagename= UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "NewsEdit",
              url: "News/{pagename}/Edit",
              defaults: new { controller = "Page", action = "EditPageContent", pagename = UrlParameter.Optional }
            );

           routes.MapRoute(
             name: "AboutUs",
             url: "About/{pagename}",
             defaults: new { controller = "Page", action = "GetPageContent", pagename = UrlParameter.Optional }
         );

            routes.MapRoute(
            name: "AboutUsEdit",
            url: "About/{pagename}/Edit",
            defaults: new { controller = "Page", action = "EditPageContent", pagename = UrlParameter.Optional }
        );

            routes.MapRoute(
            name: "Musicianship",
            url: "Musicianship/{pagename}",
            defaults: new { controller = "Page", action = "GetPageContent", pagename = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "MusicianshipEdit",
              url: "Musicianship/{pagename}/Edit",
              defaults: new { controller = "Page", action = "EditPageContent", pagename = UrlParameter.Optional }
             );

            routes.MapRoute(
              name: "Piano",
              url: "Piano/{pagename}",
              defaults: new { controller = "Page", action = "GetPageContent", pagename = UrlParameter.Optional }
             );

            routes.MapRoute(
             name: "PianoEdit",
             url: "Piano/{pagename}/Edit",
             defaults: new { controller = "Page", action = "EditPageContent", pagename = UrlParameter.Optional }
            );
          

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}