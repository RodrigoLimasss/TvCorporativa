using System.Web.Mvc;
using TvCorporativa.Controllers.Base;
using TvCorporativa.DAO;

namespace TvCorporativa.Controllers
{
    public class LoginController : BaseController
    {
        private readonly UsuarioDao _usuarioDao;

        public LoginController(UsuarioDao usuarioDao)
        {
            _usuarioDao = usuarioDao;
        }

        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public ActionResult Autentica(string login, string senha)
        {
            var usuarioValido = _usuarioDao.RetornaUsuario(login, senha);

            if (usuarioValido != null)
            {
                Session["UsuarioLogado"] = usuarioValido;
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("login.Invalido", "Login ou senha incorretos");
            return View("Index");
        }

        public ActionResult Logout()
        {
            Session["UsuarioLogado"] = null;
            return View("Index");
        }
    }
}
