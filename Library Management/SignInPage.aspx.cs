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
    public partial class SingIn : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signin_Click(object sender, EventArgs e)
        {
            try {
                SqlConnection conn = new SqlConnection(strcon);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl where member_id = '"+userid.Text.Trim()+"' AND password = '"+password.Text.Trim()+"';", conn);
                
                SqlDataReader reader= cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Response.Write("<script>alert('Login Successfully')</script>");
                        Session["username"] = reader.GetValue(8).ToString();
                        Session["fullname"] = reader.GetValue(0).ToString();
                        Session["role"] = "user";
                        Session["status"] = reader.GetValue(10).ToString();  
                        
                    }
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid UserName or Password. Please Enter Currect UserName or Password')</script>");
                }


            } catch (Exception ex) {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
            }
        }
    }
}