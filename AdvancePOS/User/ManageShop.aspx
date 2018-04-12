<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ManageShop.aspx.cs" Inherits="AdvancePOS.User.ManageShop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="HiddenRoleID" runat="server" />
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
      <h1>
        Manage Shop
      </h1>
      <ol class="breadcrumb">
        <li><a href="/default.aspx"><i class="fa fa-dashboard"></i> Home</a></li>        
        <li class="active">Manage Shop</li>
      </ol>
    </section>
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
                                    <button type="button" class="btn margin btn-success btn-sm" data-toggle="modal" data-target="#edit">Add New Shop</button>
                                    <asp:Panel ID="PnError" Visible="false" CssClass="alert alert-danger alert-dismissible" runat="server">
                                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                        <asp:Literal ID="ltrError" runat="server" />
                                    </asp:Panel>
                                    <asp:GridView ID="gvShop" runat="server" CssClass="table table-bordered table-striped"
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
                                            <asp:TemplateField HeaderText="StoreCode">
                                                <ItemStyle Width="100px" />
                                                <ItemTemplate>
                                                    <asp:Literal ID="ltrStoreCode" Text='<%#Eval("StoreCode") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Address">
                                                <ItemStyle Width="200px" />
                                                <ItemTemplate>
                                                    <asp:Literal ID="ltrAddress" Text='<%#Eval("Address") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PhoneNo">
                                                <ItemStyle Width="100px" />
                                                <ItemTemplate>
                                                    <asp:Literal ID="ltrPhoneNo" Text='<%#Eval("PhoneNo") %>' runat="server" />
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
                                <asp:Literal ID="ltrTitle" runat="server" Text="Add Shop" /></h4>
                        </div>
                        <div class="modal-body">
                            <div class="tab-content">
                                <div class="box-body">
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12">
                                            <div class="form-group">
                                                <label for="role">
                                                    Name
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtName"
                                                        ForeColor="Red" ValidationGroup="store" SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
                                            </div>
                                            <div class="form-group">
                                                <label for="role">
                                                    Email
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmail"
                                                        ForeColor="Red" ValidationGroup="store" SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                                            </div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <label for="role">
                                                            Store Code
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtStoreCode"
                                                                ForeColor="Red" ValidationGroup="store" SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                                        <asp:TextBox ID="txtStoreCode" runat="server" CssClass="form-control" />
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label for="role">
                                                            Phone
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPhone"
                                                                ForeColor="Red" ValidationGroup="store" SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                                        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="role">
                                                    Address
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddress"
                                                        ForeColor="Red" ValidationGroup="store" SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                                <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" CssClass="form-control" />
                                            </div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <label for="role">
                                                            Store Logo
                                                        </label>
                                                        <asp:HiddenField ID="HiddenFilename" runat="server" />
                                                        <asp:FileUpload ID="FileUploadLogo" onchange="showimagepreview(this)" runat="server" />
                                                    </div>
                                                    <div class="col-lg-3">
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
                                ValidationGroup="store" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnSave" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <script>
        $(function () {
            $("#MainContent_gvShop").DataTable();
        });

        function showimagepreview(input) {
            if (input.files && input.files[0]) {
                var filerdr = new FileReader();
                filerdr.onload = function (e) {
                    $('#MainContent_ImagePhoto').attr('src', e.target.result);
                }
                filerdr.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
