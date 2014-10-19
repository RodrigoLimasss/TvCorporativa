using System.Web.Mvc;
using System.Web.Routing;

namespace TvCorporativa
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Player",
                url: "{controller}/{action}/{empresa}/{idPonto}",
                defaults: new { controller = "Player", action = "Execute", empresa = "", idPonto = "" }
            );
        }
    }
}