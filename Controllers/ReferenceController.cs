using CemKeskin.Models.Classes;
using CemKeskin.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CemKeskin.Controllers
{
    public class ReferenceController : Controller
    {
        DatabaseCemKeskinEntities db = new DatabaseCemKeskinEntities();
        public ActionResult Index()
        {

            ForAdmin list = new ForAdmin();
            list.ReferencePage = db.TBLReferences.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TBLReferences reference)
        {
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                string path = "~/Images/" + _filename;
                Request.Files[0].SaveAs(Server.MapPath(path));
                reference.ReferenceImages = "/Images/" + _filename;
            }
            db.TBLReferences.Add(reference);
            db.SaveChanges();
            return View();
        }
        public ActionResult Operations(int id) //basılan güncelle butonuna göre id getiriyor.
        {
            var bring = db.TBLReferences.Find(id);
            return View("Operations", bring);
        }
        public ActionResult Update(TBLReferences param)
        {
            var bring = db.TBLReferences.Find(param.Id);
            bring.ReferenceTitle = param.ReferenceTitle;
            bring.ReferenceContent = param.ReferenceContent;
            bring.ReferencesLinks = param.ReferencesLinks;
            //string currentImg = Request.MapPath(bring.ReferenceImages);
            bring.ReferenceImages = "/Images/" + param.ReferenceImages;
            //string newImg = Request.MapPath(bring.ReferenceImages);
            //veri tabanından silinen resmin images içinden de silinmesini sağlıyoruz.
            //if (db.SaveChanges() > 0)
            //{
            //    if (System.IO.File.Exists(newImg))
            //    {
            //        System.IO.File.Copy(newImg,currentImg);
            //  }
            //}

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var bring = db.TBLReferences.Find(id); //bring = getirmek.
            string currentImg = Request.MapPath(bring.ReferenceImages);
            db.Entry(bring).State = EntityState.Deleted; //veri tabanından silinen resmin images içinden de silinmesini sağlıyoruz.
            if (db.SaveChanges() > 0)
            {
                if (System.IO.File.Exists(currentImg))
                {
                    System.IO.File.Delete(currentImg);
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
