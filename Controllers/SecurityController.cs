using CemKeskin.Models.Entity;
using CemKeskin.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CemKeskin.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        // GET: Security
        DatabaseCemKeskinEntities db = new DatabaseCemKeskinEntities();

        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TBLLogin login)
        {
            var info = db.TBLLogin.FirstOrDefault(x => x.Username == login.Username && x.Password == login.Password);
            if(info != null)
            {
                FormsAuthentication.SetAuthCookie(info.Username, false);
                return RedirectToAction("Admin", "Admin");
            }
            else
            {
                ViewBag.LoginMessage="Kullanıcı adı veya parola yanlış!";
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}