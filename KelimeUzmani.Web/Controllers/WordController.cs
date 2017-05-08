using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KelimeUzmani.Web.Controllers
{
    public class WordController : Controller
    {
        // GET: Word
        public ActionResult Index()
        {
            ViewBag.Title = "Kelimeler";
            ViewBag.SmallTitle = "Yeni Kelimeler,Kayıtlı Listelerim";      
            return View();
        }
    }
}