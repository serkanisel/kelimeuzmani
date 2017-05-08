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
    public class WordBS : IWord
    {
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
    }
}
