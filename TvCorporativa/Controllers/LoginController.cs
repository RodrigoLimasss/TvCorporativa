using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TvCorporativa.DAO;
using WebMatrix.WebData;

namespace TvCorporativa.Controllers
{
    public class LoginController : Controller
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
    }
}
