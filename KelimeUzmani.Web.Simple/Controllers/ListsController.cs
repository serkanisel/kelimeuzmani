using KelimeUzmani.Entity;
using KelimeUzmani.UnitOfWork.Contract;
using KelimeUzmani.UnitOfWork.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KelimeUzmani.Web.Simple.Controllers
{
    public class ListsController : Controller
    {
        // GET: Lists
        IWordList iList = new WordListBS();
        public ActionResult Index()
        {
            List<WordList>  list= iList.GetUserLists(1);

            return View(list);
        }

        public ActionResult SaveList(string name)
        {
            WordList wl = new WordList()
            {
                Name = name,
                UserID = 1
            };

            wl = iList.SaveWordList(wl);

            List<WordList> list = iList.GetUserLists(1);

            return PartialView("ListView",list);
        }

       }
}