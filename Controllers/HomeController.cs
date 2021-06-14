using CemKeskin.Models.Classes;
using CemKeskin.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CemKeskin.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Home
        DatabaseCemKeskinEntities db = new DatabaseCemKeskinEntities();
        public ActionResult Index()
        {
            ForHome list = new ForHome();
            list.AboutPage = db.TBLAboutMe.ToList();
            list.EducationPage = db.TBLEducation.ToList();
            list.ExpPage = db.TBLExperiences.ToList();
            list.ReferencePage = db.TBLReferences.ToList();
            list.ServicePage = db.TBLServices.ToList();
            list.SocialMediaPage = db.TBLSocialMedia.ToList();

            return View(list);
        }
    }
}