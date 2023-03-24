<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="CreateRequest.aspx.cs" Inherits="InvSystem.CreateRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="container">
        <div class="row mb-2">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                       <h4>Create Asset</h4>
                                </center>
                            </div>
                        </div>                        
                        <div class="row  mb-2">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row  mb-2">
                            <div class="col-md-6">
                                <label>Request Id</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtReqId" CssClass="form-control" runat="server" placeholder="Request Id" ReadOnly="True"></asp:TextBox>
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Request Id is empty" ControlToValidate="txtReqId"></asp:RequiredFieldValidator>
                                    </div>
                                </div>                                
                            </div>
                            <div class="col-md-6">
                                <label>Request Date</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtReqDate" CssClass="form-control" runat="server" placeholder="Request Date"  TextMode="Date"></asp:TextBox> 
                                    
                                </div>
                            </div>
                        </div>  
                        <div class="row  mb-2">
                            <div class="col">
                                <asp:GridView  ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCreated="GridView1_RowCreated">
                                    <Columns>
                                        <asp:BoundField DataField="ItemCode" HeaderText="Item Code" SortExpression="ItemCode" />      
                                        <asp:BoundField DataField="ItemDesc" HeaderText="Item Description" SortExpression="ItemDesc" />
                                        <asp:BoundField DataField="Qty" HeaderText="Quantity" SortExpression="Qty" />  
                                        <asp:BoundField DataField="Unit" HeaderText="Unit" SortExpression="Unit" />
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
                bFilter: false,
                bSort: false,
                bPaginate: false
            });
        });        

    </script>
</asp:Content>
