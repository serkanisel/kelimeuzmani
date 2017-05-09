using KelimeUzmani.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeUzmani.UnitOfWork.Contract
{
    public interface IWord
    {
        Word SaveWord(Word word);

        List<Word> SearchWord(string searchText);
    }
}
