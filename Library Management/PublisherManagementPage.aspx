<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="PublisherManagementPage.aspx.cs" Inherits="Library_Management.PublisherManagementPage" %>

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
                            <h4>Publisher Details</h4>
                        </center>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <center>
                            <img width="100px" src="Images/publisher.png" />
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
                        <label>Publisher ID</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox class="form-control" ID="PublisherId" runat="server" placeholder="ID"></asp:TextBox>
                                <asp:Button class="btn btn-primary" ID="Go_btn" runat="server" Text="Go" OnClick="Go_btn_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-8">
                        <label>Publisher Name</label>
                        <div class="form-group">
                            <asp:TextBox class="form-control" ID="PublisherName" runat="server" placeholder="Publisher Name"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-4">
                        <asp:Button ID="Add_Publisher" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Add_Publisher_Click" />
                    </div>
                    <div class="col-4">
                        <asp:Button ID="Update_Publisher" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Update_Publisher_Click" />
                    </div>
                    <div class="col-4">
                        <asp:Button ID="Delete_Publisher" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Delete_Publisher_Click" />
                    </div>
                </div>
            </div>
            <div class="col-md-7">
                <div class="row">
                    <div class="col">
                        <center>
                            <h4>Publisher List</h4>
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
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString3 %>" ProviderName="<%$ ConnectionStrings:elibraryDBConnectionString3.ProviderName %>" SelectCommand="SELECT * FROM [publisher_master_tbl]"></asp:SqlDataSource>
                        <asp:GridView class="table table-striped table-bordered" ID="GridView_Publisher" runat="server" DataSourceID="SqlDataSource2"></asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
</asp:Content>
