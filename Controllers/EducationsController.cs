using CemKeskin.Models.Classes;
using CemKeskin.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CemKeskin.Controllers
{
    public class EducationsController : Controller
    {
        // GET: Educations
        DatabaseCemKeskinEntities db = new DatabaseCemKeskinEntities();
        public ActionResult Index()
        {

            ForAdmin list = new ForAdmin();
            list.EducationPage = db.TBLEducation.ToList();
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
        public ActionResult Create(TBLEducation edu)
        {
            var rsm = db.TBLResume.Where(m => m.ResumeId == edu.TBLResume.ResumeId).FirstOrDefault();
            edu.TBLResume = rsm;
            db.TBLEducation.Add(edu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Operations(int id) //basılan güncelle butonuna göre id getiriyor.
        {
            var bring = db.TBLEducation.Find(id);
            List<SelectListItem> values = (from v in db.TBLResume.ToList()
                                           select new SelectListItem
                                           {
                                               Text = v.Positioning,
                                               Value = v.ResumeId.ToString()
                                           }).ToList();
            ViewBag.vls = values;
            return View("Operations", bring);
        }

        public ActionResult Update(TBLEducation param)
        {
            var bring = db.TBLEducation.Find(param.Id);
            bring.EducationTitle = param.EducationTitle;
            bring.EducationYear = param.EducationYear;
            bring.EducationContent = param.EducationContent;
            bring.EducationIcon = param.EducationIcon;
            var rsm = db.TBLResume.Where(m => m.ResumeId == param.TBLResume.ResumeId).FirstOrDefault();
            bring.ResumeId = rsm.ResumeId;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var bring = db.TBLEducation.Find(id);
            db.TBLEducation.Remove(bring);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}