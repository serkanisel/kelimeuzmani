namespace KelimeUzmani.Model
{
    public  class WordListWords
    {
        public int ID { get; set; }
        public int WordID { get; set; }
        public int WordListID { get; set; }

        public int UserID { get; set; }

        public bool isPublic { get; set; }


        public virtual WordList WordList { get; set; }
        public virtual User User { get; set; }

        public virtual Word Word { get; set; }
    }
}