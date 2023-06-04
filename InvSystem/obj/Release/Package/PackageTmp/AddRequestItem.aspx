<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRequestItem.aspx.cs" Inherits="InvSystem.AddRequestItem" %>

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
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="RequestID" ShowHeaderWhenEmpty="true" OnRowCommand="GridView1_RowCommand" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%">
                
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
                    <asp:TemplateField HeaderText="Request ID" >
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("RequestID") %>' runat="server"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblRequestID" Text='<%# Eval("RequestID") %>' runat="server"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblRequestIDFooter" Text='<%# Eval("RequestID") %>' runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Line ID" >
                        <ItemTemplate>
                            <asp:Label ID="lblLine" Text='<%# Eval("LineId") %>' runat="server"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblLineID" Text='<%# Eval("LineId") %>' runat="server"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblLineIDFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item Code" >
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("ItemCode") %>' runat="server"/>
                        </ItemTemplate>
                        <EditItemTemplate>                            
                            <asp:Label ID="lblItemCode" Text='<%# Eval("ItemCode") %>' runat="server"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <%--<asp:DropDownList ID="ddItemCodeFooter" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddItemCodeFooter_SelectedIndexChanged"></asp:DropDownList>--%>
                            <ajaxToolkit:ComboBox ID="ddItemCodeFooter" runat="server" CssClass="WindowsStyle"  AutoCompleteMode="SuggestAppend" AutoPostBack="true" OnSelectedIndexChanged="ddItemCodeFooter_SelectedIndexChanged"></ajaxToolkit:ComboBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item Description" >
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("ItemDesc") %>' runat="server"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblItemDesc" Text='<%# Eval("ItemDesc") %>' runat="server"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblItemDescFooter"  runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Stock" >
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Stock") %>' runat="server"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblStock" Text='<%# Eval("Stock") %>' runat="server"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblStockFooter"  runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity" ItemStyle-Width="100px">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Qty") %>' runat="server"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtQty" Text='<%# Eval("Qty") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtQtyFooter" runat="server" TextMode="Number"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="QtyGI" >
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("QtyGI") %>' runat="server"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblQtyGI" Text='<%# Eval("QtyGI") %>' runat="server"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblQtyGIFooter" Text='<%# Eval("QtyGI") %>' runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remaining Qty" >
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("RemainingQty") %>' runat="server"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblRemainingQty" Text='<%# Eval("RemainingQty") %>' runat="server"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblRemainingQtyFooter" Text='<%# Eval("RemainingQty") %>' runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Unit" >
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Unit") %>' runat="server"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblUnit" Text='<%# Eval("Unit") %>' runat="server"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblUnitFooter"  runat="server" />
                        </FooterTemplate>
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
