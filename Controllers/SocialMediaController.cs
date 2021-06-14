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
    public class SocialMediaController : Controller
    {
        DatabaseCemKeskinEntities db = new DatabaseCemKeskinEntities();
        public ActionResult Index()
        {

            ForAdmin list = new ForAdmin();
            list.SocialMediaPage = db.TBLSocialMedia.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TBLSocialMedia social)
        {
            if (Request.Files.Count > 0)
            {
                string fName = Path.GetFileName(Request.Files[0].FileName);
                string filePath = "~/Images/" + fName;
                Request.Files[0].SaveAs(Server.MapPath(filePath));
                social.SocialMediaIcons = "/Images/" + fName;
            }
            db.TBLSocialMedia.Add(social);
            db.SaveChanges();
            return View();
        }
        public ActionResult Operations(int id) //basılan güncelle butonuna göre id getiriyor.
        {
            var bring = db.TBLSocialMedia.Find(id);
            return View("Operations", bring);
        }
        public ActionResult Update(TBLSocialMedia param)
        {
            var bring = db.TBLSocialMedia.Find(param.Id);
            bring.SocialMediaName = param.SocialMediaName;
            bring.SocialMediaIcons = param.SocialMediaIcons;
            bring.SocialMediaLinks = param.SocialMediaLinks;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var bring = db.TBLSocialMedia.Find(id);
            db.TBLSocialMedia.Remove(bring);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}