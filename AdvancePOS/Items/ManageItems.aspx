<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ManageItems.aspx.cs" Inherits="AdvancePOS.Items.ManageItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <h1>Manage Items
            </h1>
            <ol class="breadcrumb">
                <li><a href="/default.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
                <li class="active">Manage Items</li>
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
                                        Add New Item</button>
                                    <asp:Panel ID="PnError" Visible="false" CssClass="alert alert-danger alert-dismissible"
                                        runat="server">
                                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">
                                            ×</button>
                                        <asp:Literal ID="ltrError" runat="server" />
                                    </asp:Panel>
                                    <asp:GridView ID="gvItem" runat="server" CssClass="table table-bordered table-striped"
                                        AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr.No#">
                                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Photo">
                                                <ItemStyle Width="50px" />
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" ImageUrl='<%#Eval("PhotoPath") %>' Width="100%" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name">
                                                <ItemTemplate>
                                                    <asp:Literal ID="ltrName" Text='<%#Eval("Name") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ItemCode">
                                                <ItemStyle Width="150px" />
                                                <ItemTemplate>
                                                    <asp:Literal ID="ltrItemCode" Text='<%#Eval("ItemCode") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="CategoryName">
                                                <ItemStyle Width="150px" />
                                                <ItemTemplate>
                                                    <asp:Literal ID="ltrCategoryName" Text='<%#Eval("CategoryName") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Qty">
                                                <ItemStyle Width="50px" />
                                                <ItemTemplate>
                                                    <%# GetItemStock(Eval("ID").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PurchasePrice">
                                                <ItemStyle Width="100px" />
                                                <ItemTemplate>
                                                    <asp:Literal ID="ltrPurchasePrice" Text='<%#Eval("PurchasePrice") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SellingPrice">
                                                <ItemStyle Width="100px" />
                                                <ItemTemplate>
                                                    <asp:Literal ID="ltrSellingPrice" Text='<%#Eval("SellingPrice") %>' runat="server" />
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
                                <asp:Literal ID="ltrTitle" runat="server" Text="Add Item" /></h4>
                        </div>
                        <div class="modal-body">
                            <div class="tab-content">
                                <div class="box-body">
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12">
                                            <div class="form-group">
                                                <label for="role">
                                                    ItemCode<asp:Literal ID="ltrCode" runat="server" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtItemCode"
                                                        ForeColor="Red" ValidationGroup="item" SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                                <asp:TextBox ID="txtItemCode" runat="server" CssClass="form-control" />
                                            </div>
                                            <div class="form-group">
                                                <label for="role">
                                                    Name
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtName"
                                                        ForeColor="Red" ValidationGroup="item" SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
                                            </div>
                                            <div class="form-group">
                                                <label for="role">
                                                    Category
                                                </label>
                                                <asp:DropDownList ID="ddlCategory" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <label for="role">
                                                            Purchase Price
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtPurchasePrice"
                                                                ValidationExpression="((\d+)((\.\d{1,2})?))$" Display="Dynamic" EnableClientScript="true"
                                                                ErrorMessage="Please enter only number.!!!" runat="server" ValidationGroup="item"
                                                                ForeColor="Red" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPurchasePrice"
                                                                ForeColor="Red" ValidationGroup="item" Display="Dynamic" SetFocusOnError="true"
                                                                ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                                        <asp:TextBox ID="txtPurchasePrice" runat="server" CssClass="form-control" />
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label for="role">
                                                            Selling Price
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtSellingPrice"
                                                                ValidationExpression="((\d+)((\.\d{1,2})?))$" Display="Dynamic" EnableClientScript="true"
                                                                ErrorMessage="Please enter only number.!!!" runat="server" ValidationGroup="item"
                                                                ForeColor="Red" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSellingPrice"
                                                                ForeColor="Red" ValidationGroup="item" Display="Dynamic" SetFocusOnError="true"
                                                                ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                                        <asp:TextBox ID="txtSellingPrice" runat="server" CssClass="form-control" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <label for="role">
                                                            Discount (%)
                                                            <asp:RegularExpressionValidator ID="RequiredFieldValidator8" ControlToValidate="txtDiscount"
                                                                ValidationExpression="((\d+)((\.\d{1,2})?))$" Display="Dynamic" EnableClientScript="true"
                                                                ErrorMessage="Please enter only number.!!!" runat="server" ValidationGroup="item"
                                                                ForeColor="Red" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDiscount"
                                                                ForeColor="Red" ValidationGroup="item" Display="Dynamic" SetFocusOnError="true"
                                                                ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                                        <asp:TextBox ID="txtDiscount" runat="server" CssClass="form-control" />
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label for="role">
                                                            Qty
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtQty"
                                                                ValidationExpression="((\d+)((\.\d{1,2})?))$" Display="Dynamic" EnableClientScript="true"
                                                                ErrorMessage="Please enter only number.!!!" runat="server" ValidationGroup="item"
                                                                ForeColor="Red" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtQty"
                                                                ForeColor="Red" ValidationGroup="item" Display="Dynamic" SetFocusOnError="true"
                                                                ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                                        <asp:TextBox ID="txtQty" runat="server" CssClass="form-control" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <label for="role">
                                                            Photo
                                                        </label>
                                                        <asp:HiddenField ID="HiddenFilename" runat="server" />
                                                        <asp:FileUpload ID="FileUploadPhoto" onchange="showimagepreview(this)" runat="server" />
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <input type="hidden" name="imgCropped" id="imgCropped" />
                                                        <asp:Image ID="ImagePhoto" Width="80%" runat="server" />
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
                                ValidationGroup="item" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSave" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <script>
        $(function () {
            $("#MainContent_gvItem").DataTable();
        });

        function showimagepreview(input) {
            if (input.files && input.files[0]) {
                var filerdr = new FileReader();
                filerdr.onload = function (e) {
                    $('#MainContent_ImagePhoto').attr('src', e.target.result);
                    $('#imgCropped').val(e.target.result);
                }
                filerdr.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
