using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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