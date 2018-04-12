<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ManagePurchase.aspx.cs" Inherits="AdvancePOS.Purchase.ManagePurchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .category1 {
            overflow-x: scroll;
            overflow-y: hidden;
            white-space: nowrap;
            margin: 0 10px;
        }
    </style>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <h1>New Purchase
            </h1>
            <ol class="breadcrumb">
                <li><a href="/default.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
                <li class="active">New Purchase</li>
            </ol>
        </div>
        <!-- Main content -->
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="content">
                    <div class="row">
                        <div class="col-xs-5">
                            <div class="box box-primary">
                                <div class="box-body">
                                    <div class="form-group">
                                        <asp:DropDownList ID="ddlProduct" runat="server" AppendDataBoundItems="true" CssClass="form-control select2"
                                            Width="100%" onchange="AddToCartPurchase(this.value)">
                                            <asp:ListItem Value="0">Search Products</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="box-body">
                                    <div id="productList" class="table-responsive">
                                    </div>
                                </div>
                                <div class="box-footer">
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-default"
                                        OnClick="btnReset_Click" />
                                    <a onclick="PopupPayment()" class="btn btn-info pull-right">Payment</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-xs-7">
                            <div class="box box-primary form-horizontal">
                                <div class="box-body">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">
                                            Category
                                        </label>
                                        <div class="col-sm-10">
                                            <asp:DropDownList ID="ddlCategory" runat="server" AppendDataBoundItems="true" CssClass="form-control select2"
                                                onchange="selectedCategory()">
                                                <asp:ListItem Value="0">-----All-----</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row margin-bottom">
                                        <div class="col-lg-12 productlist">
                                            <asp:Repeater ID="RpItems" runat="server">
                                                <ItemTemplate>
                                                    <div class="col-sm-3 product c_<%#Eval("CategoryID") %>">
                                                        <div class="waves-effect waves-block">
                                                            <h3 id="proname">
                                                                <%#Eval("Name") %></h3>
                                                            <div class="mask">
                                                                <h3>
                                                                    <%# GetAmount(Eval("PurchasePrice").ToString())%></h3>
                                                            </div>
                                                            <a onclick="AddToCartPurchase('<%#Eval("ID") %>')" class="btn btn-success btn-sm">Add
                                                                To Cart</a>
                                                            <img class="img-responsive" src="/assets/dist/img/photo1.png" alt="Photo">
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress runat="server" ID="updateProgress">
            <ProgressTemplate>
                <div class="overlay">
                    <i class="fa fa-refresh fa-spin"></i>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <div class="modal fade" id="edit" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span></button>
                                <h4 class="modal-title">
                                    <asp:HiddenField ID="HiddenID" runat="server" />
                                    <asp:Literal ID="ltrTitle" runat="server" Text="Payment" /></h4>
                            </div>
                            <div class="modal-body">
                                <div class="tab-content">
                                    <div class="box-body">
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12">
                                                <%--  <div class="form-group">
                                                    <h3 id="ItemsNum2">
                                                        <span>0</span> items</h3>
                                                </div>--%>
                                                <div class="form-group">
                                                    <h2 id="TotalModal"></h2>
                                                </div>
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            <label for="role">
                                                                Paid By
                                                            </label>
                                                            <asp:DropDownList ID="ddlPaidBy" CssClass="form-control" runat="server">
                                                                <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                                                <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                                                                <asp:ListItem Value="Credit Card">Credit Card</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            <label for="role">
                                                                Payment
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPayment"
                                                                    ForeColor="Red" ValidationGroup="supplier" SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                                            <asp:TextBox ID="txtPayment" runat="server" CssClass="form-control" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-lg-6">
                                                            <label for="role">
                                                                Supplier
                                                            </label>
                                                            <asp:DropDownList ID="ddlSupplier" CssClass="form-control" runat="server" AppendDataBoundItems="true">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <label for="role">
                                                                Date<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate"
                                                                    ForeColor="Red" ValidationGroup="supplier" SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator>
                                                            </label>
                                                            <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="role">
                                                        Notes
                                                    </label>
                                                    <asp:TextBox ID="txtNotes" TextMode="MultiLine" runat="server" CssClass="form-control" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    Close</button>
                                <asp:Button ID="btnSave" runat="server" Text="Save Changes" CssClass="btn btn-primary"
                                    ValidationGroup="supplier" OnClick="btnSave_Click" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <script type="text/javascript">
            function DeletePurchaseItem(ItemID) {
                jQuery.ajax({
                    type: "POST",
                    url: "/Helper/AdvancePOS.asmx/DeletePurchaseItem",
                    cache: false,
                    contentType: "application/json; charset=utf-8",
                    data: "{ItemID:'" + ItemID + "'}",
                    dataType: "json",
                    success: handleHtml,
                    error: ajaxFailed
                });

                function handleHtml(data) {
                    $('#productList').html(data.d);
                }

                function ajaxFailed(xmlRequest) {
                    alert("error");
                }
            }

            function UpdatePurchaseItem(ItemID, Qty) {
                jQuery.ajax({
                    type: "POST",
                    url: "/Helper/AdvancePOS.asmx/UpdatePurchaseItem",
                    cache: false,
                    contentType: "application/json; charset=utf-8",
                    data: "{ItemID:'" + ItemID + "',Qty:'" + Qty + "'}",
                    dataType: "json",
                    success: handleHtml,
                    error: ajaxFailed
                });

                function handleHtml(data) {
                    $('#productList').html(data.d);
                }

                function ajaxFailed(xmlRequest) {
                    alert("error");
                }
            }

            function selectedCategory() {
                var cID = $('#MainContent_ddlCategory').val();
                if (cID > 0) {
                    $('.productlist .product').hide();
                    $('.productlist .c_' + cID).show();
                }
                else if (cID == 0)
                    $('.productlist .product').show();
            }

            function AddToCartPurchase(ItemID) {
                if (ItemID == 0)
                    return;
                jQuery.ajax({
                    type: "POST",
                    url: "/Helper/AdvancePOS.asmx/AddToCartPurchase",
                    cache: false,
                    contentType: "application/json; charset=utf-8",
                    data: "{ItemID:'" + ItemID + "'}",
                    dataType: "json",
                    success: handleHtml,
                    error: ajaxFailed
                });

                function handleHtml(data) {
                    $('#productList').html(data.d);
                }

                function ajaxFailed(xmlRequest) {
                    alert("error");
                }
                return false;
            }

            function PopupPayment() {
                jQuery.ajax({
                    type: "POST",
                    url: "/Helper/AdvancePOS.asmx/GetPurchaseItem",
                    cache: false,
                    contentType: "application/json; charset=utf-8",
                    data: "{}",
                    dataType: "json",
                    success: handleHtml,
                    error: ajaxFailed
                });

                function handleHtml(data) {
                    $('#productList').html(data.d[0]);
                    $('#ItemsNum2 span').html(data.d[2]);
                    $('#TotalModal').html("Total Payable " + data.d[1] + " " + data.d[3]);
                    $('#edit').modal({ backdrop: 'static', keyboard: false });
                }
                function ajaxFailed(xmlRequest) {
                    alert("error");
                }

                return false;
            }
        </script>
        <script>
            $(function () {
                $(".select2").select2();
                $('#MainContent_txtDate').datepicker();
            });

            var prm = Sys.WebForms.PageRequestManager.getInstance();
            if (prm != null) {
                prm.add_endRequest(function (sender, e) {
                    if (sender._postBackSettings.panelsToUpdate != null) {
                        $(".select2").select2();
                        $('#MainContent_txtDate').datepicker();
                    }
                });
            };
        </script>
    </div>
</asp:Content>
