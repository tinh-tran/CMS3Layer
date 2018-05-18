<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BaiVietSua.aspx.cs" Inherits="MyCms.Admins.BaiViet.BaiVietSua" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <section><h3>Quản lý Bài Viết</h3></section>
<div class="box box-info">
            <div class="box-header with-border">
              <h3 class="box-title">Sửa Bài Viết</h3>
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
                                <div class="tenTruong">Tên bài viết</div>
                                <div class="oNhap"><asp:TextBox ID="txtTenBaiViet" runat="server"></asp:TextBox>
                                </div>
                            </div>
                             <div class= "thongTin">
                                <div class="tenTruong">Tiêu đề</div>
                                <div class="oNhap"><asp:TextBox ID="txtTieuDe" runat="server"></asp:TextBox>
                                </div>
                            </div>
                              <div class= "thongTin">
                                <div class="tenTruong">Nội dung</div>
                                <div class="oNhap">
                                  <ckeditor:ckeditorcontrol ID="txtNoiDung" Width="850px" runat="server" FilebrowserImageBrowseUrl="/ckeditor/ckfinder/ckfinder.aspx?type=Images&path=pic"></ckeditor:ckeditorcontrol>
                                </div>
                            </div>
                            <div class= "thongTin">
                                <div class="tenTruong">Thứ tự</div>
                                <div class="oNhap"><asp:TextBox ID="txtThuTu" runat="server"></asp:TextBox>
                                </div>
                            </div>
                             <div class="thongTin">
                                 <div class="tenTruong">Ảnh đại diện</div>
                                 <div class="oNhap">
                                 <div>
                                 <asp:HiddenField ID="hdTenAnhDaiDienCu" runat="server" />
                                 <asp:Literal ID="ltrAnhDaiDien" runat="server"></asp:Literal>
                                 </div>
                                  <asp:FileUpload ID="flAnhDaiDien" runat="server" Width="300px"/>
                                  </div>
                             </div> 
                              <div class= "thongTin">
                                <div class="tenTruong">Danh mục</div>
                                <div class="oNhap">
                                    <asp:DropDownList ID="ddlDmCha" runat="server"></asp:DropDownList></div>
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
                                    <asp:Button ID ="btnSua" runat="server"  Text="Sửa" class="btSua" OnClick="btnSua_Click" />
                                    <asp:Button ID ="btnHuy" runat="server" Text="Hủy" class="btHuy"/>
                                </div>
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
