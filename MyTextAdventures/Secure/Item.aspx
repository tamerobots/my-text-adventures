<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Item.aspx.vb" Inherits="Secure_Item" Title="My Text Adventures - Item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="leftmenu" runat="Server">
    <asp:HyperLink runat="server" ID="StoryNavLink" CssClass="storynav" /><br />
    Room:<asp:HyperLink runat="server" ID="RoomNavLink" CssClass="storynav" />
    <div class="hint">
        <h3>
            Hint</h3>
        If a user types 'hint' then the item name, the 'hint' text will show.<br />
        You can use this to help the user with a difficult item.
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <table>
        <tr>
            <td class="titletableleftright">
            </td>
            <td class="titletablecenter">
                <h1>
                    Item</h1>
            </td>
            <td class="titletableleftright">
                <asp:HyperLink runat="server" ID="BackLink" CssClass="backnav" />
            </td>
        </tr>
    </table>
    <p class="tutorialtext">
        Items are a deceptively simple thing.<br />
        You can alter the parent of the Item (whether it be a Room State, Entity or Entity
        State), but be careful.<br />
        You will need to check where this item is referenced. If you change the parent and
        the former parent requires it to update a Room State, you could cause a bug in your
        story.<br />
        Remember, once Items are in the user's Inventory, they stay there until they restart
        or finish the game, regardless of which Room they go to or what Entities they interact
        with.
    </p>
    <br />
    <asp:Label ID="SavedLabel" Visible="false" Width="100%" runat="server" Text="Saved Successfully."
        ForeColor="White" />
    <asp:Label ForeColor="Red" runat="server" ID="BadAccessWarning" Visible="false" Text="You have accessed this page from an incorrect location. Please return to the homepage and try again." />
    <br />
    <table class="contententry">
        <tr>
            <td class="left">
                Item Name<br />
                <asp:RequiredFieldValidator ControlToValidate="ItemName" ID="NameValidator" runat="server"
                    ErrorMessage="You must enter a name" />
            </td>
            <td class="right">
                <asp:TextBox ID="ItemName" MaxLength="60" CssClass="singlelinetextbox" runat="server" />
            </td>
        </tr>
        <tr>
        <td class="left">
            Description
        </td>
        <td class="right">
            <asp:TextBox ID="Description" CssClass="multilinetextarea" TextMode="MultiLine" Height="75"
                runat="server" MaxLength="20000" />
        </td>
        </tr>
        <tr>
            <td class="left">
                Long Description
            </td>
            <td class="right">
                <asp:TextBox ID="LongDescription" CssClass="multilinetextarea" TextMode="MultiLine"
                    Height="150" runat="server" MaxLength="20000" />
            </td>
        </tr>
        <tr>
            <td class="left">
                Hint
            </td>
            <td class="right">
                <asp:TextBox ID="Hint" CssClass="multilinetextarea" TextMode="MultiLine" Height="150"
                    runat="server" MaxLength="20000" />
            </td>
        </tr>
        <tr>
            <td class="left">
                Parent State
                <br />
                (can be a Room State or an Entity State)<br />
                <asp:CustomValidator ID="ParentEntityStateValidator" SetFocusOnError="true" runat="server"
                    ControlToValidate="EntityStateList" Enabled="false" Visible="false" ErrorMessage="You must specify a state to bind this item with"
                    Display="Dynamic" ValidateEmptyText="true" />
                <asp:CustomValidator ID="ParentRoomStateValidator" SetFocusOnError="true" runat="server"
                    ControlToValidate="RoomStateList" Enabled="false" Visible="false" ErrorMessage="You must specify a state to bind this item with"
                    Display="Dynamic" ValidateEmptyText="true" />
            </td>
            <td class="right">
                <asp:ObjectDataSource runat="server" ID="RoomStateObjDS" DataObjectTypeName="BE.RoomState"
                    SelectMethod="getRoomStatesbyRoomId" TypeName="DAL.RoomStateAccessor"></asp:ObjectDataSource>
                <asp:DropDownList ID="RoomStateList" DataValueField="RoomStateId" Visible="false"
                    DataTextField="RoomStateName" DataSourceID="RoomStateObjDS" AppendDataBoundItems="true"
                    runat="server">
                    <asp:ListItem Selected="True" Value="" Text=" " />
                </asp:DropDownList>
                <asp:ObjectDataSource runat="server" ID="EntityStateObjDS" DataObjectTypeName="BE.EntityState"
                    SelectMethod="getEntityStatesbyEntityId" TypeName="DAL.EntityStateAccessor">
                </asp:ObjectDataSource>
                <asp:DropDownList ID="EntityStateList" DataSourceID="EntityStateObjDS" DataValueField="EntityStateId"
                    Visible="false" DataTextField="EntityStateName" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Selected="True" Value="" Text=" " />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="buttons" colspan="2">
                <asp:Button ID="CreateButton" runat="server" Visible="false" Text="Create Item" />
                <asp:Button ID="SaveButton" runat="server" Visible="false" Text="Save" />
            </td>
        </tr>
    </table>
</asp:Content>
