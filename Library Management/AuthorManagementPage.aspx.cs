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
    public partial class AuthorManagementPage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView_author.DataBind();
        }

        protected void Add_author_Click(object sender, EventArgs e)
        {
            if (CheckIfAuthorExist())
            {
                Response.Write("<script>alert('Author ID Already Exist, Try Another ID');</script>");
            }
            else
            {
                AddAuthor();
            }
        }

        protected void Update_author_Click(object sender, EventArgs e)
        {
            if (CheckIfAuthorExist())
            {
                UpdateAuthor();
            }
            else
            {
                Response.Write("<script>alert('Invalid Author ID, Enter Currect ID');</script>");
            }
        }

        protected void Delete_author_Click(object sender, EventArgs e)
        {
            if (CheckIfAuthorExist())
            {
                DeleteAuthor();
            }
            else
            {
                Response.Write("<script>alert('Invalid Author ID, Enter Currect ID');</script>");
            }
        }

        protected void Go_Click(object sender, EventArgs e)
        {
            getAuthorId();
        }

        void getAuthorId()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl WHERE author_id = '" + AuthorId.Text.Trim() + "' ", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1)
                {
                    AuthorName.Text = dataTable.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Author ID, Enter Currect ID');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        bool CheckIfAuthorExist()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl where author_id='" + AuthorId.Text.Trim() + "'", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1)
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

        void AddAuthor()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl (author_id, author_name) values (@author_id, @author_name)", conn);
                cmd.Parameters.AddWithValue("@author_id", AuthorId.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", AuthorName.Text.Trim());
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Author added Successfully');</script>");
                conn.Close();
                ClearForm();
                GridView_author.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void DeleteAuthor()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM author_master_tbl WHERE author_id='" + AuthorId.Text.Trim() + "'", conn);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Author Deleted Successfully');</script>");
                conn.Close();
                ClearForm();
                GridView_author.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void UpdateAuthor()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE author_master_tbl SET author_name = @author_name WHERE author_id = '" + AuthorId.Text.Trim() + "'", conn);
                cmd.Parameters.AddWithValue("@author_name", AuthorName.Text.Trim());
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Author Upadated Successfully');</script>");
                conn.Close();
                ClearForm();
                GridView_author.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void ClearForm()
        {
            AuthorId.Text = "";
            AuthorName.Text = "";
        }
    }
}