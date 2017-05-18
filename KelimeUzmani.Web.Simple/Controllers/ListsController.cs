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
            List<WordList> list = iList.GetUserLists(2);

            return View(list);
        }

        public ActionResult SaveList(string name)
        {
            WordList wl = new WordList()
            {
                Name = name,
                UserID = 2
            };

            wl = iList.SaveWordList(wl);

            List<WordList> list = iList.GetUserLists(2);

            return PartialView("ListView", list);
        }

        [HttpPost]
        public ActionResult GetWordsOfList(int listID)
        {
            ViewBag.ListID = listID;
            return PartialView("WordOfList", iList.GetListByID(listID).WordListList);
        }

        [HttpPost]
        public ActionResult GetContentOfList(int listID)
        {
            WordList olist = iList.GetListByID(listID);
            ViewBag.ListID = listID;
            return PartialView(olist);
        }

        [HttpPost]
        public ActionResult AddWordToList(int listID, int wordID)
        {
            iList.AddWordToList(listID, wordID);

            List<WordListList> result = iList.GetWordLists(listID);

            return PartialView("WordTable", result);

        }

    }
}