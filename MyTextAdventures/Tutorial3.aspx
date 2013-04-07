<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Tutorial3.aspx.vb" Inherits="Tutorial3" Title="My Text Adventures - Tutorial 3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="leftmenu" runat="Server">
    <asp:HyperLink runat="server" ID="Tutorial1Link" Text="Tutorial Part One" CssClass="storynav"
        NavigateUrl="~/Tutorial.aspx" /><br />
    <p class="navseparator">
    </p>
    <asp:HyperLink runat="server" ID="Tutorial2Link" Text="Tutorial Part Two" CssClass="storynav"
        NavigateUrl="~/Tutorial2.aspx" />
    <p class="navseparator">
    </p>
    <asp:HyperLink runat="server" ID="Tutorial3Link" Text="Tutorial Part Three" CssClass="storynav"
        NavigateUrl="~/Tutorial3.aspx" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <h2>
        Create a End Game Room State</h2>
    <p class="pagetext">
        Every game needs to have a room state that, when accessed by the Player, results
        in the game ending.<br />
        Whether a room state is a trigger for the end of the game is dictated by whether
        the checkbox 'Is End Game Trigger' is checked within a room state.<br />
        Go the the Author Homepage, select your story, then select the room you wish to
        end the game in. (You could also create a room specifically for ending the game,
        if you wish.)<br />
        Create a new room state, then where you would usually write the long description
        of the room state, instead enter the text you want to display to the user when they
        finish the game.<br />
        You could state a simple "Well done, you have finished my game, bye!" or you could
        write much more, it is up to you.<br />
        When the player finishes the game, their total points will be shown to them, and
        they will have the option of restarting the game.<br />
    </p>
    <h2>
        Validate the Story</h2>
    <p class="pagetext">
        An important step to take before you think about publishing your story is to validate
        it.
        <br />
        To validate a story, navigate to Author Homepage and next to the story on the list
        you wish to validate, click the 'Validate' link. This will take you to the validation
        page.<br />
        When you click the 'Validate Now' button below the validation results text box,
        the website will go through all of the various rooms, room states, entities, entity
        states and items to check whether you have forgotten to make references between
        them, or forgotten to set certain things within the story that would otherwise stop
        the story from working properly.<br />
        Validation should not be looked at as a substitute for manually going through the
        story and checking everything is correct yourself. There may be some errors within
        a story that the validation process may not detect, so it is recommended the author
        checks the story themselves manually before validation.
    </p>
    <h2>
        Publish the Story</h2>
    <p class="pagetext">
        Finally, once your story has passed validation, navigate to the Author Homepage
        again and click the the 'Publish' button next to your story. This will make the
        story visible to anyone who accesses the site. You can also withdraw it from the public
        eye by clicking 'Withdraw' next to the story on the homepage.
    </p>
    <h1>
        Well done, you just authored a story!</h1>
</asp:Content>
