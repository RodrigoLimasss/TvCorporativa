using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TvCorporativa.Controllers
{
    public class LoginController : Controller
    {
        public LoginController()
        {
            //if (!WebSecurity.Initialized)
            //{
            //    WebSecurity.InitializeDatabaseConnection("TvCorporativaConection", "Usuario", "Id_Usuario", "Nome", true);
            //}
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autentica(string login, string senha)
        {
            //if (WebSecurity.Login(login, senha))
            //    return RedirectToAction("Index", "Home");
            
            //ModelState.AddModelError("login.Invalido", "Login ou senha incorretos");
            return RedirectToAction("Index", "Home");
        }
    }
}
