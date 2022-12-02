<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddReferenceType.aspx.cs" Inherits="InvSystem.AddReferenceType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                <div class="col-md-6 mx-auto">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col">
                                    <center>
                                           <h3>Reference Type</h3>
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
                                <label>Code</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtCode" CssClass="form-control" runat="server" placeholder="Code" ReadOnly="true"></asp:TextBox>                                    
                                </div>
                                <label>Type</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtType" CssClass="form-control" runat="server" placeholder="Type"></asp:TextBox>
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Type is empty" ControlToValidate="txtType" Display="Dynamic" ForeColor="Red" CssClass="auto-style1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <label>Tag Code</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtTagCode" CssClass="form-control" runat="server" placeholder="Tag Code" ></asp:TextBox>
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Tag Code is empty" ControlToValidate="txtTagCode" Display="Dynamic" ForeColor="Red" CssClass="auto-style1"></asp:RequiredFieldValidator>
                                  </div>
                                </div>
                                <div class="form-group mb-2">
                                    <center>
                                        <asp:Label ID="lblError" runat="server" Text="Label" CssClass="auto-style1" ForeColor="Red"></asp:Label> 
                                    </center>                                  
                                </div>
                                <div class="d-grid gap-2 mb-2">
                                    <asp:Button class="btn btn-success btn-lg" ID="btnAdd" runat="server" Text="Login" OnClick="btnAdd_Click" />
                                </div>
                            </div>
                        </div>
                        </div>
                    </div>
                    <a href="ReferenceType.aspx"><< Back To List</a><br />
                </div>
            </div>
        </div>
    </form>       
</body>
</html>
