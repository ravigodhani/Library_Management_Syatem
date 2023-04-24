using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void signin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM admin_login_tbl where username = '"+username_admin.Text.Trim()+"' AND password = '"+password_admin.Text.Trim()+"';", conn);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        Response.Write("<script>alert('Login Successfully')</script>");
                        Session["username"] = sqlDataReader.GetValue(0).ToString();
                        Session["fullname"] = sqlDataReader.GetValue(2).ToString();
                        Session["role"] = "admin";
                    }
                    Response.Redirect("AdminBookInventoryPage.aspx");
                }
                else 
                {
                    Response.Write("<script>alert('Invalid UserName or Password. Please Enter Currect UserName or Password')</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}