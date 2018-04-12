<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UserProfile.aspx.cs" Inherits="AdvancePOS.User.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <h1>
                User Profile
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                <li class="active">User profile</li>
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
                                    Employee data successfully update.!!!</p>
                            </div>
                        </asp:Panel>
                        <div class="col-md-3">
                            <!-- Profile Image -->
                            <div class="box box-primary">
                                <div class="box-body box-profile">
                                    <asp:Image ID="ImagePhoto" runat="server" CssClass="profile-user-img img-responsive img-circle" /><br />
                                    <asp:HiddenField ID="HiddenFilename" runat="server" />
                                    <asp:FileUpload ID="FileUploadProfile" onchange="showimagepreview(this)" runat="server" />
                                    <h3 class="profile-username text-center">
                                        <asp:Literal ID="ltrFullName" runat="server" /></h3>
                                    <p class="text-muted text-center">
                                        <asp:Literal ID="ltrDepartment" runat="server" /></p>
                                </div>
                                <!-- /.box-body -->
                            </div>
                            <!-- /.box -->
                        </div>
                        <!-- /.col -->
                        <div class="col-md-9">
                            <div class="row">
                                <div class="box box-primary">
                                    <div class="box-body">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>
                                                    First Name
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFirstName"
                                                        ForeColor="Red" ValidationGroup="employee" SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                                <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>
                                                    Last Name
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtLastName"
                                                        ForeColor="Red" ValidationGroup="employee" SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                                <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>
                                                    Phone No<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPhoneNo"
                                                        ForeColor="Red" ValidationGroup="employee" SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                                <asp:TextBox ID="txtPhoneNo" CssClass="form-control" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>
                                                    Email<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmail"
                                                        ForeColor="Red" ValidationGroup="employee" SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>
                                                    Department<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                        ControlToValidate="txtDepartment" ForeColor="Red" ValidationGroup="employee"
                                                        SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                                <asp:TextBox ID="txtDepartment" CssClass="form-control" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>
                                                    Designation<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                        ControlToValidate="txtDesignation" ForeColor="Red" ValidationGroup="employee"
                                                        SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                                <asp:TextBox ID="txtDesignation" CssClass="form-control" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>
                                                    Supervisor<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                        ControlToValidate="txtSupervisor" ForeColor="Red" ValidationGroup="employee"
                                                        SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                                <asp:TextBox ID="txtSupervisor" CssClass="form-control" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>
                                                    Date Of Birth<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                        ControlToValidate="txtDOB" ForeColor="Red" ValidationGroup="employee" SetFocusOnError="true"
                                                        ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                                <asp:TextBox ID="txtDOB" CssClass="form-control" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>
                                                    Address</label>
                                                <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>
                                                    UserName<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtUserName"
                                                        ForeColor="Red" ValidationGroup="employee" SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator></label>
                                                <asp:TextBox ID="txtUserName" Enabled="false" CssClass="form-control" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>
                                                    Password<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPassword"
                                                        ForeColor="Red" ValidationGroup="employee" SetFocusOnError="true" ErrorMessage="This field is require !!!"></asp:RequiredFieldValidator>
                                                </label>
                                                <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>
                                                    Confirm Passwod<asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password not match.!!!"
                                                        ForeColor="Red" ValidationGroup="employee" SetFocusOnError="true" ControlToCompare="txtPassword"
                                                        ControlToValidate="txtConfirmPassword"></asp:CompareValidator></label>
                                                <asp:TextBox ID="txtConfirmPassword" CssClass="form-control" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="role">
                                                    Role</label>
                                                <asp:DropDownList ID="ddlRole" runat="server" Enabled="false" AppendDataBoundItems="true"
                                                    CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="role">
                                                    Store</label>
                                                <asp:DropDownList ID="ddlStore" runat="server" Enabled="false" AppendDataBoundItems="true"
                                                    CssClass="form-control">
                                                </asp:DropDownList>
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
    <!-- /.content -->
</asp:Content>
