using System.Linq;
using System.Net;
using System.Web.Mvc;
using TvCorporativa.Controllers.Base;
using TvCorporativa.DAL;
using TvCorporativa.DAO;
using TvCorporativa.Models;

namespace TvCorporativa.Controllers
{
    public class TemplateController : BaseController
    {
        private readonly TemplateDao _templateDao;

        public TemplateController(TemplateDao templateDao)
        {
            _templateDao = templateDao;
        }

        public ActionResult Index()
        {
            if (!UsuarioLogado.Administrador)
                return RedirectToAction("Index", "Home");

            return View(_templateDao.GetAll());
        }

        public ActionResult Create()
        {
            MontaDropDownEmpresas();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdEmpresa,Status,Nome,Html")] Template template)
        {
            if (ModelState.IsValid)
            {
                _templateDao.Save(template);
                return RedirectToAction("Index");
            }

            return View(template);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Template template = _templateDao.Get((int) id);
            if (template == null)
            {
                return HttpNotFound();
            }
            MontaDropDownEmpresas();
            return View(template);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdEmpresa,Status,Nome,Html")] Template template)
        {
            if (ModelState.IsValid)
            {
                _templateDao.Save(template);
                return RedirectToAction("Index");
            }
            return View(template);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Template template = _templateDao.Get((int) id);
            if (template == null)
            {
                return HttpNotFound();
            }
            _templateDao.Delete(template);

            return RedirectToAction("Index");
        }

        private void MontaDropDownEmpresas()
        {
            var dropDownDataList = GetServiceHelper.GetService<EmpresaDao>().GetAll();

            var dropDownOptions = dropDownDataList.Select(t => new SelectListItem { Text = t.Nome, Value = t.Id.ToString() });

            ViewBag.DropDownEmpresas = dropDownOptions;
        }
    }
}
