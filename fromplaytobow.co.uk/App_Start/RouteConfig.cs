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
                name: "cookies",
                url: "cookies",
                defaults: new { controller = "Page", action = "GetPageContent", pagename = "cookies" }
             );

            routes.MapRoute(
                name: "cookiesedit",
                url: "cookies/Edit",
                defaults: new { controller = "Page", action = "EditPageContent", pagename = "cookies" }
            );

            routes.MapRoute(
               name: "privacypolicy",
               url: "privacypolicy",
               defaults: new { controller = "Page", action = "GetPageContent", pagename = "privacypolicy" }
            );

            routes.MapRoute(
                name: "privacypolicyedit",
                url: "privacypolicy/Edit",
                defaults: new { controller = "Page", action = "EditPageContent", pagename = "privacypolicy" }
            );

            routes.MapRoute(
                name: "exams",
                url: "exams",
                defaults: new { controller = "Page", action = "GetPageContent", pagename = "exams" }
             );

            routes.MapRoute(
                name: "examsedit",
                url: "exams/Edit",
                defaults: new { controller = "Page", action = "EditPageContent", pagename = "exams" }
            );

            routes.MapRoute(
                name: "practiceadvice",
                url: "practiceadvice",
                defaults: new { controller = "Page", action = "GetPageContent", pagename = "practiceadvice" }
             );

            routes.MapRoute(
                name: "practiceadviceedit",
                url: "practiceadvice/Edit",
                defaults: new { controller = "Page", action = "EditPageContent", pagename = "practiceadvice" }
            );

            routes.MapRoute(
                name: "Recitals",
                url: "Recitals",
                defaults: new { controller = "Page", action = "GetPageContent", pagename = "Recitals" }
             );

            routes.MapRoute(
                name: "Recitalsedit",
                url: "Recitals/Edit",
                defaults: new { controller = "Page", action = "EditPageContent", pagename = "Recitals" }
            );

            routes.MapRoute(
                 name: "termandc",
                 url: "termsandconditions",
                 defaults: new { controller = "Page", action = "GetPageContent", pagename = "termsandconditions" }
             );

            routes.MapRoute(
                name: "termandcedit",
                url: "termsandconditions/Edit",
                defaults: new { controller = "Page", action = "EditPageContent", pagename = "termsandconditions" }
            );

            routes.MapRoute(
                  name: "Contact",
                  url: "Contact",
                  defaults: new { controller = "Page", action = "GetPageContent", pagename = "contact" }
              );

            routes.MapRoute(
                 name: "ContactEdit",
                 url: "Contact/Edit",
                 defaults: new { controller = "Page", action = "EditPageContent", pagename = "contact" }
             );

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
              defaults: new { controller = "Page", action = "GetPageContent", pagename= UrlParameter.Optional }
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
              name: "InfoHomeEdit",
              url: "Info/Edit",
              defaults: new { controller = "Page", action = "EditPageContent", pagename = UrlParameter.Optional }
             );

            routes.MapRoute(
               name: "Info",
               url: "Info/{pagename}",
               defaults: new { controller = "Page", action = "GetPageContent", pagename = UrlParameter.Optional }
              );

            routes.MapRoute(
              name: "InfoEdit",
              url: "Info/{pagename}/Edit",
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