<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Advertise.aspx.cs" Inherits="MyCms.Admins.Advertise" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header"><h1>Quản lý hình ảnh</h1></section>
    <section class="content"><div class="row"><div class="col-xs-12"><div class="box adm1"> 
    <form 
    <asp:Panel ID="pnView" runat="server">
        <a class="btn btn-default" href="javascript:void(0);" onclick="window.history.go(-1);">
            <i class="icon-chevron-left"></i>&nbsp;Trở lại</a>
        <asp:LinkButton CssClass="btn btn-default" ID="lbtAddT" runat="server" OnClick="AddButton_Click"><i class="icon-plus"></i> Thêm mới</asp:LinkButton>
        <asp:LinkButton CssClass="btn btn-default" ID="lbtRefreshT" runat="server" OnClick="RefreshButton_Click"><i class="icon-ok"></i>&nbsp; Làm mới</asp:LinkButton>
        <asp:LinkButton title="Xóa" CssClass="btn btn-default" ID="lbtDeleteT" runat="server"
            OnClick="DeleteButton_Click"><i class="icon-trash"></i>&nbsp; Xóa</asp:LinkButton>
        <div style='clear: both; height: 10px'>
        </div>
        <asp:DropDownList ID="ddlFilterPosition" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFilterPosition_SelectedIndexChanged" CssClass='form-control' Style='width: 150px;'>                              
        </asp:DropDownList>
        <div class="row">
            <div style='clear: both; height: 10px'>
            </div>
            <div class="col-lg-12">
                <div class="panel panel-default">                    
               <style>
               .foo{ text-align:left}
               </style>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="dataTable_wrapper">
                            <asp:DataGrid PageSize="12" ID="grdAdvertise" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                AutoGenerateColumns="False" AllowPaging="True" PagerStyle-Mode="NumericPages"
                                PagerStyle-HorizontalAlign="Center" OnItemDataBound="grdAdvertise_ItemDataBound"
                                OnItemCommand="grdAdvertise_ItemCommand" 
                                OnPageIndexChanged="grdAdvertise_PageIndexChanged">
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
                                    <asp:BoundColumn DataField="Name" HeaderText="Tên hình ảnh" Visible="true" ItemStyle-CssClass="boxleft"></asp:BoundColumn>
                                    <asp:TemplateColumn ItemStyle-CssClass="Image">
                                        <HeaderTemplate>
                                            Hình ảnh</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Image ID="Imgbtn" runat="server" ImageUrl='<%#(DataBinder.Eval(Container.DataItem, "Image").ToString()) %>' Width="95" Height="87" />
                                        </ItemTemplate>
                                        <ItemStyle CssClass="Image" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn ItemStyle-CssClass="Function">
                                        <HeaderTemplate>
                                            Định dạng
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" Text='<%#ShowPosition(DataBinder.Eval(Container.DataItem, "Position").ToString()) %>'
                                                runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle CssClass="Function" />
                                    </asp:TemplateColumn>
                                      <asp:TemplateColumn ItemStyle-CssClass="TextShort">
                                        <HeaderTemplate>
                                            Gallery</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="cmdImage" runat="server"  CommandName="Image"  CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>'>Gallery</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="Function" />
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn DataField="Ord" HeaderText="Thứ tự" 
                                        Visible="true">
                                        
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn ItemStyle-CssClass="TextShort">
                                        <HeaderTemplate>
                                            Trạng thái</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# MyCms.Common.PageHelper.ShowActiveStatus(DataBinder.Eval(Container.DataItem, "Active").ToString()) %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="Function" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn ItemStyle-CssClass="Function">
                                        <HeaderTemplate>
                                            Chức năng</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit"
                                                CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /><asp:ImageButton
                                                    ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete"
                                                    ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>'
                                                    OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" />
                                                    <asp:ImageButton
                                                        ID="cmdActive" runat="server" AlternateText='<%#MyCms.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>'
                                                        CommandName="Active" CssClass="Active" ToolTip='<%# MyCms.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>'
                                                        ImageUrl='<%#MyCms.Common.PageHelper.ShowActiveImage(DataBinder.Eval(Container.DataItem, "Active").ToString())%>'
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /></ItemTemplate>
                                        <ItemStyle CssClass="Function" />
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle CssClass="Paging" Position="Bottom" NextPageText="Previous" 
                                    PrevPageText="Next">
                                </PagerStyle>
                            </asp:DataGrid>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>     
  <%--          <asp:UpdatePanel runat="server" ID="uppan">
            <ContentTemplate> --%>
    <asp:Panel ID="pnUpdate" runat="server" Visible="False">
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading adm2">
                        Cập nhật thông tin
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-8">
                                <form role="form">
                                <div class="form-group">
                                    <label>Định dạng </label>
                                    <asp:DropDownList runat="server" ID="ddlPosition" CssClass='form-control'></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlPosition"
                                        Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Tên hình ảnh:
                                    </label>
                                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                                        Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Hình ảnh chính:</label>
                                    <asp:TextBox ID="txtImage" runat="server" CssClass="form-control"></asp:TextBox>
                                    <br />
                                    <input class='btn btn-default' id="btnImgImage" type="button" onclick="BrowseServer('<% =txtImage.ClientID %>','Advertise');"
                                        value=" Chọn Tệp tin " />
                                    <asp:Image ID="imgImage" runat="server" ImageAlign="Middle" CssClass="image-1" Style='width: 95px;
                                        height: 87px' Visible="false" />
                                </div>
                                  <div class="form-group">
                                    <label>
                                        Hình ảnh phụ:</label>
                                    <asp:TextBox ID="txtImagesmall" runat="server" CssClass="form-control"></asp:TextBox>
                                    <br />
                                    <input class='btn btn-default' id="Button1" type="button" onclick="BrowseServer('<% =txtImagesmall.ClientID %>','Advertise');"
                                        value=" Chọn Tệp tin " />
                                    <asp:Image ID="Image1" runat="server" ImageAlign="Middle" CssClass="image-1" Style='width: 95px;
                                        height: 87px' Visible="false" />
                                </div>
                                         <div class="form-group">
                                    <label>Vị trí Module:</label>
                                    <asp:DropDownList runat="server" ID="ddlModule" CssClass='form-control'></asp:DropDownList>                                            
                                </div>
                                <div class="form-group">
                                    <label>
                                        Mô tả:</label>
                                    <asp:TextBox ID="txtsummary" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Liên kết:
                                    </label>
                                    <asp:TextBox ID="txtLink" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Kiểu liên kết:</label>
                                    <asp:DropDownList runat="server" ID="ddlTarget" CssClass='form-control'>
                                        <asp:ListItem Text="Cùng 1 trang" Value="_self" />
                                        <asp:ListItem Text="Mở trang mới" Value="_blank" />
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Thứ tự:
                                    </label>
                                    <asp:TextBox ID="txtOrd" runat="server"  CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvOrd" runat="server" ControlToValidate="txtOrd"
                                        Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Kích hoạt:</label>
                                    <div class="checkbox">
                                        <label>
                                            <asp:CheckBox ID="chkActive" runat="server" />
                                            Kích hoạt
                                        </label>
                                    </div>
                                </div>

                                <asp:LinkButton CssClass="btn btn-default" ID="lbtUpdateT" runat="server" OnClick="Update_Click"><i class="icon-save"></i>&nbsp; Lưu </asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-default" ID="lbtBackT" runat="server" OnClick="Back_Click"
                                    CausesValidation="False"><i class="icon-chevron-left"></i>&nbsp; Trở về</asp:LinkButton>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
<%--    </ContentTemplate>
    </asp:UpdatePanel>--%>
     </div></div></div></section>
</asp:Content>
