<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="admTop.ascx.cs" Inherits="MyCms.Controls.admTop" %>
<%@ Import Namespace="MyCms.Common" %>
<header class="main-header">        
        <a href="/admin" class="logo">         
          <span class="logo-mini"><b>S.W.E.E.T</b></span>         
          <span class="logo-lg" style="font-size: 20px">ADMIN PANEL</span>
        </a>
        <!-- Header Navbar: style can be found in header.less -->
        <nav class="navbar navbar-static-top" role="navigation">
          <!-- Sidebar toggle button-->
          <a href="#" class="sidebar-toggle" data-toggle="offcanvas" role="button">
          <i class='fa fa-bars'></i>
           <span>QUẢN TRỊ HỆ THỐNG</span> 
          </a>
           
          <div class="navbar-custom-menu">
            <ul class="nav navbar-nav">
                   <li style="padding:0 8px" class="dropdown notifications-menu">
                <a href="/Admins/Module.aspx" class="dropdown-toggle" >
                  <i style="font-size:21px" class="fa fa-briefcase"></i>
                  <span class="label label-warning">Menu Admin</span>
                </a>
              
              </li>

                <li style="padding:0 8px" class="dropdown notifications-menu">
                <a href="/" class="dropdown-toggle"  target="_blank">
                  <i style="font-size:21px" class="fa fa-globe"></i>
                  <span class="label label-warning">Website</span>
                </a>
              
              </li>

              <li style="padding:0 8px" class="dropdown notifications-menu">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                  <i style="font-size:21px" class="fa fa-flag"></i>
                  <span class="label label-warning"><asp:Literal ID="ltrLanguage" runat="server"></asp:Literal></span>
                </a>
                <ul class="dropdown-menu">
             
                  <li>
                    <!-- inner menu: contains the actual data -->
                    <ul class="menu">
                      <li><asp:LinkButton ID="lbtVi" runat="server"> <i class="fa fa-flag fa-fw"></i>    Tiếng Việt</asp:LinkButton></li>
                    </ul>
                  </li>
                  
                </ul>
              </li>
             
                
              <li class="dropdown user user-menu">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                  <img src="/App_Themes/Admin/images/user.png" class="user-image" alt="User Image"/>
                  <span class="hidden-xs"> <asp:Literal ID="ltrUsername" runat="server"></asp:Literal>  </span>
                </a>
                <ul class="dropdown-menu">
                  <!-- User image -->
                  <li class="user-header">
                  <img src="/App_Themes/Admin/images/user.png" class="img-circle" alt="User Image" />
                    <p>                     
                     <small><a href='/Admins/Users.aspx' style="color:#fff">Thay đổi thông tin tài khoản</a></small>
                    </p>
                  </li>
                
                  <!-- Menu Footer-->
                  <li class="user-footer">
                    <div class="pull-left">
                      <a href="#" class="btn btn-default btn-flat">Thay mật khẩu</a>
                    </div>
                    <div class="pull-right">
                      <a href="<%=GlobalClass.ApplicationPath %>/logout" class="btn btn-default btn-flat">Đăng xuất</a>
                    </div>
                  </li>
                </ul>
              </li>
              
            </ul>
          </div>
        </nav>
      </header>


