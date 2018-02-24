using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes(); //activating attibute routing...where routes are defined above actions

            //routes.MapRoute(
            //    "MoviesByReleaseDate",
            //    "movies/released/{year}/{month}",
            //    new {controller = "Movies", action = "ByReleaseDate"}, //defaults defined using an anonymous object
            //    //new {year=@"\d{4}", month=@"\d{2}"}, //applying contraints using an anonymous object with regular expressions
            //    new {year=@"2017|2018", month=@"\d{2}"} 
            //);


            //The default route below can only take one parameter to set up for more parameters, you need to create custom routes before the default route 
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
