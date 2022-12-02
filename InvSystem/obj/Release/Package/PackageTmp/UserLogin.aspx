<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="InvSystem.UserLogin" %>
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
            <div class="col-md-5 mx-auto">
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
                                       <h3>Member Login</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row  mb-2">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row  mb-2">
                            <div class="col">
                                <label>User Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" placeholder="User Name"></asp:TextBox>
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*User Name is empty" ControlToValidate="txtUserName" Display="Dynamic" ForeColor="Red" CssClass="auto-style1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <label>Password</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" placeholder="Password" ></asp:TextBox>
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Password is empty" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Red" CssClass="auto-style1"></asp:RequiredFieldValidator>
                                  </div>
                                </div>
                                <div class="form-group mb-2">
                                    <center>
                                        <asp:Label ID="lblError" runat="server" Text="Label" CssClass="auto-style1" ForeColor="Red"></asp:Label> 
                                    </center>                                  
                                </div>
                                <div class="d-grid gap-2 mb-2">
                                    <asp:Button class="btn btn-success btn-lg" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                                </div>
                                <div class="d-grid gap-2">
                                     <a href="SignUp.aspx" class="btn btn-info"><input class="btn btn-info" id="Button2" type="button" value="Sign Up" /></a>
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
