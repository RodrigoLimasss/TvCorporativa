using System.Web.Mvc;
using TvCorporativa.Controllers.Base;

namespace TvCorporativa.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
