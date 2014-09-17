using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TvCorporativa.InfraEstrutura.Autenticacao
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.RouteData.Values.ContainsValue("Login"))
                return;

            var sessaoUsuario = HttpContext.Current.Session["UsuarioLogado"];

            if (sessaoUsuario == null)
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    action = "Index",
                    controller = "Login"
                }));
        }

    }
}