using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;


namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika

        GenericRepository<TblSertifikalarım> repo = new GenericRepository<TblSertifikalarım> ();
        public ActionResult Index()
        {
            var sertifika = repo.list();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertfikagetir = repo.Find(x => x.ID == id);
            ViewBag.d = id;
            return View(sertfikagetir);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(TblSertifikalarım p)
        {
            var sertfikagetir = repo.Find(x => x.ID == p.ID);
            sertfikagetir.Tarih = p.Tarih;
            sertfikagetir.Aciklama = p.Aciklama;
            repo.TUpdate(sertfikagetir);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SertifikaEkle(TblSertifikalarım p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {
            var sertifikasil = repo.Find(x => x.ID == id);
            repo.TDelete(sertifikasil);
            return RedirectToAction("Index");
        }
    }
}