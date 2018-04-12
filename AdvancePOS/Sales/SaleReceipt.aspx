<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SaleReceipt.aspx.cs" Inherits="AdvancePOS.Sales.SaleReceipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <div class="content">
            <div class="modal-dialog" role="document" id="ticketModal">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="ticket">
                            Receipt</h4>
                    </div>
                    <div class="modal-body" id="modal-body">
                        <div id="printSection">
                            <div class="">
                                <div class="text-center">
                                    <p>
                                        <asp:Image ID="ImageLogo" runat="server" Width="140px" /></p>
                                    <p>
                                        <span style="font: 15.4px/normal Tahoma">
                                            <asp:Literal ID="ltrAddress" runat="server" /></span>
                                    </p>
                                    <p>
                                        Tel :-
                                        <asp:Literal ID="ltrPhone" runat="server" /></p>
                                </div>
                                <div style="clear: both;">
                                    <h4 class="text-center">
                                        Sale No.:
                                        <asp:Literal ID="ltrOrderNo" runat="server" /></h4>
                                    <div style="clear: both;">
                                    </div>
                                    <span class="float-left">Date:
                                        <asp:Literal ID="ltrDate" runat="server" /></span><br>
                                    <div style="clear: both;">
                                        <span class="float-left">Customer:
                                            <asp:Literal ID="ltrCustomer" runat="server" /></span><div style="clear: both;">
                                                <table class="table" cellspacing="0" border="0">
                                                    <thead>
                                                        <tr>
                                                            <th>
                                                                <em>#</em>
                                                            </th>
                                                            <th>
                                                                Item
                                                            </th>
                                                            <th>
                                                                Qty
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
                                                                    <td style="text-align: center; width: 30px;">
                                                                        <%#Container.ItemIndex+1 %>
                                                                    </td>
                                                                    <td style="text-align: left; width: 160px;">
                                                                        <%#Eval("Name") %>
                                                                    </td>
                                                                    <td style="text-align: center; width: 50px;">
                                                                        <%#Eval("Quantity","{0:0}") %>
                                                                    </td>
                                                                    <td style="text-align: right; width: 110px;">
                                                                        <%# GetAmount(Eval("NetAmount").ToString())%>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </tbody>
                                                </table>
                                                <table class="table" cellspacing="0" border="0" style="margin-bottom: 8px;">
                                                    <tbody>
                                                        <tr>
                                                            <td style="text-align: left;">
                                                                Total Items
                                                            </td>
                                                            <td style="text-align: right; padding-right: 1.5%;">
                                                                <asp:Literal ID="ltrTotalItem" runat="server" />
                                                            </td>
                                                            <td style="text-align: left; padding-left: 1.5%;">
                                                                Total
                                                            </td>
                                                            <td style="text-align: right; font-weight: bold;">
                                                                <asp:Literal ID="ltrSubTotal" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <asp:Repeater ID="rpTax" runat="server">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td style="text-align: left;">
                                                                        <%#Eval("Name") %>
                                                                    </td>
                                                                    <td style="text-align: right; padding-right: 1.5%; font-weight: bold;">
                                                                    </td>
                                                                    <td style="text-align: left; padding-left: 1.5%;">
                                                                        <%#Eval("TaxRate","({0}%)") %>
                                                                    </td>
                                                                    <td style="text-align: right; font-weight: bold;">
                                                                        <%# GetAmount(Eval("TaxAmount").ToString())%>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                        <tr>
                                                            <td colspan="2" style="text-align: left; font-weight: bold; padding-top: 5px;">
                                                                Grand Total
                                                            </td>
                                                            <td colspan="2" style="border-top: 1px dashed #000; padding-top: 5px; text-align: right;
                                                                font-weight: bold;">
                                                                <asp:Literal ID="ltrNetAmount" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="text-align: left; font-weight: bold; padding-top: 5px;">
                                                                Paid
                                                            </td>
                                                            <td colspan="2" style="padding-top: 5px; text-align: right; font-weight: bold;">
                                                                <asp:Literal ID="ltrPayment" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="text-align: left; font-weight: bold; padding-top: 5px;">
                                                                Change
                                                            </td>
                                                            <td colspan="2" style="padding-top: 5px; text-align: right; font-weight: bold;">
                                                                <asp:Literal ID="ltrChange" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="text-align: left; font-weight: bold; padding-top: 5px;">
                                                                Due
                                                            </td>
                                                            <td colspan="2" style="padding-top: 5px; text-align: right; font-weight: bold;">
                                                                <asp:Literal ID="ltrDue" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <div style="border-top: 1px solid #000; padding-top: 10px;">
                                                    <span class="float-left">
                                                        <asp:Literal ID="ltrStoreName" runat="server" /></span><span class="float-right">Tel:
                                                            <asp:Literal ID="ltrStorePhone" runat="server" /></span><div style="clear: both;
                                                                margin-top: 20px">
                                                                <center>
                                                                    <asp:Image ID="ImageBarcode" runat="server" />
                                                                </center>
                                                                <p class="text-center" style="margin: 0 auto; margin-top: 10px;">
                                                                </p>
                                                                <div class="text-center" style="background-color: #000; padding: 5px; width: 85%;
                                                                    color: #fff; margin: 0 auto; border-radius: 3px; margin-top: 20px;">
                                                                    Thank you for your business</div>
                                                            </div>
                                                </div>
                                            </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" onclick="PrintTicket()">
                            print</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.content -->
    </div>
    <!-- /.content-wrapper -->
    <script type="text/javascript">
        function PrintTicket() {
            //            $('.modal-body').removeAttr('id');
            //            $('.modal-header').html('');
            //            window.print();
            //            $('.modal-body').attr('id', 'modal-body');
            var divElements = document.getElementById('modal-body').innerHTML;
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
