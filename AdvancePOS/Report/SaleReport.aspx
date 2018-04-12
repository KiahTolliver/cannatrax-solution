<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SaleReport.aspx.cs" Inherits="AdvancePOS.Report.SaleReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <h1>Sales Report
            </h1>
            <ol class="breadcrumb">
                <li><a href="/default.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
                <li class="active">Sales Report</li>
            </ol>
        </div>
        <!-- Main content -->
        <div class="content">
            <div class="row">
                <div class="col-xs-12">
                    <!-- /.box -->
                    <div class="box box-primary form-horizontal">
                        <!-- /.box-header -->
                        <div class="box-body">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-xs-4">
                                                <label for="role" class="control-label col-lg-4">
                                                    From Date :</label>
                                                <div class="col-lg-8">
                                                    <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-xs-4">
                                                <label for="role" class="control-label col-lg-4">
                                                    To Date :</label>
                                                <div class="col-lg-8">
                                                    <asp:TextBox ID="txtToDate" CssClass="form-control" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-xs-3">
                                                <label for="role" class="control-label col-lg-2">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                </label>
                                                <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="Search"
                                                    OnClick="btnSearch_Click" />
                                                <asp:Button ID="btnReset" CssClass="btn btn-success" runat="server" Text="Reset"
                                                    OnClick="btnReset_Click" />
                                            </div>
                                        </div>
                                    </div>
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
                                                                <asp:HyperLink ID="HyperLinkReceipt" Target="_blank" runat="server">Receipt</asp:HyperLink>
                                                            </li>
                                                            <li>
                                                                <asp:HyperLink ID="HyperInvoice" Target="_blank" runat="server">Invoice</asp:HyperLink>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnSearch" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <asp:UpdateProgress runat="server" ID="updateProgress">
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
            $("#MainContent_txtFromDate").datepicker();
            $("#MainContent_txtToDate").datepicker();
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm != null) {
            prm.add_endRequest(function (sender, e) {
                if (sender._postBackSettings.panelsToUpdate != null) {
                    $("#MainContent_txtFromDate").datepicker();
                    $("#MainContent_txtToDate").datepicker();
                }
            });
        };
    </script>
</asp:Content>
