<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="UserAD.aspx.cs" Inherits="InvSystem.UserAD" %>
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
                                       <h4>User Active Directory</h4>
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
                                <button id="Button1" class="btn btn-primary" onserverclick="Button1_Click" runat="server">Sync User</button>
                            </div>
                        </div>
                        <div class="row  mb-3" id="errText" runat="server">
                            <div class="col">
                                 <center>
                                     <strong>
                                    <asp:Label ID="lblError" runat="server" Text="Label" CssClass="auto-style1" ForeColor="Red"></asp:Label>
                                     </strong>
                                 </center>
                            </div>
                        </div>
                        <div class="row  mb-2">
                            <div class="col">
                                <asp:GridView  ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCreated="GridView1_RowCreated">
                                    <Columns>
                                        <asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="UserName" />
                                        <asp:BoundField DataField="FirstName" HeaderText="Firs tName" SortExpression="FirstName" />
                                        <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
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
