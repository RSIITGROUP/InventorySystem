<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="UploadAsset.aspx.cs" Inherits="InvSystem.UploadAsset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            font-size: medium;
        }
        .auto-style2 {
            font-size: small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row mb-2">
            <div class="col-md-12 mx-auto">
                <div class="card">
                    <div class="card-body">                     
                        <div class="row  mb-2">                            
                            <div class="col">
                                <br />
                                <center>
                                    <h5>Choose Type Of Asset and Download the Excel Template</h5>
                                </center>
                            </div>
                        </div>
                        <div class="row justify-content-center mb-3">
                            <div class="col-md-3">                                     
                                <div class="form-group">                                      
                                    <label><strong>Type</strong></label>
                                    <asp:DropDownList ID="ddType" runat="server" Class="form-control" OnSelectedIndexChanged="ddType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>                                
                            </div>
                        </div>
                        <div class="row  mb-3">
                            <div class="col">
                                <center>
                                    <%--<h5>Download and Complete the Excel Template</h5>--%>
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="auto-style1">TemplateUpload.xlsx  <i class="fa fa-download"></i></asp:LinkButton>
                                    <hr />
                                </center>
                            </div>
                        </div>
                        <div class="row  mb-3">
                            <div class="col">
                                <center>
                                    <h5>Upload Excel File</h5>
                                   <asp:FileUpload ID="FileUpload1"  runat="server"></asp:FileUpload>
                                </center>
                            </div>
                        </div>
                        <div class="row  mb-3">
                            <div class="col">
                                <center>
                                   <asp:Button ID="Button2" runat="server" Text="Upload" Height="33px" OnClick="Button1_Click"></asp:Button>
                                </center>
                            </div>
                        </div>
                        <div class="row  mb-3">
                            <div class="col">
                                <center>
                                    <asp:Label ID="Label1" runat="server" Text="Label" CssClass="auto-style2" ForeColor="Red"></asp:Label>
                                </center>
                            </div>
                        </div>
                        <div class="row  mb-3">
                            <div class="col" style="overflow-x: scroll;">
                                <center>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-responsive">
                                        <Columns>
                                            <asp:BoundField DataField="AssetDesc" HeaderText="AssetDesc" SortExpression="AssetDesc" />
                                            <asp:BoundField DataField="ActivaNo" HeaderText="ActivaNo" SortExpression="ActivaNo" />
                                            <asp:BoundField DataField="PurchaseDate" HeaderText="PurchaseDate" SortExpression="PurchaseDate" />
                                            <asp:BoundField DataField="GRPODocNo" HeaderText="GRPODocNo" SortExpression="GRPODocNo" />
                                            <asp:BoundField DataField="Placement" HeaderText="Placement" SortExpression="Placement" />
                                            <asp:BoundField DataField="LocationCode" HeaderText="LocationCode" SortExpression="LocationCode" />
                                            <asp:BoundField DataField="AreaCode" HeaderText="AreaCode" SortExpression="AreaCode" />
                                            <asp:BoundField DataField="Spot" HeaderText="Spot" SortExpression="Spot" />
                                            <asp:BoundField DataField="User" HeaderText="User" SortExpression="User" />
                                            <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                                            <asp:BoundField DataField="Brand" HeaderText="Brand" SortExpression="Brand" />
                                            <asp:BoundField DataField="Model" HeaderText="Model" SortExpression="Model" />
                                            <asp:BoundField DataField="Series" HeaderText="Series" SortExpression="Series" />
                                            <asp:BoundField DataField="SerialNo" HeaderText="SerialNo" SortExpression="SerialNo" />
                                            <asp:BoundField DataField="HostName" HeaderText="HostName" SortExpression="HostName" />
                                            <asp:BoundField DataField="Color" HeaderText="Color" SortExpression="Color" />
                                            <asp:BoundField DataField="ScreenSize" HeaderText="ScreenSize" SortExpression="ScreenSize" />
                                            <asp:BoundField DataField="ScreenResolution" HeaderText="ScreenResolution" SortExpression="ScreenResolution" />
                                            <asp:BoundField DataField="TouchScreen" HeaderText="TouchScreen" SortExpression="TouchScreen" />
                                            <asp:BoundField DataField="Processor" HeaderText="Processor" SortExpression="Processor" />
                                            <asp:BoundField DataField="VGABrand" HeaderText="VGABrand" SortExpression="VGABrand" />
                                            <asp:BoundField DataField="VGAType" HeaderText="VGAType" SortExpression="VGAType" />
                                            <asp:BoundField DataField="VGASize" HeaderText="VGASize" SortExpression="VGASize" />
                                            <asp:BoundField DataField="RAMType" HeaderText="RAMType" SortExpression="RAMType" />
                                            <asp:BoundField DataField="RAMMHz" HeaderText="RAMMHz" SortExpression="RAMMHz" />
                                            <asp:BoundField DataField="RAMSize" HeaderText="RAMSize" SortExpression="RAMSize" />
                                            <asp:BoundField DataField="Storagetype" HeaderText="Storagetype" SortExpression="Storagetype" />
                                            <asp:BoundField DataField="StorageSize" HeaderText="StorageSize" SortExpression="StorageSize" />
                                            <asp:BoundField DataField="ChargerType" HeaderText="ChargerType" SortExpression="ChargerType" />
                                            <asp:BoundField DataField="UnitVoltage" HeaderText="UnitVoltage" SortExpression="UnitVoltage" />
                                            <asp:BoundField DataField="UnitAmps" HeaderText="UnitAmps" SortExpression="UnitAmps" />
                                            <asp:BoundField DataField="UnitWatt" HeaderText="UnitWatt" SortExpression="UnitWatt" />
                                            <asp:BoundField DataField="BatteryType" HeaderText="BatteryType" SortExpression="BatteryType" />
                                            <asp:BoundField DataField="BatteryVoltage" HeaderText="BatteryVoltage" SortExpression="BatteryVoltage" />
                                            <asp:BoundField DataField="BatteryAmps" HeaderText="BatteryAmps" SortExpression="BatteryAmps" />
                                            <asp:BoundField DataField="BatteryWatt" HeaderText="BatteryWatt" SortExpression="BatteryWatt" />
                                            <asp:BoundField DataField="Motherboard" HeaderText="Motherboard" SortExpression="Motherboard" />
                                            <asp:BoundField DataField="ChasingSize" HeaderText="ChasingSize" SortExpression="ChasingSize" />
                                            <asp:BoundField DataField="CameraResolution" HeaderText="CameraResolution" SortExpression="CameraResolution" />
                                            <asp:BoundField DataField="CameraType" HeaderText="CameraType" SortExpression="CameraType" />
                                            <asp:BoundField DataField="Health" HeaderText="Health" SortExpression="Health" />
                                            <asp:BoundField DataField="OperatingSystem" HeaderText="OperatingSystem" SortExpression="OperatingSystem" />
                                            <asp:BoundField DataField="Imei" HeaderText="Imei" SortExpression="Imei" />
                                            <asp:BoundField DataField="MACAddress" HeaderText="MACAddress" SortExpression="MACAddress" />
                                            <asp:BoundField DataField="IP" HeaderText="IP" SortExpression="IP" />
                                            <asp:BoundField DataField="MobileNumber" HeaderText="MobileNumber" SortExpression="MobileNumber" />
                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />
                                            <asp:BoundField DataField="TypeQuality" HeaderText="TypeQuality" SortExpression="TypeQuality"/>
                                            <asp:BoundField DataField="TypePort" HeaderText="TypePort" SortExpression="TypePort"/>
                                            <asp:BoundField DataField="TypeSystem" HeaderText="TypeSystem" SortExpression="TypeSystem"/>
                                            <asp:BoundField DataField="PortQuantity" HeaderText="PortQuantity" SortExpression="PortQuantity"/>
                                            <asp:BoundField DataField="SFPPortQuantity" HeaderText="SFPPortQuantity" SortExpression="SFPPortQuantity"/>
                                            <asp:BoundField DataField="FrequencyBand" HeaderText="FrequencyBand" SortExpression="FrequencyBand"/>
                                            <asp:BoundField DataField="TypeConnectivity" HeaderText="TypeConnectivity" SortExpression="TypeConnectivity"/>
                                            <asp:BoundField DataField="TypeFunctionality" HeaderText="TypeFunctionality" SortExpression="TypeFunctionality"/>
                                        </Columns>
                                    </asp:GridView>
                                </center>
                            </div>
                        </div>
                    </div>
                </div>
                <a href="Asset.aspx"><< Back To List Asset</a><br />
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
