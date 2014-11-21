using System.Web.Mvc;
using TvCorporativa.Controllers.Base;

namespace TvCorporativa.Controllers
{
    public class ApresentacaoController : BaseController
    {
        //
        // GET: /Apresentacao/
        public ActionResult Index()
        {
            return View();
        }
	}
}