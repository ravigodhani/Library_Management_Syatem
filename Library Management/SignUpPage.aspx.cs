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
    public partial class SingUpPage : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signup_Click(object sender, EventArgs e)
        {
            if (CheckMemberExits())
            {
                Response.Write("<script>alert('User Already Exist with User ID Try Other ID')</script>");
            }
            else
            {
                NewSignUpUser();
            }

        }


        bool CheckMemberExits()
        {

            SqlConnection conn = new SqlConnection(strcon);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl where member_id = '" + useridup.Text.Trim() + "';", conn); ;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count >= 1)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        void NewSignUpUser()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl(full_name, dob, contact_no, email, state, city, pinecode, full_address, member_id, password, account_status) " +
                    "values (@full_name, @dob, @contact_no, @email, @state, @city, @pinecode, @full_address, @member_id, @password, @account_status)", conn);

                cmd.Parameters.AddWithValue("@full_name", fullnameup.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", dateofbirthup.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", contactnumberup.Text.Trim());
                cmd.Parameters.AddWithValue("@email", emailidup.Text.Trim());
                cmd.Parameters.AddWithValue("@state", stateup.SelectedItem.Value.Trim());
                cmd.Parameters.AddWithValue("@city", cityup.Text.Trim());
                cmd.Parameters.AddWithValue("@pinecode", pinecodeup.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", fulladdressup.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", useridup.Text.Trim());
                cmd.Parameters.AddWithValue("@password", passwordup.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "padding");

                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Sign Up Successfully. Go To User Login to Login')</script>");
                conn.Close();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}