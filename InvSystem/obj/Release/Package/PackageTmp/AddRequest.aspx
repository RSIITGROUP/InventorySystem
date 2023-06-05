﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AddRequest.aspx.cs" Inherits="InvSystem.AddRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <div class="container">
        <div class="row mb-2">
            <div class="col-md-12 mx-auto">
                <div class="card" id="mains" runat="server">
                    <div class="card-body">                                
                        <%--<div class="row  mb-2">
                            <div class="col">
                                <a href="Asset.aspx"><< Back To Asset List</a><br />  
                            </div>
                        </div>--%>
                        <div class="row">
                            <div class="col">
                                 <h4><span class="badge text-bg-light"><i class="fa fa-bars"></i> Request</span></h4>                                
                            </div>
                        </div> 
                        <div class="row  mb-2">
                            <div class="col-md-2">
                                <label>Request Id</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtReqId" CssClass="form-control" runat="server" placeholder="Request Id" ReadOnly="True"></asp:TextBox>
                                    
                                </div>                                
                            </div>
                            <div class="col-md-2">
                                <label>Production Date</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtReqDate" CssClass="form-control" runat="server" placeholder="Request Date"  TextMode="Date"></asp:TextBox> 
                                    
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Work Group</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddWorkGroup" Class="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Purpose</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddPurpose" Class="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Request Description</label>
                                <div class="form-group mb-2">
                                    <asp:DropDownList ID="ddReqDesc" Class="form-control" runat="server"></asp:DropDownList>                                    
                                </div>
                            </div>
                        </div>           
                        <%--<div class="row  mb-2">                         
                            <div class="col-md-8">
                                <label>Request Description</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtReqDesc" CssClass="form-control" runat="server" placeholder="Requst Description" TextMode="MultiLine" Rows="3" MaxLength="500"></asp:TextBox>
                                    
                                </div>
                            </div>
                        </div>--%>
                        <div class="row">                         
                            <div class="col-md-12">
                                <iframe height="200" id="frame1" width="100%" runat="server"></iframe>
                            </div>
                        </div>
                        <div class="row  mb-2" id="divapproval" runat="server">                         
                            <div class="col-md-10">
                                <iframe height="150" width="100%" id="frame2" runat="server" scrolling="no"></iframe>
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
                        <div class="row mb-2" runat="server" id="divSave">
                            <div class="col">                                
                                <div class="form-group">
                                    <center>
                                        <asp:Button ID="btnAdd" class="btn btn-primary" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                        <input id="Reset1" class="btn btn-success" type="reset" value="Reset" runat="server"/>
                                     </center>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>  
    <script type="text/javascript">       
      

    </script>
</asp:Content>
