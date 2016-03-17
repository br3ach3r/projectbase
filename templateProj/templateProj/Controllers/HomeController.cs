﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using templateProj.Filters;
using templateProj.Models;

namespace templateProj.Controllers
{
    [SessionTimeOutFilter]
    [Authorize]
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        public ActionResult Home()
        {
            string uname = HttpContext.Session["Uname"].ToString();
            UserModel um = db.Umodel.Find(uname);

            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.usermodel = um;

            return View(homeViewModel);  
        }

    }
}