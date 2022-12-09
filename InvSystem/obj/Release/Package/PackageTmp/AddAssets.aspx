<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AddAssets.aspx.cs" Inherits="InvSystem.AddAssets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<style type="text/css">
        .auto-style4 {
            width: 26%;
            text-align: left;
            font-size: small;
        }
        .auto-style5 {
            width: 81px;
            height: 39px;
            font-weight: bold;
            font-size: small;
        }
        .auto-style6 {
            text-align: left;
            font-size: small;
        }
        .auto-style7 {
            font-size: small;
        }
        .auto-style8 {
            text-align: center;
            font-size: small;
        }
        .auto-style9 {
            width: 24%;
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row mb-2">
            <div class="col-md-12 mx-auto">
                <div class="card">
                    <div class="card-body">     
                        <%--<div class="row">
                            <div class="col">
                                <center>
                                       <h4>Asset</h4>
                                </center>
                            </div>
                        </div>  --%>                                 
                        
                        <div class="row  mb-2">
                            <div class="col">
                                <%--<br />--%>
                                <a href="Asset.aspx"><< Back To Asset List</a><br />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                 <h4><span class="badge text-bg-light"><i class="fa fa-bars"></i> Asset</span></h4>                                
                            </div>
                        </div> 
                        <div class="row  mb-2">
                            <div class="col-md-2">
                                <label>Code</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtAssetCode" CssClass="form-control" runat="server" placeholder="Asset Code" ReadOnly="True"></asp:TextBox>
                                </div>                                
                            </div>
                            <div class="col-md-3">
                                <label>Description</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtAssetDesc" CssClass="form-control" runat="server" placeholder="Asset Description"></asp:TextBox>                                    
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>Activa Number</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtActivaNO" CssClass="form-control" runat="server" placeholder="Activa Number" MaxLength="50"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Purchase Date</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtPurchaseDate" CssClass="form-control" runat="server" placeholder="Purchase Date"  TextMode="Date"></asp:TextBox>                                     
                                </div>                                
                            </div>                                   
                            <div class="col-md-2">
                                <label>GRPO Doc Num</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtGRPODocNum" CssClass="form-control" runat="server" placeholder="GRPO Doc Num" MaxLength="20"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                                 <h4><span class="badge text-bg-light"><i class="fa fa-bars"></i> Health & Placement Characteristic</span></h4>                                
                            </div>
                        </div>   
                        <div class="row  mb-2">
                            <div class="col-md-2">
                                <label>Health</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddHealth" Class="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Placement</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddPlacement" Class="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Location</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddLocation" Class="form-control" runat="server"> </asp:DropDownList>       
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Area</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddArea" Class="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Spot</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtSpot" runat="server" CssClass="form-control" placeholder="Spot"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>User</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" placeholder="User"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                                 <h4><span class="badge text-bg-light"><i class="fa fa-bars"></i> Spesification</span></h4>                                
                            </div>
                        </div> 
                        <div class="row  mb-2">
                            <div class="col-md-2">
                                <label>Type</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddType" runat="server" Class="form-control"> </asp:DropDownList>
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Asset Type is empty" ControlToValidate="ddType" Display="Dynamic" ForeColor="Red" CssClass="auto-style1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Brand</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddBrand" Class="form-control" runat="server" > </asp:DropDownList>                                    
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Brand Asset is empty" ControlToValidate="ddBrand" Display="Dynamic" ForeColor="Red" CssClass="auto-style1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>Model</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtModel" runat="server" CssClass="form-control" placeholder="Model"></asp:TextBox>
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Model is empty" ControlToValidate="txtModel" Display="Dynamic" ForeColor="Red" CssClass="auto-style1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>                                
                            </div>
                            <div class="col-md-2">
                                <label>Series</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtSeries" CssClass="form-control" runat="server" placeholder="Series"></asp:TextBox>
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Series is empty" ControlToValidate="txtSeries" Display="Dynamic" ForeColor="Red" CssClass="auto-style1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>                                
                            </div>
                            <div class="col-md-3">
                                <label>Serial No</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtSerialNo" CssClass="form-control" runat="server" placeholder="Series No"></asp:TextBox>
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Serial No is empty" ControlToValidate="txtSerialNo" Display="Dynamic" ForeColor="Red" CssClass="auto-style1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row  mb-2">
                            <div class="col-md-3">
                                <label>Host Name</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtHostName" runat="server" CssClass="form-control" placeholder="Host Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Color</label>
                                <div class="form-group mb-2">
                                     <asp:DropDownList ID="ddColor" runat="server"  Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>Processor</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtProcessor" runat="server" CssClass="form-control" placeholder="Processor"></asp:TextBox>
                                </div>                                
                            </div>
                            <div class="col-md-3">
                                <label>OS</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddOS" Class="form-control" runat="server" > </asp:DropDownList>
                                </div>
                            </div>
                        </div>     
                        <div class="row">
                            <div class="col">
                                <hr />
                                 <h4><span class="badge text-bg-light"><i class="fa fa-bars"></i> Screen</span></h4>                                
                            </div>
                        </div>  
                        <div class="row  mb-2">
                            <div class="col-md-3">
                                <label>Size</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtScrSize" runat="server" CssClass="form-control" placeholder="Size"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Resolution</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtScrRsl" runat="server" CssClass="form-control" placeholder="Resolution"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Touch Screen</label>
                                <div class="form-group mb-2">
                                     <asp:DropDownList ID="ddTchScr" runat="server"  Class="form-control"></asp:DropDownList>
                                </div>
                            </div>                           
                        </div> 
                        <div class="row">
                            <div class="col">
                                <hr />
                                 <h4><span class="badge text-bg-light"><i class="fa fa-bars"></i> VGA</span></h4>                                
                            </div>
                        </div>
                        <div class="row  mb-2">
                            <div class="col-md-2">
                                <label>Brand</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddVGABrand" runat="server" Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>Type</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddVGAType" runat="server" Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>Size</label>
                                <div class="form-group mb-2">
                                     <asp:TextBox ID="txtVGASize" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>                           
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                                 <h4><span class="badge text-bg-light"><i class="fa fa-bars"></i> RAM & Storage</span></h4>                                
                            </div>
                        </div>
                        <div class="row  mb-2">
                            <div class="col-md-3">
                                <label>RAM Type</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddRAMType" runat="server" Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>RAM MHz</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtRAMMHz" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>RAM Size</label>
                                <div class="form-group mb-2">
                                     <asp:TextBox ID="txtRAMSize" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                </div>
                            </div> 
                            <div class="col-md-3">
                                <label>Storage Type</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddStrType" runat="server" Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Storage Size</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtStrSize" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                                 <h4><span class="badge text-bg-light"><i class="fa fa-bars"></i> Charger</span></h4>                                
                            </div>
                        </div>
                        <div class="row  mb-2">
                            <div class="col-md-3">
                                <label>Type</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddChrType" runat="server" Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Voltage</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtVoltage" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Amps</label>
                                <div class="form-group mb-2">
                                     <asp:TextBox ID="txtAmps" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                </div>
                            </div> 
                            <div class="col-md-3">
                                <label>Watt</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtWatt" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                                 <h4><span class="badge text-bg-light"><i class="fa fa-bars"></i> Battery</span></h4>                                
                            </div>
                        </div>
                        <div class="row  mb-2">
                            <div class="col-md-3">
                                <label>Type</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtBtrType" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Voltage</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtBtrVoltage" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Amps</label>
                                <div class="form-group mb-2">
                                     <asp:TextBox ID="txtBtrAmps" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                </div>
                            </div> 
                            <div class="col-md-3">
                                <label>Watt</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtBtrWatt" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                                 <h4><span class="badge text-bg-light"><i class="fa fa-bars"></i> Others</span></h4>                                
                            </div>
                        </div>
                        <div class="row  mb-2">                            
                            <div class="col-md-4">
                                <label>Motherboard</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtMotherboard" CssClass="form-control" runat="server" placeholder="Motherboard"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>Chasing Size</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddCshSize" runat="server" Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>Camera Resolution</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtResolution" CssClass="form-control" runat="server" placeholder="Camera Resolution"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Channel Quantity</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtCnlQty" CssClass="form-control" runat="server" placeholder="Channel Quantity"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row  mb-2"> 
                            <div class="col-md-3">
                                <label>IMEI</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtImei" CssClass="form-control" runat="server" placeholder="Imei"></asp:TextBox>
                                </div>
                            </div>                           
                            <div class="col-md-3">
                                <label>MAC Address</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtMacAddr" CssClass="form-control" runat="server" placeholder="MAC Address"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>IP Address</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtIP" CssClass="form-control" runat="server" placeholder="IP"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>Mobile Number</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server" placeholder="Mobile Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row  mb-2">                         
                            <div class="col-md-6">
                                <label>Remark</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtRemark" CssClass="form-control" runat="server" placeholder="Remark" TextMode="MultiLine" Rows="3" MaxLength="500"></asp:TextBox>
                                </div>
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
