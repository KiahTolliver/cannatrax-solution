<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ManageTax.aspx.cs" Inherits="AdvancePOS.Items.ManageTax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <h1>Manage Tax
            </h1>
            <ol class="breadcrumb">
                <li><a href="/default.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
                <li class="active">Manage Tax</li>
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
                                    <button type="button" class="btn margin btn-success btn-sm" data-toggle="modal" data-target="#edit">
                                        Add New Tax</button>
                                    <asp:Panel ID="PnError" Visible="false" CssClass="alert alert-danger alert-dismissible"
                                        runat="server">
                                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">
                                            ×</button>
                                        <asp:Literal ID="ltrError" runat="server" />
                                    </asp:Panel>
                                    <asp:GridView ID="gvTax" runat="server" CssClass="table table-bordered table-striped"
                                        AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr.No#">
                                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name">
                                                <ItemTemplate>
                                                    <asp:Literal ID="ltrName" Text='<%#Eval("Name") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tax Rate">
                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Literal ID="ltrTaxRate" Text='<%#Eval("TaxRate") %>' runat="server" />%
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="IsActive">
                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButtonActive" runat="server" OnClick="LinkActive_Click" CommandArgument='<%#Eval("ID") %>'>
                                                        <%# GetStatusString(Eval("IsActive").ToString())%></asp:LinkButton>
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
                                                                    OnClick="LinkEdit_Click" CssClass="edit">Edit</asp:LinkButton></li>
                                                            <li>
                                                                <asp:LinkButton ID="LinkDelete" runat="server" CommandArgument='<%#Eval("ID") %>'
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
    <div class="modal fade" id="edit" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <%--<iframe id="FrameId" name="contntframe" width="100%" scrolling="no" height="100%"
                            frameborder="0"></iframe>--%>
                        <div class="modal-header">
                            <asp:LinkButton ID="LinkButtonClose" CssClass="close" runat="server" OnClick="btnClose_Click"><span aria-hidden="true">&times;</span></asp:LinkButton>
                            <h4 class="modal-title">
                                <asp:HiddenField ID="HiddenID" runat="server" />
                                <asp:Literal ID="ltrTitle" runat="server" Text="Add Tax" /></h4>
                        </div>
                        <div class="modal-body">
                            <div class="tab-content">
                                <div class="box-body">
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12">
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <label for="role">
                                                            Name
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtName"
                                                                ForeColor="Red" ValidationGroup="tax" SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <label for="role">
                                                            Tax Rate
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtTaxRate"
                                                                ValidationExpression="((\d+)((\.\d{1,2})?))$" Display="Dynamic" EnableClientScript="true"
                                                                ErrorMessage="Please enter only number.!!!" runat="server" ValidationGroup="tax"
                                                                ForeColor="Red" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTaxRate"
                                                                ForeColor="Red" ValidationGroup="tax" Display="Dynamic" SetFocusOnError="true"
                                                                ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                                        <asp:TextBox ID="txtTaxRate" runat="server" CssClass="form-control" />
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
                                ValidationGroup="tax" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <script>
        $(function () {
            $("#MainContent_gvTax").DataTable();
        });
    </script>
</asp:Content>
