using System;
using System.Net;
using System.Web.Mvc;
using TvCorporativa.Controllers.Base;
using TvCorporativa.DAL;
using TvCorporativa.DAO;

namespace TvCorporativa.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Visualizar(int? idPonto, int? idEmpresa)
        {
            if (idPonto == null || idEmpresa == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var empresa = GetServiceHelper.GetService<EmpresaDao>().Get((int)idEmpresa);

            return Redirect(string.Format("~/Player/Execute/{0}/{1}", empresa.NomeAmigavel, idPonto));
        }

        [HttpPost]
        public ActionResult SincronizarPonto(int idPonto)
        {
            try
            {
                var repoPonto = GetServiceHelper.GetService<PontoDao>();
                var ponto = repoPonto.Get(idPonto);
                ponto.Sincronizar = true;
                repoPonto.Save(ponto);

                return Json("true", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("false", JsonRequestBehavior.AllowGet);
            }
        }
    }
}
