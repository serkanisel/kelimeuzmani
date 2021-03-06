﻿using KelimeUzmani.Entity;
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

        void AddWordToList(int listID, int wordID);

        List<WordListList> GetWordLists(int listID);

        List<WordList> GetAllWordList();

        Word GetNextWord(int listID, int index); 

    }
}
