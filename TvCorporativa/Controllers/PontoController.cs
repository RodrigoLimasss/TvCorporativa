using System.Linq;
using System.Net;
using System.Web.Mvc;
using TvCorporativa.Controllers.Base;
using TvCorporativa.DAL;
using TvCorporativa.DAO;
using TvCorporativa.Models;

namespace TvCorporativa.Controllers
{
    public class PontoController : BaseController
    {
        private readonly PontoDao _pontoDao;

        public PontoController(PontoDao pontoDao)
        {
            _pontoDao = pontoDao;
        }

        public ActionResult Index()
        {
            if (!UsuarioLogado.Administrador)
                return RedirectToAction("Index", "Home");

            var pontos = _pontoDao.GetAll();

            return View(pontos);
        }

        public ActionResult Create()
        {
            MontaDropDownTemplates();
            MontaDropDownEmpresas();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdTemplate,IdEmpresa,Nome,Status")] Ponto ponto)
        {
            if (ModelState.IsValid)
            {
                _pontoDao.Save(ponto);
                
                return RedirectToAction("Index");
            }

            return View(ponto);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ponto ponto = _pontoDao.Get((int)id);
            if (ponto == null)
            {
                return HttpNotFound();
            }
            MontaDropDownTemplates();
            MontaDropDownEmpresas();
            return View(ponto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdTemplate,IdEmpresa,Nome,Status")] Ponto ponto)
        {
            if (ModelState.IsValid)
            {
                _pontoDao.Save(ponto);
                return RedirectToAction("Index");
            }
            return View(ponto);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ponto ponto = _pontoDao.Get((int)id);
            if (ponto == null)
            {
                return HttpNotFound();
            }
            _pontoDao.Delete(ponto);
            return RedirectToAction("Index");
        }

        private void MontaDropDownTemplates()
        {
            var dropDownDataList = GetServiceHelper.GetService<TemplateDao>().GetAll();

            var dropDownOptions = dropDownDataList.Select(t => new SelectListItem { Text = t.Nome, Value = t.Id.ToString() });

            ViewBag.DropDownTemplates = dropDownOptions;
        }

        private void MontaDropDownEmpresas()
        {
            var dropDownDataList = GetServiceHelper.GetService<EmpresaDao>().GetAll();

            var dropDownOptions = dropDownDataList.Select(t => new SelectListItem { Text = t.Nome, Value = t.Id.ToString() });

            ViewBag.DropDownEmpresas = dropDownOptions;
        }
    }
}
