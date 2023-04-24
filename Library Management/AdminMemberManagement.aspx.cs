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
    public partial class AdminMemberManagement : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView_member.DataBind();
        }

        protected void Go_member_Click(object sender, EventArgs e)
        {
            getMemberByID();
        }

        protected void Active_btn_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("Active");
        }

        protected void Panding_btn_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("Panding");
        }

        protected void Deactive_btn_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("Deactive");
        }

        protected void deleteuser_member_Click(object sender, EventArgs e)
        {
            deleteMemberByID();
        }

        bool checkIfMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id='" + member_id_manage.Text.Trim() + "';", con);
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
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void deleteMemberByID()
        {
            if (checkIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE FROM member_master_tbl WHERE member_id='" + member_id_manage.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Member Deleted Successfully');</script>");
                    clearForm();
                    GridView_member.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID');</script>");
            }
        }

        void getMemberByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl where member_id='" + member_id_manage.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        FullName_mamber.Text = dr.GetValue(0).ToString();
                        Account_status_member.Text = dr.GetValue(10).ToString();
                        DOB_member.Text = dr.GetValue(1).ToString();
                        Contact_member.Text = dr.GetValue(2).ToString();
                        email_member.Text = dr.GetValue(3).ToString();
                        state_member.Text = dr.GetValue(4).ToString();
                        city_mamber.Text = dr.GetValue(5).ToString();
                        pincode_mamber.Text = dr.GetValue(6).ToString();
                        fulladdress_member.Text = dr.GetValue(7).ToString();

                    }

                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void updateMemberStatusByID(string status)
        {
            if (checkIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                    }
                    SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status='" + status + "' WHERE member_id='" + member_id_manage.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView_member.DataBind();
                    Response.Write("<script>alert('Member Status Updated');</script>");


                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID');</script>");
            }

        }

        void clearForm()
        {
            FullName_mamber.Text = "";
            Account_status_member.Text = "";
            DOB_member.Text = "";
            Contact_member.Text = "";
            email_member.Text = "";
            state_member.Text = "";
            city_mamber.Text = "";
            pincode_mamber.Text = "";
            fulladdress_member.Text = "";
        }

        
    }
}