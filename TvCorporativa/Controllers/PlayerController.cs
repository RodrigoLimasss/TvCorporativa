using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TvCorporativa.DAL;
using TvCorporativa.DAO;

namespace TvCorporativa.Controllers
{
    public class PlayerController : Controller
    {
        //
        // GET: /Player/
        public ActionResult Execute(string empresa, int idPonto)
        {
            if (string.IsNullOrEmpty(empresa))
                return View("Error");

            var oEmpresa = GetServiceHelper.GetService<EmpresaDao>().GetPorNomeAmigavel(empresa);

            if (oEmpresa == null)
                return View("Error");

            ViewBag.HiddenIdPonto = idPonto;

            return View();
        }
	}
}