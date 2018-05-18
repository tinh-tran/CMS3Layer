<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="UpdatePass.aspx.cs" Inherits="MyCms.Admins.UpdatePass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header"><h1>Quản lý tài khoản</h1></section>
    <section class="content"><div class="row"><div class="col-xs-12"><div class="box adm1"> 
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading adm2">
                        Cập nhật thông tin
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <form role="form">
                                <div class="form-group">
                                    Mật khẩu cũ:
                                    <asp:TextBox ID="txtPassOld" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>      
                                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtPassOld" Display="None" ValidationGroup="Save" ErrorMessage="Chưa nhập mật khẩu cũ"></asp:RequiredFieldValidator>                                                                       
                                </div>  
                                <div class="form-group">
                                    Mật khẩu mới:
                                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                    <asp:TextBox ID="txtPassNew" TextMode="Password" runat="server"  CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txtPassNew" Display="None" ValidationGroup="Save" ErrorMessage="Chưa nhập mật khẩu mới" ></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegExp1" runat="server"  Display="None" ValidationGroup="Save"  ErrorMessage="Mật khẩu phải trong khoảng từ 7-20 ký tự" ControlToValidate="txtPassNew" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{7,20}$" />
                                </div>
                                <div class="form-group">                                    
                                    Nhập lại mật khẩu mới:
                                    <asp:TextBox ID="txtRePass" TextMode="Password" runat="server" CssClass="form-control" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="txtPassNew" Display="None" ErrorMessage="Chưa nhập lại mật khẩu" ValidationGroup="Save"></asp:RequiredFieldValidator>                                                                         
                                </div>
                                    <asp:CompareValidator ID="cpv1" runat="server"  ControlToValidate="txtPassNew" ValidationGroup="Save" ControlToCompare="txtRePass" Display="None" ErrorMessage="Mật khẩu mới không khớp" ></asp:CompareValidator> 
                                     <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ID="ValSummary" ValidationGroup="Save" runat="server" />  
                                                                 <div class='clear'></div>
                                <asp:LinkButton CssClass="btn btn-default" ID="lbtUpdateT" runat="server" OnClick="Update_Click" ValidationGroup="Save"> Lưu </asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-default" ID="lbtReset" runat="server" 
                                    onclick="lbtReset_Click" Visible="false" > Reset Mật khẩu mới </asp:LinkButton>
                                <a href='#' class="btn btn-default"><i class="icon-chevron-left"></i>&nbsp; Trở về</a>
                                
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </div></div></div></section>
</asp:Content>