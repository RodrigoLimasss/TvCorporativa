﻿using System;
using System.Linq;
using System.Net;
using System.Web.Helpers;
using System.Web.Mvc;
using Newtonsoft.Json;
using TvCorporativa.Controllers.Base;
using TvCorporativa.DAL;
using TvCorporativa.DAO;
using TvCorporativa.Models;

namespace TvCorporativa.Controllers
{
    public class PontoController : BaseController
    {
        private readonly PontoDao _pontoDao;

        public PontoController(PontoDao pontoDao)
        {
            _pontoDao = pontoDao;
        }

        public ActionResult Index()
        {
            if (!UsuarioLogado.Administrador)
                return RedirectToAction("Index", "Home");

            var pontos = _pontoDao.GetAll();

            return View(pontos);
        }

        public ActionResult Create()
        {
            MontaDropDownTemplates(null);
            MontaDropDownEmpresas();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdTemplate,IdEmpresa,Nome,Status")] Ponto ponto)
        {
            if (ModelState.IsValid)
            {
                _pontoDao.Save(ponto);
                
                return RedirectToAction("Index");
            }

            return View(ponto);
        }

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
            MontaDropDownTemplates(ponto.Empresa);
            MontaDropDownEmpresas();
            return View(ponto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdTemplate,IdEmpresa,Nome,Status")] Ponto ponto)
        {
            if (ModelState.IsValid)
            {
                _pontoDao.Save(ponto);
                return RedirectToAction("Index");
            }
            return View(ponto);
        }

        public ActionResult Delete(int? id)
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
            _pontoDao.Delete(ponto);
            return RedirectToAction("Index");
        }

        public ActionResult Visualizar(int? idPonto, int? idEmpresa)
        {
            if (idPonto == null || idEmpresa == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var empresa = GetServiceHelper.GetService<EmpresaDao>().Get((int) idEmpresa);

            return Redirect(string.Format("~/Player/Execute/{0}/{1}", empresa.NomeAmigavel, idPonto));
        }

        private void MontaDropDownTemplates(Empresa empresa)
        {
            var dropDownDataList = empresa != null
                ? GetServiceHelper.GetService<TemplateDao>().GetAll(empresa)
                : GetServiceHelper.GetService<TemplateDao>().GetAll();

            var dropDownOptions = dropDownDataList.Select(t => new SelectListItem { Text = t.Nome, Value = t.Id.ToString() });

            ViewBag.DropDownTemplates = dropDownOptions;
        }

        private void MontaDropDownEmpresas()
        {
            var dropDownDataList = GetServiceHelper.GetService<EmpresaDao>().GetAll();

            var dropDownOptions = dropDownDataList.Select(t => new SelectListItem { Text = t.Nome, Value = t.Id.ToString() });

            ViewBag.DropDownEmpresas = dropDownOptions;
        }

        [HttpPost]
        public string AtualizarDropTemplate(int idEmpresa)
        {
            var empresa = GetServiceHelper.GetService<EmpresaDao>().Get(idEmpresa);
            var dropDownDataList = GetServiceHelper.GetService<TemplateDao>().GetAll(empresa);

            var dropDownOptions = dropDownDataList.Select(t => new { Text = t.Nome, Value = t.Id.ToString() });

            return JsonConvert.SerializeObject(dropDownOptions);
        }
    }
}
