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
    public partial class PublisherManagementPage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView_Publisher.DataBind();
        }
        protected void Add_Publisher_Click(object sender, EventArgs e)
        {
            if (CheckIdExist())
            {
                Response.Write("<script>alert('Publisher ID Already Exist, Try Another ID');</script>");
            }
            else
            {
                Addpublisher();
            }
        }

        protected void Update_Publisher_Click(object sender, EventArgs e)
        {
            if (CheckIdExist())
            {
                UpdatePublisher();
            }
            else
            {
                Response.Write("<script>alert('Invalid Publisher ID, Enter Currect ID');</script>");
            }
        }

        protected void Delete_Publisher_Click(object sender, EventArgs e)
        {
            if (CheckIdExist())
            {
                Deletepublisher();
            }
            else
            {
                Response.Write("<script>alert('Invalid Publisher ID, Enter Currect ID');</script>");
            }
        }

        protected void Go_btn_Click(object sender, EventArgs e)
        {
            getPublisherId();
        }

        void getPublisherId()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM publisher_master_tbl WHERE publisher_id = '" + PublisherId.Text.Trim() + "'", conn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count >= 1)
                {
                    PublisherName.Text = dataTable.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Publisher ID, Enter Currect ID');</script>");

                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        bool CheckIdExist()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM publisher_master_tbl WHERE publisher_id = '"+PublisherId.Text.Trim()+"'", conn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd); 
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch(Exception ex)
            {
                Response.Write(ex.Message); 
                return false;
            }
        }

        void Addpublisher()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl (publisher_id, publisher_name) values (@publisher_id, @publisher_name)", conn);
                cmd.Parameters.AddWithValue("@publisher_id", PublisherId.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", PublisherName.Text.Trim());
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script>alert('Publisher ID Added Successfully');</script>");
                ClearForm();
                GridView_Publisher.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message); 
            }
        }

        void UpdatePublisher()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tbl SET publisher_name = '"+PublisherName.Text.Trim()+"' WHERE publisher_id = '"+PublisherId.Text.Trim()+"'", conn);
                cmd.ExecuteNonQuery ();
                conn.Close();
                Response.Write("<script>alert('Publisher ID Updated Successfully');</script>");
                ClearForm();
                GridView_Publisher.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        void Deletepublisher()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM publisher_master_tbl WHERE publisher_id = '"+PublisherId.Text.Trim()+"'", conn);
                cmd.ExecuteNonQuery () ;
                conn.Close();
                Response.Write("<script>alert('Publisher ID Deleted Successfully');</script>");
                ClearForm();
                GridView_Publisher.DataBind();
            }
            catch (Exception ex ) 
            {
                Response.Write (ex.Message);
            }
        }

        void ClearForm()
        {
            PublisherId.Text = "";
            PublisherName.Text = "";
        }

    }
}