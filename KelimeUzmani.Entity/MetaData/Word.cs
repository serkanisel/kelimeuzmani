using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeUzmani.Entity
{
    partial class Word
    {
        private string _descptionHTML;
        public string DescriptionHTML
        {
            get
            {
                _descptionHTML = Description;
                _descptionHTML = _descptionHTML.Replace("&lt;", "<");
                _descptionHTML = _descptionHTML.Replace("&gt;", ">");
                return _descptionHTML;
            }
        }
    }
}
