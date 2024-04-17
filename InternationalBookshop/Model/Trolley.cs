using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternationalBookshop.Model
{
    public class Trolley
    {
        public int trolleyid { get; set; }
        public int bookid { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string ISBN { get; set; }
        public string PhotoPath { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }
    }
}