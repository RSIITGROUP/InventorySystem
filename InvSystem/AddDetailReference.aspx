<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDetailReference.aspx.cs" Inherits="InvSystem.AddDetailReference" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <%--<style type="text/css">
        .auto-style2 {
            text-align: center;
        }
        .auto-style4 {
            width: 30%;
            height: 28px;
        }
        .auto-style5 {
            width: 7px;
            height: 28px;
        }
        .auto-style6 {
            height: 28px;
        }
        .auto-style7 {
            height: 79px;
        }
        .auto-style8 {
            height: 45px;
        }
        .auto-style9 {
            width: 30%;
            height: 36px;
        }
        .auto-style10 {
            width: 7px;
            height: 36px;
        }
        .auto-style11 {
            height: 36px;
        }
        .auto-style12 {
            font-weight: bold;
            height:39px;
        }
    </style>--%>
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="datatables/css/datatables.min.css" rel="stylesheet" />
    <link href="fontawesome/css/all.css" rel="stylesheet" />
    <link href="css/customstylesheet.css" rel="stylesheet" />
    <link href="ajax/css/font-awesome.min.css" rel="stylesheet" />

    <script src="Scripts/jquery-3.3.1.slim.min.js"></script>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="bootstrap/js/popper.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <script src="bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="datatables/js/datatables.min.js"></script>
    
    <style type="text/css">
        .auto-style1 {
            font-size: small;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row mb-2">
                <div class="col-md-8 mx-auto">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col">
                                    <center>
                                           <h3>Reference</h3>
                                    </center>
                                </div>
                            </div>
                            <div class="row mb-2">
                                <div class="col">
                                    <hr />
                                </div>
                            </div>
                            <div class="row mb-2">
                                <div class="col-md-6">
                                    <label>Type</label>
                                    <div class="form-group">  
                                        <asp:DropDownList ID="drType" CssClass="form-control" runat="server" AutoPostBack = "true" OnSelectedIndexChanged="drType_SelectedIndexChanged" OnTextChanged="drType_TextChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <label>Code</label>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtCode" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row mb-2">
                                <div class="col-md-6">
                                    <label>Name</label>
                                    <div class="form-group mb-2">
                                        <asp:TextBox ID="txtName" CssClass="form-control" runat="server" placeholder="Name" ></asp:TextBox>
                                        <div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Name is empty" ControlToValidate="txtName" Display="Dynamic" ForeColor="Red" CssClass="auto-style1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <label>Status</label>
                                    <div class="form-group mb-2">
                                        <asp:DropDownList ID="drStatus" CssClass="form-control"  runat="server">
                                        </asp:DropDownList>
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
                                    <center>
                                        <asp:Button class="btn btn-success" ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                                        <asp:Button class="btn btn-info" ID="btnNew" runat="server" Text="New" OnClick="btnNew_Click" CausesValidation="false"/>
                                    </center>
                                </div>
                            </div>
                        </div>    
                    </div>
                    <a href="DetailReference.aspx"><< Back To List</a><br />
                </div>
            </div>
        </div>
    </form>       
</body>
</html>
