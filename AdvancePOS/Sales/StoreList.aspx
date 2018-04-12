<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="StoreList.aspx.cs" Inherits="AdvancePOS.Sales.StoreList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <h1>
                Choose A Store
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                <li class="active">Choose A Store</li>
            </ol>
        </div>
        <!-- Main content -->
        <div class="content">
            <div class="row">
                <asp:Repeater ID="RpStore" runat="server">
                    <ItemTemplate>
                        <div class="col-xs-6">
                            <div class="box box-primary">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h4 class="modal-title">
                                            <%#Eval("Name") %></h4>
                                    </div>
                                    <div class="modal-body">
                                        <p>
                                            <b>Address : </b>
                                            <%#Eval("Address") %></p>
                                        <p>
                                            <b>PhoneNo : </b>
                                            <%#Eval("PhoneNo") %></p>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:LinkButton ID="LinkButtonSelect" runat="server" CommandArgument='<%#Eval("ID") %>'
                                            OnClick="LinkSelect_Click" CssClass="btn btn-primary">Select</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <!-- /.content -->
    </div>
    <!-- /.content-wrapper -->
</asp:Content>
