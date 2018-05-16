<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QLDanhMuc.aspx.cs" Inherits="MyCms.Admins.BaiViet.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <script type="text/javascript">
        function XoaDanhMuc(MaDM)
        {
            if(confirm ("Bạn có muốn xóa danh mục này không?"))
            {
            $.post("/Admins/BaiViet/Ajax/AjDanhMuc.aspx",
                {
                    "ThaoTac": "XoaDanhMuc",
                    "MaDM": MaDM 
                },
                function (data, status) {
                    //alert("Data :" + data + "\n Status :" + status);
                    if (data == 1) {
                        //thực hiện thành công => ẩn dòng vừa xóa đi
                        $("#maDong" + MaDM).slideUp();
                    }
                });
            }
        }
    </script>
     <section><h3>Quản lý Bài Viết</h3></section>
<div class="box box-info collapsed-box">
            <div class="box-header with-border">
              <h3 class="box-title">Thêm Mới Danh Mục</h3>
             <div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-plus"></i>
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
                                    <asp:Button ID ="btnThem" runat="server"  Text="Thêm mới" class="btThem" OnClick="btnThem_Click"/>
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
    <div class="box box-info">
            <div class="box-header with-border">
              <h3 class="box-title">Danh Sách Danh Mục</h3>
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
                  <thead>
                       <tr>
                           <th class="cotMa"style="text-align:center">Mã</th>
                           <th class="cotTen"  style="text-align:center">Tên danh mục</th>
                           <th class="cotThuTu" style="text-align:center">Thứ tự</th>
                            <th class="cotHienThi"style="text-align:center">Hiển thị</th>
                           <th class="cotChucNang"style="text-align:center">Chức năng</th>
                        </tr>
                      <asp:Literal ID="ltrDanhMuc"  runat="server"></asp:Literal>
                  </thead>
                </table>
              </div>
              <!-- /.table-responsive -->
            </div>
            <!-- /.box-body -->
           
          </div>
</asp:Content>
