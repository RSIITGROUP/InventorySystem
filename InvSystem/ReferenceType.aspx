<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReferenceType.aspx.cs" Inherits="InvSystem.ReferenceType" %>

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
        <div>
            <button id="Button1" class="btn btn-primary" onserverclick="Button1_Click" runat="server"><i class="fa fa-add"></i> Add</button>           
        </div>
        <div>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" >
                <Columns>
                    <asp:BoundField DataField="Code" HeaderText="Code" ReadOnly="True" SortExpression="Code" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="TagCode" HeaderText="Tag Code" SortExpression="TagCode" />
                    <asp:BoundField DataField="CreateDate" HeaderText="Create Date" SortExpression="CreateDate" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="Edit" runat="server" OnCommand="Edit_Command"
                                CommandArgument='<%# Eval("Code") %>'
                                Text="Edit" />
                        </ItemTemplate> 
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <div><center>No records found.</center></div>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </form>
    <script type="text/javascript">
        $(function () {
            $('#<%=GridView1.ClientID%>').DataTable(
            {
                bLengthChange: true,
                lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                bFilter: true,
                bSort: true,
                bPaginate: true
            });
        });
    </script>
</body>
</html>
