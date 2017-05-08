namespace KelimeUzmani.DBFirst.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WordListList")]
    public partial class WordListList
    {
        public int ID { get; set; }

        public int WordID { get; set; }

        public int WordListID { get; set; }

        public bool isPublic { get; set; }

        public virtual Word Word { get; set; }

        public virtual WordList WordList { get; set; }
    }
}
