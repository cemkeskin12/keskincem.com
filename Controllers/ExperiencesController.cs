using CemKeskin.Models.Classes;
using CemKeskin.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CemKeskin.Controllers
{
    public class ExperiencesController : Controller
    {
        // GET: Experiences
        DatabaseCemKeskinEntities db = new DatabaseCemKeskinEntities();
        public ActionResult Index()
        {

            ForAdmin list = new ForAdmin();
            list.ExpPage = db.TBLExperiences.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> values = (from v in db.TBLResume.ToList()
                                           select new SelectListItem
                                           {
                                               Text = v.Positioning,
                                               Value = v.ResumeId.ToString()
                                           }).ToList();
            ViewBag.vls = values;
            return View();
        }
        [HttpPost]
        public ActionResult Create(TBLExperiences exp)
        {
            var rsm = db.TBLResume.Where(m => m.ResumeId == exp.TBLResume.ResumeId).FirstOrDefault();
            exp.TBLResume = rsm;
            db.TBLExperiences.Add(exp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Operations(int id) //basılan güncelle butonuna göre id getiriyor.
        {
            var bring = db.TBLExperiences.Find(id);
            List<SelectListItem> values = (from v in db.TBLResume.ToList()
                                           select new SelectListItem
                                           {
                                               Text = v.Positioning,
                                               Value = v.ResumeId.ToString()
                                           }).ToList();
            ViewBag.vls = values;
            return View("Operations", bring);
        }
        
        public ActionResult Update(TBLExperiences param)
        {
            var bring = db.TBLExperiences.Find(param.Id);
            bring.ExpTitle = param.ExpTitle;
            bring.ExpYear = param.ExpYear;
            bring.ExpContent = param.ExpContent;
            bring.ExpIcon = param.ExpIcon;
            var rsm = db.TBLResume.Where(m => m.ResumeId == param.TBLResume.ResumeId).FirstOrDefault();
            bring.ResumeId = rsm.ResumeId;
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var bring = db.TBLExperiences.Find(id);
            db.TBLExperiences.Remove(bring);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}