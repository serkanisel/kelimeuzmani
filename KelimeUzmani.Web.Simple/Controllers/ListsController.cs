using KelimeUzmani.Entity;
using KelimeUzmani.UnitOfWork.Contract;
using KelimeUzmani.UnitOfWork.UOW;
using PagedList;
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
            return PartialView("WordOfList", (IPagedList)iList.GetListByID(listID).WordListList.Take(10));
        }

        [HttpPost]
        public ActionResult GetContentOfList(int listID)
        {
            List<WordListList> olist = iList.GetWordLists(listID);
            ViewBag.ListID = listID;
            return PartialView("WordOfList",olist.Take(10));
        }

        [HttpPost]
        public ActionResult AddWordToList(int listID, int wordID)
        {
            iList.AddWordToList(listID, wordID);

            List<WordListList> result = iList.GetWordLists(listID);


            return PartialView("WordTable", (IPagedList)result);

        }

        public ActionResult  WordList(int ID)
        {
            WordList result= iList.GetListByID(ID);
            return View(result);
        }

        public ActionResult WordTable(int listID,int count)
        {
            return PartialView("WordTable", iList.GetWordLists(listID).Take(count));
        }

        [HttpPost]
        public ActionResult GetPreviewScreen(int listID)
        {
            List<WordListList> result= iList.GetWordLists(listID);

            
            return PartialView(result[0].Word);
        }

    }
}