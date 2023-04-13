<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ListGoodsIssue.aspx.cs" Inherits="InvSystem.ListGoodsIssue" %>
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
                                       <h4>List Goods Issue</h4>
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
                                <asp:GridView  ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCreated="GridView1_RowCreated">
                                    <Columns>
                                       <asp:TemplateField HeaderText="Goods Issue Id">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLink1" runat="server"
                                                    NavigateUrl='<%# Eval("GIID", "~/AddGoodsIssue.aspx?GIID={0}&Action=view") %>' 
                                                    Text='<%# Eval("GIID") %>'>
                                                </asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Request ID">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLink1" runat="server"
                                                    NavigateUrl='<%# Eval("RequestID", "~/AddRequest.aspx?ReqID={0}&Action=close") %>' 
                                                    Text='<%# Eval("RequestID") %>'>
                                                </asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                                        <asp:BoundField DataField="GIDate" HeaderText="Goods Issue Date" SortExpression="GIDate" />
                                        <asp:BoundField DataField="GIUsr" HeaderText="User Create" SortExpression="GIUsr" />                                      
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
