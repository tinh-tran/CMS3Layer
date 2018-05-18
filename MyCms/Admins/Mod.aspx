<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mod.aspx.cs" Inherits="MyCms.Admins.Mod" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .tree, .tree ul
        {
            margin: 0;
            padding: 0;
            list-style: none;
        }
        .tree ul
        {
            margin-left: 1em;
            position: relative;
        }
        .tree ul ul
        {
            margin-left: .5em;
        }
        .tree ul:before
        {
            content: "";
            display: block;
            width: 0;
            position: absolute;
            top: 0;
            bottom: 0;
            left: 0;
            border-left: 1px solid;
        }
        .tree li
        {
            margin: 0;
            padding: 0 1em;
            line-height: 2em;
            color: #369;
            font-weight: 700;
            position: relative;
            cursor: pointer;
        }
        .tree ul li:before
        {
            content: "";
            display: block;
            width: 10px;
            height: 0;
            border-top: 1px solid;
            margin-top: -1px;
            position: absolute;
            top: 1em;
            left: 0;
        }
        .tree ul li:last-child:before
        {
            background: #fff;
            height: auto;
            top: 1em;
            bottom: 0;
        }
        .indicator
        {
            margin-right: 5px;
        }
        .tree li a
        {
            text-decoration: none;
            color: #369;
        }
        .tree li button, .tree li button:active, .tree li button:focus
        {
            text-decoration: none;
            color: #369;
            border: none;
            background: transparent;
            margin: 0px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            outline: 0;
        }
        .functionitem i
        {
            margin-right: 5px;
            font-size: 18px;
            margin-top: 5px;
        }
        .functionitem
        {
            padding-left: 20px;
            display: none;
        }
        /*  .functionitem a{ display:inline-block !important;}  */
        
        .line-through
        {
            text-decoration: line-through;
        }
    </style>
    <script>
        jQuery(function ($) {
            $("ul li").hover(
                function () {
                    $(this).children(".functionitem").show();
                },
                function () {
                    $(this).children(".functionitem").hide();
                }
            );
        });

        $(document).ready(function () {
            $("#showbtn").click(function () {
                if ($("#tree2 ul li ul li.branch").is(":visible")) {
                    $("#tree2 ul li ul li.branch").css("display", "none");
                    $("#tree2 ul li ul li.branch ul li.branch").css("display", "none");
                }
                else {
                    $("#tree2 ul li ul li.branch").css("display", "list-item");
                    $("#tree2 ul li ul li.branch ul li.branch").css("display", "list-item");
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header"><h1>Quản lý danh mục Module</h1></section>
    <section class="content"><div class="row"><div class="col-xs-12"><div class="box adm1">             
        <a id="showbtn" class="btn btn-default" href="#"> Ẩn - Hiện </a> 
        <a class="btn btn-default" href='?add=1'> Thêm mới </a> 
        <a class="btn btn-default" href="/Admins/Mod.aspx" ><i class="icon-chevron-left"></i>&nbsp;Trở lại</a>        
        <asp:LinkButton CssClass="btn btn-default" ID="lbtRefreshT" runat="server" OnClick="RefreshButton_Click"><i class="icon-ok"></i>&nbsp; Làm mới</asp:LinkButton>
        <div style='clear: both; height: 10px'></div>
          <div class="row">
            <div style='clear: both; height: 10px'>
            </div>
              <asp:Panel ID="pnUpdate" runat="server" Visible="False">
            <div class="col-lg-6">
                <div class="panel panel-default">
                    <div class="panel-heading adm2">
                        Cập nhật thông tin
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <form role="form">
                                  <asp:TextBox ID="txtId" runat="server" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtSubId" runat="server" Visible="false"></asp:TextBox>
                                  <div class="form-group">                                       
                                  <%--AutoPostBack="true" ontextchanged="txtMod_Name_TextChanged"--%>
                                    Tên Module: <asp:TextBox ID="txtMod_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtMod_Name" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:Label ID="lblerror" ForeColor="Red" runat="server"></asp:Label>                                                                              
                                     </div>
                            
                                     <div class="form-group">
                                     Cấp Module:                                               
                                               <asp:DropDownList ID="ddlParent" CssClass="form-control" runat="server"></asp:DropDownList>
                                     </div>
                                         <div class="form-group">
                                     Level:
                                               <asp:TextBox ID="txtLevel" runat="server" CssClass="form-control"></asp:TextBox>
                                     </div>
                                     <div class="form-group">
                                     
                                     Mã Module:
                                            <asp:TextBox ID="txtMod_Code" runat="server" CssClass="form-control"></asp:TextBox>
                                     </div>
                                     <div class="form-group">
                                     Định dạng:                                             
                                             <asp:DropDownList ID="ddltype" CssClass="form-control" runat="server"></asp:DropDownList>
                                             <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="ddltype" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                     </div>
                                     <div class="form-group">
                                     Liên kết:
                                        <asp:TextBox ID="txtMod_Url" runat="server" CssClass="form-control"></asp:TextBox>                                              
                                     </div>
                                      <div class="form-group">
                                  Trùng Tag:
                                     <asp:CheckBox ID="chk_Same" runat="server" 
                                              oncheckedchanged="chk_Same_CheckedChanged" AutoPostBack="true" />

                                              <asp:TextBox ID="txtMod_Tag" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                  </div>                                     
                                   
                                     <div class="form-group">
                                     Ảnh Module:                                                                        
                                     <asp:TextBox ID="txtMod_Img" runat="server" CssClass="form-control"></asp:TextBox>                                                                                                                                                                      
                                     <p></p>
                                     <input class='btn btn-default' id="btnImgImage" type="button" onclick="BrowseServer('<% =txtMod_Img.ClientID %>','Advertise');" value=" Chọn Tệp tin " />
                                     </div>
                                      <div class="form-group">
                                      Vị trí trang chủ:
                                          <asp:DropDownList ID="txtMod_style" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Chọn vị trí" Value=""></asp:ListItem>                                                                                        
                                            <asp:ListItem Text="Giới thiệu" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Tin tức" Value="1"></asp:ListItem>                                                                                                                                                                                                                           
                                            <asp:ListItem Text="Sản phẩm" Value="3"></asp:ListItem>                                                                                                                                                                                                                           
                                            

                                          </asp:DropDownList>                                          
                                      </div>
                                        
                                      <script>                                          $(document).ready(function () { $("#buttonngioithieu").click(function () { $("#noidunggioithieu").toggle(); }); });</script>
                                      
                                      <a class='btn btn-default' id="buttonngioithieu" style="cursor:pointer">Viết nội dung</a>
                                      <p></p>
                                      <div id="noidunggioithieu" style="display:none">
                                          <div class="form-group" >
                                      Tóm tắt:
                                     <CKEditor:CKEditorControl ID="fckIntro" runat="server" BasePath="/Scripts/ckeditor"></CKEditor:CKEditorControl>

                                    </div>
                                      <div class="form-group" >
                                      Nội dung:
                                     <CKEditor:CKEditorControl ID="fckContentDetail" runat="server" BasePath="/Scripts/ckeditor"></CKEditor:CKEditorControl>

                                    </div>
                                    </div>
                                     <div class="form-group">
                                      Thứ tự:
                                     <asp:TextBox ID="txtMod_Pos" runat="server" CssClass="form-control"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMod_Pos" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </div>
                              
                                  <div class="form-group">
                                  Kích hoạt:
                                     <asp:CheckBox ID="chkStatus" runat="server" />
                                  </div>
                             <div class="form-group">
                             Hiển thị trang chủ:
                                    <asp:CheckBox ID="chkHot" runat="server" />
                                  </div>
                                        
                       <div class="form-group">
                       Title Meta:
                                             <asp:TextBox ID="txtMod_Title" runat="server" CssClass="form-control"></asp:TextBox>
                                     </div>
                                     <div class="form-group">
                                     Keyword Meta:
                                              <asp:TextBox ID="txtMod_Key" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                     </div>
                                     <div class="form-group">
                                     Description Meta:
                                            <asp:TextBox ID="txtMod_Meta" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
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
                </asp:Panel>
            <div class="col-lg-6">
                <div class="panel panel-default">                                    
                    <div class="panel-heading adm2">
                        Danh sách module
                    </div>
                    <div class="panel-body">
                        <div class="dataTable_wrapper">
                        <ul id="tree2" class="tree">                                                 
                              <asp:Literal ID="ltrmod" runat="server"></asp:Literal>                                                                                
                        </ul>  
                        <script type="text/javascript">
                            $.fn.extend({
                                treed: function (o) {

                                    var openedClass = 'glyphicon-minus-sign';
                                    var closedClass = 'glyphicon-plus-sign';

                                    if (typeof o != 'undefined') {
                                        if (typeof o.openedClass != 'undefined') {
                                            openedClass = o.openedClass;
                                        }
                                        if (typeof o.closedClass != 'undefined') {
                                            closedClass = o.closedClass;
                                        }
                                    };

                                    //initialize each of the top levels
                                    var tree = $(this);
                                    tree.addClass("tree");
                                    tree.find('li').has("ul").each(function () {
                                        var branch = $(this); //li with children ul
                                        branch.prepend("<i class='indicator glyphicon " + closedClass + "'></i>");
                                        branch.addClass('branch');
                                        branch.on('click', function (e) {
                                            if (this == e.target) {
                                                var icon = $(this).children('i:first');
                                                icon.toggleClass(openedClass + " " + closedClass);
                                                $(this).children().children().toggle();
                                            }
                                        })
                                        branch.children().children().toggle();
                                    });
                                    //fire event from the dynamically added icon
                                    tree.find('.branch .indicator').each(function () {
                                        $(this).on('click', function () {
                                            $(this).closest('li').click();
                                        });
                                    });
                                    //fire event to open branch if the li contains an anchor instead of text
                                    tree.find('.branch>a').each(function () {
                                        $(this).on('click', function (e) {
                                            $(this).closest('li').click();
                                            e.preventDefault();
                                        });
                                    });
                                    //fire event to open branch if the li contains a button instead of text
                                    tree.find('.branch>button').each(function () {
                                        $(this).on('click', function (e) {
                                            $(this).closest('li').click();
                                            e.preventDefault();
                                        });
                                    });
                                }
                            });

                            //Initialization of treeviews
                            $('#tree2').treed({ openedClass: 'glyphicon-folder-open', closedClass: 'glyphicon-folder-close' });	 
    </script>                       
                        </div>
                    </div>
                </div>
            </div>          
        </div>
       </div></div></div></section>
</asp:Content>

