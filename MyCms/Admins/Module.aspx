<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Module.aspx.cs" Inherits="MyCms.Admins.Module"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <section class="content-header"><h1> Quản lý Module</h1></section><section class="content"><div class="row"><div class="col-xs-12"><div class="box adm1"> 
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
                            <asp:DataGrid ID="grdModule" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False"
                                AllowPaging="True" PageSize="20" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center"
                                OnItemDataBound="grdModule_ItemDataBound" OnItemCommand="grdModule_ItemCommand"
                                OnPageIndexChanged="grdModule_PageIndexChanged">
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
                                            Chuyên mục</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtTen" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Name")%>'
                                                CommandName="AddSub" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>'></asp:LinkButton>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateColumn>
                      
                                          <asp:TemplateColumn >
                                        <HeaderTemplate>Thứ tự</HeaderTemplate>
                                        <ItemTemplate>                                 
                                            <asp:TextBox Width="40px" ID='txtthutu' runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Ord")%>'></asp:TextBox>
                                            <asp:LinkButton ID="lbtReseller" runat="server" CommandName="UpdateOrd" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>'><i class='fa fa-refresh' style='font-size: 17px;margin-left: 5px; color:#2D2D2D'></i> </asp:LinkButton>
                                        </ItemTemplate>                                        
                                    </asp:TemplateColumn>
                                    
                                    

                                         <asp:TemplateColumn >
                                        <HeaderTemplate>Icon</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblicon" runat="server" Text='<%# hienthiIcon(DataBinder.Eval(Container.DataItem, "Icon").ToString()) %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateColumn>


                                    <asp:BoundColumn DataField="Link" HeaderText="Liên kết" ItemStyle-CssClass="form-group"
                                        Visible="true" >
                                        <ItemStyle CssClass="form-group" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn ItemStyle-CssClass="Active">
                                        <HeaderTemplate>
                                            Kích hoạt</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# MyCms.Common.PageHelper.ShowActiveStatus(DataBinder.Eval(Container.DataItem, "Active").ToString()) %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="Active" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn ItemStyle-CssClass="Function">
                                        <HeaderTemplate>
                                            Chức năng</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit"
                                                CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /><asp:ImageButton
                                                    ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete"
                                                    ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>'
                                                    OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" /><asp:ImageButton
                                                        ID="cmdActive" runat="server" AlternateText='<%#MyCms.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>'
                                                        CommandName="Active" CssClass="Active" ToolTip='<%# MyCms.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>'
                                                        ImageUrl='<%#MyCms.Common.PageHelper.ShowActiveImage(DataBinder.Eval(Container.DataItem, "Active").ToString())%>'
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /></ItemTemplate>
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
                                Tên Module:
                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox><asp:RequiredFieldValidator
                                        ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </div>
                         
                                <div class="form-group">
                                Icon: <asp:Label ID="Label1" runat="server"></asp:Label>  <a style="padding: 2px 5px;" class="btn btn-default" href="/Admins/Icon.aspx" target="_blank">Chọn Icon</a> Sau đó paste code vào ô phía dưới ↓
                                <div class='clear10'></div>
                                    <asp:TextBox ID="txtIcon" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                Liên kết:
                                    <asp:TextBox ID="txtLink" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                       <div class="form-group">
                                Thứ tự:
                                    <asp:TextBox ID="txtOrd" runat="server" CssClass="form-control" /><asp:RequiredFieldValidator
                                        ID="rfvOrd" runat="server" ControlToValidate="txtOrd" Display="Dynamic" ErrorMessage="*"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                Kích hoạt:
                                    <asp:CheckBox ID="chkActive" runat="server" />
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
