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
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BookController booksController = new BookController();

            List<Book> bookList = booksController.GetBooks(string.Empty);

            repBooks.DataSource = bookList;
            repBooks.DataBind();
        }
        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {
            FirebaseUser user = new FirebaseUser()
            {
                email = txtEmail.Value,
                password = txtPwd.Value
            };

            LoginController loginController = new LoginController();

            user = loginController.FirebaseAuth(user);

            if (user.registered)
            {
                Session["session"] = user;

                UserNameIfLogged.InnerText = "Welcome " + user.displayName;

                //Mostranto el boton logout
                divLogout.Attributes.Remove("hidden");
                divMyBooks.Attributes.Remove("hidden");
                //Ocultando el login
                divLogin.Attributes.Add("hidden", "hidden");

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Login approved')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Login denied')", true);
            }
        }

        protected void btnLogout_ServerClick(object sender, EventArgs e)
        {
            //Mostrando el login
            divLogin.Attributes.Remove("hidden");
            //Ocultando el boton logout
            divLogout.Attributes.Add("hidden", "hidden");
            divMyBooks.Attributes.Add("hidden", "hidden");

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Session has been closed')", true);
            Session.Clear();
        }

        protected void btnSignUp_ServerClick(object sender, EventArgs e)
        {
            FirebaseUser user = new FirebaseUser()
            {
                displayName = txtDisplayName.Value,
                email = txtSignUpEmail.Value,
                password = txtSignUpPwd.Value
            };

            LoginController loginController = new LoginController();

            if (loginController.FirebaseSigUp(user))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sign Up completed')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sign Up failed')", true);
            }
        }
        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            string valor = txtSearch.Value;
            BookController booksController = new BookController();

            List<Book> bookList = booksController.GetBooks(valor);

            repBooks.DataSource = bookList;
            repBooks.DataBind();
        }
    }
}
