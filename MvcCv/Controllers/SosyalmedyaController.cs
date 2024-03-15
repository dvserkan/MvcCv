using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SosyalmedyaController : Controller
    {
        // GET: Sosyalmedya
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();
        public ActionResult Index()
        {
            var veriler = repo.list();
            return View(veriler);
        }
        [HttpGet]
        public ActionResult SosyalmedyaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SosyalmedyaEkle(TblSosyalMedya p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SosyalmedyaGetir(int id)
        {
            var degerler = repo.Find(x => x.ID == id);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult SosyalmedyaGetir(TblSosyalMedya p )
        {
            var degerler = repo.Find(x => x.ID == p.ID);
            degerler.Ad = p.Ad;
            degerler.Durum = true;
            degerler.ikon = p.ikon;
            degerler.Link = p.Link;
            repo.TUpdate(degerler);
            return RedirectToAction("Index");
        }
        public ActionResult SosyalmedyaSil(int id)
        {
            var degerler = repo.Find(x => x.ID == id);
            degerler.Durum = false;
            repo.TUpdate(degerler);
            return RedirectToAction("Index");
        }

    }
}