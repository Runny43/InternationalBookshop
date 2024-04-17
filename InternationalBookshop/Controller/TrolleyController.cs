using InternationalBookshop.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace InternationalBookshop.Controller
{
    public class TrolleyController
    {
        public void SaveTrolley(Trolley trolley)
        {
            DatabaseHelper.Database database = new DatabaseHelper.Database();

            database.SaveTrolley(trolley);
        }

        public List<Trolley> GetTrolley(string user)
        {
            List<Trolley> trolleyList = new List<Trolley>();

            DatabaseHelper.Database database = new DatabaseHelper.Database();
            DataTable dsTrolley = database.GetTrolley(user);

            foreach (DataRow dr in dsTrolley.Rows)
            {
                trolleyList.Add(new Trolley
                {
                    bookid = (int)dr["bookid"],
                    name= dr["Name"].ToString(),
                    email= dr["email"].ToString(),
                    ISBN = dr["ISBN"].ToString(),
                    PhotoPath = dr["photoPath"].ToString(),
                    Title = dr["title"].ToString(),
                    Author = dr["author"].ToString(),
                    PublicationDate = Convert.ToDateTime(dr["publicationdate"]),
                    Price = (decimal)dr["Price"]
                });
            }

            return trolleyList;
        }
        

    }
}