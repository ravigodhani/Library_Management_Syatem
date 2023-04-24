using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].Equals("admin"))
                {
                    author.Visible = true;
                    publisher.Visible = true;
                    book_inventory.Visible = true;  
                    BookIssuing.Visible = true;
                    member.Visible = true;
                    Logout.Visible = true;  
                }
                else
                {
                    author.Visible = false;
                    publisher.Visible = false;
                    book_inventory.Visible = false;
                    BookIssuing.Visible = false;
                    member.Visible = false;
                    Logout.Visible = false;
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void AM_Click(object sender, EventArgs e)
        {
            Response.Redirect("AuthorManagementPage.aspx");
        }

        protected void PM_Click(object sender, EventArgs e)
        {
            Response.Redirect("PublisherManagementPage.aspx");
        }

        protected void BI_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminBookInventoryPage.aspx");
        }

        protected void BookIssuing_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminBookIssuingPage.aspx");
        }

        protected void MM_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminMemberManagement.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";

            author.Visible = false;
            publisher.Visible = false;
            book_inventory.Visible = false;
            BookIssuing.Visible = false;
            member.Visible = false;
            Logout.Visible = false;

            Response.Redirect("AdminLogin.aspx");
        }
    }
}