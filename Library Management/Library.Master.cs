using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management
{
    public partial class Library : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].Equals("user"))
                {
                    signUp.Visible = false;
                    UserLogin.Visible = false;
                    Logout.Visible = true;
                }
                else
                {
                    signUp.Visible = true;
                    UserLogin.Visible = true;
                    Logout.Visible = false;
                }
            }
            catch(Exception ex)
            {
            }
            
        }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void AboutUs_Click(object sender, EventArgs e)
        {

        }

        protected void Terms_Click(object sender, EventArgs e)
        {

        }

        protected void ViewBooks_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewBooksPage.aspx");
        }

        protected void signUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUpPage.aspx");
        }

        protected void UserLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignInPage.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";

            signUp.Visible = true;
            UserLogin.Visible = true;
            Logout.Visible = false;
        }
    }
}