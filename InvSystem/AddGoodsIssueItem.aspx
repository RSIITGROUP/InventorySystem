<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddGoodsIssueItem.aspx.cs" Inherits="InvSystem.AddGoodsIssueItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: justify;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="GIID" ShowHeaderWhenEmpty="true" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%">
                
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" VerticalAlign="Middle"  />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
                <Columns>
                    <asp:TemplateField HeaderText="Request Id">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("RequestId") %>' runat="server"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblRequestID" Text='<%# Eval("RequestId") %>' runat="server"/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Line ID" >
                        <ItemTemplate>
                            <asp:Label ID="lblLine" Text='<%# Eval("LineId") %>' runat="server"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblLineID" Text='<%# Eval("LineId") %>' runat="server"/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item Code" >
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("ItemCode") %>' runat="server"/>
                        </ItemTemplate>
                        <EditItemTemplate>                            
                            <asp:Label ID="lblItemCode" Text='<%# Eval("ItemCode") %>' runat="server"/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item Description" >
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("ItemDesc") %>' runat="server"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblItemDesc" Text='<%# Eval("ItemDesc") %>' runat="server"/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity" >
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Qty") %>' runat="server"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtQty" Text='<%# Eval("Qty") %>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Unit" >
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Unit") %>' runat="server"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblUnit" Text='<%# Eval("Unit") %>' runat="server"/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/imgs/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px" />
                            <asp:ImageButton ImageUrl="~/imgs/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="~/imgs/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />
                            <asp:ImageButton ImageUrl="~/imgs/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </div>
            <%--<br/>
            <center>
                <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
            </center>
            <br/>--%>
            <center>
                <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />
            </center>
        </div>
    </form>
</body>
</html>
