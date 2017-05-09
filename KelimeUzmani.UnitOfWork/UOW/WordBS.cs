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

        public Word SaveWord(Word word)
        {
            RepositoryBase<Word> _rep = new RepositoryBase<Word>();

            word = _rep.Add(word);

            //RepositoryBase<SampleSentence> _repSen = new RepositoryBase<SampleSentence>();

            //foreach (var item in word.SampleSentence)
            //{
            //    item.WordID = word.ID;
            //    _repSen.Add(item);
            //}


            return word;
        }

        public List<Word> SearchWord(string searchText)
        {
            RepositoryBase<Word> _rep = new RepositoryBase<Word>();

            return _rep.GetList(p => p.WordBody.StartsWith(searchText));

        }
    }
}
