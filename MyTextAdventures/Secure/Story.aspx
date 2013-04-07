<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Story.aspx.vb" Inherits="Secure_Story" Title="My Text Adventures - Story" %>

<asp:Content ID="Content1" ContentPlaceHolderID="leftmenu" runat="Server">
    <p class="navseparator">
    </p>
    <asp:HyperLink runat="server" ID="StoryNavLink" CssClass="storynav" />
    <div class="hint">
        <h3>
            Hint</h3>
        You should remember to specify an initial room, or the story will not start.
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <table>
        <tr>
            <td class="titletableleftright">
            </td>
            <td class="titletablecenter">
                <h1>
                    Story</h1>
            </td>
            <td class="titletableleftright">
                <asp:HyperLink runat="server" ID="BackLink" CssClass="backnav" />
            </td>
        </tr>
    </table>
    <p class="tutorialtext">
        Let's start making your Story!<br />
        Enter a Story Name and Description, click 'Create Story', then when you page refreshes
        you can start creating Rooms!<br />
        You can have as many Rooms as you like, but make sure you specify a room for the
        story to start with.
    </p>
    <br />
    <asp:Label ID="SavedLabel" Visible="false" Width="100%" runat="server" Text="Saved Successfully."
        ForeColor="White" />
    <table class="contententry">
        <tr>
            <td align="left">
            </td>
            <td align="right">
                <asp:Button ID="NewRoomButton" runat="server" Text="Create New Room" />
            </td>
        </tr>
        <tr>
            <td class="left" />
            <asp:Label ID="CreateWarning" Visible="false" Width="100%" runat="server" Text="The next step is to create a room for your story, so that the story can be accessed." />
            <td class="right">
                <asp:ObjectDataSource runat="server" ID="RoomObjDS" DataObjectTypeName="BE.Room"
                    SelectMethod="getRoomsbyStoryId" DeleteMethod="Delete" TypeName="DAL.RoomAccessor">
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="" Name="StoryId" QueryStringField="StoryId"
                            Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:GridView ID="myGridView" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False"
                    Width="100%" DataSourceID="RoomObjDS" AllowPaging="True" AllowSorting="True"
                    EmptyDataText="No rooms yet. Rooms will appear here.">
                    <Columns>
                        <asp:BoundField DataField="RoomName" HeaderText="Room Name" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField ID="RoomId" runat="server" Value='<%#Eval("RoomId") %>' />
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
                Story Author
            </td>
            <td class="right">
                <asp:TextBox ID="AuthorName" CssClass="singlelinetextbox" Enabled="false" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="left">
                Name the Story
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="StoryName"
                    Display="Dynamic" runat="server" ErrorMessage="You must enter a name for the Story." />
            </td>
            <td class="right">
                <asp:TextBox ID="StoryName" EnableViewState="false" CssClass="singlelinetextbox"
                    MaxLength="119" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="left">
                Description
            </td>
            <td class="right">
                <asp:TextBox ID="Description" CssClass="multilinetextarea" TextMode="MultiLine" Height="100"
                    runat="server" />
            </td>
        </tr>
        <tr>
            <td class="left">
                <asp:Label ID="StartRoomLabel" runat="server" Text="Room to begin the Story with: " />
            </td>
            <td class="right">
                <asp:DropDownList ID="StartRoomList" DataValueField="RoomId" DataTextField="RoomName"
                    DataSourceID="RoomObjDS" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Selected="True" Value="" Text="None specified." />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="buttons" colspan="2">
                <asp:Button ID="CreateButton" runat="server" Visible="false" Text="Create Story" />
                <asp:Button ID="SaveButton" runat="server" Visible="false" Text="Save Story" />
            </td>
        </tr>
    </table>
</asp:Content>
