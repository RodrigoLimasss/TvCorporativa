using System.Web.Mvc;
using TvCorporativa.Controllers.Base;
using TvCorporativa.DAO;

namespace TvCorporativa.Controllers
{
    public class EmpresaController : BaseController
    {
        private readonly EmpresaDao _empresaDao;

        public EmpresaController(EmpresaDao empresaDao)
        {
            _empresaDao = empresaDao;
        }

        //
        // GET: /Empresa/

        public ActionResult Index()
        {
            if (!UsuarioLogado.Administrador)
                return RedirectToAction("Index", "Home");

            var empresas = _empresaDao.GetAll();
   
            return View(empresas);
        }

        //
        // GET: /Empresa/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Empresa/Create

        public ActionResult Create()
        {
            //var empresas = new List<Empresa>
            //{
            //    new Empresa
            //    {
            //        Id = 1,
            //        Nome = "C-se",
            //        Cnpj = "123.456.789-0001",
            //        DataCriacao = new DateTime(2014, 09, 06),
            //        Endereco = "Av. Rio Branco 100 - Centro",
            //        Status = true,
            //        Telefone = "2222-2222"
            //    },
            //    new Empresa
            //    {
            //        Id = 2,
            //        Nome = "RiWeb",
            //        Cnpj = "123.456.789-0001",
            //        DataCriacao = new DateTime(2013, 09, 06),
            //        Endereco = "Av. Berrini 100 - Brooklin Novo",
            //        Status = true,
            //        Telefone = "1111-2222"
            //    }
            //};

            return View();
        }

        //
        // POST: /Empresa/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Empresa/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Empresa/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Empresa/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Empresa/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
