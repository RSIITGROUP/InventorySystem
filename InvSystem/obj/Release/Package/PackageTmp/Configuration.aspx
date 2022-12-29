<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Configuration.aspx.cs" Inherits="InvSystem.Configuration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row mb-2">
            <div class="col-md-7 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <%--<div class="row">
                            <div class="col">
                                <center>
                                       <h4>Asset Configuration</h4>
                                </center>
                            </div>
                        </div>                      
                        <div class="row  mb-2">
                            <div class="col">
                                <hr />
                            </div>
                        </div> --%>  
                        <div class="row justify-content-center mb-2">
                            <div class="col-md-4">                                
                                <label>Type</label>                                    
                                <div class="form-group">  
                                    <asp:DropDownList ID="ddType" runat="server" Class="form-control" OnSelectedIndexChanged="ddType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>                                
                            </div>
                        </div>
                        <div class="row  mb-2">
                            <div class="col-md-5">
                                <center>
                                    <label>From</label>
                                    <div class="form-group">  
                                        <asp:ListBox ID="lstSource" runat="server" Class="form-control" Height="400px" Width="200px" SelectionMode="Multiple"></asp:ListBox>
                                    </div>
                                </center>
                            </div>
                            <div class="col align-self-center">                                  
                                <div class="d-grid gap-2 justify-content-center">  
                                    <button id="Button1" class="btn btn-info btn-sm" onserverclick="btnGo_Click" runat="server"><i class="fa fa-angle-double-right   fa-lg"></i> </button>
                                    <button id="Button2" class="btn btn-info btn-sm" onserverclick="btnBack_Click" runat="server"><i class="fa fa-angle-double-left fa-lg"></i> </button>
                                </div>                                
                            </div>
                            <div class="col-md-5">
                                <center>
                                    <label>To</label>
                                    <div class="form-group">  
                                        <asp:ListBox ID="lstDestination" runat="server" Class="form-control" Height="400px" Width="200px" SelectionMode="Multiple"></asp:ListBox>
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
                                <center>                                    
                                    <br />
                                    <asp:Button class="btn btn-success" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                </center>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
