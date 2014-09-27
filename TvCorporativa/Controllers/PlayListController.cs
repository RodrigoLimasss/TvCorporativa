using System;
using System.Net;
using System.Web.Mvc;
using TvCorporativa.Controllers.Base;
using TvCorporativa.Models;
using TvCorporativa.DAO;

namespace TvCorporativa.Controllers
{
    public class PlayListController : BaseController
    {
        private readonly PlayListDao _playListDao;

        public PlayListController(PlayListDao playListDao)
        {
            _playListDao = playListDao;
        }

        public ActionResult Index()
        {
            return View(_playListDao.GetAll(UsuarioLogado.Empresa, true));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Nome,Status,DataInicio,HoraInicio,DataFim,HoraFim")] PlayList playlist)
        {
            if (ModelState.IsValid)
            {
                playlist.IdEmpresa = UsuarioLogado.Empresa.Id;
                playlist.DataCriacao = DateTime.Now;
                playlist.DataInicio = playlist.DataInicio.Add(playlist.HoraInicio);
                playlist.DataFim = playlist.DataFim.Add(playlist.HoraFim);

                _playListDao.Save(playlist);
                return RedirectToAction("Index");
            }

            return View(playlist);
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdEmpresa,Nome,Status,DataCriacao,DataInicio,HoraInicio,DataFim,HoraFim")] PlayList playlist)
        {
            if (ModelState.IsValid)
            {
                playlist.DataInicio = playlist.DataInicio.Add(playlist.HoraInicio);
                playlist.DataFim = playlist.DataFim.Add(playlist.HoraFim);
                _playListDao.Save(playlist);
                
                return RedirectToAction("Index");
            }
            return View(playlist);
        }

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
            _playListDao.Delete(playlist);
            return RedirectToAction("Index");
        }

    }
}
