<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AuthorManagementPage.aspx.cs" Inherits="Library_Management.AuthorManagementPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-5">
                <div class="row">
                    <div class="col">
                        <center>
                            <h4>Author Details</h4>
                        </center>
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                        <center>
                            <img width="100px" src="Images/writer.png" />

                        </center>
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                        <hr>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-4 mb-4">
                        <label>Author ID</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox class="form-control" ID="AuthorId" runat="server" placeholder="ID"></asp:TextBox>
                                <asp:Button class="btn btn-primary" ID="Go" runat="server" Text="Go" OnClick="Go_Click" />
                            </div>
                        </div>
                    </div>

                    <div class="col-md-8">
                        <label>Author Name</label>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="AuthorName" runat="server" placeholder="Author Name"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-4">
                        <asp:Button ID="Add_author" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Add_author_Click" />
                    </div>
                    <div class="col-4">
                        <asp:Button ID="Update_author" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Update_author_Click" />
                    </div>
                    <div class="col-4">
                        <asp:Button ID="Delete_author" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Delete_author_Click" />
                    </div>
                </div>
            </div>
            <div class="col-md-7">
                <div class="row">
                    <div class="col">
                        <center>
                            <h4>Author List</h4>
                        </center>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <hr>
                    </div>
                </div>
                <div class="row">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString2 %>" ProviderName="<%$ ConnectionStrings:elibraryDBConnectionString2.ProviderName %>" SelectCommand="SELECT * FROM [author_master_tbl]"></asp:SqlDataSource>
                    <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView_author" runat="server" DataSourceID="SqlDataSource1"></asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
</asp:Content>
