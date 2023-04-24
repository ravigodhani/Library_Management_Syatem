<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminMemberManagement.aspx.cs" Inherits="Library_Management.AdminMemberManagement" %>
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
         <div class="col-md-6">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Member Details</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="Images/generaluser.png" />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-3">
                        <label>Member ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="member_id_manage" runat="server" placeholder="Member ID"></asp:TextBox>
                              <asp:LinkButton CssClass="btn btn-primary" ID="Go_member" Onclick="Go_member_Click" runat="server"><i class="fas fa-check-circle mt-2"></i></asp:LinkButton>
                           </div>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Full Name</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="FullName_mamber" runat="server" placeholder="Full Name" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-5">
                        <label>Account Status</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox class="form-control mr-1 inbtn" ID="Account_status_member" runat="server" placeholder="Account Status" ReadOnly="True"></asp:TextBox>
                               <asp:LinkButton class="btn btn-success mr-1" ID="Active_btn" runat="server" OnClick="Active_btn_Click"><i class="fas fa-check-circle mt-2"></i></asp:LinkButton>
                               <asp:LinkButton class="btn btn-warning mr-1" ID="Panding_btn" runat="server" OnClick="Panding_btn_Click"><i class="far fa-pause-circle mt-2"></i></asp:LinkButton>
                               <asp:LinkButton class="btn btn-danger mr-1" ID="Deactive_btn" runat="server" OnClick="Deactive_btn_Click"><i class="fas fa-times-circle mt-2"></i></asp:LinkButton>
                           </div>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-3">
                        <label>DOB</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="DOB_member" runat="server" placeholder="DOB" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Contact No</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Contact_member" runat="server" placeholder="Contact No" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-5">
                        <label>Email ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="email_member" runat="server" placeholder="Email ID" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                        <label>State</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="state_member" runat="server" placeholder="State" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>City</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="city_mamber" runat="server" placeholder="City" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Pin Code</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="pincode_mamber" runat="server" placeholder="Pin Code" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-12">
                        <label>Full Postal Address</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="fulladdress_member" runat="server" placeholder="Full Postal Address" TextMode="MultiLine" Rows="2" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-8 mx-auto">
                         <center>
                             <asp:Button ID="deleteuser_member" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete User Permanently" OnClick="deleteuser_member_Click" />
                         </center>
                     </div>
                  </div>
         </div>
         <div class="col-md-6">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Member List</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString4 %>" ProviderName="<%$ ConnectionStrings:elibraryDBConnectionString4.ProviderName %>" SelectCommand="SELECT * FROM [member_master_tbl]"></asp:SqlDataSource>
                     <div class="col">
                         <asp:GridView class="table table-striped table-bordered" ID="GridView_member" runat="server" DataSourceID="SqlDataSource3" AutoGenerateColumns="False">
                             <Columns>
                              <asp:BoundField DataField="member_id" HeaderText="ID" ReadOnly="True" SortExpression="member_id" />
                              <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                              <asp:BoundField DataField="account_status" HeaderText="Account Status" SortExpression="account_status" />
                              <asp:BoundField DataField="contact_no" HeaderText="Contact No" SortExpression="contact_no" />
                              <asp:BoundField DataField="email" HeaderText="Email ID" SortExpression="email" />
                              <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                              <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                           </Columns>
                         </asp:GridView>
                     </div>
                  </div>
        </div>
        </div>
      </div>
   </div>
    <br />

</asp:Content>
