using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeUzmani.Model
{
    public class SampleSentence
    {
        public SampleSentence()
        {
            this.Word = new Word();
        }
        public int ID { get; set; }

        public int WordID { get; set; }

        public string Sentence { get; set; }


        public virtual Word Word { get; set; }
    }
}
