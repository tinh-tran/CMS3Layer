<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="MyCms.Modules.Pages.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Refresh" content="3 ; URL=/login" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <asp:Literal ID="ltrMessage" runat="server"></asp:Literal>
    </div>
</asp:Content>
