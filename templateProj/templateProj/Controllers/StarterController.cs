using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace templateProj.Controllers
{
    public class StarterController : Controller
    {
        // GET: Starter
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StarterPage()
        {
            return View();
        }
    }
}