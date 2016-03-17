using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace templateProj.Controllers
{
    public class lolController : Controller
    {
        // GET: lol
        [HttpPost]
        public ActionResult Index(string[] SelectedProducts)
        {
            foreach (string s in SelectedProducts)
                Debug.WriteLine(s);
            //string s = string.Concat(SelectedProducts);
            return View("~/Views/Starter/StarterPage.cshtml");
        }
    }
}