<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master"  EnableEventValidation="false" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Library_Management.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header class="hero">
        <img src="Images/Header-bg.png" />
        <div class="containar">
            <h2>E-Library</h2>
            <p>
                This is an Online Library Management system which helps you to monitor and control the transactions in the library. It is used to find books, calculate fine,store detailed information of the users and books database.
               It uses Barcode scanning features.
            </p>
            </div>
    </header>
    <section>
      <div class="container" style="margin-top:0.5rem;">
         <div class="row">
            <div class="col-12">
                <br />
               <center>
                  <h2 style="color:var(--hover)">Our Features</h2>
                  <p><b>Our 3 Primary Features -</b></p>
               </center>
                <br />
            </div>
         </div>
         <div class="row">
            <div class="col-md-4">
               <center>
                  <img class="mb-3" width="150px" src="Images/2.svg"/>
                  <h4>Digital Book Inventory</h4>
                  <p class="text-justify">Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Lorem ipsum dolor. reprehenderit</p>
               </center>
            </div>
            <div class="col-md-4">
               <center>
                  <img class="mb-3" width="150px" src="Images/3.svg"/>
                  <h4>Search Books</h4>
                  <p class="text-justify">Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Lorem ipsum dolor. reprehenderit</p>
               </center>
            </div>
            <div class="col-md-4">
               <center>
                  <img class="mb-3" width="150px" src="Images/1.svg"/>
                  <h4>Defaulter List</h4>
                  <p class="text-justify">Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Lorem ipsum dolor. reprehenderit</p>
               </center>
            </div>
         </div>
      </div>
   </section>
     <section>
      <div class="container">
          <br />
         <div class="row">
            <div class="col-12">
               <center>
                  <h2 style="color:var(--hover)">Our Process</h2>
                  <p><b>We have a Simple 3 Step Process</b></p>
               </center>
                <br />
            </div>
         </div>
         <div class="row">
            <div class="col-md-4">
               <center>
                  <img class="mb-3" width="230px" src="Images/4.svg" />
                  <h4>Sign Up</h4>
                  <p class="text-justify">Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Lorem ipsum dolor. reprehenderit</p>
               </center>
            </div>
            <div class="col-md-4">
               <center>
                  <img class="mb-3" width="150px" src="Images/3.svg"/>
                  <h4>Search Books</h4>
                  <p class="text-justify">Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Lorem ipsum dolor. reprehenderit</p>
               </center>
            </div>
            <div class="col-md-4">
               <center>
                  <img class="mb-3" width="150px" src="Images/6.svg"/>
                  <h4>Visit Us</h4>
                  <p class="text-justify">Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Lorem ipsum dolor. reprehenderit</p>
               </center>
            </div>
         </div>
      </div>
   </section>
    <section>
        <div class="content">
            <div class="row">
                <div class="col-12">
                    <center>
                        <h2 style="color: var(--hover)">Contact Us</h2
                    </center>
                </div>
            </div>
            <br />
            <br />
            <div class="container">
                <div class="row align-items-stretch no-gutters contact-wrap">
                    <div class="col-md-12">
                        <div class="form h-100">
                            <form class="mb-5" method="post" id="contactForm" name="contactForm">
                                <div class="row">
                                    <div class="col-md-6 form-group mb-3">
                                        <asp:Label class="col-form-label" runat="server" Text="Name"></asp:Label>
                                        <asp:TextBox  class="form-control" placeholder="Your name" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 form-group mb-3">
                                        <asp:Label class="col-form-label" runat="server" Text="E-Mail"></asp:Label>
                                        <asp:TextBox  class="form-control" placeholder="Your E-Mail" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12 form-group mb-3">
                                        <asp:Label class="col-form-label" runat="server" Text="Message"></asp:Label>
                                        <asp:TextBox  class="form-control" placeholder="Message" runat="server" ID="message"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12 form-group">
                                        <asp:Button ID="Button1" class="btn btn-primary rounded-0 py-2 px-4" runat="server" Text="Send Message" />
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
