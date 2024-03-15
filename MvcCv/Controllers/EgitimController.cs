using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<TblEgitimlerim> repo = new GenericRepository<TblEgitimlerim>();
        public ActionResult Index()
        {
            var egitim = repo.list();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.Tadd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            var egitimsil = repo.Find(x => x.ID == id);
            repo.TDelete(egitimsil);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimGüncelle (int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }
        [HttpPost]
        public ActionResult EgitimGüncelle(TblEgitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimGüncelle");
            }
            var egüncelle = repo.Find(x => x.ID == p.ID);
            egüncelle.Baslik = p.Baslik;
            egüncelle.AltBaslik1 = p.AltBaslik1;
            egüncelle.AltBaslik2 = p.AltBaslik2;
            egüncelle.GNO = p.GNO;
            egüncelle.Tarih = p.Tarih;
            repo.TUpdate(egüncelle);
            return RedirectToAction("Index");
        }
    }
}