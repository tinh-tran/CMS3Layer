<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="MyCms.Admins.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header"><h1>Quản lý tài khoản</h1></section>
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
                            <asp:DataGrid ID="grdUser" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                AutoGenerateColumns="False" OnItemDataBound="grdUser_ItemDataBound" OnItemCommand="grdUser_ItemCommand"
                                OnPageIndexChanged="grdUser_PageIndexChanged">
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
                                            Tên người dùng</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Name")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="Center" />
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn DataField="Username" HeaderText="Tên đăng nhập" 
                                        Visible="true">
                                        <ItemStyle CssClass="Center" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn >
                                        <HeaderTemplate>
                                            Quyền hạn</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbladmin" runat="server" Text='<%# ShowAdmin(DataBinder.Eval(Container.DataItem, "Admin").ToString())%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="Center" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn ItemStyle-CssClass="TextShort">
                                        <HeaderTemplate>
                                            Trạng thái</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text=''></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="Function" />
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
                                    Tên Người dùng:
                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>                                    
                                    <asp:RequiredFieldValidator                                    
                                        ID="rfvName" runat="server" ControlToValidate="txtName" Display="None" ErrorMessage="Chưa nhập họ tên" ValidationGroup="Save"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </div>
                                                                
                                <div class="form-group">
                                    Tên đăng nhập:
                                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ValidationGroup="Save" ControlToValidate="txtUsername" Display="None" ErrorMessage="Chưa nhập tên đăng nhập" SetFocusOnError="True"></asp:RequiredFieldValidator>                                       
                                </div>

                                <div class="form-group">
                                    <asp:Literal ID="ltrPass" runat="server"></asp:Literal>
                                    <asp:TextBox ID="txtPass" TextMode="Password" runat="server" CssClass="form-control" ></asp:TextBox>                                    
                                    <asp:RequiredFieldValidator ID="frvPass" runat="server" ValidationGroup="Save" ControlToValidate="txtPass" Display="None" ErrorMessage="Chưa nhập mật khẩu" SetFocusOnError="True"></asp:RequiredFieldValidator>                                       
                                </div>
                  
                                <div class="form-group">
                                Ngày tạo:
                                <asp:TextBox ID="txtDate" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                                                     
                                <div class="form-group">
                                    Quyền hạn:
                                    <asp:DropDownList runat="server" ID="ddlAdmin" CssClass="form-control">
                                        <asp:ListItem Text="Quản trị" Value="1" />
                                        <asp:ListItem Text="Nhân viên" Value="2" />
                                     </asp:DropDownList>
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
        </div>
    </asp:Panel>
    </div></div></div></section>
</asp:Content>