using System.Net;
using System.Web.Mvc;
using TvCorporativa.Controllers.Base;
using TvCorporativa.InfraEstrutura;
using TvCorporativa.Models;
using TvCorporativa.DAO;

namespace TvCorporativa.Controllers
{
    public class MidiaController : BaseController
    {
        private readonly MidiaDao _midiaDao;

        public MidiaController(MidiaDao midiaDao)
        {
            _midiaDao = midiaDao;
        }

        public ActionResult Index()
        {
            return View(_midiaDao.GetAll(UsuarioLogado.Empresa, true));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,Extensao,Tamanho")] Midia midia)
        {
            if (ModelState.IsValid)
            {
                midia.IdEmpresa = UsuarioLogado.Empresa.Id;
                _midiaDao.Save(midia);
                return RedirectToAction("Index");
            }

            return View(midia);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Midia midia = _midiaDao.Get((int)id);
            if (midia == null)
            {
                return HttpNotFound();
            }
            return View(midia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,IdEmpresa,Status,Nome,Extensao,Tamanho")] Midia midia)
        {
            if (ModelState.IsValid)
            {
                _midiaDao.Save(midia);
                return RedirectToAction("Index");
            }
            return View(midia);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Midia midia = _midiaDao.Get((int)id);
            if (midia == null)
            {
                return HttpNotFound();
            }
            _midiaDao.Delete(midia);

            GerenciarMidia.DeletarMidiaDirectory(string.Format("{0}{1}", midia.Nome, midia.Extensao), midia.IdEmpresa);

            return RedirectToAction("Index");
        }
    }
}
