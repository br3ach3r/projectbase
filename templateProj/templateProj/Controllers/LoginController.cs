using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using templateProj.Models;
using templateProj.Property;

namespace templateProj.Controllers
{
    //[AllowAnonymous]
    public class LoginController : Controller
    {

        DataContext db = new DataContext();
        Paths path = new Paths();
        Encrypt hash = new Encrypt();

        // Login action
        public ActionResult Index()
        {

            return View("login");
        }

        // Recover Password page
        public ActionResult RecoverPass()
        {

            return View("ForgotPassword", null);
        }

        // Login method
        [HttpPost]
        public ActionResult Login(string uname, string pass)
        {

            if (ModelState.IsValid)
            {
                SessionController s = new SessionController();
                try
                {
                    UserModel um = db.Umodel.Find(uname);

                    string hashPw = hash.HashPassword(pass, um.salt);

                    UserModel User = db.Umodel.Single(usr => usr.Username == uname
                        && usr.password == hashPw);

                    UserRole role = s.GetUserValidity(User);

                    string Urole = "";

                    if (role == UserRole.Admin)
                    {
                        Urole = "Admin";
                    }
                    else if (role == UserRole.PManager)
                    {
                        Urole = "PManager";
                    }
                    else if (role == UserRole.Developer)
                    {
                        Urole = "Developer";
                    }
                    else if (role == UserRole.ScrumMaster)
                    {
                        Urole = "ScrumMaster";
                    }
                    else
                    {
                        ViewBag.errorMsg = "error";
                        return View();
                    }

                    FormsAuthentication.SetAuthCookie(User.Username, true);

                    Session["Role"] = Urole;
                    Session["Uname"] = User.Username;
                    Session["ProPic"] = User.ProfilePic;
                  
                    return RedirectToAction("Home", "Home");
                }
                catch (System.InvalidOperationException e)
                {
                    ViewBag.errorMsg = "error";
                    return View();
                }
            }
            else
            {
                ViewBag.errorMsg = "error";
                return View();
            }
        }

        // Logout method
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

        // New password entry
        public ActionResult NewPw(string pw, string username)
        {

            UserModel user = db.Umodel.Find(username);

            string salt = hash.CreateSalt();

            string hashPw = hash.HashPassword(pw, salt);

            user.password = hashPw;
            user.salt = salt;

            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

                return View(path.dict["loginURL"]);
            }

            return View(path.dict["loginURL"]);
        }
    }
}