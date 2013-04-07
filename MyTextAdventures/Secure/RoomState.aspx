<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="RoomState.aspx.vb" Inherits="Secure_RoomState" Title="My Text Adventures - Room State" %>

<asp:Content ID="Content1" ContentPlaceHolderID="leftmenu" runat="Server">
    <asp:HyperLink runat="server" ID="StoryNavLink" CssClass="storynav" /><br />
    Room:<asp:HyperLink runat="server" ID="RoomNavLink" CssClass="storynav" />
    <p class="navseparator">
    </p>
    <div class="hint">
        <h3>
            Hint</h3>
        If you tick the 'End Game Trigger' checkbox, the game will end if this room state
        is encountered, so make the 'Long Description' a final paragraph congratulating
        the user on finishing your game!
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <table>
        <tr>
            <td class="titletableleftright">
            </td>
            <td class="titletablecenter">
                <h1>
                    Room State</h1>
            </td>
            <td class="titletableleftright">
                <asp:HyperLink runat="server" ID="BackLink" CssClass="backnav" />
            </td>
        </tr>
    </table>
    <p class="tutorialtext">
        Specify a Room State.<br />
        You can input how many points the player receives when they reach this room state,
        whether the player can go in certain directions from this room state, and the next
        room state from this one, if you plan on having an entity that the player can use
        to change the state of the room.<br />
        You can also create entities and items that are specific to this room state.<br />
        The game will remember the current Room State for each Room every time the player
        enters it.<br />
    </p>
    <br />
    <asp:Label ID="SavedLabel" Visible="false" Width="100%" runat="server" Text="Saved Successfully."
        ForeColor="White" />
    <table class="contententry">
        <tr>
            <td align="left">
            </td>
            <td align="right">
                <asp:Button ID="NewEntityButton" runat="server" Text="Create New Entity" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ObjectDataSource runat="server" ID="EntityObjDS" DataObjectTypeName="BE.Entity"
                    SelectMethod="getEntitiesbyRoomStateId" DeleteMethod="Delete" TypeName="DAL.EntityAccessor">
                </asp:ObjectDataSource>
                <asp:GridView ID="EntityGridView" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False"
                    Width="100%" DataSourceID="EntityObjDS" AllowPaging="True" AllowSorting="True"
                    EmptyDataText="No Entities yet. Entities will appear here." TypeName="DAL.EntityAccessor">
                    <Columns>
                        <asp:BoundField DataField="EntityName" HeaderText="Entity Name" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField ID="EntityId" runat="server" Value='<%#Eval("EntityId") %>' />
                                <asp:LinkButton ID="Edit" CommandName="Edit" runat="server">Edit</asp:LinkButton>
                                <asp:LinkButton ID="Delete" CommandName="Delete" runat="server">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
            </td>
        </tr>
        <tr>
            <td align="left">
            </td>
            <td align="right">
                <asp:Button ID="NewItemButton" runat="server" Text="Create New Item" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ObjectDataSource runat="server" ID="ItemObjDS" DataObjectTypeName="BE.Item"
                    SelectMethod="getItemsbyParentStateId" DeleteMethod="Delete" TypeName="DAL.ItemAccessor">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="ParentStateId" QueryStringField="RoomStateId" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:GridView ID="myGridView" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False"
                    Width="100%" DataSourceID="ItemObjDS" AllowPaging="True" AllowSorting="True"
                    EmptyDataText="No items yet. Items will appear here." TypeName="DAL.ItemAccessor">
                    <Columns>
                        <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField ID="ItemId" runat="server" Value='<%#Eval("ItemId") %>' />
                                <asp:LinkButton ID="Edit" CommandName="Edit" runat="server">Edit</asp:LinkButton>
                                <asp:LinkButton ID="Delete" CommandName="Delete" runat="server">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
            </td>
        </tr>
        <tr>
            <td class="left">
                Room State Name<br />
                <asp:RequiredFieldValidator ControlToValidate="RoomStateName" ID="NameValidator"
                    runat="server" ErrorMessage="You must enter a name" />
            </td>
            <td class="right">
                <asp:TextBox ID="RoomStateName" MaxLength="60"  CssClass="singlelinetextbox" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="left">
                Points Awarded
                <asp:RegularExpressionValidator ID="PointsValidator" runat="server" ControlToValidate="PointsAwarded"
                    ErrorMessage="Please enter a number." ValidationExpression="[0-9]*"></asp:RegularExpressionValidator>
            </td>
            <td class="right">
                <asp:TextBox ID="PointsAwarded" CssClass="singlelinetextbox" TextMode="SingleLine"
                    runat="server" MaxLength="4" Text="0" />
            </td>
        </tr>
        <tr>
            <td class="left">
                Can the Player go North?
            </td>
            <td class="right">
                <asp:CheckBox runat="server" ID="canGoNorth" /><br />
            </td>
        </tr>
        <tr>
            <td class="left">
                Can the Player go East?
            </td>
            <td class="right">
                <asp:CheckBox runat="server" ID="canGoEast" /><br />
            </td>
        </tr>
        <tr>
            <td class="left">
                Can the Player go South?<br />
            </td>
            <td class="right">
                <asp:CheckBox runat="server" ID="canGoSouth" /><br />
            </td>
        </tr>
        <tr>
            <td class="left">
                Can the Player go West?<br />
            </td>
            <td class="right">
                <asp:CheckBox runat="server" ID="canGoWest" /><br />
            </td>
        </tr>
        <tr>
            <td class="left">
                Long Description<br />
                This should be what is stated the first time you enter the room. Mention any entities
                or items you want the player to notice.
            </td>
            <td class="right">
                <asp:TextBox ID="LongDescription" CssClass="multilinetextarea" TextMode="MultiLine"
                    Height="150" MaxLength="20000" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="left">
                Description<br />
                This should be a short description for when you re-enter a room. Don't forget your
                entities and items!
            </td>
            <td class="right">
                <asp:TextBox ID="Description" CssClass="multilinetextarea" TextMode="MultiLine" Height="75"
                    runat="server" MaxLength="20000" />
            </td>
        </tr>
        <tr>
            <td class="left">
                Is this state a trigger for the end of the game?<br />
            </td>
            <td class="right">
                <asp:CheckBox runat="server" ID="isEndGameTrigger" /><br />
            </td>
        </tr>
        <tr>
            <td class="left">
                Next Room State
            </td>
            <td class="right">
                <asp:ObjectDataSource runat="server" ID="RoomStateObjDS" DataObjectTypeName="BE.RoomState"
                    SelectMethod="getRoomStatesbyRoomId" TypeName="DAL.RoomStateAccessor"></asp:ObjectDataSource>
                <asp:DropDownList ID="RoomStateList" DataValueField="RoomStateId" DataTextField="RoomStateName"
                    DataSourceID="RoomStateObjDS" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Selected="True" Value="" Text="This is the Final Room State" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="buttons" colspan="2">
                <asp:Button ID="CreateButton" runat="server" Visible="false" Text="Create Room State" />
                <asp:Button ID="SaveButton" runat="server" Visible="false" Text="Save" />
            </td>
        </tr>
    </table>
</asp:Content>
