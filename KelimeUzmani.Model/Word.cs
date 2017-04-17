using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeUzmani.Model
{
    public class Word
    {
        public Word()
        {
            this.WordListWords = new List<WordListWords>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MaxLength(200)]
        [Display(Name = "Global Number")]
        public string WordBody { get; set; }

        public string Description { get; set; }

        
        public virtual ICollection<WordListWords> WordListWords { get; set; }
    }
}
