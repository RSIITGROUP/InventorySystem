<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="DetailEndUser.aspx.cs" Inherits="InvSystem.DetailEndUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row mb-2">
            <div class="col-md-12 mx-auto">
                <div class="card" id="mains" runat="server">
                    <div class="card-body">                                
                        <div class="row  mb-2">
                            <div class="col">
                                <a href="EndUser.aspx"><< Back To End User List</a><br />
                            </div>
                        </div> 
                        <div class="row">
                            <div class="col">
                                 <h4><span class="badge text-bg-light"><i class="fa fa-bars"></i> Profile</span></h4>                                
                            </div>
                        </div> 
                        <div class="row  mb-2">
                            <div class="col-md-2">
                                <label>NIK</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtNIK" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>                                
                            </div>
                            <div class="col-md-3">
                                <label>Name</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>                                    
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>Email</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Region</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtRegion" CssClass="form-control" runat="server" ReadOnly="True" ></asp:TextBox>                                     
                                </div>                                
                            </div>                                   
                            <div class="col-md-2">
                                <label>Department</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtDepartment" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        
                        <div class="row  mb-2">
                            <div class="col-md-2">
                                <label>Mobile Number</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtMobileNo" Class="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>SAP UserId</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtSAP" Class="form-control" runat="server" ReadOnly="True"> </asp:TextBox>       
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Peach UserId</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtPeach" Class="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>AQM UserId</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtAQM" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Talenta UserId</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtTalenta" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Status</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtStatus" Class="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>                       
                        <div class="row  mb-2" id="Remarks" runat="server">                         
                            <div class="col-md-6">
                                <label>Remark</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtRemark" CssClass="form-control" runat="server" ReadOnly="True" TextMode="MultiLine" Rows="3" MaxLength="500"></asp:TextBox>
                                </div>
                            </div>
                        </div> 
                        <div class="row">
                            <div class="col">
                                 <h4><span class="badge text-bg-light"><i class="fa fa-bars"></i> Asset</span></h4>                                
                            </div>
                        </div>
                        <div class="row  mb-2">
                            
                            <div class="col-md-4">
                                <center>
                                    <%--<label>To</label>--%>
                                    <div class="form-group">  
                                        <asp:ListBox ID="lstDestination" runat="server" Class="form-control" Height="300px" Width="400px" ReadOnly="True"></asp:ListBox>
                                    </div>
                                </center>
                            </div>
                        </div> 
                    </div>
                </div>
            </div>
        </div>
    </div> 
</asp:Content>
