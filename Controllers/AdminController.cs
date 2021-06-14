using CemKeskin.Models.Classes;
using CemKeskin.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CemKeskin.Controllers
{
    
    public class AdminController : Controller
    {
        DatabaseCemKeskinEntities db = new DatabaseCemKeskinEntities();
        // GET: Admin
        public ActionResult Admin()
        {
            
            return View();
        }
    }
}