using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;
namespace MvcCv.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        GenericRepository<Tbliletisim> repo = new GenericRepository<Tbliletisim>();
        public ActionResult Index()
        {
            var degerler = repo.list();
            var sırala = (from Tbliletisim x in degerler orderby x.ID descending select x).ToList();
            return View(sırala);
        }
        [HttpGet]
        public ActionResult iletisimGetir()
        {
            return View();
        }
    }
}