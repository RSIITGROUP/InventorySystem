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
                <div class="card">
                    <div class="card-body">   
                        <div class="row  mb-2">
                            <div class="col">
                                <%--<br />--%>
                                <a href="Asset.aspx"><< Back To Asset List</a><br />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:Button ID="Button1" runat="server" Text="Placement History" CssClass="roundedcorner" Font-Size="Large" />
                                <asp:Button ID="Button2" runat="server" Text="Health History" CssClass="roundedcorner" Font-Size="Large" />									  
                            </div>
                        </div>                                 
                        
                        <div class="row  mb-2">
                            <div class="col">
                               <%-- <br />--%>
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
                                    <asp:TextBox ID="txtAssetCode" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>                                
                            </div>
                            <div class="col-md-3">
                                <label>Description</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtAssetDesc" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>                                    
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>Activa Number</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtActivaNO" CssClass="form-control" runat="server" MaxLength="50" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Purchase Date</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtPurchaseDate" CssClass="form-control" runat="server" TextMode="Date" ReadOnly="true"></asp:TextBox>                                     
                                </div>                                
                            </div>                                   
							  
													  
                            <div class="col-md-2">
                                <label>GRPO Doc Num</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtGRPODocNum" CssClass="form-control" runat="server" MaxLength="20" ReadOnly="true"></asp:TextBox>
									  
								  
												  
													 
															 
																																	 
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
                                    <asp:TextBox ID="txtHealth" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
							  
											   
                            <div class="col-md-2">
                                <label>Placement</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtPlacement" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Location</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>       
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Area</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtArea" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Spot</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtSpot" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>User</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
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
                                    <asp:TextBox ID="txtType" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Brand</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtBrand" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>Model</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtModel" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>                                
                            </div>
                            <div class="col-md-2">
                                <label>Series</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtSeries" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>                                
                            </div>
                            <div class="col-md-3">
                                <label>Serial No</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtSerialNo" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
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
                                     <asp:TextBox ID="txtColor" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
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
                                    <asp:TextBox ID="txtOS" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
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
                                    <asp:TextBox ID="txtScrSize" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Resolution</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtScrRsl" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Touch Screen</label>
                                <div class="form-group mb-2">
                                     <asp:TextBox ID="txtTchScr" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
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
                                    <asp:TextBox ID="txtVGABrand" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>Type</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtVGAType" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>Size</label>
                                <div class="form-group mb-2">
                                     <asp:TextBox ID="txtVGASize" runat="server" CssClass="form-control" TextMode="Number" ReadOnly="true"></asp:TextBox>
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
                                    <asp:TextBox ID="txtRAMType" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>RAM MHz</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtRAMMHz" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>RAM Size</label>
                                <div class="form-group mb-2">
                                     <asp:TextBox ID="txtRAMSize" runat="server" CssClass="form-control" TextMode="Number" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div> 
                            <div class="col-md-3">
                                <label>Storage Type</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtStrType" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Storage Size</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtStrSize" runat="server" CssClass="form-control" TextMode="Number" ReadOnly="true"></asp:TextBox>
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
                                    <asp:TextBox ID="txtChrType" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Voltage</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtVoltage" runat="server" CssClass="form-control" TextMode="Number" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Amps</label>
                                <div class="form-group mb-2">
                                     <asp:TextBox ID="txtAmps" runat="server" CssClass="form-control" TextMode="Number" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div> 
                            <div class="col-md-3">
                                <label>Watt</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtWatt" runat="server" CssClass="form-control" TextMode="Number" ReadOnly="true"></asp:TextBox>
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
                                    <asp:TextBox ID="txtBtrType" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Voltage</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtBtrVoltage" runat="server" CssClass="form-control" TextMode="Number" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Amps</label>
                                <div class="form-group mb-2">
                                     <asp:TextBox ID="txtBtrAmps" runat="server" CssClass="form-control" TextMode="Number" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div> 
                            <div class="col-md-3">
                                <label>Watt</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtBtrWatt" runat="server" CssClass="form-control" TextMode="Number" ReadOnly="true"></asp:TextBox>
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
                                    <asp:TextBox ID="txtMotherboard" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>Chasing Size</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtCshSize" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>Camera Resolution</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtResolution" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Channel Quantity</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtCnlQty" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row  mb-2"> 
                            <div class="col-md-3">
                                <label>IMEI</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtImei" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>                           
                            <div class="col-md-3">
                                <label>MAC Address</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtMacAddr" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>IP Address</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtIP" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>Mobile Number</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row  mb-2">                         
                            <div class="col-md-6">
                                <label>Remark</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtRemark" CssClass="form-control" runat="server" ReadOnly="true" TextMode="MultiLine" Rows="3" MaxLength="500"></asp:TextBox>
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
