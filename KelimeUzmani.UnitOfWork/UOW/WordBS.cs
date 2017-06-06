using KelimeUzmani.UnitOfWork.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KelimeUzmani.Entity;
using KelimeUzmani.Repository;

namespace KelimeUzmani.UnitOfWork.UOW
{
    public class WordBS : IWord, IDisposable
    {
        public void Dispose()
        {
            this.Dispose();
        }

        public List<Word> GetUserWords(int userID)
        {
            RepositoryBase<Word> _rep = new RepositoryBase<Word>();

            return _rep.GetList(p => p.UserID == userID);
        }

        public Word SaveWord(Word word, int WordListID = 0)
        {
            RepositoryBase<Word> _rep = new RepositoryBase<Word>();

            //sorgula eğer yoksa ekle. 
            Word wTemp = _rep.Get(p => p.WordBody == word.WordBody);
            if (wTemp == null)
            {
                word = _rep.Add(word);
                //kelimeyi listeye ekle.
                if (WordListID != 0)
                    ListeyeEkle(word, WordListID);
                return word;
            }
            else
            {
                if (WordListID != 0)
                    ListeyeEkle(wTemp, WordListID);
                return wTemp;
            }


            //RepositoryBase<SampleSentence> _repSen = new RepositoryBase<SampleSentence>();

            //foreach (var item in word.SampleSentence)
            //{
            //    item.WordID = word.ID;
            //    _repSen.Add(item);
            //}

        }

        public void ListeyeEkle(Word word, int ListID)
        {
            RepositoryBase<WordListList> _rep = new RepositoryBase<WordListList>();

            WordListList wlist = new WordListList();
            wlist.isPublic = true;
            wlist.WordID = word.ID;
            wlist.WordListID = ListID;
            _rep.Add(wlist);
        }

        public List<Word> SearchWord(string searchText)
        {
            RepositoryBase<Word> _rep = new RepositoryBase<Word>();

            return _rep.GetList(p => p.WordBody.StartsWith(searchText));

        }
    }
}
