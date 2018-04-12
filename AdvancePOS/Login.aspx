<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AdvancePOS.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>User Login | Advance POS</title>
    <!-- Bootstrap 3.3.5 -->
    <link rel="stylesheet" href="/assets/bootstrap/css/bootstrap.min.css">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="/assets/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="/assets/css/ionicons.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="/assets/dist/css/AdminLTE.min.css">
    <!-- iCheck -->
    <link rel="stylesheet" href="/assets/plugins/iCheck/square/blue.css">
    <link rel="icon" type="image/x-icon" href="/images/favicon.ico">
</head>
<body class="hold-transition login-page">
    <div class="login-box">
        <div class="login-logo">
            <asp:Literal ID="ltrLogo" runat="server" />
        </div>
        <!-- /.login-logo -->
        <div class="login-box-body">
            <p class="login-box-msg">
                Sign in to start your session</p>
            <form id="Form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="PnError" runat="server" Visible="false" CssClass="alert alert-danger alert-dismissible">
                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">
                            ×</button>
                        <asp:Literal ID="ltrMessage" runat="server" />
                    </asp:Panel>
                    <asp:Panel ID="Panel1" runat="server" DefaultButton="brnSubmit">
                        <div class="form-group has-feedback">
                            <asp:TextBox ID="txtUserName" runat="server" placeholder="UserName" CssClass="form-control" />
                            <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                        </div>
                        <div class="form-group has-feedback">
                            <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password"
                                CssClass="form-control" />
                            <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                        </div>
                        <div class="row">
                            <!-- /.col -->
                            <div class="col-xs-4">
                                <asp:Button ID="brnSubmit" runat="server" Text="Sign In" CssClass="btn btn-primary btn-block btn-flat"
                                    OnClick="brnSubmit_Click" />
                            </div>
                            <!-- /.col -->
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            </form>
            <br />            
        </div>
        <!-- /.login-box-body -->
    </div>
    <script src="/assets/plugins/jQuery/jQuery-2.2.0.min.js"></script>
    <script src="/assets/bootstrap/js/bootstrap.min.js"></script>
    <script src="/assets/plugins/iCheck/icheck.min.js"></script>
    <script>
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });
        });
    </script>
</body>
