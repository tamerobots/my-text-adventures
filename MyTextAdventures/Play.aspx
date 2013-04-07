<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Play.aspx.vb" Inherits="_Default" Title="My Text Adventures - Play Game" %>

<asp:Content ID="Content1" ContentPlaceHolderID="leftmenu" runat="Server">
    <div>
        <asp:Label  runat="server" ID="StoryName" /><br />
        <asp:Label runat="server" ID="AuthorName" /><br />
        <asp:Label runat="server" ID="PublishedOn" /><br />
    </div>
     <div class="hint">
        <h3>
            Hint</h3>
          Standard Command names:
   <ul style="text-align:left;margin:0px;padding-left:15px;">
   <li>Go (compass direction)</li>
   <li>Look (in, at, around)</li>
   <li>Pick up (item)</li>
   <li>Hint (entity, item)</li>
   <li>Inventory</li>
   <li>Restart</li>
    </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" EnableViewState="true" ContentPlaceHolderID="main" runat="Server">
    <h1 runat="server" id="storyh1">
        Play a Game</h1>
    <br />
    <table class="contententry">
        <tr>
            <td>
                <asp:ObjectDataSource runat="server" ID="StoryObjDS" DataObjectTypeName="BE.Story"
                    SelectMethod="getPublishedStories" TypeName="DAL.StoryAccessor"></asp:ObjectDataSource>
                <asp:GridView ID="myGridView" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                    AllowSorting="True" EnableSortingAndPagingCallbacks="false">
                    <Columns>
                        <asp:BoundField DataField="StoryName" HeaderText="Story Name" />
                        <asp:BoundField DataField="UserName" HeaderText="Author Name" />
                        <asp:BoundField DataField="CreatedOn" HeaderText="Created On" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="PublishedOn" HeaderText="Published On" DataFormatString="{0:d}" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField ID="StoryId" runat="server" Value='<%#Eval("StoryId") %>' />
                                <asp:LinkButton ForeColor="white" ID="Play" CommandName="Play" runat="server">Play Game</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:TextBox ID="ResultTextBox" Font-Size="Small" TextMode="MultiLine" Text="no story loaded.."
                AutoPostBack="true" EnableViewState="true" Width="70%" Height="400" runat="server"></asp:TextBox>
            <asp:TextBox ID="EntryTextBox" Width="40%" runat="server">
            </asp:TextBox>
            <asp:Button ID="EntryButton" runat="server" Text="Enter" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
    <br />
    <p class="tutorialtext">
  
  Apart from the standard command names to the left, which are common to each story on this website,
   you are free to try any word you can think up to interact with the story.<br />
   The Author could have specified any number of different command names to interact with objects.<br />
   Try a verb with the name of something, like 'program computer' or 'break glass'. See what you can find out..
  
    </p>
    <br />
</asp:Content>
