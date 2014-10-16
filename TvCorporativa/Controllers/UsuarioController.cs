using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TvCorporativa.Controllers.Base;
using TvCorporativa.DAL;
using TvCorporativa.Models;
using TvCorporativa.DAO;

namespace TvCorporativa.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly UsuarioDao _usuarioDao;

        public UsuarioController(UsuarioDao usuarioDao)
        {
            _usuarioDao = usuarioDao;
        }

        public ActionResult Index()
        {
            if (!UsuarioLogado.Administrador)
                return RedirectToAction("Index", "Home");

            return View(_usuarioDao.GetAll());
        }

        public ActionResult Create()
        {
            MontaDropDownEmpresas();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdEmpresa,Nome,Senha,Status,Administrador,Email,Sexo,Telefone")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Telefone = usuario.Telefone.Replace(" ", "").Replace("-", "");
                usuario.DataCadastro = DateTime.Now;
                _usuarioDao.Save(usuario);
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = _usuarioDao.Get((int)id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            MontaDropDownEmpresas();
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdEmpresa,Nome,Senha,Status,Administrador,DataCadastro,Email,Sexo,Telefone")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Telefone = usuario.Telefone.Replace(" ", "").Replace("-", "");
                _usuarioDao.Save(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = _usuarioDao.Get((int)id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            _usuarioDao.Delete(usuario);

            return RedirectToAction("Index");
        }

        private void MontaDropDownEmpresas()
        {
            var dropDownDataList = GetServiceHelper.GetService<EmpresaDao>().GetAll();

            var dropDownOptions = dropDownDataList.Select(t => new SelectListItem { Text = t.Nome, Value = t.Id.ToString() });

            ViewBag.DropDownEmpresas = dropDownOptions;
        }
    }
}
