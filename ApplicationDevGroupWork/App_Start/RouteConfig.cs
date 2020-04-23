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
      defaults: new { controller = "Producers", action = "Index", id = UrlParameter.Optional }
   );
            routes.MapRoute(
      name: "Default2",
      url: "Loan/{controller}/{action}/{id}",
      defaults: new { controller = "Loan", action = "Index", id = UrlParameter.Optional }
   );


            routes.MapRoute(
              name: "Default3",
              url: "DVDDetails/{controller}/{action}/{id}",
              defaults: new { controller = "DVDDetails", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "Default4",
              url: "CastDetails/{controller}/{action}/{id}",
              defaults: new { controller = "CastDetails", action = "Index", id = UrlParameter.Optional }
           );


            routes.MapRoute(
              name: "Default5",
              url: "CastMembers/{controller}/{action}/{id}",
              defaults: new { controller = "CastMembers", action = "Index", id = UrlParameter.Optional }
           );


            routes.MapRoute(
              name: "Default6",
              url: "MemberCategories/{controller}/{action}/{id}",
              defaults: new { controller = "MemberCategories", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
  name: "Default7",
  url: "Members/{controller}/{action}/{id}",
  defaults: new { controller = "Members", action = "Index", id = UrlParameter.Optional }
);





            routes.MapRoute(
         name: "Default",
         url: "{controller}/{action}/{id}",
         defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
         );


        }
    }
}
