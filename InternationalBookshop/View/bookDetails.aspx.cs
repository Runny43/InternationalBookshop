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
    public partial class bookDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["session"] != null)
            {
                FirebaseUser user = (FirebaseUser)Session["session"];

                UserNameIfLogged.InnerText = "Welcome " + user.displayName;

                int id = Convert.ToInt16(Request.QueryString["id"]);

                BookController bookController = new BookController();

                List<Book> bookList = bookController.GetBook(id);

                repBook.DataSource = bookList;
                repBook.DataBind();
            }
            else
            {
                Response.Redirect("main.aspx");
            }
        }
        protected void btnSaveTrolley_ServerClick(object sender, EventArgs e)
        {
            TrolleyController trolleyController = new TrolleyController();

            FirebaseUser user = (FirebaseUser)Session["session"];

            int id = Convert.ToInt16(Request.QueryString["id"]);

            BookController bookController = new BookController();

            List<Book> bookList = bookController.GetBook(id);

            Trolley trolley = new Trolley
            {
                bookid = Convert.ToInt16(Request.QueryString["id"]),
                name = user.displayName,
                email = user.email,
                ISBN = Convert.ToString(bookList[0].ISBN),
                PhotoPath= Convert.ToString(bookList[0].PhotoPath),
                Title= Convert.ToString(bookList[0].Title),
                Author= Convert.ToString(bookList[0].Author),
                PublicationDate= Convert.ToDateTime(bookList[0].PublicationDate),
                Price = Convert.ToDecimal(bookList[0].Price)
            };

            trolleyController.SaveTrolley(trolley);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your trip was saved successfully')", true);
        }
    }
}