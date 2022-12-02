<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="InvSystem.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            font-size: small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container">
        <div class="row mb-2">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                       <img width="150px" src="imgs/generaluser.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row  mb-2">
                            <div class="col">
                                <center>
                                       <h3>Member Sign Up</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row mb-2">
                            <div class="col-md-6">
                                <label>First Name</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server" placeholder="First Name"></asp:TextBox>
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*First Name is empty" ControlToValidate="txtFirstName" Display="Dynamic" ForeColor="Red" CssClass="auto-style1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Last Name</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server" placeholder="Last Name"></asp:TextBox>
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Last Name is empty" ControlToValidate="txtLastName" Display="Dynamic" ForeColor="Red" CssClass="auto-style1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-2">
                            <div class="col">
                                <label>Email</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Email is empty" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" CssClass="auto-style1"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Wrong format Email" ControlToValidate="txtEmail" CssClass="auto-style1" Display="Dynamic" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-2">
                            <div class="col-md-4">
                                <label>User Name</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" placeholder="User Name"></asp:TextBox>
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*User Name is empty" ControlToValidate="txtUserName" Display="Dynamic" ForeColor="Red" CssClass="auto-style1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>                                
                            </div>
                            <div class="col-md-4">
                                <label>Password</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Password is empty" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Red" CssClass="auto-style1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Confirm Password</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtCPassword" CssClass="form-control" runat="server" TextMode="Password" placeholder="Confirm Password"></asp:TextBox>
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Confirm Password is empty" ControlToValidate="txtCPassword" Display="Dynamic" ForeColor="Red" CssClass="auto-style1"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*Both Password musb be match" ControlToCompare="txtPassword" ControlToValidate="txtCPassword" CssClass="auto-style1" Display="Dynamic" ForeColor="Red"></asp:CompareValidator>
                                    </div>
                                </div>
                            </div>    
                            <div class="form-group mb-2">
                                <center>
                                    <asp:Label ID="lblError" runat="server" Text="Label" CssClass="auto-style1" ForeColor="Red"></asp:Label> 
                                </center>                                  
                            </div>
                        </div>
                        <div class="row mb-2">
                            <div class="col">                                
                                <div class="d-grid gap-2 mb-2">
                                    <asp:Button class="btn btn-success btn-lg" ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <a href="Home.aspx"><< Back To Home</a><br />
            </div>
        </div>
    </div>
</asp:Content>
