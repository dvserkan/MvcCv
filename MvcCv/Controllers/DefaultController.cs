using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default

        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var degerler = db.TblHakkinda.ToList();
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TblSosyalMedya.Where(x=>x.Durum==true).ToList();
            return PartialView(sosyalmedya);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TblDeneyimlerim.ToList();
            var sırala = (from TblDeneyimlerim x in deneyimler orderby x.ID descending select x).ToList();
            return PartialView(sırala);
        }
        public PartialViewResult Egitimlerim()
        {
            var egitimlerim = db.TblEgitimlerim.ToList();
            return PartialView(egitimlerim);
        }
        public PartialViewResult Yeteneklerim()
        {
            var yeteneklerim = db.TblYeteneklerim.ToList();
            return PartialView(yeteneklerim);
        }
        public PartialViewResult Hobilerim()
        {
            var hobilerim = db.TblHobilerim.ToList();
            return PartialView(hobilerim);
        }
        public PartialViewResult Sertifikalar()
        {
            var sertfikalarım = db.TblSertifikalarım.ToList();
            return PartialView(sertfikalarım);
        }
        [HttpGet]
        public PartialViewResult İletisim()
        {
            var iletisim = db.Tbliletisim.ToList();
            return PartialView(iletisim);
        }
        [HttpPost]
        public PartialViewResult İletisim(Tbliletisim t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbliletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}