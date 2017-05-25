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
    public class WordController : Controller
    {
        // GET: Word
        IWord iWord = new WordBS();

        public ActionResult Index()
        {
            List<Word> result = iWord.GetUserWords(1); // kullanıcının id'si gelecek bu kısıma.
            ViewBag.fromIndex = 1;
            return View(result);
        }

        [HttpPost]
        public ActionResult SaveWord(string word, string mean, string sample)
        {
            try
            {
                Word oWord = new Word()
                {
                    Description = mean,
                    WordBody = word,
                    UserID=1,
                };

                oWord.SampleSentence = new List<SampleSentence>();
                SampleSentence smp = new SampleSentence()
                {
                    Sentence = sample,
                };

                oWord.SampleSentence.Add(smp);

                oWord = iWord.SaveWord(oWord);
                ViewData["Message"] = "Kayıt tamamlandı.";

                return PartialView("Message");
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.ToString();
                return PartialView("Error");
            }

            

        }

        [HttpPost]
        public ActionResult SearchWord(string searchText,int listID)
        {
            if(searchText==string.Empty)
                return PartialView("SearchList", null);

            List<Word> result= iWord.SearchWord(searchText);
            ViewBag.ListID = listID;
            return PartialView("SearchList", result);
        }

        [HttpGet]
        public ActionResult GetSearchWord(int listID=0)
        {
            ViewBag.ID = listID;
            return PartialView();
        }

        [HttpPost]
        public ActionResult GetUserWords(int userID)
        {
            List<Word> result = iWord.GetUserWords(1); // kullanıcının id'si gelecek bu kısıma.
            ViewBag.fromIndex = 1;
            return PartialView("SearchList", result);
        }

       
    }
}