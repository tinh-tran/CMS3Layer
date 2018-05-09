<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Modtype.aspx.cs" Inherits="MyCms.Admins.Modtype" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
     .table-bordered>tbody>tr.trOdd>td , .table-bordered>tbody>tr.trEven>td {text-align:left}
    
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <section class="content-header"><h1>Quản lý định dạng Module</h1></section><section class="content"><div class="row"><div class="col-xs-12"><div class="box adm1"> 
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
        <asp:DataGrid ID="grdModtype" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False"
            AllowPaging="True" PageSize="20" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center"
            OnItemDataBound="grdModtype_ItemDataBound" OnItemCommand="grdModtype_ItemCommand"
            OnPageIndexChanged="grdModtype_PageIndexChanged">
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
                <asp:BoundColumn DataField="Modtype_Name" HeaderText="Tên định dạng" Visible="true" ></asp:BoundColumn>
              <asp:BoundColumn DataField="Modtype_Code" HeaderText="Mã định dạng" Visible="true" ></asp:BoundColumn>
                 <asp:TemplateColumn ItemStyle-CssClass="text-left">
                 <HeaderTemplate>Định dạng</HeaderTemplate>
                  <ItemTemplate>
                   <asp:Label ID="lblDinhdang" runat="server" Text='<%# dinhdang(DataBinder.Eval(Container.DataItem, "Modtype_Filter").ToString()) %>'></asp:Label>
                   </ItemTemplate>                                        
                </asp:TemplateColumn>  
              
              <asp:BoundColumn DataField="Modtype_Target" HeaderText="Đường dẫn" Visible="true" ></asp:BoundColumn>
 
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
                                 Tên định dạng:
                                            <asp:TextBox ID="txtModtype_Name" runat="server" CssClass="form-control"></asp:TextBox> 
                                            <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtModtype_Name" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                     </div>
                                          <div class="form-group">
                                 Định dạng cha:
                                            <asp:DropDownList ID="ddlFilter" runat="server" CssClass="form-control"></asp:DropDownList>
                                            
                                     </div>
                                       <div class="form-group">
                                       Mã định dạng:
                                            <asp:TextBox ID="txtModtype_Code" runat="server" CssClass="form-control"></asp:TextBox>
                                     </div>
                                     <div class="form-group">
                                       Đường dẫn Form:
                                            <asp:TextBox ID="txtModtype_Targer" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="txtModtype_Targer" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                     </div>
                                       <div class="form-group">
                                       Kích hoạt:
                                            <asp:CheckBox ID="chkStatus" runat="server" />
                                            
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
