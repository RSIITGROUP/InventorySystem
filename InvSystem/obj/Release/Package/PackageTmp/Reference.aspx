<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Reference.aspx.cs" Inherits="InvSystem.Reference" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function refresh(val) {
            var ifrm = document.getElementById(val);
            ifrm.src = ifrm.src;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row mb-2">
            <div class="col-md-12 mx-auto">
                <div class="card">
                    <div class="card-body">   
                        <div class="row  mb-2">
                            <div class="col">
                                <ul class="nav nav-tabs">
                                    <li class="nav-item" role="presentation" onclick="refresh('frame1')">
                                        <button class="nav-link active" data-bs-toggle="tab" id="refType-tab" type="button" data-bs-target="#refType" role="tab" aria-controls="refType" aria-selected="true">Reference Type</button>
                                    </li>
                                    <li class="nav-item" role="presentation" onclick="refresh('frame2')">
                                        <button class="nav-link" data-bs-toggle="tab" id="reference-tab" type="button" data-bs-target="#reference" role="tab" aria-controls="reference" aria-selected="true">Reference</button>
                                    </li>
                                </ul>
                                <div class="tab-content" id="myTabControl">
                                    <div class="tab-pane fade show active" role="tabpanel" id="refType" aria-labelledby="refType-tab">
                                        <div><br /></div>
                                        <center>
                                            <iframe src="ReferenceType.aspx" height="480" width="1080" id="frame1" onclick="refresh('frame1')"></iframe>
                                        </center>
                                    </div>
                                    <div class="tab-pane fade" role="tabpanel" id="reference" aria-labelledby="reference-tab">       
                                        <div><br /></div>
                                        <center>
                                            <iframe src="DetailReference.aspx" height="480" width="1080" id="frame2" onclick="refresh('frame2')"></iframe>
                                        </center>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
