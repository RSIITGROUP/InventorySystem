<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="EndUser.aspx.cs" Inherits="InvSystem.EndUser" %>
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
                                       <h4>End User List</h4>
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
                                <button id="Button1" class="btn btn-primary" onserverclick="Button1_Click" runat="server"><i class="fa fa-add"></i> Add</button>
                            </div>
                        </div>
                        <div class="row  mb-2">
                            <div class="col">
                                <asp:GridView  ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCreated="GridView1_RowCreated">
                                    <Columns>
                                       <asp:TemplateField HeaderText="NIK">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLink1" runat="server"
                                                    NavigateUrl='<%# Eval("ID", "~/DetailEndUser.aspx?ID={0}&Action=detail") %>' 
                                                    Text='<%# Eval("NIK") %>'>
                                                </asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>        
                                        <%--<asp:BoundField DataField="NIK" HeaderText="NIK" SortExpression="NIK" />--%>
                                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                        <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" />
                                        <asp:BoundField DataField="Department" HeaderText="Department" SortExpression="Department" />
                                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />
                                        <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Justify">    
                                            <ItemTemplate>
                                                <asp:LinkButton ID="Edit" runat="server" OnCommand="Edit_Command"
                                                    CommandArgument='<%# Eval("ID") %>'
                                                    Text="Edit"><i class="fa fa-edit"></i></asp:LinkButton>
                                                <%--<asp:LinkButton ID="Remove" runat="server" OnClientClick="return confirm('Are you sure you want to delete this End User?');" OnCommand="Remove_Command"
                                                    CommandArgument='<%# Eval("ID") %>'
                                                    Text="Edit"><i class="fa fa-trash"></i></asp:LinkButton>--%>
                                            </ItemTemplate> 

<ItemStyle HorizontalAlign="Justify"></ItemStyle>
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
