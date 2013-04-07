<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="EntityState.aspx.vb" Inherits="Secure_EntityState" Title="My Text Adventures - Entity State" %>

<asp:Content ID="Content1" ContentPlaceHolderID="leftmenu" runat="Server">
    <asp:HyperLink runat="server" ID="StoryNavLink" CssClass="storynav" /><br />
    Room:<asp:HyperLink runat="server" ID="RoomNavLink" CssClass="storynav" />
    Entity:<asp:HyperLink runat="server" ID="EntityNavLink" CssClass="storynav" />
    <div class="hint">
        <h3>
            Hint</h3>
        Make sure you remember to select 'Verb Updates Room State' if you want this entity
        to update the room state!
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <table>
        <tr>
            <td class="titletableleftright">
            </td>
            <td class="titletablecenter">
                <h1>
                    Entity State</h1>
            </td>
            <td class="titletableleftright">
                <asp:HyperLink runat="server" ID="BackLink" CssClass="backnav" />
            </td>
        </tr>
    </table>
    <p class="tutorialtext">
        An Entity can have just one Entity State, or many.<br />
        The 'Activation Verb' refers to the command the user must input to update the Entity
        to it's next Entity State (which is specified in the 'Next Entity State' dropdown
        list, once you click the 'Create Entity State' button.<br />
        For example, if the Entity was called 'book' and its Entity State's Activation Verb
        was 'read', the user entering 'read book' would take change the book's entity state
        to one selected in the 'Next Entity State' drop-down box below, which could be 'book
        is open'.<br />
        You can also uncheck the 'Visible' box if you do not want this entity state to be
        available.<br />
        Also, you can set it so that if the Activation Verb is entered by the user, the
        Room State updates.<br />
        For example, if you 'move' a 'cupboard' Entity, it might reveal a hidden door on
        the north side of the Room. You could then update the Room State to one that allows
        the user to go north.<br />
        You can also specify an item a user might need in their Inventory to update the
        Entity State, like a 'crowbar' item to 'move' the 'cupboard'.<br />
        The game will remember the current Entity State for each Entity every time the player
        encounters it.<br />
    </p>
    <br />
    <asp:Label ID="SavedLabel" Visible="false" Width="100%" runat="server" Text="Saved Successfully."
        ForeColor="White" />
    <table class="contententry">
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
                        <asp:QueryStringParameter Name="ParentStateId" QueryStringField="EntityStateId" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:GridView ID="ItemGridView" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False"
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
                Entity State Name<br />
                <asp:RequiredFieldValidator ControlToValidate="EntityStateName" ID="NameValidator"
                    runat="server" ErrorMessage="You must enter a name" />
            </td>
            <td class="right">
                <asp:TextBox ID="EntityStateName" MaxLength="30" CssClass="singlelinetextbox" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="left">
                Long Description<br />
                This should be a long description for when you see this entity state for the first
                time.
            </td>
            <td class="right">
                <asp:TextBox ID="LongDescription" TextMode="MultiLine" Height="150" CssClass="multilinetextarea"
                    runat="server" MaxLength="10000" />
            </td>
        </tr>
        <tr>
            <td class="left">
                Description<br />
                This should be a short description for when you see this entity state for a second
                time.
            </td>
            <td class="right">
                <asp:TextBox ID="Description" MaxLength="10000" TextMode="MultiLine" Height="75" CssClass="multilinetextarea"
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
                Activation Verb (Must be a single word)
                <asp:CustomValidator ID="ActivationVerbValidator" runat="server" ControlToValidate="ActivationVerb"
                    Enabled="false" Visible="false" ErrorMessage="You must specify an Activation Verb"
                    Display="Dynamic"  ValidateEmptyText="true" />
                <br />
                <%--<span class="warningtext"> Note: every verb used on any entity in a particular room must be different.</span>--%>
            </td>
            <td class="right">
                <asp:TextBox ID="ActivationVerb" MaxLength="60" CssClass="singlelinetextbox" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="left">
                Activation Text<br />
                (Text that shows once the Activation Verb is succesfully guessed).
            </td>
            <td class="right">
                <asp:TextBox ID="ActivationText" MaxLength="10000" TextMode="MultiLine" Height="75" CssClass="multilinetextarea"
                    runat="server" />
            </td>
        </tr>
        <tr>
            <td class="left">
                Points Awarded<br />
                <asp:RegularExpressionValidator ID="PointsValidator" runat="server" ControlToValidate="PointsAwarded"
                    ErrorMessage="Please enter a number." ValidationExpression="[0-9]*"></asp:RegularExpressionValidator>
            </td>
            <td class="right">
                <asp:TextBox ID="PointsAwarded" MaxLength="4" CssClass="singlelinetextbox" runat="server" Text="0" />
            </td>
        </tr>
        <tr>
            <td class="left">
                Verb Updates Room State
            </td>
            <td class="right">
                <asp:CheckBox runat="server" ID="VerbUpdatesRoomState" Checked="false" /><br />
            </td>
        </tr>
        <tr>
            <td class="left">
                Hint
            </td>
            <td class="right">
                <asp:TextBox ID="Hint" TextMode="MultiLine" Height="75" CssClass="multilinetextarea"
                    runat="server" MaxLength="10000" />
            </td>
        </tr>
        <tr>
            <td class="left">
                <asp:Label ID="NextEntityStateLabel" runat="server" Text="Next Entity State from this one:" />
            </td>
            <td class="right">
                <asp:ObjectDataSource runat="server" ID="EntityStateObjDS" DataObjectTypeName="BE.EntityState"
                    SelectMethod="getEntityStatesbyEntityId" DeleteMethod="Delete" TypeName="DAL.EntityStateAccessor">
                </asp:ObjectDataSource>
                <asp:DropDownList ID="EntityStateList" DataValueField="EntityStateId" DataTextField="EntityStateName"
                    DataSourceID="EntityStateObjDS" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Selected="True" Value="" Text=" " />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="left">
                <asp:Label ID="ItemRequiredLabel" runat="server" Text="Item Required for Entity State Update:" />
            </td>
            <td class="right">
                <asp:ObjectDataSource runat="server" ID="StoryItemObjDS" DataObjectTypeName="BE.Item"
                    SelectMethod="getItemsbyStoryId" TypeName="DAL.ItemAccessor"></asp:ObjectDataSource>
                <asp:DropDownList ID="ItemReqList" DataValueField="ItemId" DataTextField="ItemName"
                    DataSourceID="StoryItemObjDS" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Selected="True" Value="" Text="None" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="buttons" colspan="2">
                <asp:Button ID="CreateButton" runat="server" Visible="false" Text="Create Entity State" />
                <asp:Button ID="SaveButton" runat="server" Visible="false" Text="Save" />
            </td>
        </tr>
    </table>
</asp:Content>
