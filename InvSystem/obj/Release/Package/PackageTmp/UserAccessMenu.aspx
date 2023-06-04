<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="UserAccessMenu.aspx.cs" Inherits="InvSystem.UserAccessMenu" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: justify;
        }
       .WindowsStyle .ajax__combobox_inputcontainer .ajax__combobox_textboxcontainer input
        {
            margin: 0;
            border: solid 1px #7F9DB9;
            border-right: 0px none;
            padding: 1px 0px 0px 5px;
            font-size: 14px;
            height: 25px;
            position: relative;       
        }
        .WindowsStyle .ajax__combobox_inputcontainer .ajax__combobox_buttoncontainer button
        {
            height: 40px;
            width: 21px;
        }
        .WindowsStyle .ajax__combobox_itemlist
        {
            border-color: #7F9DB9;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <div class="container">
        <div class="row mb-2">
            <div class="col-md-7 mx-auto">
                <div class="card">
                    <div class="card-body"> 
                        <div class="row">
                            <div class="col">
                                <h4><span class="badge text-bg-light"><i class="fa fa-bars"></i> User Access Menu</span></h4>
                            </div>
                        </div>                       
                        <%--<div class="row  mb-2">
                            <div class="col">
                                <hr />
                            </div>
                        </div>--%>
                        <div class="row justify-content-center mb-2">
                            <div class="col-md-4">                                
                                <label>User</label>                                    
                                <div class="form-group">  
                                    <%--<asp:DropDownList ID="ddUser" runat="server" Class="form-control" OnSelectedIndexChanged="ddUser_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>--%>
                                    <ajaxToolkit:ComboBox ID="ddUsers" runat="server" CssClass="WindowsStyle"  AutoCompleteMode="SuggestAppend" AutoPostBack="true" OnSelectedIndexChanged="ddUsers_SelectedIndexChanged"></ajaxToolkit:ComboBox>
                                </div>                                
                            </div>
                        </div>
                        <div class="row  mb-2">
                            <div class="col-md-5">
                                <center>
                                    <label>From</label>
                                    <div class="form-group">  
                                        <asp:ListBox ID="lstSource" runat="server" Class="form-control" Height="200px" Width="200px" SelectionMode="Multiple"></asp:ListBox>
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
                                        <asp:ListBox ID="lstDestination" runat="server" Class="form-control" Height="200px" Width="200px" SelectionMode="Multiple"></asp:ListBox>
                                    </div>
                                </center>
                            </div>
                        </div> 
                        <div class="row">
                            <div class="col">
                                <br />
                                <h4><span class="badge text-bg-light"><i class="fa fa-bars"></i> Approver</span></h4>
                            </div>
                        </div>
                        <div class="row  mb-2">
                            <div class="col-md-5">
                                <div class="form-group">  
                                    <%--<asp:DropDownList ID="ddApprover" CssClass="form-control" runat="server"></asp:DropDownList>--%>
                                    <ajaxToolkit:ComboBox ID="ddApprovers" runat="server" CssClass="WindowsStyle"  AutoCompleteMode="SuggestAppend"></ajaxToolkit:ComboBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <br />
                                <h4><span class="badge text-bg-light"><i class="fa fa-bars"></i> Work Group</span></h4>
                            </div>
                        </div>
                        <div class="row  mb-2">
                            <div class="col-md-5">
                                <div class="form-group">  
                                    <asp:DropDownList ID="ddWorkGroup" CssClass="form-control" runat="server"></asp:DropDownList>
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
