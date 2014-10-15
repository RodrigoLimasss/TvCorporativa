using System;
using System.Net;
using System.Web.Mvc;
using TvCorporativa.Controllers.Base;
using TvCorporativa.DAO;
using TvCorporativa.Models;

namespace TvCorporativa.Controllers
{
    public class EmpresaController : BaseController
    {
        private readonly EmpresaDao _empresaDao;

        public EmpresaController(EmpresaDao empresaDao)
        {
            _empresaDao = empresaDao;
        }

        
        public ActionResult Index()
        {
            if (!UsuarioLogado.Administrador)
                return RedirectToAction("Index", "Home");

            var empresas = _empresaDao.GetAll(true);
   
            return View(empresas);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,Status,Endereco,Telefone,Cnpj")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                empresa.DataCriacao = DateTime.Now;
                empresa.Telefone = empresa.Telefone.Replace(" ", "").Replace("-", "");
                empresa.Cnpj = empresa.Cnpj.Replace(".", "").Replace("/", "").Replace("-", "");
                _empresaDao.Save(empresa);
                return RedirectToAction("Index");
            }

            return View(empresa);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = _empresaDao.Get((int)id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,DataCriacao,Status,Endereco,Telefone,Cnpj")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                empresa.Telefone = empresa.Telefone.Replace(" ", "").Replace("-", "");
                empresa.Cnpj = empresa.Cnpj.Replace(".", "").Replace("/", "").Replace("-", "");
                _empresaDao.Save(empresa);

                return RedirectToAction("Index");
            }
            return View(empresa);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = _empresaDao.Get((int)id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            _empresaDao.Delete(empresa);
            return RedirectToAction("Index");
        }
    }
}
