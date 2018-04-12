<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SaleHistory.aspx.cs" Inherits="AdvancePOS.Sales.SaleHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <h1>Sale History
            </h1>
            <ol class="breadcrumb">
                <li><a href="/default.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
                <li class="active">Sale History</li>
            </ol>
        </div>
        <!-- Main content -->
        <div class="content">
            <div class="row">
                <div class="col-xs-12">
                    <!-- /.box -->
                    <div class="box box-primary">
                        <!-- /.box-header -->
                        <div class="box-body">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="PnError" Visible="false" CssClass="alert alert-danger alert-dismissible"
                                        runat="server">
                                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">
                                            ×</button>
                                        <asp:Literal ID="ltrError" runat="server" />
                                    </asp:Panel>
                                    <asp:GridView ID="gvSales" runat="server" CssClass="table table-bordered table-striped"
                                        AutoGenerateColumns="false" OnRowDataBound="gvSales_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr.No#">
                                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="OrderNo">
                                                <ItemStyle Width="80px" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <%#Eval("OrderNo") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Purchase Date">
                                                <ItemStyle Width="120px" />
                                                <ItemTemplate>
                                                    <asp:Literal ID="ltrPurchaseDate" Text='<%#Eval("OrderDate","{0:dd-MMM-yyyy}") %>'
                                                        runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="CustomerName">
                                                <ItemTemplate>
                                                    <asp:Literal ID="ltrlCustomerName" Text='<%#Eval("CustomerName") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Item">
                                                <ItemStyle Width="100px" />
                                                <ItemTemplate>
                                                    <asp:Literal ID="ltrTotalItem" Text='<%#Eval("TotalItem") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Amount">
                                                <ItemStyle Width="200px" />
                                                <ItemTemplate>
                                                    <asp:Literal ID="ltrTotalAmount" Text='<%#Eval("NetAmount") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Payment">
                                                <ItemStyle Width="100px" />
                                                <ItemTemplate>
                                                    <asp:Literal ID="ltrPayment" Text='<%#Eval("Payment") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemStyle Width="100px" />
                                                <ItemTemplate>
                                                    <%# GetStatus(Eval("Status").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Actions">
                                                <ItemStyle Width="100px" />
                                                <ItemTemplate>
                                                    <div class="dropdown">
                                                        <button class="btn btn-xs btn-primary blue dropdown-toggle" type="button" data-toggle="dropdown"
                                                            aria-haspopup="true" aria-expanded="false">
                                                            Actions <span class="caret"></span>
                                                        </button>
                                                        <ul class="dropdown-menu" aria-labelledby="dLabel">
                                                            <li>
                                                                <asp:LinkButton ID="LinkButtonEdit" runat="server" CommandArgument='<%#Eval("ID") %>'
                                                                    CssClass="edit" OnClick="LinkEdit_Click">Edit</asp:LinkButton></li>
                                                            <li>
                                                                <asp:LinkButton ID="LinkButtonPayment" runat="server" CommandArgument='<%#Eval("ID") %>'
                                                                    CssClass="edit" OnClick="LinkPayment_Click">Payment</asp:LinkButton>
                                                            </li>
                                                            <li>
                                                                <asp:HyperLink ID="HyperLinkReceipt" Target="_blank" runat="server">Receipt</asp:HyperLink>
                                                            </li>
                                                            <li>
                                                                <asp:HyperLink ID="HyperInvoice" Target="_blank" runat="server">Invoice</asp:HyperLink>
                                                            </li>
                                                            <li>
                                                                <asp:LinkButton ID="LinkDelete" runat="server" CommandArgument='<%#Eval("ID") %>'
                                                                    OnClientClick="return confirm('Are you sure that you want to delete this record?');"
                                                                    OnClick="LinkDelete_Click">Delete</asp:LinkButton>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdateProgress runat="server" AssociatedUpdatePanelID="UpdatePanel1" ID="updateProgress">
                                <ProgressTemplate>
                                    <div class="overlay">
                                        <i class="fa fa-refresh fa-spin"></i>
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                        <!-- /.box-body -->
                    </div>
                    <!-- /.box -->
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->
        </div>
        <!-- /.content -->
    </div>
    <script>
        $(function () {
            $("#MainContent_gvsales").DataTable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm != null) {
            prm.add_endRequest(function (sender, e) {
                if (sender._postBackSettings.panelsToUpdate != null) {
                    $("#MainContent_gvsales").DataTable();
                }
            });
        };

    </script>
    <div class="modal fade" id="edit" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="box">
                        <div class="modal-content">
                            <div class="modal-header">
                                <asp:LinkButton ID="LinkButtonClose" CssClass="close" runat="server" OnClick="btnClose_Click"><span aria-hidden="true">&times;</span></asp:LinkButton>
                                <h4 class="modal-title">
                                    <asp:HiddenField ID="HiddenID" runat="server" />
                                    <asp:Literal ID="ltrTitle" runat="server" Text="Edit" /></h4>
                            </div>
                            <div class="modal-body">
                                <div class="box tab-content">
                                    <div class="box-body">
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12">
                                                <h3>
                                                    <b>Total</b>
                                                    <asp:Literal ID="ltrNetAmount" runat="server" />
                                                    <b>Paid :</b>
                                                    <asp:Literal ID="ltrPayment" runat="server" /></h3>
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            <label for="role">
                                                                Customer
                                                            </label>
                                                            <asp:DropDownList ID="ddlCustomer" CssClass="form-control" runat="server" AppendDataBoundItems="true">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            <label for="role">
                                                                Change Status</label>
                                                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                                                <asp:ListItem Value="Paid">Paid</asp:ListItem>
                                                                <asp:ListItem Value="UnPaid">UnPaid</asp:ListItem>
                                                                <asp:ListItem Value="Partial Payment">Partial Payment</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-default"
                                    OnClick="btnClose_Click" />
                                <asp:Button ID="btnSave" runat="server" Text="Save Changes" CssClass="btn btn-primary"
                                    ValidationGroup="supplier" OnClick="btnSave_Click" />
                            </div>
                        </div>
                        <asp:UpdateProgress runat="server" AssociatedUpdatePanelID="upModal" ID="updateProgress1">
                            <ProgressTemplate>
                                <div class="overlay">
                                    <i class="fa fa-refresh fa-spin"></i>
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
    <div class="modal fade" id="payment" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <asp:UpdatePanel ID="upPayment" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="box">
                        <div class="modal-content">
                            <div class="modal-header">
                                <asp:LinkButton ID="LinkButton1" CssClass="close" runat="server" OnClick="btnPaymentClose_Click"><span aria-hidden="true">&times;</span></asp:LinkButton>
                                <h4 class="modal-title">
                                    <asp:HiddenField ID="HiddenSaleID" runat="server" />
                                    <asp:Literal ID="Literal1" runat="server" Text="Payments" /></h4>
                            </div>
                            <div class="modal-body">
                                <div class="tab-content">
                                    <div class="box-body">
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12">
                                                <h3>
                                                    <b>Total</b>
                                                    <asp:Literal ID="ltrpNetAmount" runat="server" />
                                                    <b>Paid :</b>
                                                    <asp:Literal ID="ltrpPayment" runat="server" /></h3>
                                                <h3>Make Payment</h3>
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            <asp:GridView ID="gvPayment" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="false">
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
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-lg-9">
                                                            <label for="role">
                                                                PaidBy
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
                                                        <div class="col-lg-9">
                                                            <label for="role">
                                                                Payment
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPayment"
                                                                ForeColor="Red" ValidationGroup="sPayment" SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator></label>
                                                            <asp:TextBox ID="txtPayment" runat="server" CssClass="form-control paid" Text="0" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-lg-9">
                                                            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="Button1" runat="server" Text="Close" CssClass="btn btn-default" OnClick="btnPaymentClose_Click" />
                                <asp:Button ID="Button2" runat="server" Text="Save Changes" CssClass="btn btn-primary"
                                    ValidationGroup="sPayment" OnClick="btnSavePayment_Click" />
                            </div>
                        </div>
                        <asp:UpdateProgress runat="server" AssociatedUpdatePanelID="upPayment" ID="updateProgress2">
                            <ProgressTemplate>
                                <div class="overlay">
                                    <i class="fa fa-refresh fa-spin"></i>
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
</asp:Content>
