using System.Net;
using System.Web.Mvc;
using TvCorporativa.Controllers.Base;
using TvCorporativa.Models;
using TvCorporativa.DAO;

namespace TvCorporativa.Controllers
{
    public class FeedController : BaseController
    {
        private readonly FeedDao _feedDao;

        public FeedController(FeedDao feedDao)
        {
            _feedDao = feedDao;
        }

        // GET: /Feed/
        public ActionResult Index()
        {
            return View(_feedDao.GetAll());
        }

        // GET: /Feed/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feed feed = _feedDao.Get((int)id);
            if (feed == null)
            {
                return HttpNotFound();
            }
            return View(feed);
        }

        // GET: /Feed/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Feed/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,Endereco")] Feed feed)
        {
            if (ModelState.IsValid)
            {
                _feedDao.Save(feed);
                return RedirectToAction("Index");
            }

            return View(feed);
        }

        // GET: /Feed/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feed feed = _feedDao.Get((int)id);
            if (feed == null)
            {
                return HttpNotFound();
            }
            return View(feed);
        }

        // POST: /Feed/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,Endereco")] Feed feed)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(feed).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(feed);
        }

        // GET: /Feed/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feed feed = _feedDao.Get((int)id);
            if (feed == null)
            {
                return HttpNotFound();
            }
            return View(feed);
        }

        // POST: /Feed/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feed feed = _feedDao.Get(id);
            _feedDao.Delete(feed);
            return RedirectToAction("Index");
        }

    }
}
