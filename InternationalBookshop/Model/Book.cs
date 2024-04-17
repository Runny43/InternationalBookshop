using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternationalBookshop.Model
{
    public class Book
    {
        public int bookid { get; set; }
        public string ISBN { get; set; }
        public string PhotoPath { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }
    }
}