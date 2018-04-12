<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SaleInvoice.aspx.cs" Inherits="AdvancePOS.Sales.SaleInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <h1>
                Invoice
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                <li class="active">Invoice</li>
            </ol>
        </div>
        <!-- Main content -->
        <div id="invoice" class="invoice">
            <!-- title row -->
            <div class="row">
                <div class="col-xs-12">
                    <h2 class="page-header">
                        <i class="fa fa-globe"></i>
                        <asp:Literal ID="ltrCompanyName" runat="server" />
                        <small class="pull-right">Date:
                            <asp:Literal ID="ltrDate" runat="server" /></small>
                    </h2>
                </div>
                <!-- /.col -->
            </div>
            <!-- info row -->
            <div class="row invoice-info">
                <div class="col-sm-4 invoice-col">
                    From
                    <address>
                        <strong>
                            <asp:Literal ID="ltrCompanyName1" runat="server" /></strong><br>
                        <asp:Literal ID="ltrAddress" runat="server" /><br />
                        Phone:
                        <asp:Literal ID="ltrPhone" runat="server" /><br>
                        Email:
                        <asp:Literal ID="ltrEmail" runat="server" />
                    </address>
                </div>
                <!-- /.col -->
                <div class="col-sm-4 invoice-col">
                    To
                    <address>
                        <strong>
                            <asp:Literal ID="ltrCustomerName" runat="server" /></strong><br>
                        <asp:Literal ID="ltrCustomerAddress" runat="server" /><br />
                        Phone:
                        <asp:Literal ID="ltrCustomerPhone" runat="server" /><br>
                        Email:
                        <asp:Literal ID="ltrCustomerEmail" runat="server" />
                    </address>
                </div>
                <!-- /.col -->
                <div class="col-sm-4 invoice-col">
                    <b>Invoice #<asp:Literal ID="ltrOrderNo" runat="server" /></b><br>
                    <br>
                    <b>Due :</b>
                    <asp:Literal ID="ltrDue" runat="server" /><br />
                    <b>Change :</b><asp:Literal ID="ltrChange" runat="server" />
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->
            <!-- Table row -->
            <div class="row">
                <div class="col-xs-12 table-responsive">
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>
                                    ItemCode
                                </th>
                                <th>
                                    Item
                                </th>
                                <th>
                                    Qty
                                </th>
                                <th>
                                    Sell Price
                                </th>
                                <th>
                                    Amount
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RpItem" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%#Eval("ItemCode") %>
                                        </td>
                                        <td>
                                            <%#Eval("Name") %>
                                        </td>
                                        <td>
                                            <%#Eval("Quantity","{0:0}") %>
                                        </td>
                                        <td>
                                            <%#Eval("SellPrice","{0:0}") %>
                                        </td>
                                        <td>
                                            <%# GetAmount(Eval("NetAmount").ToString())%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->
            <div class="row">
                <!-- accepted payments column -->
                <div class="col-xs-6">
                    <p class="lead">
                        Payment Detail:</p>
                    <asp:GridView ID="gvPayment" runat="server" CssClass="table table-bordered table-striped"
                        AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="PaymentDate">
                                <ItemTemplate>
                                    <asp:Literal ID="ltrPaymentDate" Text='<%#Eval("PaymentDate","{0:dd-MMM-yyyy}") %>'
                                        runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PaymentMode">
                                <ItemTemplate>
                                    <asp:Literal ID="ltrPaymentMode" Text='<%#Eval("PaymentMode") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:Literal ID="ltrAmount" Text='<%#Eval("Amount","{0:0.00}") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <!-- /.col -->
                <div class="col-xs-6">
                    <div class="table-responsive">
                        <table class="table">
                            <tr>
                                <th style="width: 50%">
                                    Subtotal:
                                </th>
                                <td>
                                    <asp:Literal ID="ltrSubTotal" runat="server" />
                                </td>
                            </tr>
                            <asp:Repeater ID="rpTax" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <th>
                                            <%#Eval("Name") %>
                                            <%#Eval("TaxRate","({0}%)") %>
                                        </th>
                                        <td>
                                            <%# GetAmount(Eval("TaxAmount").ToString())%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            <tr>
                                <th>
                                    Payment:
                                </th>
                                <td>
                                    <asp:Literal ID="ltrPayment" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    Total:
                                </th>
                                <td>
                                    <asp:Literal ID="ltrNetAmount" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->
            <!-- this row will not appear when printing -->
            <div class="row no-print">
                <div class="col-xs-12">
                    <a href="invoice-print.html" target="_blank" onclick="PrintTicket()" class="btn btn-default"><i class="fa fa-print">
                    </i>Print</a>                  
                </div>
            </div>
        </div>
        <!-- /.content -->
        <div class="clearfix">
        </div>
    </div>
    <script type="text/javascript">
        function PrintTicket() {            
            var divElements = document.getElementById('invoice').innerHTML;
            //Get the HTML of whole page
            var oldPage = document.body.innerHTML;

            //Reset the page's HTML with div's HTML only
            document.body.innerHTML =
             "<html><head><title>Print Copy</title></head><body style=\"width:380px\"><center>" +
              divElements + "</center></body>";
            //printWindow.document.write('<html><head><title>Report Print</title>');
            //Print Page
            window.print();

            //Restore orignal HTML
            document.body.innerHTML = oldPage;
        }
    </script>
</asp:Content>
