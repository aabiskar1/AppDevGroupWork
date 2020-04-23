using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ApplicationDevGroupWork
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
      name: "Default1",
      url: "Producers/{controller}/{action}/{id}",
      defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
   );
            routes.MapRoute(
      name: "Default2",
      url: "Loan/{controller}/{action}/{id}",
      defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
   );


            routes.MapRoute(
              name: "Default3",
              url: "DVDDetails/{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "Default4",
              url: "CastDetails/{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );


            routes.MapRoute(
              name: "Default5",
              url: "CastMembers/{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );




            routes.MapRoute(
         name: "Default",
         url: "{controller}/{action}/{id}",
         defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
         );


        }
    }
}
