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

        public ActionResult Index()
        {
            return View(_feedDao.GetAll(UsuarioLogado.Empresa));
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,Endereco")] Feed feed)
        {
            if (ModelState.IsValid)
            {
                feed.IdEmpresa = UsuarioLogado.Empresa.Id;
                _feedDao.Save(feed);
                return RedirectToAction("Index");
            }

            return View(feed);
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdEmpresa,Nome,Endereco")] Feed feed)
        {
            if (ModelState.IsValid)
            {
                _feedDao.Save(feed);
                return RedirectToAction("Index");
            }
            return View(feed);
        }

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
            _feedDao.Delete(feed);
            return RedirectToAction("Index");
        }

    }
}
