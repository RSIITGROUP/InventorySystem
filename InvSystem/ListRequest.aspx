﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ListRequest.aspx.cs" Inherits="InvSystem.ListRequest" %>
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
                                       <h4>List Request</h4>
                                </center>
                            </div>
                        </div>                       
                        <div class="row  mb-2">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                       <%-- <div class="row  mb-3">
                            <div class="col">
                                <button id="Button1" class="btn btn-primary" onserverclick="Button1_Click" runat="server"><i class="fa fa-add"></i> Add</button>
                                <button id="Button2" class="btn btn-primary" onserverclick="Button2_Click" runat="server"><i class="fa fa-upload"></i> Upload</button>
                            </div>
                        </div>--%> 
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
                                        <asp:BoundField DataField="ReqDate" HeaderText="Request Date" SortExpression="ReqDate" />
                                        <asp:BoundField DataField="ReqState" HeaderText="Request State" SortExpression="ReqState" />
                                        <asp:BoundField DataField="ReqUsr" HeaderText="User Request" SortExpression="ReqUsr" />
                                        <asp:BoundField DataField="ReqApr" HeaderText="Request Approver" SortExpression="ReqUApr" />
                                        <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Justify">    
                                            <ItemTemplate>
                                                <asp:LinkButton ID="Edit" runat="server" OnCommand="Approve_Command"
                                                    CommandArgument='<%# Eval("ReqID") %>'
                                                    Text="Edit"><i class="fa fa-check-square-o"></i></asp:LinkButton>
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
                order: [[3, 'asc'],[0, 'desc']],
                bPaginate: true
            });
        });        

    </script>
</asp:Content>