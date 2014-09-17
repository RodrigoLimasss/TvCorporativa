using System.Net;
using System.Web.Mvc;
using TvCorporativa.Models;
using TvCorporativa.DAO;

namespace TvCorporativa.Controllers
{
    public class PlayListController : Controller
    {
        private readonly PlayListDao _playListDao;

        public PlayListController(PlayListDao playListDao)
        {
            _playListDao = playListDao;
        }
        // GET: /PlayList/
        public ActionResult Index()
        {
            var usuario = new Usuario {Id = 1};
            return View(_playListDao.GetAll(usuario));
        }

        // GET: /PlayList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayList playlist = _playListDao.Get((int)id);
            if (playlist == null)
            {
                return HttpNotFound();
            }
            return View(playlist);
        }

        // GET: /PlayList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PlayList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,Status,DataCriacao,DataInicio,DataFim")] PlayList playlist)
        {
            if (ModelState.IsValid)
            {
                _playListDao.Save(playlist);
                return RedirectToAction("Index");
            }

            return View(playlist);
        }

        // GET: /PlayList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayList playlist = _playListDao.Get((int)id);
            if (playlist == null)
            {
                return HttpNotFound();
            }
            return View(playlist);
        }

        // POST: /PlayList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,Status,DataCriacao,DataInicio,DataFim")] PlayList playlist)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(playlist).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(playlist);
        }

        // GET: /PlayList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayList playlist = _playListDao.Get((int)id);
            if (playlist == null)
            {
                return HttpNotFound();
            }
            return View(playlist);
        }

        // POST: /PlayList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayList playlist = _playListDao.Get((int)id);
            _playListDao.Delete(playlist);
            return RedirectToAction("Index");
        }

    }
}
