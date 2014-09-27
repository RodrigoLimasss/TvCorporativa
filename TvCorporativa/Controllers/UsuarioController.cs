using System.Net;
using System.Web.Mvc;
using TvCorporativa.Controllers.Base;
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

        // GET: /Usuario/
        public ActionResult Index()
        {
            if (!UsuarioLogado.Administrador)
                return RedirectToAction("Index", "Home");

            return View(_usuarioDao.GetAll());
        }

        // GET: /Usuario/Details/5
        public ActionResult Details(int? id)
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
            return View(usuario);
        }

        // GET: /Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,Senha,Status,Administrador,DataCadastro,Email,Sexo,Telefone")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioDao.Save(usuario);
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: /Usuario/Edit/5
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
            return View(usuario);
        }

        // POST: /Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,Senha,Status,Administrador,DataCadastro,Email,Sexo,Telefone")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(usuario).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: /Usuario/Delete/5
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
            return View(usuario);
        }

        // POST: /Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = _usuarioDao.Get(id);
            _usuarioDao.Delete(usuario);
           
            return RedirectToAction("Index");
        }
    }
}
