using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace PsuSearch.Models
{
    public class PsuShortResult
    {
        public string Name { get; set; }
        public MailAddress Email { get; set; }
        public string MailId { get; set;}
        public string Title { get; set; }
        public string AdminArea { get; set; }
        public string Campus { get; set; }
        public string Curriculum { get; set; }

    }
}
