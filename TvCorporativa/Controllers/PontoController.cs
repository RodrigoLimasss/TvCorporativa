using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TvCorporativa.DAO;
using TvCorporativa.Models;
using TvCorporativa.DAL;

namespace TvCorporativa.Controllers
{
    public class PontoController : Controller
    {
        private readonly PontoDao _pontoDao;

        public PontoController(PontoDao pontoDao)
        {
            _pontoDao = pontoDao;
        }

        // GET: /Ponto/
        public ActionResult Index()
        {
            var pontos = _pontoDao.GetAll();
            return View(pontos);
        }

        // GET: /Ponto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ponto ponto = _pontoDao.Get((int) id);
            if (ponto == null)
            {
                return HttpNotFound();
            }
            return View(ponto);
        }

        // GET: /Ponto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Ponto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,Status")] Ponto ponto)
        {
            if (ModelState.IsValid)
            {
                _pontoDao.Save(ponto);
                
                return RedirectToAction("Index");
            }

            return View(ponto);
        }

        // GET: /Ponto/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ponto ponto = _pontoDao.Get((int)id);
            if (ponto == null)
            {
                return HttpNotFound();
            }
            return View(ponto);
        }

        // POST: /Ponto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,Status")] Ponto ponto)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(ponto).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ponto);
        }

        // GET: /Ponto/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ponto ponto = _pontoDao.Get((int)id);
            if (ponto == null)
            {
                return HttpNotFound();
            }
            return View(ponto);
        }

        // POST: /Ponto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            //Ponto ponto = db.Pontos.Find(id);
            //db.Pontos.Remove(ponto);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
