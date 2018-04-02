<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyCms.Modules.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head class="head1" runat="server">
  <title>Đăng nhập Hệ thống Quản trị</title>
    <link href="/App_Themes/Admin/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="/App_Themes/Admin/AdminLTE.min.css" rel="stylesheet" type="text/css" />
    <link href="/App_Themes/Admin/AllSkinLTE.css" rel="stylesheet" type="text/css" />
    <link href="/App_Themes/Admin/font-awesome.min.css" rel="stylesheet" type="text/css" />
</head>
<body class="login-page"">
    <form id="form1" runat="server">
        <div class="login-box">
        <div class="login-logo">
            <a href="#">ĐĂNG NHẬP HỆ THỐNG </a>
        </div>
        <div class="login-box-body">
            <center>
                <img src="/App_Themes/Admin/images/logo.png" style="border-radius: 10px;" />
            </center>
            <br />
            
            
            <div class="form-group has-feedback">
                <asp:TextBox placeholder="Tên đăng nhập" CssClass="form-control" ID="txtUsername"
                    Style='width: 100%' runat="server"></asp:TextBox>
                <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername"
                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group has-feedback">
                <asp:TextBox placeholder="Mật khẩu" CssClass="form-control" ID="txtPassword" runat="server"
                    Style='width: 100%' TextMode="Password"></asp:TextBox>
                <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </div>
            
            <div class="row">
                <div class="col-xs-12">
                    <asp:Literal ID="ltrError" runat="server"></asp:Literal>
                </div>
                <div class='clear10'></div>
                 <div class="col-xs-4">
                    <a href='#' class="btn btn-primary btn-block btn-flat" target="_blank">Facebook</a>
                </div>
                 <div class="col-xs-4">
                    <a href='#' class="btn btn-danger btn-block btn-flat" target="_blank">Google</a>
                </div>
                <div class="col-xs-4">
                    <asp:Button ID="btnLogin" CssClass="btn btn-success btn-block btn-flat" runat="server"
                        Text="Đăng nhập" OnClick="btnLogin_Click" />
                </div>
                
            </div>
            
            <br />
            <br />
            Bạn muốn hỗ trợ ?<br>
            Hãy liên hệ với chúng tôi xxxxx|<br>
        </div>
        <!-- /.login-box-body -->
        <div class='clear10'>
        </div>
        <div class='clear10'>
        </div>
        <center>
           <p style="color: #fff">
                        2018 © Powered by <a style="color: #fff" href="#">SweetSoft.net</a> </p>
        </center>
    </div>
    </form>
      <style>
                span#rfvPassword , span#rfvUsername{    position: absolute;
            top: 0;
            left: 0;}
            body{ overflow:hidden;}
            </style>
</body>
</html>
