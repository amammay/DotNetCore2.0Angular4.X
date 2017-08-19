using System;
using System.Collections.Generic;
using System.Text;

namespace PsuSearch.Models
{
    public class SearchForm
    {
        public string Sn { get; set; }
        public string Cn { get; set; }
        public string Uid { get; set; }
        public string Mail { get; set; }
        public PsuSearchEnum Full { get; set; }
    }
}
