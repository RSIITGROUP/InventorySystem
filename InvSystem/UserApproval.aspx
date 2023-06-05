<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserApproval.aspx.cs" Inherits="InvSystem.UserApproval" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>    
    <style type="text/css">
        .auto-style1 {
            text-align: justify;
        }
       .WindowsStyle .ajax__combobox_inputcontainer .ajax__combobox_textboxcontainer input
        {
            margin: 0;
            border: solid 1px #7F9DB9;
            border-right: 0px none;
            padding: 1px 0px 0px 5px;
            font-size: 13px;
            height: 18px;
            position: relative;       
        }
        .WindowsStyle .ajax__combobox_inputcontainer .ajax__combobox_buttoncontainer button
        {
            height: 21px;
            width: 21px;
        }
        .WindowsStyle .ajax__combobox_itemlist
        {
            border-color: #7F9DB9;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
        <div>
            <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="UserId" ShowHeaderWhenEmpty="true" OnRowCommand="GridView1_RowCommand" 
                OnRowDeleting="GridView1_RowDeleting" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="90%">
                
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" VerticalAlign="Middle"  />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
                <Columns>                    
                    <asp:TemplateField HeaderText="Approver" >
                        <ItemTemplate>
                            <asp:Label ID="lblApprover" Text='<%# Eval("ApproverId") %>' runat="server"/>
                        </ItemTemplate>
                        <EditItemTemplate>                            
                            <asp:Label ID="lblApproverID" Text='<%# Eval("ApproverId") %>' runat="server"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <ajaxToolkit:ComboBox ID="ddApproverFooter" runat="server" CssClass="WindowsStyle"  AutoCompleteMode="SuggestAppend"></ajaxToolkit:ComboBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/imgs/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="~/imgs/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ImageUrl="~/imgs/addnew.png" runat="server" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px" />
                        </FooterTemplate>
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
