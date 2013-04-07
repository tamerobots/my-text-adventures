<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Validate.aspx.vb" Inherits="Secure_Validate" title="My Text Adventures - Validate Story" %>

<asp:Content ID="Content1" ContentPlaceHolderID="leftmenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" Runat="Server">
<table >
<tr>
<td class="titletableleftright" ></td>
<td class="titletablecenter" ><h1>Validate Story</h1></td>
<td class="titletableleftright" >
<asp:HyperLink runat="server" ID="BackLink" CssClass="backnav" /></td>
</tr>
</table>

<br />
<asp:TextBox ID="ResultTextBox" Font-Size="Small" TextMode="MultiLine" Text="Validation results will appear here."
                AutoPostBack="true" EnableViewState="true" Width="70%" Height="400" runat="server"></asp:TextBox>
                <br />
                 <asp:Button ID="ValidateButton" runat="server" Text="Validate Now!"/><asp:Button ID="PlayStoryButton" runat="server" Text="Play Story" Enabled="false"/>
                

  

           
</asp:Content>

