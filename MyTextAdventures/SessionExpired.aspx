<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="SessionExpired.aspx.vb" Inherits="Default2" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="leftmenu" Runat="Server">
Caution!
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" Runat="Server">
<h1>Session Expired</h1>
<p>
Session Expired. Please visit the <a runat="server" href="~/Login.aspx" id="loginlink" >login page</a> and re-login.
Apologies for the inconvenience!
</p>

</asp:Content>

