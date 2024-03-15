using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;
namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        GenericRepository<TblHakkinda> repo = new GenericRepository<TblHakkinda>();

        public ActionResult Index()
        {
            var degerler = repo.list();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult HakkindaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HakkindaEkle(TblHakkinda p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult HakkindaGetir(int id)
        {
            var degerler = repo.Find(x => x.ID == id);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult HakkindaGetir(TblHakkinda p)
        {
            var degerler = repo.Find(x => x.ID == p.ID);
            degerler.Ad = p.Ad;
            degerler.Soyad = p.Soyad;
            degerler.Adres = p.Adres;
            degerler.Mail = p.Mail;
            degerler.Telefon = p.Telefon;
            degerler.Aciklama = p.Aciklama;
            degerler.Resim = p.Resim;
            repo.TUpdate(degerler);
            return RedirectToAction("Index");
        }
        public ActionResult HakkindaSil(int id)
        {
            var degerler = repo.Find(x => x.ID == id);
            repo.TDelete(degerler);
            return RedirectToAction("Index");
        }
    }
}
