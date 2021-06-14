using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CemKeskin.Models.Entity;
using CemKeskin.Models.Classes;

namespace CemKeskin.Controllers
{
    public class AboutMeController : Controller
    {
        // GET: AboutMe
        DatabaseCemKeskinEntities db = new DatabaseCemKeskinEntities();
        public ActionResult Index()
        {

            ForAdmin list = new ForAdmin();
            list.AboutPage = db.TBLAboutMe.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TBLAboutMe about)
        {
            db.TBLAboutMe.Add(about);
            db.SaveChanges();
            return View();
        }
        public ActionResult Operations(int id) //basılan güncelle butonuna göre id getiriyor.
        {
            var bring = db.TBLAboutMe.Find(id);
            return View("Operations", bring);
        }
        public ActionResult Update(TBLAboutMe param)
        {
            var bring = db.TBLAboutMe.Find(param.Id);
            bring.AboutContent = param.AboutContent;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var bring = db.TBLAboutMe.Find(id);
            db.TBLAboutMe.Remove(bring);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}