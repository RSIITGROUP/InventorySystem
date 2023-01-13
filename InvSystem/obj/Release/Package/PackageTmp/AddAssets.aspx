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
                <div class="card" id="mains" runat="server">
                    <div class="card-body">                                
                        <div class="row  mb-2">
                            <div class="col">
                                <a href="Asset.aspx"><< Back To Asset List</a><br />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                 <h4><span class="badge text-bg-light"><i class="fa fa-bars"></i> Asset Header</span></h4>                                
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
                                    <%--<asp:TextBox ID="txtUser" runat="server" CssClass="form-control" placeholder="User"></asp:TextBox>--%>
                                    <asp:DropDownList ID="ddUser" Class="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        
                        <div class="row  mb-2">
                            <div class="col-md-2">
                                <label>Type</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddType" runat="server" Class="form-control" OnSelectedIndexChanged="ddType_SelectedIndexChanged" AutoPostBack="true"> </asp:DropDownList>
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
                            <div class="col-md-2">
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
                            <div class="col-md-2">
                                <label>Serial No</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtSerialNo" CssClass="form-control" runat="server" placeholder="Series No"></asp:TextBox>
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Serial No is empty" ControlToValidate="txtSerialNo" Display="Dynamic" ForeColor="Red" CssClass="auto-style1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Color</label>
                                <div class="form-group mb-2">
                                     <asp:DropDownList ID="ddColor" runat="server"  Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>   
                        <div class="row" id="Detail9" runat="server">
                            <div class="col">
                                <hr />
                                 <h4><span class="badge text-bg-light"><i class="fa fa-bars"></i> Asset Detail</span></h4>                                
                            </div>
                        </div>
                        <div class="row  mb-2" id="Detail1" runat="server">
                            <div class="col-md-2" id="HostName" runat="server">
                                <label>Host Name</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtHostName" runat="server" CssClass="form-control" placeholder="Host Name"></asp:TextBox>
                                </div>
                            </div>                            
                            <div class="col-md-2" id="Processor" runat="server">
                                <label>Processor</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddProcessor" runat="server"  Class="form-control"></asp:DropDownList>
                                </div>                                
                            </div>
                            <div class="col-md-2" id="OperatingSystem" runat="server">
                                <label>Operating System</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddOperatingSystem" Class="form-control" runat="server" > </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" id="TypeConnectivity" runat="server">
                                <label>Type Connectivity</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddTypeConnectivity" Class="form-control" runat="server" > </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" id="TypeFunctionality" runat="server">
                                <label>Type Functionality</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddTypeFunctionality" Class="form-control" runat="server" > </asp:DropDownList>
                                </div>
                            </div>
                        </div>    
                        <div class="row  mb-2"  id="Detail2" runat="server">
                            <div class="col-md-2" id="ScreenSize" runat="server">
                                <label>Screen Size</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddScrSize" runat="server"  Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" id="ScreenResolution" runat="server">
                                <label>Screen Resolution</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddScrRsl" runat="server"  Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" id="TouchScreen" runat="server">
                                <label>Touch Screen</label>
                                <div class="form-group mb-2">
                                     <asp:DropDownList ID="ddTchScr" runat="server"  Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" id="VGABrand" runat="server">
                                <label>VGA Brand</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddVGABrand" runat="server" Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" id="VGAType" runat="server">
                                <label>VGA Type</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddVGAType" runat="server" Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" id="VGASize" runat="server">
                                <label>VGA Size</label>
                                <div class="form-group mb-2">
                                     <asp:TextBox ID="txtVGASize" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>                         
                        <div class="row  mb-2" id="Detail3" runat="server">
                                                       
                        </div>                        
                        <div class="row  mb-2" id="Detail4" runat="server">
                            <div class="col-md-3" id="RAMType" runat="server">
                                <label>RAM Type</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddRAMType" runat="server" Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" id="RAMMHz" runat="server">
                                <label>RAM MHz</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtRAMMHz" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" id="RAMSize" runat="server">
                                <label>RAM Size</label>
                                <div class="form-group mb-2">
                                     <asp:TextBox ID="txtRAMSize" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                </div>
                            </div> 
                            <div class="col-md-3" id="Storagetype" runat="server">
                                <label>Storage Type</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddStrType" runat="server" Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" id="StorageSize" runat="server">
                                <label>Storage Size</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtStrSize" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>                        
                        <div class="row  mb-2" id="Detail5" runat="server">
                            <div class="col-md-2" id="ChargerType" runat="server">
                                <label>Charger Type</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddChrType" runat="server" Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" id="UnitVoltage" runat="server">
                                <label>Unit Voltage</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddUnitVoltage" runat="server" Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" id="UnitAmps" runat="server">
                                <label>Unit Amps</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddUnitAmps" runat="server" Class="form-control"></asp:DropDownList>
                                </div>
                            </div> 
                            <div class="col-md-2" id="UnitWatt" runat="server">
                                <label>Unit Watt</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddUnitWatt" runat="server" Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" id="Motherboard" runat="server">
                                <label id="lblMotherboard">Motherboard</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtMotherboard" CssClass="form-control" runat="server" placeholder="Motherboard"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" id="ChasingSize" runat="server">
                                <label>Chasing Size</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddCshSize" runat="server" Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>                        
                        <div class="row  mb-2" id="Detail6" runat="server">
                            <div class="col-md-2" id="BatteryType" runat="server">
                                <label>Battery Type</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddBtrType" runat="server"  Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" id="BatteryVoltage" runat="server">
                                <label>Battery Voltage</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddBtrVoltage" runat="server" Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" id="BatteryAmps" runat="server">
                                <label>Battery Amps</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddBtrAmps" runat="server" Class="form-control"></asp:DropDownList>
                                </div>
                            </div> 
                            <div class="col-md-2" id="BatteryWatt" runat="server">
                                <label>Battery Watt</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddBtrWatt" runat="server" Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" id="CameraResolution" runat="server">
                                <label>Camera Resolution</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddResolution" runat="server" Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" id="CameraType" runat="server">
                                <label>Camera Type</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddCameraType" runat="server" Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>                        
                        <div class="row  mb-2" id="Detail7" runat="server">                            
                            <div class="col-md-2" id="TypeQuality" runat="server">
                                <label>Type Quality</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddTypeQuality" runat="server"  Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" id="TypePort" runat="server">
                                <label>Type Port</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddTypePort" runat="server" Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" id="TypeSystem" runat="server">
                                <label>Type System</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddTypeSystem" runat="server" Class="form-control"></asp:DropDownList>
                                </div>
                            </div> 
                            <div class="col-md-2" id="PortQuantity" runat="server">
                                <label>Port Quantity</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddPortQuantity" runat="server" Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" id="SFPPortQuantity" runat="server">
                                <label>SFP Port Quantity</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddSFPPortQuantity" runat="server" Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2" id="FrequencyBand" runat="server">
                                <label>Frequency Band</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddFrequencyBand" runat="server" Class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row  mb-2" id="Detail8" runat="server"> 
                            <div class="col-md-3" id="Imei" runat="server">
                                <label>IMEI</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtImei" CssClass="form-control" runat="server" placeholder="Imei"></asp:TextBox>
                                </div>
                            </div>                           
                            <div class="col-md-3" id="MACAddress" runat="server">
                                <label>MAC Address</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtMacAddr" CssClass="form-control" runat="server" placeholder="MAC Address"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3" id="IP" runat="server">
                                <label>IP Address</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtIP" CssClass="form-control" runat="server" placeholder="IP"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3" id="MobileNumber" runat="server">
                                <label>Mobile Number</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server" placeholder="Mobile Number"></asp:TextBox>
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
