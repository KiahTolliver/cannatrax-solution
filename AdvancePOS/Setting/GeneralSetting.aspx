<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="GeneralSetting.aspx.cs" Inherits="AdvancePOS.Setting.GeneralSetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <h1>
                General Setting
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                <li class="active">General Setting</li>
            </ol>
        </div>
        <!-- Main content -->
        <div class="content">
            <div class="row">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnMessage" Visible="false" runat="server" CssClass="box-body">
                            <div class="alert alert-info alert-dismissible">
                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">
                                    ×</button>
                                <h4>
                                    Update!</h4>
                                <p>
                                    General setting successfully update.!!!</p>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="PnError" Visible="false" CssClass="box-body" runat="server">
                            <div class="alert alert-danger alert-dismissible">
                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">
                                    ×</button>
                                <asp:Literal ID="ltrError" runat="server" />
                            </div>
                        </asp:Panel>
                        <div class="col-md-9">
                            <div class="box box-primary">
                                <div class="box-body">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>
                                                Company Name
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCompanyName"
                                                    ForeColor="Red" ValidationGroup="employee" SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                            <asp:TextBox ID="txtCompanyName" CssClass="form-control" runat="server" />
                                        </div>
                                        <div class="form-group">
                                            <label>
                                                Address
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtAddress"
                                                    ForeColor="Red" ValidationGroup="employee" SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                            <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" TextMode="MultiLine" />
                                        </div>
                                        <div class="form-group">
                                            <label>
                                                Phone No<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPhoneNo"
                                                    ForeColor="Red" ValidationGroup="employee" SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                            <asp:TextBox ID="txtPhoneNo" CssClass="form-control" runat="server" />
                                        </div>
                                        <div class="form-group">
                                            <label>
                                                Email<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmail"
                                                    ForeColor="Red" ValidationGroup="employee" SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" />
                                        </div>
                                        <div class="form-group">
                                            <label>
                                                Website</label>
                                            <asp:TextBox ID="txtWebsite" CssClass="form-control" runat="server" />
                                        </div>
                                        <div class="form-group">
                                            <label>
                                                Currency Code<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                    ControlToValidate="txtCurrencyCode" ForeColor="Red" ValidationGroup="employee"
                                                    SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                            <asp:TextBox ID="txtCurrencyCode" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Image ID="ImagePhoto" runat="server" CssClass="profile-user-img img-responsive img-circle" /><br />
                                            <asp:HiddenField ID="HiddenFilename" runat="server" />
                                            <asp:FileUpload ID="FileUploadProfile" onchange="showimagepreview(this)" runat="server" />
                                            <h3 class="profile-username text-center">
                                                <asp:Literal ID="ltrFullName" runat="server" /></h3>
                                            <p class="text-muted text-center">
                                                <asp:Literal ID="ltrDepartment" runat="server" /></p>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.box-body -->
                                <div class="box-footer">
                                    <asp:Button ID="btnSave" runat="server" Text="Save Changes" CssClass="btn btn-primary pull-right"
                                        ValidationGroup="employee" OnClick="btnSave_Click" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnSave" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
    </div>
    <script>
        $(function () {
            $("#MainContent_gvEmployee").DataTable();
            $('#MainContent_txtDOB').datepicker();
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
