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
        public ActionResult Create([Bind(Include = "Nome,Status,DataInicio,HoraInicio,DataFim,HoraFim")] PlayList playlist, string idsPontos, string idsMidias)
        {
            if (ModelState.IsValid)
            {
                var anonObject = new[] { new { id = 0, ordem = 0 } };
                var dPontos = JsonConvert.DeserializeAnonymousType(idsPontos, anonObject);
                var dMidias = JsonConvert.DeserializeAnonymousType(idsMidias, anonObject);

                var newPontos = dPontos.Select(x => new KeyValuePair<int, int>(Convert.ToInt32(x.id), x.ordem)).ToList();
                var newMidias = dMidias.Select(x => new KeyValuePair<int, int>(Convert.ToInt32(x.id), x.ordem)).ToList();

                _playListDao.AddPontosAndMidias(playlist, newPontos, newMidias);

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
        public ActionResult Edit([Bind(Include = "Id,IdEmpresa,Nome,Status,DataCriacao,DataInicio,HoraInicio,DataFim,HoraFim")] PlayList playlist, string idsPontos, string idsMidias)
        {
            var playListEdit = _playListDao.Get(playlist.Id);

            if (ModelState.IsValid)
            {
                var anonObject = new[] {new {id = 0, ordem = 0}};
                var dPontos = JsonConvert.DeserializeAnonymousType(idsPontos, anonObject);
                var dMidias = JsonConvert.DeserializeAnonymousType(idsMidias, anonObject);

                var newPontos = dPontos.Select(x => new KeyValuePair<int, int>(Convert.ToInt32(x.id), x.ordem)).ToList();
                var newMidias = dMidias.Select(x => new KeyValuePair<int, int>(Convert.ToInt32(x.id), x.ordem)).ToList();

                playListEdit.Status = playlist.Status;
                playListEdit.Nome = playlist.Nome;
                playListEdit.DataInicio = playlist.DataInicio.Add(playlist.HoraInicio);
                playListEdit.DataFim = playlist.DataFim.Add(playlist.HoraFim);

                _playListDao.AddPontosAndMidias(playListEdit, newPontos, newMidias);
                _playListDao.Save(playListEdit);
                
                return RedirectToAction("Index");
            }
            return View(playListEdit);
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
