<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminBookInventoryPage.aspx.cs" Inherits="Library_Management.AdminBookInventoryPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="row">
                    <div class="col">
                        <center>
                            <h4>Book Details</h4>
                        </center>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <center>
                            <img width="100px" src="Images/books.png" />
                        </center>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <hr>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:FileUpload class="form-control" Onchange="readURI(this)" ID="FileUpload1" runat="server" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <label>Book ID</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="Book_id" runat="server" placeholder="Book ID"></asp:TextBox>
                                <asp:LinkButton class="btn btn-primary" ID="Go_btn_book" runat="server" OnClick="Go_btn_book_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-8">
                        <label>Book Name</label>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="Book_name" runat="server" placeholder="Book Name"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <label>Language</label>
                        <div class="form-group">
                            <asp:DropDownList class="form-control" ID="DropDownList_lang" runat="server">
                                <asp:ListItem Text="English" Value="English" />
                                <asp:ListItem Text="Hindi" Value="Hindi" />
                                <asp:ListItem Text="Marathi" Value="Marathi" />
                                <asp:ListItem Text="French" Value="French" />
                                <asp:ListItem Text="German" Value="German" />
                                <asp:ListItem Text="Urdu" Value="Urdu" />
                            </asp:DropDownList>
                        </div>
                        <label>Publisher Name</label>
                        <div class="form-group">
                            <asp:DropDownList class="form-control" ID="DropDownList_publisher" runat="server">
                                <asp:ListItem Text="Publisher 1" Value="Publisher 1" />
                                <asp:ListItem Text="Publisher 2" Value="Publisher 2" />
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <label>Author Name</label>
                        <div class="form-group">
                            <asp:DropDownList class="form-control" ID="DropDownList_author" runat="server">
                                <asp:ListItem Text="A1" Value="a1" />
                                <asp:ListItem Text="a2" Value="a2" />
                            </asp:DropDownList>
                        </div>
                        <label>Publish Date</label>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="Date_book" runat="server" placeholder="Date" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <label>Genre</label>
                        <div class="form-group">
                            <asp:ListBox CssClass="form-control" ID="ListBox_cat" runat="server" SelectionMode="Multiple" Rows="5">
                                <asp:ListItem Text="Action" Value="Action" />
                                <asp:ListItem Text="Adventure" Value="Adventure" />
                                <asp:ListItem Text="Comic Book" Value="Comic Book" />
                                <asp:ListItem Text="Self Help" Value="Self Help" />
                                <asp:ListItem Text="Motivation" Value="Motivation" />
                                <asp:ListItem Text="Healthy Living" Value="Healthy Living" />
                                <asp:ListItem Text="Wellness" Value="Wellness" />
                                <asp:ListItem Text="Crime" Value="Crime" />
                                <asp:ListItem Text="Drama" Value="Drama" />
                                <asp:ListItem Text="Fantasy" Value="Fantasy" />
                                <asp:ListItem Text="Horror" Value="Horror" />
                                <asp:ListItem Text="Poetry" Value="Poetry" />
                                <asp:ListItem Text="Personal Development" Value="Personal Development" />
                                <asp:ListItem Text="Romance" Value="Romance" />
                                <asp:ListItem Text="Science Fiction" Value="Science Fiction" />
                                <asp:ListItem Text="Suspense" Value="Suspense" />
                                <asp:ListItem Text="Thriller" Value="Thriller" />
                                <asp:ListItem Text="Art" Value="Art" />
                                <asp:ListItem Text="Autobiography" Value="Autobiography" />
                                <asp:ListItem Text="Encyclopedia" Value="Encyclopedia" />
                                <asp:ListItem Text="Health" Value="Health" />
                                <asp:ListItem Text="History" Value="History" />
                                <asp:ListItem Text="Math" Value="Math" />
                                <asp:ListItem Text="Textbook" Value="Textbook" />
                                <asp:ListItem Text="Science" Value="Science" />
                                <asp:ListItem Text="Travel" Value="Travel" />
                            </asp:ListBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <label>Edition</label>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="Book_edition" runat="server" placeholder="Edition"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <label>Book Cost(per unit)</label>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="Book_cost" runat="server" placeholder="Book Cost(per unit)" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <label>Pages</label>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="Book_pages" runat="server" placeholder="Pages" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <label>Actual Stock</label>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="Actual_Book_Stock" runat="server" placeholder="Actual Stock" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <label>Current Stock</label>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="Current_Book_Stock" runat="server" placeholder="Current Stock" TextMode="Number" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <label>Issued Books</label>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="Issued_Book" runat="server" placeholder="Issued Books" TextMode="Number" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <label>Book Description</label>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="Book_description" runat="server" placeholder="Book Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-4">
                        <asp:Button ID="Add_book" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Add_book_Click" />
                    </div>
                    <div class="col-4">
                        <asp:Button ID="Update_book" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Update_book_Click" />
                    </div>
                    <div class="col-4">
                        <asp:Button ID="Delete_book" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Delete_book_Click" />
                    </div>
                </div>
            </div>
            <div class="col-md-7">
                <div class="row">
                    <div class="col">
                        <center>
                            <h4>Book Inventory List</h4>
                        </center>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <hr>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString5 %>" ProviderName="<%$ ConnectionStrings:elibraryDBConnectionString5.ProviderName %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
                        <asp:GridView class="table table-striped table-bordered" ID="GridView_Books" runat="server" DataSourceID="SqlDataSource4" AutoGenerateColumns="False">
                            <Columns>


                                <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id"></asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="container-fluid">
                                            <div class="row">
                                                <div class="col-lg-10">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                        </div>
                                                    </div>
                                                
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <span>Author - </span>
                                                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("author_name") %>'></asp:Label>
                                                            &nbsp;| <span><span>&nbsp;</span>Genre - </span>
                                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>'></asp:Label>
                                                            &nbsp;|<span>
                                                                   Language -<span>&nbsp;</span>
                                                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("language") %>'></asp:Label>
                                                            </span>
                                                        </div>
                                                    </div>
                                                    
                                                    <div class="row">
                                                        <div class="col-12">
                                                            Publisher -
                                                                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                            &nbsp;| Publish Date -
                                                                            <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                            &nbsp;| Pages -
                                                                            <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("no_of_page") %>'></asp:Label>
                                                            &nbsp;| Edition -
                                                                            <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>'></asp:Label>
                                                        </div>
                                                    </div>
                                                   
                                                    <div class="row">
                                                        <div class="col-12">
                                                            Cost -
                                                                            <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>'></asp:Label>
                                                            &nbsp;| Actual Stock -
                                                                            <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                            &nbsp;| Available Stock -
                                                                            <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-12">
                                                            Description -
                                                                            <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("book_description") %>'></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <br />
</asp:Content>
