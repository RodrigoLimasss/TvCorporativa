using System.Net;
using System.Web.Mvc;
using TvCorporativa.Controllers.Base;
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,Html")] Template template)
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
            return View(template);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,Html")] Template template)
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
    }
}
