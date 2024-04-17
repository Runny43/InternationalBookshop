using InternationalBookshop.Controller;
using InternationalBookshop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InternationalBookshop.View
{
    public partial class Bill : System.Web.UI.Page
    {
        static decimal sumarprecios(List<Trolley> trolley)
        {
            decimal suma = 0;
            foreach (var trolleyPrice in trolley)
            {
                suma += trolleyPrice.Price;
            }
            return suma;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["session"] != null)
            {
                FirebaseUser user = (FirebaseUser)Session["session"];

                UserName.InnerText = "Welcome " + user.displayName;

                BookedController bookedController = new BookedController();

                TrolleyController trolleyController = new TrolleyController();

                List<Booked> bookedList = bookedController.GetBooked(user.email);

                repBills.DataSource = bookedList;
                repBills.DataBind();

            }
            else
            {
                Response.Redirect("main.aspx");
            }
        }

    }
}