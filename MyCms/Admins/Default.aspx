<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyCms.Admins.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <section class="content" style="padding-bottom:0">
          <!-- Info boxes -->
          <div class="row">
            <div class="col-md-3 col-sm-6 col-xs-12">
              <div class="info-box">
                <span class="info-box-icon bg-aqua"><i style="margin-top:25px" class="fa fa-book"></i></span>
                <div class="info-box-content">
                  <span class="info-box-text"><b>Chờ duyệt</b></span>
                  <span class="info-box-number"> <%=tintuc %> </span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div><!-- /.col -->
            <div class="col-md-3 col-sm-6 col-xs-12">
              <div class="info-box">
                <span class="info-box-icon bg-red"><i style="margin-top:25px" class="fa fa-check-square-o"></i></span>
                <div class="info-box-content">
                  <span class="info-box-text"><b>Đã duyệt</b></span>
                  <span class="info-box-number"><%=tintucduyet%></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div><!-- /.col -->

            <!-- fix for small devices only -->
            <div class="clearfix visible-sm-block"></div>

            <div class="col-md-3 col-sm-6 col-xs-12">
              <div class="info-box">
                <span class="info-box-icon bg-green"><i style="margin-top:25px" class="fa fa-comments-o"></i></i></span>
                <div class="info-box-content">
                  <span class="info-box-text"><b>Liên hệ</b></span>
                  <span class="info-box-number"><%=lienhe %></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div><!-- /.col -->
            <div class="col-md-3 col-sm-6 col-xs-12">
              <div class="info-box">
                <span class="info-box-icon bg-yellow"><i style="margin-top:25px" class="fa fa-user-plus"></i></span>
                <div class="info-box-content">
                  <span class="info-box-text">Thành viên</span>
                  <span class="info-box-number"><%=thanhvien %></span>
                </div><!-- /.info-box-content -->
              </div><!-- /.info-box -->
            </div><!-- /.col -->
          </div><!-- /.row -->

            
          <div class="row">
            <!-- Left col -->
            <div class="col-md-8" style='padding-right:0'>
      
        
        
              
              <div class="box box-info">
                <div class="box-header with-border">
                  <h3 class="box-title"><i class="fa fa-book"></i>  Bài Chưa Duyệt</h3>
                  <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                  </div>
                </div><!-- /.box-header -->
                <div class="box-body">
                  <div class="table-responsive">
                     
                    <asp:DataGrid ID="grdNews" runat="server" Width="100%" CssClass="table no-margin" AutoGenerateColumns="False"  BorderColor="White"
                                AllowPaging="True" PageSize="8" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center"
                                 OnItemCommand="grdNews_ItemCommand"  OnPageIndexChanged="grdNews_PageIndexChanged">
                                <HeaderStyle CssClass="trHeader"></HeaderStyle>
                                <ItemStyle CssClass="trOdd"></ItemStyle>
                                <AlternatingItemStyle CssClass="trEven"></AlternatingItemStyle>
                                <Columns>
                                  
                                    <asp:BoundColumn DataField="Id" HeaderText="Id" Visible="False" />
                                    <asp:BoundColumn DataField="Content_Status" HeaderText="Active" Visible="False" />
                                    <asp:BoundColumn DataField="Content_Name" HeaderText="Tiêu đề tin" 
                                        Visible="true">                                        
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn ItemStyle-CssClass="Function">
                                        <HeaderTemplate>
                                            Chức năng</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit"
                                                CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /><asp:ImageButton
                                                    ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete"
                                                    ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>'
                                                    OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" /><asp:ImageButton
                                                        ID="cmdActive" runat="server" AlternateText='<%#MyCms.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Content_Status").ToString())%>'
                                                        CommandName="Active" CssClass="Active" ToolTip='<%# MyCms.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Content_Status").ToString())%>'
                                                        ImageUrl='<%#MyCms.Common.PageHelper.ShowActiveImage(DataBinder.Eval(Container.DataItem, "Content_Status").ToString())%>'
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /></ItemTemplate>
                                        <ItemStyle CssClass="Function" />
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle CssClass="Paging" Position="Bottom" NextPageText="Previous" PrevPageText="Next">
                                </PagerStyle>
                            </asp:DataGrid>

                  </div>
                  
                </div><!-- /.box-body -->
                <div class="box-footer clearfix">
                  
                  <a href="/Admins/News2.aspx" class="btn btn-sm btn-default btn-flat pull-right">Xem tất cả bài viết</a>
                </div><!-- /.box-footer -->
                
              </div>
           
              <div class="nav-tabs-custom">
                <ul class="nav nav-tabs pull-right">
                  <li class=""><a href="#tab_1-1" data-toggle="tab" aria-expanded="false">Sweetsoft.net</a></li>
                  <li class="active"><a href="#tab_2-2" data-toggle="tab" aria-expanded="true">Server - Hosting</a></li>
                  <li class=""><a href="#tab_3-2" data-toggle="tab" aria-expanded="false">Hỗ trợ khách hàng </a></li>
              
                  <li class="pull-left header"><i class="fa fa-university"></i>Sweetsoft.net</li>
                </ul>
                <div class="tab-content" style='  padding: 0px 10px 10px 10px;'>
                  <div class="tab-pane" id="tab_1-1">
                    <b> <a href='http://Sweetsoft.net' title="thiết kế website">>Sweetsoft.net </a></b>
                         <p>
                                Với Mảng 
                                    thiết kế website Sweetsoft đem đến cho Quý khách hàng những dịch vụ,
                                sản phẩm website chuyên nghiệp, tốt nhất. Sản phẩm Sweetsoft đưa ra mang đậm
                                phong cách mỹ thuật, ý tưởng, hệ thống code riêng theo từng khách hàng. Một website
                                tốt phải là một website đẹp, chuyên nghiệp, đáp ứng tốt nhất nhu cầu cung cấp thông
                                tin, sản phẩm, dịch vụ và tầm nhìn của công ty đến với khách hàng.
                            </p>


                  </div><!-- /.tab-pane -->
                  <div class="tab-pane active" id="tab_2-2">
                     Server - Hosting là dịch vụ lưu trữ website, server lưu trữ dùng riêng của khách
                                hàng. Web hosting là giải pháp phù hợp cho các cá nhân hoặc doanh nghiệp muốn có
                                một website giới thiệu, giao dịch thương mại trên Internet một cách hiệu quả và
                                tiết kiệm chi phí.
                  </div><!-- /.tab-pane -->
                  <div class="tab-pane" id="tab_3-2">
                    Sweetsoft luôn hỗ trợ kỹ thuật 24/7 với mô hình hỗ trợ khách hàng chuyên nghiệp
                                nhất theo phong cách các nhà cung cấp dịch vụ công nghệ chuyên nghiệp qua:<br />
                                
                                <br />
                                
                  </div><!-- /.tab-pane -->
                </div><!-- /.tab-content -->
              </div>
            </div><!-- /.col -->

            <div class="col-md-4">
          

              <!-- PRODUCT LIST -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title"><i class="fa fa-pie-chart"></i> Thống kê truy cập</h3>
                  <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                  </div>
                </div><!-- /.box-header -->    
              </div><!-- /.box -->
            </div><!-- /.col -->
          </div><!-- /.row -->
        </section>
</asp:Content>
