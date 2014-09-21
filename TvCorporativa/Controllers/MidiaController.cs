using System.Net;
using System.Web.Mvc;
using TvCorporativa.Controllers.Base;
using TvCorporativa.Models;
using TvCorporativa.DAO;

namespace TvCorporativa.Controllers
{
    public class MidiaController : BaseController
    {
        private readonly MidiaDao _midiaDao;

        public MidiaController(MidiaDao midiaDao)
        {
            _midiaDao = midiaDao;
        }

        // GET: /Midia/
        public ActionResult Index()
        {
            return View(_midiaDao.GetAll());
        }

        // GET: /Midia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Midia midia = _midiaDao.Get((int)id);
            if (midia == null)
            {
                return HttpNotFound();
            }
            return View(midia);
        }

        // GET: /Midia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Midia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,Extensao,Tamanho")] Midia midia)
        {
            if (ModelState.IsValid)
            {
                _midiaDao.Save(midia);
                return RedirectToAction("Index");
            }

            return View(midia);
        }

        // GET: /Midia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Midia midia = _midiaDao.Get((int)id);
            if (midia == null)
            {
                return HttpNotFound();
            }
            return View(midia);
        }

        // POST: /Midia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,Extensao,Tamanho")] Midia midia)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(midia).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(midia);
        }

        // GET: /Midia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Midia midia = _midiaDao.Get((int)id);
            if (midia == null)
            {
                return HttpNotFound();
            }
            return View(midia);
        }

        // POST: /Midia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Midia midia = _midiaDao.Get(id);
            _midiaDao.Delete(midia);
            return RedirectToAction("Index");
        }

    }
}
