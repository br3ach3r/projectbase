using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using templateProj.Models;

namespace templateProj.Controllers
{
    [Authorize]
    public class SessionController : Controller
    {
        public UserRole GetUserValidity(UserModel u)
        {
            if (u.role == "Admin")
            {
                return UserRole.Admin;
            }
            else if (u.role == "PManager")
            {
                return UserRole.PManager;
            }
            else
            {
                return UserRole.Developer;
            }
        }

        public ActionResult RestrictionError()
        {
            return View();
        }

        public ActionResult Timeout()
        {
            return View();
        }
    }
}