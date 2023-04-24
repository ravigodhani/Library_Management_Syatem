﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminBookIssuingPage.aspx.cs" Inherits="Library_Management.AdminBookIssuingPage" %>
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
                           <h4>Book Issuing</h4>
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
                  <div class="row mb-4">
                     <div class="col-md-6">
                        <label>Member ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Member ID"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Book ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Book ID"></asp:TextBox>
                               <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
                           </div>
                        </div>
                     </div>
                  </div>
                  <div class="row mb-4">
                     <div class="col-md-6">
                        <label>Member Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Member Name" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Book Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Book Name" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row mb-4">
                     <div class="col-md-6">
                        <label>Start Date</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Start Date" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>End Date</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="End Date" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-6">
                         <asp:Button ID="Button2" class="btn btn-lg btn-block btn-primary" runat="server" Text="Issue" OnClick="Button2_Click" />
                     </div>
                     <div class="col-6">
                         <asp:Button ID="Button4" class="btn btn-lg btn-block btn-success" runat="server" Text="Return" OnClick="Button4_Click" />
                     </div>
                  </div>
            <br>
         </div>
         <div class="col-md-7">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Issued Book List</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString='<%$ ConnectionStrings:elibraryDBConnectionString %>' SelectCommand="SELECT * FROM [book_issue_tbl]"></asp:SqlDataSource>
                     <div class="col">
                         <asp:GridView class="table table-striped table-bordered" ID="GridView_book_issuing" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource5">
                             <Columns>
                                 <asp:BoundField DataField="member_id" HeaderText="Member ID" SortExpression="member_id"></asp:BoundField>
                                 <asp:BoundField DataField="membar_name" HeaderText="Member Name" SortExpression="membar_name"></asp:BoundField>
                                 <asp:BoundField DataField="book_id" HeaderText="Book ID" SortExpression="book_id"></asp:BoundField>
                                 <asp:BoundField DataField="book_name" HeaderText="Book Name" SortExpression="book_name"></asp:BoundField>
                                 <asp:BoundField DataField="issue_date" HeaderText="Issue Date" SortExpression="issue_date"></asp:BoundField>
                                 <asp:BoundField DataField="due_date" HeaderText="Due_Date" SortExpression="due_date"></asp:BoundField>
                             </Columns>
                         </asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
         </div>
</asp:Content>
