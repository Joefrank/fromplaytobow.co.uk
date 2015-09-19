using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace Utils
{
    public static class RouteCollectionExtensions
    {
        public static Route MapRouteWithName(this RouteCollection routes,
        string name, string url, object defaults, object constraints)
        {
            Route route = routes.MapRoute(name, url, defaults, constraints);
            route.DataTokens = new RouteValueDictionary();
            route.DataTokens.Add("RouteName", name);

            return route;
        }
    }
}
