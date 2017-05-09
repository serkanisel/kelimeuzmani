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
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveWord(string word, string mean, string sample)
        {
            try
            {
                IWord iWord = new WordBS();
                Word oWord = new Word()
                {
                    Description = mean,
                    WordBody = word,
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
            IWord iword = new WordBS();

            List<Word> result= iword.SearchWord(searchText);
            ViewBag.ID = listID;
            return PartialView("SearchList", result);
        }

        [HttpGet]
        public ActionResult GetSearchWord(int listID=0)
        {
            ViewBag.ID = listID;
            return PartialView();
        }
    }
}