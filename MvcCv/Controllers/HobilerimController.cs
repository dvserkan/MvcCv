using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

using MvcCv.Repositories;
namespace MvcCv.Controllers
{
    public class HobilerimController : Controller
    {
        // GET: Hobilerim
        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();

        public ActionResult Index()
        {
            var degerler = repo.list();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult HobiEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HobiEkle(TblHobilerim p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult HobiGetir(int id)
        {
            var degerler = repo.Find(x => x.ID == id);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult HobiGetir(TblHobilerim p)
        {
            var degerler = repo.Find(x => x.ID == p.ID);
            degerler.Aciklama1 = p.Aciklama1;
            degerler.Aciklama2 = p.Aciklama2;
            repo.TUpdate(degerler);
            return RedirectToAction("Index");
        }
        public ActionResult HobiSil(int id)
        {
            var degerler = repo.Find(x => x.ID == id);
            repo.TDelete(degerler);
            return RedirectToAction("Index");
        }
    }
}