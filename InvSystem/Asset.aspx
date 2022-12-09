<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Asset.aspx.cs" Inherits="InvSystem.Asset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row mb-2">
            <div class="col-md-12 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                       <h4>Asset List</h4>
                                </center>
                            </div>
                        </div>                        
                        <div class="row  mb-2">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row  mb-3">
                            <div class="col">
                                <%--<i class="fa fa-add"></i>
                                <asp:Button class="btn btn-primary btn-sm fa fa-add" ID="Button1" runat="server" Text="Add Asset" />--%>
                                <button id="Button1" class="btn btn-primary" onserverclick="Button1_Click" runat="server"><i class="fa fa-add"></i> Add</button>
                                <button id="Button2" class="btn btn-primary" onserverclick="Button2_Click" runat="server"><i class="fa fa-upload"></i> Upload</button>
                            </div>
                        </div>
                        <div class="row  mb-2">
                            <div class="col">
                                <asp:GridView  ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCreated="GridView1_RowCreated">
                                    <Columns>
                                       <asp:TemplateField HeaderText="Asset Code">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLink1" runat="server"
                                                    NavigateUrl='<%# Eval("AssetCode", "~/DetailAsset.aspx?assetCode={0}&Action=detail") %>' 
                                                    Text='<%# Eval("AssetCode") %>'>
                                                </asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>        
                                        <asp:BoundField DataField="AssetDesc" HeaderText="Asset Desc" SortExpression="AssetDesc" />
                                        <asp:BoundField DataField="ActivaNo" HeaderText="Activa No" SortExpression="ActivaNo" />
                                        <asp:BoundField DataField="SerialNo" HeaderText="Serial No" SortExpression="SerialNo" />
                                        <asp:BoundField DataField="User" HeaderText="User" SortExpression="User" />
                                        <asp:BoundField DataField="PurchaseDate" HeaderText="PurchaseDate" SortExpression="Purchase Date" />
                                        <asp:BoundField DataField="GRPODocNo" HeaderText="GRPODocNo" SortExpression="GRPO Doc No" />
                                        <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Justify">    
                                            <ItemTemplate>
                                                <asp:LinkButton ID="Edit" runat="server" OnCommand="Edit_Command"
                                                    CommandArgument='<%# Eval("AssetCode") %>'
                                                    Text="Edit"><i class="fa fa-edit"></i></asp:LinkButton>
                                                <asp:LinkButton ID="Remove" runat="server" OnClientClick="return confirm('Are you sure you want to delete this asset?');" OnCommand="Remove_Command"
                                                    CommandArgument='<%# Eval("AssetCode") %>'
                                                    Text="Edit"><i class="fa fa-trash"></i></asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton1" runat="server" OnCommand="Print_Command"
                                                    CommandArgument='<%# Eval("AssetCode") %>'
                                                    Text="Print"><i class="fa fa-print"></i></asp:LinkButton>
                                                <%--<asp:Button ID="Btn1" runat="server" OnCommand="Print_Command" CssClass="fa fa-print" CommandArgument='<%# Eval("AssetCode") %>' Text="Print" />--%><%--<i class="fa fa-print"></asp:Button>--%>
                                            </ItemTemplate> 
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div><center>No records found.</center></div>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
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
</asp:Content>
