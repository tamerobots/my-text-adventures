<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Login.aspx.vb" Inherits="Login" Title="My Text Adventures - Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="leftmenu" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <h1>
        Login
    </h1>
    <table align="center">
        <tr>
            <td>
                <asp:Label ID="UserNameLabel" runat="server" Text="User Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="UserNameTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="PasswordLabel" runat="server" Text="Password"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="PasswordTextBox" TextMode="Password" runat="server"></asp:TextBox>
            </td>
            <tr>
                <td>
                    <asp:CheckBox TextAlign="Right" ID="PersistCheckBox" Text=" Remember Me" runat="server" />
                </td>
                <td align="right">
                    <asp:Button ID="SubmitButton" runat="server" Text="Login" />
                </td>
            </tr>
    </table>
    <asp:Label ID="ErrorLabel" runat="server" Font-Bold="true" ForeColor="Firebrick"></asp:Label>
</asp:Content>
