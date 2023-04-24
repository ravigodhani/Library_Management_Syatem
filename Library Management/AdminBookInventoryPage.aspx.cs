using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management
{
    public partial class AdminBookInventoryPage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;
        protected void Page_Load(object sender, EventArgs e)
        {
            fillAuthorPublisherValues();
            GridView_Books.DataBind();
        }

        protected void Go_btn_book_Click(object sender, EventArgs e)
        {
            getBookByID();
        }

        protected void Add_book_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                Response.Write("<script>alert('Book Already Exist, try some other Book ID');</script>");
            }
            else
            {
                addNewBook();
            }
        }

        protected void Update_book_Click(object sender, EventArgs e)
        {
            UpdateById();
        }

        protected void Delete_book_Click(object sender, EventArgs e)
        {
            deleteBookByID();   
        }

        void fillAuthorPublisherValues()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT author_name FROM author_master_tbl", conn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                DropDownList_author.DataSource = dataTable;
                DropDownList_author.DataValueField = "author_name";
                DropDownList_author.DataBind();

                cmd = new SqlCommand("SELECT publisher_name FROM publisher_master_tbl", conn);
                sqlDataAdapter = new SqlDataAdapter(cmd);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                DropDownList_publisher.DataSource = dataTable;
                DropDownList_publisher.DataValueField = "publisher_name";
                DropDownList_publisher.DataBind();
            }
            catch(Exception ex)
            {

            }
        }

        bool checkIfBookExists()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl where book_id='" + Book_id.Text.Trim() + "' OR book_name='"+Book_name.Text.Trim()+"'", conn);
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

        void addNewBook()
        {
            try
            {
                string genres = "";
                foreach (int i in ListBox_cat.GetSelectedIndices())
                {
                    genres = genres + ListBox_cat.Items[i] + ",";
                }

                genres = genres.Remove(genres.Length - 1);

                string filepath = "~/book_inventory/book1.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                filepath = "~/book_inventory/" + filename;

                SqlConnection conn = new SqlConnection(strcon);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string query = "INSERT INTO book_master_tbl (book_id, book_name, genre, author_name, publisher_name, publish_date, " +
                    "language, edition, book_cost, no_of_page, book_description, actual_stock, " +
                    "current_stock, book_img_link) values (@book_id, @book_name, @genre, @author_name," +
                    "@publisher_name, @publish_date, @language, @edition, @book_cost, @no_of_page, @book_description, " +
                    "@actual_stock, @current_stock, @book_img_link )";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@book_id", Book_id.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", Book_name.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", DropDownList_author.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList_publisher.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@language", DropDownList_lang.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", Date_book.Text.Trim());
                cmd.Parameters.AddWithValue("@edition", Book_edition.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", Book_cost.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_page", Book_pages.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", Book_description.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", Actual_Book_Stock.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", Actual_Book_Stock.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@book_img_link", filepath);

                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script>alert('Book Added successfullys');</script>");
                GridView_Books.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }

        void UpdateById()
        {
            if (checkIfBookExists())
            {
                try
                {

                    int actual_stock = Convert.ToInt32(Actual_Book_Stock.Text.Trim());
                    int current_stock = Convert.ToInt32(Current_Book_Stock.Text.Trim());

                    if (global_actual_stock == actual_stock)
                    {

                    }
                    else
                    {
                        if (actual_stock < global_issued_books)
                        {
                            Response.Write("<script>alert('Actual Stock value cannot be less than the Issued books');</script>");
                            return;


                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_books;
                            Current_Book_Stock.Text = "" + current_stock;
                        }
                    }

                    string genres = ""; 
                    foreach (int i in ListBox_cat.GetSelectedIndices())
                    {
                        genres = genres + ListBox_cat.Items[i] + ",";
                    }
                    genres = genres.Remove(genres.Length - 1);

                    string filepath = "~/book_inventory/books1";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;

                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                        filepath = "~/book_inventory/" + filename;
                    }

                    SqlConnection conn = new SqlConnection(strcon);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl set book_name=@book_name, " +
                        "genre=@genre, author_name=@author_name, publisher_name=@publisher_name, " +
                        "publish_date=@publish_date, language=@language, edition=@edition, " +
                        "book_cost=@book_cost, no_of_page=@no_of_pages, book_description=@book_description, " +
                        "actual_stock=@actual_stock, current_stock=@current_stock, book_img_link=@book_img_link where " +
                        "book_id='" + Book_id.Text.Trim() + "'", conn);

                    cmd.Parameters.AddWithValue("@book_name", Book_name.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@author_name", DropDownList_author.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownList_publisher.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publish_date", Date_book.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", DropDownList_lang.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", Book_edition.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_cost", Book_cost.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", Book_pages.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", Book_description.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
                    cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString());
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);


                    cmd.ExecuteNonQuery();
                    conn.Close();
                    GridView_Books.DataBind();
                    Response.Write("<script>alert('Book Updated Successfully');</script>");


                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID');</script>");
            }
        }

        void getBookByID()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl WHERE book_id='" + Book_id.Text.Trim() + "';", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    Book_name.Text = dt.Rows[0]["book_name"].ToString();
                    Date_book.Text = dt.Rows[0]["publish_date"].ToString();
                    Book_edition.Text = dt.Rows[0]["edition"].ToString();
                    Book_cost.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    Book_pages.Text = dt.Rows[0]["no_of_page"].ToString().Trim();
                    Actual_Book_Stock.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    Current_Book_Stock.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    Book_description.Text = dt.Rows[0]["book_description"].ToString();
                    Issued_Book.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));

                    DropDownList_lang.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                    DropDownList_publisher.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    DropDownList_author.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();

                    ListBox_cat.ClearSelection();
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                    for (int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < ListBox_cat.Items.Count; j++)
                        {
                            if (ListBox_cat.Items[j].ToString() == genre[i])
                            {
                                ListBox_cat.Items[j].Selected = true;

                            }
                        }
                    }

                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_filepath = dt.Rows[0]["book_img_link"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID');</script>");
                }

            }
            catch (Exception ex)
            {

            }
        }

        void deleteBookByID()
        {
            if (checkIfBookExists())
            {
                try
                {
                    SqlConnection conn = new SqlConnection(strcon);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from book_master_tbl WHERE book_id='" + Book_id.Text.Trim() + "'", conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Write("<script>alert('Book Deleted Successfully');</script>");

                    GridView_Books.DataBind();

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

    }
}
