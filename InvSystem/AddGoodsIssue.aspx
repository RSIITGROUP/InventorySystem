<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AddGoodsIssue.aspx.cs" Inherits="InvSystem.AddGoodsIssue" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
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
                                 <h4><span class="badge text-bg-light"><i class="fa fa-bars"></i> Goods Issue</span></h4>                                
                            </div>
                        </div> 
                        <div class="row  mb-2">
                            <div class="col-md-3">
                                <label>Goods Issue Id</label>
                                <div class="form-group mb-2">
                                    <asp:TextBox ID="txtGIId" CssClass="form-control" runat="server" placeholder="Goods Issue Id" ReadOnly="True"></asp:TextBox>                                    
                                </div>                                
                            </div>
                            <div class="col-md-3">
                                <label>Request Id</label>
                                <div class="form-group mb-2">
                                    <%--<asp:DropDownList ID="ddReqId" Class="form-control" runat="server" OnSelectedIndexChanged="ddReqId_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>  --%>   
                                    <ajaxToolkit:ComboBox ID="cbReqId"  runat="server" AutoCompleteMode="SuggestAppend" OnSelectedIndexChanged="ddReqId_SelectedIndexChanged" AutoPostBack="true"></ajaxToolkit:ComboBox>  
                                </div>
                            </div>
                            <%--<div class="col-md-3">
                                <label>Request Id2</label>
                                <div class="form-group mb-2">
                                    <ajaxToolkit:ComboBox ID="cbCustomers"  runat="server" AutoCompleteMode="SuggestAppend" OnSelectedIndexChanged="ddReqId_SelectedIndexChanged" AutoPostBack="true"></ajaxToolkit:ComboBox>                            
                                </div>
                            </div>--%>
                        </div>           
                        <div class="row">                         
                            <div class="col-md-12">
                                <iframe height="200" width="100%" id="frame1" runat="server"></iframe>
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
