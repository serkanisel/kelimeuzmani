namespace KelimeUzmani.DBFirst.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SampleSentence")]
    public partial class SampleSentence
    {
        public int ID { get; set; }

        public int WordID { get; set; }

        public string Sentence { get; set; }

        public virtual Word Word { get; set; }
    }
}
