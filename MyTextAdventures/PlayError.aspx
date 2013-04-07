<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
 CodeFile="PlayError.aspx.vb" Inherits="ErrorPage" title="My Text Adventures - Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="leftmenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" Runat="Server">
<h1>Whoops!</h1>
<p class="pagetext">
An error occurred in the Story you are were playing.<br />
This is likely an inconsistency within the Story that the Author has not yet noticed.<br />
We apologise for the inconvenience.<br />
<asp:Label ID="CommandText" runat="server" Visible="false"  />

</p>
</asp:Content>

