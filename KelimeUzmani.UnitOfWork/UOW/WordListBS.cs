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
    public class WordListBS : IWordList, IDisposable
    {
        public void AddWordToList(int listID, int wordID)
        {
            RepositoryBase<WordListList> _rep = new RepositoryBase<WordListList>();
            //sorgula, ekli değilse listeye ekle. 
            if (_rep.Get(p => p.WordListID == listID && p.WordID == wordID) == null)
            {

                WordListList list = new WordListList()
                {
                    isPublic = true,
                    WordID = wordID,
                    WordListID = listID,
                };


                _rep.Add(list);
            }
        }

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

        public List<WordListList> GetWordLists(int listID)
        {
            RepositoryBase<WordListList> _rep = new RepositoryBase<WordListList>();

            return _rep.GetList(p => p.WordListID == listID);
        }

        public WordList SaveWordList(WordList wordList)
        {
            RepositoryBase<WordList> _rep = new RepositoryBase<WordList>();

            wordList = _rep.Add(wordList);


            return wordList;
        }

        public List<WordList> GetAllWordList()
        {
            RepositoryBase<WordList> _rep = new RepositoryBase<WordList>();

            return _rep.GetList();
        }

        public Word GetNextWord(int listID, int index)
        {
            List<WordListList> lists = GetWordLists(listID);

            RepositoryBase<Word> _rep = new RepositoryBase<Word>(false);
            int wordID = lists[index].Word.ID;

            return _rep.Get(p => p.ID==wordID); 
        }
    }
}
