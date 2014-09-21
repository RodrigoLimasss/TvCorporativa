using System.Web.Mvc;
using TvCorporativa.Models;

namespace TvCorporativa.Controllers.Base
{
    public abstract class BaseController : Controller
    {

        public Usuario UsuarioLogado
        {
            get
            {
                if (Session["UsuarioLogado"] != null) return (Usuario)Session["UsuarioLogado"];
                return null;
            }
        }
    }
}