using InternationalBookshop.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace InternationalBookshop.Controller
{
    public class BookedController
    {
        public void SaveBooked(Booked booked)
        {
            DatabaseHelper.Database database = new DatabaseHelper.Database();

            database.SaveBooked(booked);
        }

        public List<Booked> GetBooked(string user)
        {
            List<Booked> bookedList = new List<Booked>();

            DatabaseHelper.Database database = new DatabaseHelper.Database();
            DataTable dsTrolley = database.GetBooked(user);

            foreach (DataRow dr in dsTrolley.Rows)
            {
                bookedList.Add(new Booked
                {
                    BookId = (int)dr["bookid"],
                    Name = dr["name"].ToString(),
                    Email = dr["email"].ToString(),
                    Country = dr["country"].ToString(),
                    Province = dr["province"].ToString(),
                    Address = dr["address"].ToString(),
                    PostalCode = (int)dr["postalcode"],
                    CardNumber = (int)dr["cardnumber"],
                    Checkout = Convert.ToDateTime(dr["checkout"]),
                    SecurityCode= (int)dr["securitycode"],
                    Total = (int)dr["price"]
                }) ;
            }

            return bookedList;
        }
    }
}