using CemKeskin.Models.Classes;
using CemKeskin.Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CemKeskin.Controllers
{
    public class ServiceController : Controller
    {
        DatabaseCemKeskinEntities db = new DatabaseCemKeskinEntities();
        public ActionResult Index()
        {

            ForAdmin list = new ForAdmin();
            list.ServicePage = db.TBLServices.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TBLServices service)
        {

            db.TBLServices.Add(service);
            db.SaveChanges();
            return View();
        }
        public ActionResult Operations(int id) //basılan güncelle butonuna göre id getiriyor.
        {
            var bring = db.TBLServices.Find(id);
            return View("Operations", bring);
        }
        public ActionResult Update(TBLServices param)
        {
            var bring = db.TBLServices.Find(param.Id);
            bring.ServicesTitle = param.ServicesTitle;
            bring.ServicesContent = param.ServicesContent;
            bring.ServicesIcon = param.ServicesIcon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var bring = db.TBLServices.Find(id);
            db.TBLServices.Remove(bring);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
