<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="DetailAsset.aspx.cs" Inherits="InvSystem.DetailAsset" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>    
    <asp:Panel ID="Panel1" CssClass="popup roundedcorner" runat="server" Width="950px" Height="350px">    
        <div>                                
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" >
                <Columns>
                    <asp:BoundField DataField="Version" HeaderText="Version" SortExpression="Version" />
                    <asp:BoundField DataField="PlacementCharacteristic" HeaderText="Placement Characteristic" SortExpression="PlacementCharacteristic" />
                    <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                    <asp:BoundField DataField="Area" HeaderText="Area" SortExpression="Area" />
                    <asp:BoundField DataField="Spot" HeaderText="Spot" SortExpression="Spot" />
                    <asp:BoundField DataField="User" HeaderText="User" SortExpression="User" />
                    <asp:BoundField DataField="CreateDate" HeaderText="Create Date" ReadOnly="True" SortExpression="CreateDate" />
                </Columns>
            </asp:GridView>
        </div>
    </asp:Panel> 
    <asp:Panel ID="Panel2" CssClass="popup roundedcorner" runat="server" Width="700px" Height="300px">     
        <div>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" >
                <Columns>
                    <asp:BoundField DataField="Version" HeaderText="Version" SortExpression="Version" />
                    <asp:BoundField DataField="Health" HeaderText="Health" SortExpression="Health" />
                    <asp:BoundField DataField="CreateDate" HeaderText="Create Date" ReadOnly="True" SortExpression="CreateDate" />
                </Columns>
            </asp:GridView>
        </div>
    </asp:Panel>
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="mpe" TargetControlID="Button1" PopupControlID="Panel1" BackgroundCssClass="background" runat="server"></cc1:ModalPopupExtender>
    <cc1:ModalPopupExtender ID="ModalPopupExtender2" BehaviorID="mpe2" TargetControlID="Button2" PopupControlID="Panel2" BackgroundCssClass="background" runat="server"></cc1:ModalPopupExtender>
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
                                <asp:Button ID="Button1" runat="server" Text="Placement History" CssClass="roundedcorner" Font-Size="Large" />
                                <asp:Button ID="Button2" runat="server" Text="Health History" CssClass="roundedcorner" Font-Size="Large" />									  
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
                                    <asp:TextBox ID="txtAssetCode" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>                                
                            </div>
                            <div class="col-md-3">
                                <label>Description</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtAssetDesc" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>                                    
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>Activa Number</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtActivaNO" CssClass="form-control" runat="server" ReadOnly="True" MaxLength="50"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Purchase Date</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtPurchaseDate" CssClass="form-control" runat="server" ReadOnly="True"  TextMode="Date"></asp:TextBox>                                     
                                </div>                                
                            </div>                                   
                            <div class="col-md-2">
                                <label>GRPO Doc Num</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtGRPODocNum" CssClass="form-control" runat="server" ReadOnly="True" MaxLength="20"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        
                        <div class="row  mb-2">
                            <div class="col-md-2">
                                <label>Health</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtHealth" Class="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Placement</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtPlacement" Class="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Location</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtLocation" Class="form-control" runat="server" ReadOnly="True"> </asp:TextBox>       
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Area</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtArea" Class="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Spot</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtSpot" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>User</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        
                        <div class="row  mb-2">
                            <div class="col-md-2">
                                <label>Type</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtType" runat="server" Class="form-control" ReadOnly="True"> </asp:TextBox>
                                    
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Brand</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtBrand" Class="form-control" runat="server" ReadOnly="True"> </asp:TextBox>                                    
                                    
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Model</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtModel" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                    
                                </div>                                
                            </div>
                            <div class="col-md-2">
                                <label>Series</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtSeries" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                    
                                </div>                                
                            </div>
                            <div class="col-md-2">
                                <label>Serial No</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtSerialNo" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                    
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Color</label>
                                <div class="form-group mb-2">
                                     <asp:TextBox ID="txtColor" runat="server"  Class="form-control" ReadOnly="True"></asp:TextBox>
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
                                    <asp:TextBox ID="txtHostName" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>                            
                            <div class="col-md-2" id="Processor" runat="server">
                                <label>Processor</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtProcessor" runat="server"  Class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>                                
                            </div>
                            <div class="col-md-2" id="OperatingSystem" runat="server">
                                <label>Operating System</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtOperatingSystem" Class="form-control" runat="server" ReadOnly="True"> </asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" id="TypeConnectivity" runat="server">
                                <label>Type Connectivity</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtTypeConnectivity" Class="form-control" runat="server" ReadOnly="True"> </asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" id="TypeFunctionality" runat="server">
                                <label>Type Functionality</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtTypeFunctionality" Class="form-control" runat="server" ReadOnly="True"> </asp:TextBox>
                                </div>
                            </div>
                        </div>    
                        <div class="row  mb-2"  id="Detail2" runat="server">
                            <div class="col-md-2" id="ScreenSize" runat="server">
                                <label>Screen Size</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtScrSize" runat="server"  Class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" id="ScreenResolution" runat="server">
                                <label>Screen Resolution</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtScrRsl" runat="server"  Class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" id="TouchScreen" runat="server">
                                <label>Touch Screen</label>
                                <div class="form-group mb-2">
                                     <asp:TextBox ID="txtTchScr" runat="server"  Class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" id="VGABrand" runat="server">
                                <label>VGA Brand</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtVGABrand" runat="server" Class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" id="VGAType" runat="server">
                                <label>VGA Type</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtVGAType" runat="server" Class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" id="VGASize" runat="server">
                                <label>VGA Size</label>
                                <div class="form-group mb-2">
                                     <asp:TextBox ID="txtVGASize" runat="server" CssClass="form-control" TextMode="Number" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>                         
                        <div class="row  mb-2" id="Detail3" runat="server">
                                                       
                        </div>                        
                        <div class="row  mb-2" id="Detail4" runat="server">
                            <div class="col-md-3" id="RAMType" runat="server">
                                <label>RAM Type</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtRAMType" runat="server" Class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" id="RAMMHz" runat="server">
                                <label>RAM MHz</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtRAMMHz" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" id="RAMSize" runat="server">
                                <label>RAM Size</label>
                                <div class="form-group mb-2">
                                     <asp:TextBox ID="txtRAMSize" runat="server" CssClass="form-control" TextMode="Number" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div> 
                            <div class="col-md-3" id="Storagetype" runat="server">
                                <label>Storage Type</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtStrType" runat="server" Class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" id="StorageSize" runat="server">
                                <label>Storage Size</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtStrSize" runat="server" CssClass="form-control" TextMode="Number" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>                        
                        <div class="row  mb-2" id="Detail5" runat="server">
                            <div class="col-md-2" id="ChargerType" runat="server">
                                <label>Charger Type</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtChrType" runat="server" Class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" id="UnitVoltage" runat="server">
                                <label>Unit Voltage</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtUnitVoltage" runat="server" Class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" id="UnitAmps" runat="server">
                                <label>Unit Amps</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtUnitAmps" runat="server" Class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div> 
                            <div class="col-md-2" id="UnitWatt" runat="server">
                                <label>Unit Watt</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtUnitWatt" runat="server" Class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" id="Motherboard" runat="server">
                                <label id="lblMotherboard">Motherboard</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtMotherboard" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" id="ChasingSize" runat="server">
                                <label>Chasing Size</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtCshSize" runat="server" Class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>                        
                        <div class="row  mb-2" id="Detail6" runat="server">
                            <div class="col-md-2" id="BatteryType" runat="server">
                                <label>Battery Type</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtBtrType" runat="server"  Class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" id="BatteryVoltage" runat="server">
                                <label>Battery Voltage</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtBtrVoltage" runat="server" Class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" id="BatteryAmps" runat="server">
                                <label>Battery Amps</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtBtrAmps" runat="server" Class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div> 
                            <div class="col-md-2" id="BatteryWatt" runat="server">
                                <label>Battery Watt</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtBtrWatt" runat="server" Class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" id="CameraResolution" runat="server">
                                <label>Camera Resolution</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtResolution" runat="server" Class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" id="CameraType" runat="server">
                                <label>Camera Type</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtCameraType" runat="server" Class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>                        
                        <div class="row  mb-2" id="Detail7" runat="server">                            
                            <div class="col-md-2" id="TypeQuality" runat="server">
                                <label>Type Quality</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtTypeQuality" runat="server"  Class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" id="TypePort" runat="server">
                                <label>Type Port</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtTypePort" runat="server" Class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" id="TypeSystem" runat="server">
                                <label>Type System</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtTypeSystem" runat="server" Class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div> 
                            <div class="col-md-2" id="PortQuantity" runat="server">
                                <label>Port Quantity</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtPortQuantity" runat="server" Class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" id="SFPPortQuantity" runat="server">
                                <label>SFP Port Quantity</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtSFPPortQuantity" runat="server" Class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" id="FrequencyBand" runat="server">
                                <label>Frequency Band</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtFrequencyBand" runat="server" Class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row  mb-2" id="Detail8" runat="server"> 
                            <div class="col-md-3" id="Imei" runat="server">
                                <label>IMEI</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtImei" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>                           
                            <div class="col-md-3" id="MACAddress" runat="server">
                                <label>MAC Address</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtMacAddr" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3" id="IP" runat="server">
                                <label>IP Address</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtIP" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3" id="MobileNumber" runat="server">
                                <label>Mobile Number</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
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
                    </div>
                </div>
            </div>
        </div>
    </div>       
    <script type="text/javascript">
        function pageLoad() {
            var modalPopup = $find('mpe');
            modalPopup.add_shown(function () {
                modalPopup._backgroundElement.addEventListener("click", function () {
                    modalPopup.hide();
                });
            });

            var modalPopup2 = $find('mpe2');
            modalPopup2.add_shown(function () {
                modalPopup2._backgroundElement.addEventListener("click", function () {
                    modalPopup2.hide();
                });
            });
        };

         $(function () {
            $('#<%=GridView1.ClientID%>').DataTable(
            {
                bLengthChange: true,
                lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                bFilter: true,
                bSort: true,
                bPaginate: true
                 });

             $('#<%=GridView2.ClientID%>').DataTable(
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
