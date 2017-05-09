using KelimeUzmani.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeUzmani.UnitOfWork.Contract
{
    public interface IWordList
    {
        List<WordList> GetUserLists(int userID);
        WordList SaveWordList(WordList wordList);

        WordList GetListByID(int listID);
    }
}
