<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SelfRequestList.aspx.cs" Inherits="InvSystem.SelfRequestList" %>
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
                                       <h4>Request List</h4>
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
                                       <asp:TemplateField HeaderText="Request ID">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLink1" runat="server"
                                                    NavigateUrl='<%# Eval("ReqID", "~/AddRequest.aspx?ReqID={0}&Action=edit") %>' 
                                                    Text='<%# Eval("ReqID") %>'>
                                                </asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ReqDesc" HeaderText="Request Desc" SortExpression="ReqDesc" />
                                        <asp:BoundField DataField="ReqDate" HeaderText="Production Date" SortExpression="ReqDate" />
                                        <asp:BoundField DataField="ReqState" HeaderText="Request State" SortExpression="ReqState" />
                                        <asp:BoundField DataField="ReqUsr" HeaderText="User Request" SortExpression="ReqUsr" />
                                        <asp:BoundField DataField="ReqApr" HeaderText="Approver" SortExpression="ReqUApr" />                                        
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
                order: [[0, 'desc']],
                bPaginate: true
            });
        });        

    </script>
</asp:Content>
