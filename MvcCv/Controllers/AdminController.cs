using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;
namespace MvcCv.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();
        public ActionResult Index()
        {
            var liste = repo.list();
            return View(liste);
        }

        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminEkle(TblAdmin p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }
        public ActionResult AdminSil(int id)
        {
            var sil = repo.Find(x => x.ID == id);
            repo.TDelete(sil);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AdminGetir(int id)
        {
            var getir = repo.Find(x => x.ID == id);
            return View(getir);
        }

        [HttpPost]
        public ActionResult AdminGetir(TblAdmin p)
        {
            var degerler = repo.Find(x => x.ID == p.ID);
            degerler.KullaniciAdi = p.KullaniciAdi;
            degerler.Sifre = p.Sifre;
            repo.TUpdate(degerler);
            return RedirectToAction("Index");
        }
    }
}