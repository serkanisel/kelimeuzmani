using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeUzmani.Model
{
    public class WordList
    {
        public WordList()
        {
            this.WordListWords = new List<WordListWords>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<WordListWords> WordListWords { get; set; } 
    }
}
