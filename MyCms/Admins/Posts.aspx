<%@ Page Title="" Language="C#" MasterPageFile="~/MyCms/Site.Master" AutoEventWireup="true" CodeFile="Posts.aspx.cs" Inherits="MyCms_Admins_Posts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
        <section class="content-header"><h1>Quản lý bài viết</h1></section>
    <section class="content"><div class="row"><div class="col-xs-12"><div class="box adm1"> 
    <asp:Panel ID="pnView" runat="server">
        <a class="btn btn-default" href="javascript:void(0);" onclick="window.history.go(-1);">
            <i class="icon-chevron-left"></i>&nbsp;Trở lại</a>
        <asp:LinkButton CssClass="btn btn-default" ID="lbtAddT" runat="server" OnClick="AddButton_Click"><i class="icon-plus"></i> Thêm mới</asp:LinkButton>
        <asp:LinkButton CssClass="btn btn-default" ID="lbtRefreshT" runat="server" OnClick="RefreshButton_Click"><i class="icon-ok"></i>&nbsp; Làm mới</asp:LinkButton>
        <asp:LinkButton title="Xóa" CssClass="btn btn-default" ID="lbtDeleteT" runat="server"
            OnClick="DeleteButton_Click"><i class="icon-trash"></i>&nbsp; Xóa</asp:LinkButton>
        <div style='clear: both; height: 10px'>
        </div>
           <div class="row">
            <div style='clear: both; height: 10px'>
            </div>
            <div class="col-lg-12">
                <div class="panel panel-default">
            
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="dataTable_wrapper">
                            <asp:DataGrid ID="grPosts" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                AutoGenerateColumns="False" OnItemDataBound="grPost_ItemDataBound" OnItemCommand="grPosts_ItemCommand"
                                OnPageIndexChanged="grPosts_PageIndexChanged">
                                <HeaderStyle CssClass="trHeader"></HeaderStyle>
                                <ItemStyle CssClass="trOdd"></ItemStyle>
                                <AlternatingItemStyle CssClass="trEven"></AlternatingItemStyle>
                                <Columns>
                                    <asp:TemplateColumn ItemStyle-CssClass="tdCenter">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="False"></asp:CheckBox>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server"></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="tdCenter"></ItemStyle>
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn DataField="Id" HeaderText="Id" Visible="False" />
                                    <asp:BoundColumn DataField="Active" HeaderText="Active" Visible="False" />
                                    <asp:TemplateColumn >
                                        <HeaderTemplate>
                                            Tên bài viết</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Name")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="Center" />
                                    </asp:TemplateColumn>
                                     <asp:TemplateColumn >
                                        <HeaderTemplate>
                                            Tiêu đề</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTieuDe" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"TieuDe")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="Center" />
                                    </asp:TemplateColumn>
                                     <asp:TemplateColumn >
                                        <HeaderTemplate>
                                            Nội dung</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblNoiDung" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"NoiDung")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="Center" />
                                    </asp:TemplateColumn>
                                        <asp:TemplateColumn ItemStyle-CssClass="Image">
                                        <HeaderTemplate>
                                            Hình ảnh</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Image ID="Imgbtn" runat="server" ImageUrl='<%#(DataBinder.Eval(Container.DataItem, "Anh").ToString()) %>' Width="95" Height="87" />
                                        </ItemTemplate> 
                                            <ItemStyle CssClass="Image" />
                                    </asp:TemplateColumn>
                                     <asp:TemplateColumn >
                                        <HeaderTemplate>
                                            Thứ tự</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblThuTu" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ThuTu")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="Center" />
                                    </asp:TemplateColumn>
                                     <asp:TemplateColumn >
                                        <HeaderTemplate>
                                            Hiển thị</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ckHienThi" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"HienThi")%>'></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="Center" />
                                    </asp:TemplateColumn>
                               <asp:TemplateColumn >
                                        <HeaderTemplate>
                                            Ngày Đăng</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblNgayDang" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"NgayDang")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="Center" />
                                    </asp:TemplateColumn>
                                     <asp:TemplateColumn >
                                        <HeaderTemplate>
                                            Mã danh mục</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblmaDM" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"MaDM")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="Center" />
                                    </asp:TemplateColumn>
                                     <asp:TemplateColumn ItemStyle-CssClass="Function">
                                        <HeaderTemplate>
                                            Chức năng</HeaderTemplate>
                                        <ItemTemplate>
                                        
                                        <asp:ImageButton ID="cmdPass" runat="server" AlternateText="Sửa" CommandName="Pass"
                                                CssClass="Edit" ToolTip="Mật khẩu" ImageUrl="/App_Themes/Admin/images/pass.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' />
                                                
                                                <asp:ImageButton ID="cmdRole" runat="server" AlternateText="Sửa" CommandName="Role"
                                                CssClass="Edit" ToolTip="Phân quyền" ImageUrl="/App_Themes/Admin/images/role.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' />

                                            <asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit"
                                                CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' />
                                            <asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete"
                                                CssClass="Delete" ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png"
                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" />
                                            <asp:ImageButton ID="cmdActive" runat="server" AlternateText=''
                                                CommandName="Active" CssClass="Active" ToolTip='<%#MyCms.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>'
                                                ImageUrl='<%#MyCms.Common.PageHelper.ShowActiveImage(DataBinder.Eval(Container.DataItem, "Active").ToString())%>'
                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' />
                                        </ItemTemplate>
                                        <ItemStyle CssClass="Function" />
                                    </asp:TemplateColumn>
                                </Columns>
                            </asp:DataGrid>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnUpdate" runat="server" Visible="False">
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading adm2" id="pnUpdate">
                        Cập nhật thông tin
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <form role="form">
                                <div class="form-group">
                                   Tên bài viết
                                    <asp:TextBox ID="txtTenBV" runat="server" CssClass="form-control"></asp:TextBox>                                    
                                    <asp:RequiredFieldValidator                                    
                                        ID="rfvTenBV" runat="server" ControlToValidate="txtTenBV" Display="None" ErrorMessage="Chưa nhập tên bài viết" ValidationGroup="Save"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </div>
                                                                
                                <div class="form-group">
                                    Tiêu đề
                                    <asp:TextBox ID="txtTieuDe" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvTieuDe" runat="server" ValidationGroup="Save" ControlToValidate="txtTieuDe" Display="None" ErrorMessage="Chưa nhập Tiều đề" SetFocusOnError="True"></asp:RequiredFieldValidator>                                       
                                </div>
                                <div class="form-group">
                                    Nội dung
                                    <asp:TextBox ID="txtNoiDung" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvNoiDung" runat="server" ValidationGroup="Save" ControlToValidate="txtNoiDung" Display="None" ErrorMessage="Chưa nhập Nội dung" SetFocusOnError="True"></asp:RequiredFieldValidator>                                       
                                </div> 
                                        <div class="form-group">
                                    Hình ảnh
                                    <asp:TextBox ID="txtImage" runat="server" CssClass="form-control"></asp:TextBox> 
                                     <br />
                                    <input
                                        id="btnImgImage" type="button" onclick="BrowseServer('<% =txtImage.ClientID %>','News');"
                                        class='btn btn-default' value=" Chọn Tệp tin " /><br />
                                    <asp:Image ID="imgImage" runat="server" ImageAlign="Middle" CssClass="image-1" Style='width: 95px;
                                        height: 87px; margin-top: 10px' Visible="false" />
                                </div>
                                    <div class="form-group">
                                    Thứ tự:
                                    <asp:TextBox ID="txtThuTu" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvThuTu" runat="server" ValidationGroup="Save" ControlToValidate="txtThuTu" Display="None" ErrorMessage="Chưa nhập thứ tự" SetFocusOnError="True"></asp:RequiredFieldValidator>                                       
                                </div>
                  
                                <div class="form-group">
                                Ngày đăng
                                <asp:TextBox ID="txtDate" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>      

                                <div class="form-group">
                                    Kích hoạt:
                                    <asp:CheckBox ID="chkActive" runat="server" Checked="True" />
                                </div>


                                <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ID="ValSummary" ValidationGroup="Save" runat="server" />  

                                <asp:LinkButton CssClass="btn btn-default" ID="lbtUpdateT" runat="server" OnClick="Update_Click" ValidationGroup="Save"><i class="icon-save"></i>&nbsp; Lưu </asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-default" ID="lbtBackT" runat="server" OnClick="Back_Click"
                                    CausesValidation="False"><i class="icon-chevron-left"></i>&nbsp; Trở về</asp:LinkButton>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="display:none">
    
        </div>
    </asp:Panel>
    </div></div></div></section>
</asp:Content>

