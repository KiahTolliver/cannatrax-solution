<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ManageSale.aspx.cs" Inherits="AdvancePOS.Sales.ManageSale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <input id="currency" type="hidden" />
    <style type="text/css">
        .category1
        {
            overflow-x: scroll;
            overflow-y: hidden;
            white-space: nowrap;
            margin: 0 10px;
        }
    </style>
    <asp:HiddenField ID="HiddenOrderNo" runat="server" />
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <h1>
                New Sale <a onclick="PopupOpenedBill()" class="btn btn-danger">Opened Hold </a>
            </h1>
            <ol class="breadcrumb">
                <li><a href="/default.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
                <li class="active">New Sale</li>
            </ol>
        </div>
        <asp:Panel ID="PnSuccess" runat="server" CssClass="box-body" Visible="false">
            <div class="alert alert-info alert-dismissible" style="margin-bottom: 0px">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">
                    ×</button>
                <h4>
                    <i class="icon fa fa-info"></i>Success !</h4>
                Successfully Added to Opened Bill.
            </div>
        </asp:Panel>
        <!-- Main content -->
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="content">
                    <div class="row">
                        <div class="col-xs-5">
                            <div class="box box-primary">
                                <div class="box-body">
                                    <div class="form-group">
                                        <label for="role">
                                            Customer
                                        </label>
                                        <asp:DropDownList ID="ddlCustomer" CssClass="form-control select2" runat="server"
                                            AppendDataBoundItems="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <asp:DropDownList ID="ddlProduct" runat="server" AppendDataBoundItems="true" CssClass="form-control select2"
                                            Width="100%" onchange="AddToCartSale(this.value)">
                                            <asp:ListItem Value="0">Search Products</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="box-body">
                                    <div id="productList" class="table-responsive">
                                    </div>
                                </div>
                                <div class="box-footer">
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn margin btn-danger"
                                        OnClick="btnReset_Click" />
                                    <a onclick="PopupPayment()" class="btn btn-primary margin pull-right">Payment</a>
                                    <a onclick="PopupHold()" class="btn btn-success margin pull-right">Hold</a>
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
                                                                    <%# GetAmount(Eval("ID").ToString())%>
                                                                    (<%# GetItemStock(Eval("ID").ToString())%>)</h3>
                                                            </div>
                                                            <a onclick="AddToCartSale('<%#Eval("ID") %>','<%# GetItemStock(Eval("ID").ToString())%>')"
                                                                class="btn btn-success btn-sm">Add To Cart</a>
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
                                <div class="tab-content form-horizontal">
                                    <div class="box-body">
                                        <div class="col-md-12 col-sm-12">
                                            <%--  <div class="form-group">
                                                    <h3 id="ItemsNum2">
                                                        <span>0</span> items</h3>
                                                </div>--%>
                                            <div class="form-group">
                                                <h2 id="TotalModal">
                                                </h2>
                                            </div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-lg-9">
                                                        <label for="role" class="col-sm-3 control-label">
                                                            PaidBy
                                                        </label>
                                                        <div class="col-lg-9">
                                                            <asp:DropDownList ID="ddlPaidBy" CssClass="form-control" runat="server">
                                                                <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                                                <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                                                                <asp:ListItem Value="Credit Card">Credit Card</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-lg-9">
                                                        <label for="role" class="col-sm-3 control-label">
                                                            Discount
                                                        </label>
                                                        <div class="col-lg-9">
                                                            <asp:TextBox ID="txtDiscount" runat="server" CssClass="form-control discount" Text="0" /></div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-lg-9">
                                                        <label for="role" class="col-sm-3 control-label">
                                                            Payment
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPayment"
                                                                ForeColor="Red" ValidationGroup="sPayment" SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator></label>
                                                        <div class="col-lg-9">
                                                            <asp:TextBox ID="txtPayment" runat="server" CssClass="form-control paid" Text="0" /></div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-lg-9">
                                                    <h3 style="margin: 0px">
                                                        Due : <span id="dueAmount"></span>
                                                    </h3>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-lg-9">
                                                    <h3 style="margin: 0px">
                                                        Change : <span id="changeAmount"></span>
                                                    </h3>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-lg-12">
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
                                    ValidationGroup="sPayment" OnClick="btnSave_Click" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="modal fade" id="DivHold" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span></button>
                                <h4 class="modal-title">
                                    Save to Opened Bills</h4>
                            </div>
                            <div class="modal-body">
                                <div class="tab-content form-horizontal">
                                    <div class="box-body">
                                        <div class="col-md-12 col-sm-12">
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-lg-9">
                                                        <label for="role" class="col-sm-4 control-label">
                                                            Hold Bill Ref.<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                ControlToValidate="txtHoldRef" ForeColor="Red" ValidationGroup="sHold" SetFocusOnError="true"
                                                                ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        </label>
                                                        <div class="col-lg-8">
                                                            <asp:TextBox ID="txtHoldRef" runat="server" CssClass="form-control" /></div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    Close</button>
                                <asp:Button ID="btnHold" runat="server" Text="Save Changes" CssClass="btn btn-primary"
                                    ValidationGroup="sHold" OnClick="btnSave_Click" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="modal fade" id="DivOpenedBill" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span></button>
                                <h4 class="modal-title">
                                    Opened Bills</h4>
                            </div>
                            <div class="modal-body">
                                <div class="tab-content form-horizontal">
                                    <div class="col-md-12 col-sm-12">
                                        <div class="form-group">
                                            <div class="row" style="border-bottom: 1px solid #ddd;padding-bottom: 10px;">
                                                <div class="col-lg-9">
                                                    <label for="role" class="col-sm-5 control-label">
                                                        Search Opended Bill
                                                    </label>
                                                    <div class="col-lg-7">
                                                        <input type="text" class="form-control" style="border: 1px solid #373942;" placeholder="Ref. Number"
                                                            value="" onkeyup="GetOpenedBills(this.value)"></div>
                                                </div>
                                            </div>
                                            <div class="row" id="OpenBill">
                                               
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    Close</button>
                                <asp:Button ID="Button1" runat="server" Text="Save Changes" CssClass="btn btn-primary"
                                    ValidationGroup="sHold" OnClick="btnSave_Click" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <script type="text/javascript">
            function DeleteSaleItem(ItemID) {
                jQuery.ajax({
                    type: "POST",
                    url: "/Helper/AdvancePOS.asmx/DeleteSaleItem",
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

            function UpdateSaleItem(ItemID, Qty) {
                jQuery.ajax({
                    type: "POST",
                    url: "/Helper/AdvancePOS.asmx/UpdateSaleItem",
                    cache: false,
                    contentType: "application/json; charset=utf-8",
                    data: "{ItemID:'" + ItemID + "',Qty:'" + Qty + "'}",
                    dataType: "json",
                    success: handleHtml,
                    error: ajaxFailed
                });

                function handleHtml(data) {
                    if (data.d[1] == "low") {
                        alert("Low Inventory");
                        UpdateSaleItem(ItemID, data.d[0]);
                        return;
                    }
                    else
                        $('#productList').html(data.d[0]);
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

            function AddToCartSale(ItemID, Qty) {
                if (ItemID == 0)
                    return;
                if (Qty < 1) {
                    alert("Low Inventory");
                    return;
                }
                jQuery.ajax({
                    type: "POST",
                    url: "/Helper/AdvancePOS.asmx/AddToCartSale",
                    cache: false,
                    contentType: "application/json; charset=utf-8",
                    data: "{ItemID:'" + ItemID + "'}",
                    dataType: "json",
                    success: handleHtml,
                    error: ajaxFailed
                });

                function handleHtml(data) {
                    if (data.d[1] == "low") {
                        alert("Low Inventory");
                        return;
                    }
                    else
                        $('#productList').html(data.d[0]);
                }

                function ajaxFailed(xmlRequest) {
                    alert("error");
                }
                return false;
            }

            //Hold Popup
            function PopupHold() {
                var Gridlength = $.trim($('#productList').text()).length;
                if (Gridlength == "0") {
                    alert("Please add at least one item.!!!");
                    return;
                }
                else
                    $('#DivHold').modal({ backdrop: 'static', keyboard: false });
            }

            //Opened Bill
            function PopupOpenedBill() {
                $('#DivOpenedBill').modal({ backdrop: 'static', keyboard: false });
            }

            //Payment Popup
            function PopupPayment() {
                jQuery.ajax({
                    type: "POST",
                    url: "/Helper/AdvancePOS.asmx/GetSaleItem",
                    cache: false,
                    contentType: "application/json; charset=utf-8",
                    data: "{}",
                    dataType: "json",
                    success: handleHtml,
                    error: ajaxFailed
                });

                function handleHtml(data) {
                    if (data.d.ProductList == "") {
                        alert("Please add at least one item.!!!");
                        return;
                    }
                    $('#productList').html(data.d.ProductList);
                    $('#ItemsNum2 span').html(data.TotalItem);
                    $('#currency').val(data.d.Currency);
                    $('#TotalModal').html("Total Payable " + data.d.NetAmount + " " + data.d.Currency);
                    $('#edit').modal({ backdrop: 'static', keyboard: false });
                }
                function ajaxFailed(xmlRequest) {
                    alert("error");
                }
                return false;
            }

            //Payment Popup
            function GetOpenedBills(RefNo) {
                jQuery.ajax({
                    type: "POST",
                    url: "/Helper/AdvancePOS.asmx/GetOpenedBills",
                    cache: false,
                    contentType: "application/json; charset=utf-8",
                    data: "{RefNo:'" + RefNo + "'}",
                    dataType: "json",
                    success: handleHtml,
                    error: ajaxFailed
                });

                function handleHtml(data) {
                    $('#OpenBill').html(data.d);                    
                }
                function ajaxFailed(xmlRequest) {
                   
                }
                return false;
            }

            //Open Bill Edit
            function GetOpenedBillDetails() {                
                jQuery.ajax({
                    type: "POST",
                    url: "/Helper/AdvancePOS.asmx/GetSaleItem",
                    cache: false,
                    contentType: "application/json; charset=utf-8",
                    data: "{}",
                    dataType: "json",
                    success: handleHtml,
                    error: ajaxFailed
                });

                function handleHtml(data) {                    
                    $('#productList').html(data.d.ProductList);
                    $('#ItemsNum2 span').html(data.TotalItem);
                    $('#currency').val(data.d.Currency);
                    $('#TotalModal').html("Total Payable " + data.d.NetAmount + " " + data.d.Currency);
                }
                function ajaxFailed(xmlRequest) {
                    
                }
                return false;
            }
        </script>
        <script>
            $(function () {
                $(".select2").select2();                
                GetOpenedBills('');
            });

            var prm = Sys.WebForms.PageRequestManager.getInstance();
            if (prm != null) {
                prm.add_endRequest(function (sender, e) {
                    if (sender._postBackSettings.panelsToUpdate != null) {
                        $(".select2").select2();
                    }
                });
            };

            $('.paid,.discount').on('keyup', function () {
                var discount = $('.discount').val();
                var payment = $('.paid').val();

                var change = -(parseFloat($('#total').text()) - parseFloat(payment) - parseFloat(discount));
                var due = (parseFloat($('#total').text()) - parseFloat(payment) - parseFloat(discount));
                $('#dueAmount').text(due.toFixed(2) + " " + $('#currency').val());
                if (change < 0) {
                    $('#changeAmount').text(change.toFixed(2) + " " + $('#currency').val());
                    $('#changeAmount').addClass("text-red");
                } else {
                    $('#changeAmount').text(change.toFixed(2) + " " + $('#currency').val());
                    $('#changeAmount').removeClass("text-red");
                }
            });
        </script>
    </div>
</asp:Content>
