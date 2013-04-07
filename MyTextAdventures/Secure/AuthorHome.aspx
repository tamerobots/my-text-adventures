<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AuthorHome.aspx.vb" 
Inherits="AuthorHome" title="My Text Adventures - Author Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="leftmenu" Runat="Server">
   <div class="hint" >
   <h3>Hint</h3>
  You can have as many stories as you wish! <br />
  Publishing a story makes it visible to the public.<br />
   You can withdraw a story at any time.<br />
   
   </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1"  runat="server">
        <ContentTemplate>
          <h1>Author Home</h1>
   
  <p class="tutorialtext">
Here are all the Stories you have written.<br />
For each Story, you can Edit a Story by clicking the 'Edit' button, Validate a Story to check
whether all it's references are intact and the Story is ready to Publish, and the Published status of the
Story.<br />
When a Story is Published, it is viewable by anyone that accesses the site. If it is not Published, only the Author
can play it. This means the Author can test the game before they release it.<br />
It is <span class="b"> strongly recommended </span>that you validate your Story before releasing it.<br />

</p>

            
<table >
<tr>
<td align="right">
<asp:Button runat="server" ID="NewStoryButton" Text="Create New Story" PostBackUrl="~/Secure/Story.aspx" />
</td>
</tr>
    <tr>
        <td>
          <asp:ObjectDataSource runat="server" ID="AuthorObjDS" DataObjectTypeName="BE.Story" 
                SelectMethod="getStoriesByAuthorId" 
                TypeName="DAL.StoryAccessor"    >
      <SelectParameters>
          <asp:SessionParameter DefaultValue="" Name="AuthorId" SessionField="AuthorId" 
              Type="String" />
      </SelectParameters>
            </asp:ObjectDataSource>

  <asp:GridView id="myGridView" runat="server"  AutoGenerateColumns="False"
    DataSourceID="AuthorObjDS" AllowPaging="True" Allowsorting="True"  EnableSortingAndPagingCallbacks="true"
  >
            <Columns>
            
                <asp:BoundField DataField="StoryName" HeaderText="Story Name" />
                <asp:BoundField DataField="UserName" HeaderText="Author Name" />
                <asp:BoundField DataField="isPublished" HeaderText="Published" />
                <asp:BoundField DataField="CreatedOn" HeaderText="Created On" 
                    DataFormatString="{0:d}" />
                <asp:BoundField DataField="PublishedOn" HeaderText="Published On"
                DataFormatString="{0:d}" />                
        <asp:TemplateField>
               <ItemTemplate>
             <asp:HiddenField ID="StoryId" runat="server" Value='<%#Eval("StoryId") %>' />
            <asp:LinkButton ID="Test" CommandName="Play" runat="server">Play</asp:LinkButton>             
            <asp:LinkButton ID="Validate" CommandName="Validate" runat="server">Validate</asp:LinkButton>
            <asp:LinkButton ID="Edit" CommandName="Edit" runat="server">Edit</asp:LinkButton>
          <asp:LinkButton ID="Delete" CommandName="Delete" runat="server">Delete</asp:LinkButton>
          
           </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField>
               <ItemTemplate>
      <asp:linkButton ID="PublishButton" runat="server" CommandName="Publish" Visible="false"   Text="Publish" /> 
      <asp:linkButton ID="WithdrawButton" runat="server" CommandName="Withdraw" Visible="false"   Text="Withdraw" />
      </ItemTemplate>
      </asp:TemplateField>
              
            
            </Columns>
            </asp:GridView>
            

           
        </td>
  </tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>

