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

        // GET: /Template/
        public ActionResult Index()
        {
            return View(_templateDao.GetAll());
        }

        // GET: /Template/Details/5
        public ActionResult Details(int? id)
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

        // GET: /Template/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Template/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome")] Template template)
        {
            if (ModelState.IsValid)
            {
                _templateDao.Save(template);
                return RedirectToAction("Index");
            }

            return View(template);
        }

        // GET: /Template/Edit/5
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

        // POST: /Template/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome")] Template template)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(template).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(template);
        }

        // GET: /Template/Delete/5
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
            return View(template);
        }

        // POST: /Template/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Template template = _templateDao.Get(id);
            _templateDao.Delete(template);
            return RedirectToAction("Index");
        }

    }
}
