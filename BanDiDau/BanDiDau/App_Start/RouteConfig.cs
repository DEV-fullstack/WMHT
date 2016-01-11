using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BanDiDau
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            #region //Route-Hotel
            routes.MapRoute("hotel-details", "hotel-details/{id}",
               new { controller = "Hotel", action = "Hotel_Details",id = UrlParameter.Optional}
               );
            routes.MapRoute("hotel-index", "hotel-index",
             new { controller = "Hotel", action = "Hotel" }
             );
            routes.MapRoute("hotel-payment", "hotel-payment",
               new { controller = "Hotel", action = "Hotel_Payment" }
               );
            routes.MapRoute("hotel-payment-registered-card", "hotel-payment-registered-card",
              new { controller = "Hotel", action = "Hotel_Ppayment_Registered_Card" }
              );
            routes.MapRoute("hotel-payment-unregistered", "hotel-payment-unregistered",
              new { controller = "Hotel", action = "Hotel_Payment_Unregistered" }
              );
            routes.MapRoute("hotel-search", "hotel-search",
              new { controller = "Hotel", action = "Hotel_Search" }
              );
            routes.MapRoute("hotels-search-results", "hotels-search-results",
              new { controller = "Hotel", action = "Hotels_Search_Results" }
              );
            #endregion
            #region //Route-Fligth
          
            routes.MapRoute("flights-index", "flights-index",
             new { controller = "Home", action = "Flight" }
             );
            routes.MapRoute("flights-payment", "flights-payment",
               new { controller = "Home", action = "Flight_Payment" }
               );
            routes.MapRoute("flights-payment-registered-card", "flights-payment-registered-card",
              new { controller = "Home", action = "Flight_Ppayment_Registered_Card" }
              );
            routes.MapRoute("flights-payment-unregistered", "flights-payment-unregistered",
              new { controller = "Home", action = "Flight_Payment_Unregistered" }
              );
            routes.MapRoute("flights-search", "flights-search",
              new { controller = "Home", action = "Hotel_Search" }
              );
            routes.MapRoute("flights-search-results", "flights-search-results",
              new { controller = "Home", action = "Flight_Search_Results" }
              );
            #endregion
            routes.MapRoute("home-index", "home-index",
              new { controller = "Home", action = "Index" }
              );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
           
        }
    }
}
