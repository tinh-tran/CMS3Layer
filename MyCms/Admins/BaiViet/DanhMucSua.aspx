<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhMucSua.aspx.cs" Inherits="MyCms.Admins.BaiViet.DanhMucSua" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <div class="box box-info">
            <div class="box-header with-border">
              <h3 class="box-title">Sửa Danh Mục</h3>
             <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
              </div>
            </div>
            <!-- /.box-header -->
            <div class="box-body" style="">
              <div class="table-responsive">
                <table class="table no-margin">
                  
                  <tbody>
                     
                         <div class="FormThemMoiDM">
      
                             <div class= "thongTin">
                                <div class="tenTruong">Mã Danh Mục</div>
                                <div class="oNhap"><asp:TextBox ID="txtMaDM" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class= "thongTin">
                                <div class="tenTruong">Danh mục cha</div>
                                <div class="oNhap">
                                    <asp:DropDownList ID="ddlDmCha" runat="server"></asp:DropDownList></div>
                            </div>
                           
                            <div class= "thongTin">
                                <div class="tenTruong">Tên danh mục</div>
                                <div class="oNhap"><asp:TextBox ID="txtTenDanhMuc" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class= "thongTin">
                                <div class="tenTruong">Thứ tự</div>
                                <div class="oNhap"><asp:TextBox ID="txtThuTu" runat="server"></asp:TextBox>
                                </div>
                            </div>
                             <div class= "thongTin">
                                <div class="tenTruong">Hiển thị</div>
                                <div class="oNhap">
                                    <asp:CheckBox ID="cbHienThi" runat="server"></asp:CheckBox>
                                </div>
                            </div>
                             <div class="thongTin">
                                <div class="tenTruong">&nbsp;</div>
                                <div class="oNhap">
                                    <asp:Button ID ="btnSua" runat="server"  Text="Sửa" class="btSua" OnClick="btnSua_Click"/>
                                    <asp:Button ID ="btnHuy" runat="server" Text="Hủy" class="btHuy"/>
                                </div>
                        </div>
                    
                  </tbody>
                </table>
              </div>
              <!-- /.table-responsive -->
            </div>
            <!-- /.box-body -->
           
          </div>
</asp:Content>
