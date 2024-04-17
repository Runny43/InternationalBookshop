using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternationalBookshop.Model
{
    public class Booked
    {
        public int BookedId { get; set; }
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public int CardNumber { get; set; }
        public DateTime Checkout { get; set; }
        public int SecurityCode { get; set; }
        public int Total { get; set; }
    }
}