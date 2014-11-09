using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Newtonsoft.Json;
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
            return View(_feedDao.GetAll(UsuarioLogado.Empresa, true));
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Status,Nome,Endereco")] Feed feed, string idsPontos)
        {
            if (ModelState.IsValid)
            {
                var anonObject = new[] { new { id = 0, ordem = 0 } };
                var dPontos = JsonConvert.DeserializeAnonymousType(idsPontos, anonObject);

                var newPontos = dPontos.Select(x => new KeyValuePair<int, int>(Convert.ToInt32(x.id), x.ordem)).ToList();
                
                _feedDao.AddPontos(feed, newPontos);
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
        public ActionResult Edit([Bind(Include = "Id,IdEmpresa,Status,Nome,Endereco")] Feed feed, string idsPontos)
        {
            var feedEdit = _feedDao.Get(feed.Id);

            if (ModelState.IsValid)
            {
                var anonObject = new[] { new { id = 0, ordem = 0 } };
                var dPontos = JsonConvert.DeserializeAnonymousType(idsPontos, anonObject);

                var newPontos = dPontos.Select(x => new KeyValuePair<int, int>(Convert.ToInt32(x.id), x.ordem)).ToList();

                feedEdit.Status = feed.Status;
                feedEdit.Nome = feed.Nome;
                feedEdit.Endereco = feed.Endereco;
                feedEdit.IdEmpresa = UsuarioLogado.Empresa.Id;
                _feedDao.AddPontos(feedEdit, newPontos);

                _feedDao.Save(feedEdit);
                return RedirectToAction("Index");
            }
            return View(feedEdit);
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
