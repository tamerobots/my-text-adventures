<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Room.aspx.vb" Inherits="Secure_Room" Title="My Text Adventures - Room" %>

<asp:Content ID="Content1" ContentPlaceHolderID="leftmenu" runat="Server">
    <asp:HyperLink runat="server" ID="StoryNavLink" CssClass="storynav" /><br />
    <p class="navseparator">
    </p>
    Room:
    <asp:HyperLink runat="server" ID="RoomNavLink" CssClass="storynav" />
    <p class="navseparator">
    </p>
    <div class="hint">
        <h3>
            Hint</h3>
        Remember to specify an initial room state, or the room will not load.<br />
        You can also set the compass points of a room to point to itself!
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <table>
        <tr>
            <td class="titletableleftright">
            </td>
            <td class="titletablecenter">
                <h1>
                    Room</h1>
            </td>
            <td class="titletableleftright">
                <asp:HyperLink runat="server" ID="BackLink" CssClass="backnav" />
            </td>
        </tr>
    </table>
    <p class="tutorialtext">
        Enter the Name of the Room and it's relation to any other rooms in the story, then
        'Create Room'.<br />
        Once you have created the room, start adding Entities and Room States to the room.<br />
        An Entity is an object specific to this room, and a Room state is a possible state
        the room can be in. (you must have at least one room state for each room.)<br />
        Remember, once you have multiple rooms, come back to this room and update the compass
        point connections to maintain navigation. Once you have at least one room state,
        specify the initial room state, which is the room state loaded when the player enters
        the room for the first time.
    </p>
    <br />
    <asp:Label ID="SavedLabel" Visible="false" Width="100%" runat="server" Text="Saved Successfully."
        ForeColor="White" />
    <table class="contententry">
        <tr>
            <td align="left">
            </td>
            <td align="right">
                <asp:Button ID="NewRoomStateButton" runat="server" Text="Create New Room State" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ObjectDataSource runat="server" ID="RoomStateObjDS" DataObjectTypeName="BE.RoomState"
                    SelectMethod="getRoomStatesbyRoomId" DeleteMethod="Delete" TypeName="DAL.RoomStateAccessor">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="RoomId" QueryStringField="RoomId" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:GridView ID="myGridView" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False"
                    Width="100%" DataSourceID="RoomStateObjDS" AllowPaging="True" AllowSorting="True"
                    EmptyDataText="No room states yet. Room states will appear here." TypeName="DAL.RoomStateAccessor">
                    <Columns>
                        <asp:BoundField DataField="RoomStateName" HeaderText="Room State Name" />
                        <asp:BoundField DataField="PointsAwarded" HeaderText="Points Awarded" />
                        <asp:BoundField DataField="canGoNorth" HeaderText="Can Go North" />
                        <asp:BoundField DataField="canGoEast" HeaderText="Can Go East" />
                        <asp:BoundField DataField="canGoSouth" HeaderText="Can Go South" />
                        <asp:BoundField DataField="canGoWest" HeaderText="Can Go West" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField ID="RoomStateId" runat="server" Value='<%#Eval("RoomStateId") %>' />
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
                <asp:Button ID="NewEntityButton" runat="server" Text="Create New Entity" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ObjectDataSource runat="server" ID="EntityObjDS" DataObjectTypeName="BE.Entity"
                    SelectMethod="getEntitiesbyRoomId" TypeName="DAL.EntityAccessor">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="RoomId" QueryStringField="RoomId" Type="String" />
                    </SelectParameters>
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
            <td class="left">
                Room Name<br />
                <asp:RequiredFieldValidator ControlToValidate="RoomName" ID="NameValidator" runat="server"
                    ErrorMessage="You must enter a name" />
            </td>
            <td class="right">
                <asp:TextBox ID="RoomName" MaxLength="60" CssClass="singlelinetextbox" runat="server" />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="left">
                <asp:ObjectDataSource runat="server" ID="RoomObjDS" DataObjectTypeName="BE.Room"
                    SelectMethod="getRoomsbyStoryId" DeleteMethod="Delete" TypeName="DAL.RoomAccessor">
                    <SelectParameters>
                        <asp:Parameter Name="StoryId" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:Label ID="NorthLabel" runat="server" Text="North:" />
            </td>
            <td class="right">
                <asp:DropDownList ID="NorthList" DataValueField="RoomId" DataTextField="RoomName"
                    DataSourceID="RoomObjDS" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Selected="True" Value="" Text="None specified" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="left">
                <asp:Label ID="EastLabel" runat="server" Text="East:" />
            </td>
            <td class="right">
                <asp:DropDownList ID="EastList" DataValueField="RoomId" DataTextField="RoomName"
                    DataSourceID="RoomObjDS" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Selected="True" Value="" Text="None specified" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="left">
                <asp:Label ID="SouthLabel" runat="server" Text="South:" />
            </td>
            <td class="right">
                <asp:DropDownList ID="SouthList" DataValueField="RoomId" DataTextField="RoomName"
                    DataSourceID="RoomObjDS" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Selected="True" Value="" Text="None specified" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="left">
                <asp:Label ID="WestLabel" runat="server" Text="West:" />
            </td>
            <td class="right">
                <asp:DropDownList ID="WestList" DataValueField="RoomId" DataTextField="RoomName"
                    DataSourceID="RoomObjDS" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Selected="True" Value="" Text="None specified" />
                </asp:DropDownList>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="left">
                <asp:Label ID="StartRoomStateLabel" runat="server" Text="Initial Room State:" />
            </td>
            <td class="right">
                <asp:DropDownList ID="StartRoomStateList" DataValueField="RoomStateId" DataTextField="RoomStateName"
                    DataSourceID="RoomStateObjDS" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Selected="True" Value="" Text="None specified" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left">
            </td>
            <tr>
                <td class="buttons" colspan="2">
                    <asp:Button ID="CreateButton" runat="server" Visible="false" Text="Create Room" />
                    <asp:Button ID="SaveButton" runat="server" Visible="false" Text="Save Changes" />
                </td>
            </tr>
    </table>
</asp:Content>
