<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master"  AutoEventWireup="true" CodeBehind="ImagesDetail.aspx.cs" Inherits="MyCms.Admins.ImagesDetail" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<section class="content-header"><h1>Quản lý hình ảnh</h1></section><section class="content"><div class="row"><div class="col-xs-12"><div class="box adm1"> 
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
                            <asp:DataGrid ID="grdProductImage" runat="server" Width="100%"    CssClass="table table-striped table-bordered table-hover"
                                AutoGenerateColumns="False" AllowPaging="True" PageSize="20" PagerStyle-Mode="NumericPages"
                                PagerStyle-HorizontalAlign="Center" OnItemDataBound="grdProductImage_ItemDataBound"
                                OnItemCommand="grdProductImage_ItemCommand" 
                                OnPageIndexChanged="grdProductImage_PageIndexChanged">
                                <HeaderStyle CssClass="trHeader">
                                </HeaderStyle>
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
                                    <asp:BoundColumn DataField="Name" HeaderText="Mô tả" 
                                            Visible="true">
                                            
                                        </asp:BoundColumn>
                                    <asp:TemplateColumn ItemStyle-CssClass="Image">
                                        <HeaderTemplate>
                                            Hình ảnh</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Image ID="Imgbtn" runat="server" ImageUrl='<%#DataBinder.Eval(Container.DataItem, "Image").ToString() %>'
                                                Width="95" Height="87" />
                                        </ItemTemplate>
                                        <ItemStyle CssClass="Image" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn ItemStyle-CssClass="Function">
                                        <HeaderTemplate>
                                            Chức năng</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit"
                                                CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /><asp:ImageButton
                                                    ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete"
                                                    ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>'
                                                    OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" /></ItemTemplate>
                                        <ItemStyle CssClass="Function" />
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle CssClass="Paging" Position="Bottom" NextPageText="Previous"
                                    PrevPageText="Next"></PagerStyle>
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
                    <div class="panel-heading adm2">
                        Cập nhật thông tin
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <form role="form">
                                 <div class="form-group">
                                             Tên:
                                                 
                                                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                                     <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                                     </div>
                                      <div class="form-group">
                                               Mô tả:
                                               <asp:TextBox ID="txtSummary" runat="server" CssClass="form-control" TextMode="MultiLine" ></asp:TextBox>
                                               </div>
                                      <div class="form-group">
                                               Gallery:
                                                    <asp:TextBox ID="txtImage" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <div class='clear10'></div>
                                                    <input id="btnImgImage" type="button" onclick="BrowseServer('<% =txtImage.ClientID %>','testimg');" class='btn btn-default' value=" Chọn tệp tin " />&nbsp;
                                                    <asp:Image ID="imgImage" runat="server" ImageAlign="Middle" Width="100px" />
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
    </div></div></div></section>
</asp:Content>
