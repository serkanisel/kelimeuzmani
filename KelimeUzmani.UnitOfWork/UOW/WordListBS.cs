﻿using KelimeUzmani.UnitOfWork.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KelimeUzmani.Entity;
using KelimeUzmani.Repository;

namespace KelimeUzmani.UnitOfWork.UOW
{
    public class WordListBS : IWordList, IDisposable
    {
        public void Dispose()
        {
            this.Dispose();
        }

        public WordList GetListByID(int listID)
        {
            RepositoryBase<WordList> _rep = new RepositoryBase<WordList>();

            return _rep.Get(p => p.ID == listID);

        }

        public List<WordList> GetUserLists(int userID)
        {
            RepositoryBase<WordList> _rep = new RepositoryBase<WordList>();

            List<WordList> lists = _rep.GetList(p => p.UserID == userID);

            return lists;
        }

        public WordList SaveWordList(WordList wordList)
        {
            RepositoryBase<WordList> _rep = new RepositoryBase<WordList>();

            wordList = _rep.Add(wordList);

       
            return wordList;
        }




    }
}
