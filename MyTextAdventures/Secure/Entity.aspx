<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Entity.aspx.vb" Inherits="Secure_Entity" Title="My Text Adventures - Entity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="leftmenu" runat="Server">
  <asp:HyperLink runat="server" ID="StoryNavLink" CssClass="storynav" /><br />
    <p class="navseparator" ></p>
    Room: <asp:HyperLink runat="server" ID="RoomNavLink" CssClass="storynav" />
    <p class="navseparator" ></p>
 <div class="hint">
        <h3>
            Hint</h3>
     If you don't like where this entity is, you can select a different place in the parent state drop-down list,
     and the entity will be moved there without you having to create a new entity in that place and re-enter the information!
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <table >
<tr>
<td class="titletableleftright" ></td>
<td class="titletablecenter" ><h1>Entity</h1></td>
<td class="titletableleftright" >
<asp:HyperLink runat="server" ID="BackLink" CssClass="backnav" /></td>
</tr>
</table>
<p class="tutorialtext">
This Entity will appear in the Room or Room State you specified, although you can alter this below.<br />
Remember, an Entity can be anything - a person, an object, even an atom if you wish! Be creative.<br />
Once you have created the Entity, you can specify States for it - you only need one if you do not wish
the Player to be able to change the Entity in any way.
</p>
<br />
<asp:Label ID="SavedLabel" Visible="false" Width="100%" runat="server" Text="Saved Successfully."
                    ForeColor="White" />
        <asp:Label ForeColor="Red" runat="server" ID="BadAccessWarning" Visible="false"
     Text="You have accessed this page from an incorrect location. Please return to the homepage and try again." />

    <table class="contententry">
        <tr>
            <td align="left">
            </td>
            <td align="right">
                <asp:Button ID="NewEntityStateButton" runat="server" Text="Create New Entity State" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ObjectDataSource runat="server" ID="EntityStateObjDS" DataObjectTypeName="BE.EntityState"
                    SelectMethod="getEntityStatesbyEntityId" TypeName="DAL.EntityStateAccessor">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="EntityId" QueryStringField="EntityId" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:GridView ID="myGridView" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False"
                    Width="100%" DataSourceID="EntityStateObjDS" AllowPaging="True" AllowSorting="True"
                    EmptyDataText="No Entity States yet. Entity States will appear here." TypeName="DAL.EntityStateAccessor">
                    <Columns>
                        <asp:BoundField DataField="EntityStateName" HeaderText="Entity State Name" />
                        <asp:BoundField DataField="Visible" HeaderText="Visible" />
                        <asp:BoundField DataField="PointsAwarded" HeaderText="Points Awarded" />
                        <asp:BoundField DataField="ActivationVerb" HeaderText="Activation Verb" />
                        <asp:BoundField DataField="VerbUpdatesRoomState" HeaderText="Verb Updates Room State" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField ID="EntityStateId" runat="server" Value='<%#Eval("EntityStateId") %>' />
                                <asp:LinkButton ID="Edit" CommandName="Edit" runat="server">Edit</asp:LinkButton>
                                <asp:LinkButton ID="Delete" CommandName="Remove" runat="server">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
            </td>
        </tr>
     
        <tr>
            <td class="left">
                Entity Name<br />
<asp:RequiredFieldValidator ControlToValidate="EntityName" ID="NameValidator"
 runat="server" ErrorMessage="You must enter a name" />
            </td>
            <td class="right">
                <asp:TextBox ID="EntityName" MaxLength="60" CssClass="singlelinetextbox" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="left">
                Description
            </td>
            <td class="right">
                <asp:TextBox ID="Description" MaxLength="2000"  TextMode="MultiLine" Height="75" CssClass="multilinetextarea"
                    runat="server" />
            </td>
        </tr>
        <tr>
            <td class="left">
                Visible
            </td>
            <td class="right">
                <asp:CheckBox runat="server" ID="Visible" Checked="true" /><br />
            </td>
        </tr>
        <tr>
            <td class="left">
              <asp:Label ID="StartEntityStateLabel" runat="server" Text="Initial Entity State:" />
            </td>
            <td class="right">
                <asp:DropDownList ID="EntityStateList" DataValueField="EntityStateId" DataTextField="EntityStateName"
                    DataSourceID="EntityStateObjDS" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Selected="True" Value="" Text="None specified." />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="left">
                Parent
                <br />
                (can be a Room or a Room State)<br />
                <asp:CustomValidator ID="ParentRoomValidator" runat="server" ControlToValidate="RoomList"
                    Enabled="false" Visible="false" ErrorMessage="You must specify a room to bind this item with"
                    Display="Dynamic" ValidateEmptyText="true" />
                <asp:CustomValidator ID="ParentRoomStateValidator" runat="server" ControlToValidate="RoomStateList"
                    Enabled="false" Visible="false" ErrorMessage="You must specify a room state to bind this item with"
                    Display="Dynamic" ValidateEmptyText="true" />
            </td>
            <td class="right">
                <asp:ObjectDataSource runat="server" ID="RoomStateObjDS" DataObjectTypeName="BE.RoomState"
                    SelectMethod="getRoomStatesbyRoomId" TypeName="DAL.RoomStateAccessor"></asp:ObjectDataSource>
                <asp:DropDownList ID="RoomStateList" DataValueField="RoomStateId" Visible="false"
                    DataTextField="RoomStateName" DataSourceID="RoomStateObjDS" AppendDataBoundItems="true"
                    runat="server">
                    <asp:ListItem Selected="True" Value="" Text="None Specified" />
                </asp:DropDownList>
                <asp:ObjectDataSource runat="server" ID="RoomObjDS" DataObjectTypeName="BE.Room"
                    SelectMethod="getRoomsByStoryId" TypeName="DAL.RoomAccessor"></asp:ObjectDataSource>
                <asp:DropDownList ID="RoomList" DataSourceID="RoomObjDS" DataValueField="RoomId"
                    Visible="false" DataTextField="RoomName" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Selected="True" Value="" Text="None Specified" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="buttons" colspan="2">
                <asp:Button ID="CreateButton" runat="server" Visible="false" Text="Create Entity" />
                <asp:Button ID="SaveButton" runat="server" Visible="false" Text="Save" />
                
            </td>
        </tr>
    </table>
</asp:Content>
