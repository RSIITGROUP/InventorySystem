<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AddEndUser.aspx.cs" Inherits="InvSystem.AddEndUser" %>
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
                                    <asp:TextBox ID="txtNIK" CssClass="form-control" runat="server" placeholder="NIK" MaxLength="25"></asp:TextBox>
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*NIK is empty" ControlToValidate="txtNIK" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>                                
                            </div>
                            <div class="col-md-3">
                                <label>Name</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server" placeholder="Name" MaxLength="50"></asp:TextBox>  
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Name is empty" ControlToValidate="txtName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>Email</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="Email" MaxLength="40"></asp:TextBox>
                                    <div>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Wrong format Email" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Region</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddRegion" Class="form-control" runat="server"></asp:DropDownList>                                     
                                </div>                                
                            </div>                                   
                            <div class="col-md-2">
                                <label>Department</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddDepartment" Class="form-control" runat="server"></asp:DropDownList> 
                                </div>
                            </div>
                        </div>
                        
                        <div class="row  mb-2">
                            <div class="col-md-2">
                                <label>Mobile Number</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtMobileNo" CssClass="form-control" runat="server" placeholder="Mobile Number" MaxLength="20"></asp:TextBox>
                                    <div>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*Wrong format" ControlToValidate="txtMobileNo" Display="Dynamic" ForeColor="Red" ValidationExpression="^0\d{10,11}$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>SAP UserId</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtSapId" CssClass="form-control" runat="server" placeholder="SAP UsrId" MaxLength="30"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Peach UserId</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtPeach" CssClass="form-control" runat="server" placeholder="Peach UsrId" MaxLength="30"></asp:TextBox>       
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>AQM UserId</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtAQM" CssClass="form-control" runat="server" placeholder="AQM UsrId" MaxLength="30"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Talenta UserId</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtTalenta" CssClass="form-control" runat="server" placeholder="Talenta UsrId" MaxLength="30"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Status</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddStatus" Class="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>      
                        <div class="row  mb-2" id="Remarks" runat="server">                         
                            <div class="col-md-6">
                                <label>Remark</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtRemark" CssClass="form-control" runat="server" placeholder="Remark" TextMode="MultiLine" Rows="3" MaxLength="500"></asp:TextBox>
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
                                    <label>From</label>
                                    <div class="form-group">  
                                        <asp:ListBox ID="lstSource" runat="server" Class="form-control" Height="300px" Width="400px" SelectionMode="Multiple"></asp:ListBox>
                                    </div>
                                </center>
                            </div>
                            <div class="col-md-1 align-self-center">                                  
                                <div class="d-grid gap-2 justify-content-center">  
                                    <button id="Button1" class="btn btn-info btn-sm" onserverclick="btnGo_Click" runat="server" causesvalidation="False"><i class="fa fa-angle-double-right fa-lg"></i> </button>
                                    <button id="Button2" class="btn btn-info btn-sm" onserverclick="btnBack_Click" runat="server" causesvalidation="False"><i class="fa fa-angle-double-left fa-lg"></i> </button>
                                </div>                                
                            </div>
                            <div class="col-md-4">
                                <center>
                                    <label>To</label>
                                    <div class="form-group">  
                                        <asp:ListBox ID="lstDestination" runat="server" Class="form-control" Height="300px" Width="400px" SelectionMode="Multiple"></asp:ListBox>
                                    </div>
                                </center>
                            </div>
                        </div> 
                        <div class="row mb-2">
                            <div class="col">                                
                                <div class="form-group">
                                    <center>
                                       <asp:Label ID="lblError" runat="server" Text="Label" CssClass="auto-style1" ForeColor="Red"></asp:Label>
                                     </center>
                                </div>
                            </div>                            
                        </div>
                        <div class="row mb-2">
                            <div class="col">                                
                                <div class="form-group">
                                    <center>
                                        <asp:Button ID="btnAdd" class="btn btn-primary btn-lg" runat="server" Text="Add" OnClick="btnAdd_Click" />
                                        <input id="Reset1" class="btn btn-success  btn-lg" type="reset" value="Reset" />
                                     </center>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>    
</asp:Content>
