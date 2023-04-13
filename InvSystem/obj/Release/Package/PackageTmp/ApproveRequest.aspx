<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApproveRequest.aspx.cs" Inherits="InvSystem.ApproveRequest" %>

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
</head>
<body>
    <form id="form1" runat="server">
        <div class="row mb-2">
            <div class="col">
                <h4><span class="badge text-bg-light"><i class="fa fa-bars"></i> Request State</span></h4>                 
            </div>
        </div>
        <div class="row mb-2">
            <div class="col-md-2">
                <label>State</label>
                <div class="form-group">  
                    <asp:DropDownList ID="ddState" CssClass="form-control" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-6">
                <label>Remark</label>
                <div class="form-group mb-2">
                    <asp:TextBox ID="txtRemark" CssClass="form-control" runat="server" placeholder="Remark" MaxLength="500"></asp:TextBox>                                    
                </div>
            </div> 
            <div class="col-md-1">
                <br />
                    <asp:Button class="btn btn-success btn-sm" ID="btnAdd" runat="server" Text="submit" OnClick="btnAdd_Click" />
            </div>
        </div>
        <div class="row mb-2">
            <div class="col">                                
                <div class="form-group">
                    <center>
                        <asp:Label ID="lblError" runat="server" Text="Label" CssClass="auto-style1" ForeColor="Red"></asp:Label>
                        </center>
                </div>
            </div>
                            
        </div>
    </form>       
</body>
</html>
