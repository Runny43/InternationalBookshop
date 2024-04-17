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
    public partial class MyBooks : System.Web.UI.Page
    {
        static decimal sumarprecios(List<Trolley> trolley)
        {
            decimal suma = 0;
            foreach(var trolleyPrice in trolley)
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

                UserNameIfLogged.InnerText = "Welcome " + user.displayName;



                TrolleyController trolleyController = new TrolleyController();

                List<Trolley> trolleyList = trolleyController.GetTrolley(user.email);

                decimal suma = sumarprecios(trolleyList);

                PrecioTotal.InnerText = suma.ToString();
                

                repTrolley.DataSource = trolleyList;
                repTrolley.DataBind();

            }
            else
            {
                Response.Redirect("main.aspx");
            }
        }
        public void btnBuyBooks_ServerClick(object sender, EventArgs e)
        {
            TrolleyController trolleyController = new TrolleyController();

            FirebaseUser user = (FirebaseUser)Session["session"];

            BookedController bookedController = new BookedController();
            List<Trolley> trolleyList = trolleyController.GetTrolley(user.email);

            
            
            Booked booked = new Booked
            {
                BookId= Convert.ToInt16(trolleyList[0].bookid),
                
                Name = user.displayName,
                Email = user.email,
                Country = txtCountry.Value,
                Province = Convert.ToString(bookList[0].PhotoPath),
                Address = txtAddress.Value,
                PostalCode = (int)(txtPostalCode.Value),
                CardNumber= Convert.ToInt16(txtCardNumber.Value),
                Checkout = Convert.ToDateTime(dtCheckOut.Value),
                Total = (int)sumarprecios(trolleyList)
            };
           
            bookedController.SaveBooked(booked);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your trip was saved successfully')", true);
        
    }
    }
}