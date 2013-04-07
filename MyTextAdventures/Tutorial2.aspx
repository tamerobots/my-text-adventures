<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Tutorial2.aspx.vb" Inherits="Tutorial2" Title="My Text Adventures - Tutorial 2" %>

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
    <h1>
        Author Tutorial Part Two</h1>
    <h2>
        Getting Started - Creating a Story</h2>
    <p class="pagetext">
        Click on the
        <asp:HyperLink Target="_blank" CssClass="storynav" NavigateUrl="~/Secure/AuthorHome.aspx"
            Text="Author Home" runat="server" />
        link on the navigation bar to the left. This is the central hub for the author -
        it shows all the current stories for the author, as well as links to edit them.<br />
        Select 'Create a Story' and on the next page fill in the name of the story, along
        with a description.<br />
        Once you click the 'Create a Story' button a new story will be created and added
        to the database.
        <br />
        Once the 'Create' button has been clicked, more options open up on the page.<br />
        You can then create the first room in the story by clicking the 'Create a Room'
        button.<br />
        Generally each of the pages that follow are similar, in that initially the creation
        page has some basic fields to enter data into. Once the Create button is clicked,
        an entry is made in the database, and other fields open up on the page. At this
        point you can edit both the new fields and the ones that were present during the
        previous page. This stops new records being created in error if a page is visited by
        accident.
    </p>
    <h2>
        Create a Room</h2>
    <p class="pagetext">
        When you create a new room, all you specify is the room name and the rooms that
        may be connected in each direction.<br />
        You do not need to specify a connected room for any of the points of the compass
        if you do not wish to. However, as this is the first room you have created, there
        will be no values in the drop down lists other than the room itself (in case you
        wanted to be able to, for example, go west from this room and end up in the same room.)<br />
        Click the 'Create Room' button. Once the room is created, you can add new entities
        or room states to the room. Let's make the first room state.
    </p>
    <h2>
        Create a Room State</h2>
    <p class="pagetext">
        Click the 'Create Room State' button. You can then specify some initial data for
        the room state, such as Points Awarded, and whether the player can travel in any
        of the compass point directions from this room state. Tick the 'go east' option,
        and click the Create button.<br />
        You should immediately click the back link at the top right or use the navigation
        bar on the left to return to the parent room, and specify the room state you just
        created as that room's initial room state. This means there will not be an error
        once the story is played.<br />
        Click the 'Save Changes' button on the room page to save the initial room state
        you specified. You can then click the 'Edit' button next to the room state you just
        created on the list at the top of the page.<br />
        Now you have created a room and room state, you can play your game by going to the
        Author Homepage and clicking 'Play' next to your story. Be careful, however. Even
        if you Validate your story first (By clicking the 'Validate' button to check for
        errors) an early, unfinished Story is likely to be unstable.<br />
        Next, let's add an entity to the first room state.
    </p>
    <h2>
        Create an Entity</h2>
    <p class="pagetext">
        From the room state page, click the 'Create an Entity' button. This will take you
        to the entity page.<br />
        The creation page is relatively simple - a name, a description, and most importantly
        the parent drop-down list. Select a room or room state from the list to allow the
        entity to be located when the game is played.
    </p>
    <h2>
        Create an Entity State</h2>
    <p class="pagetext">
        The next step is somewhat more complex. Once the entity has been created, you must
        create an entity state for it.<br />
        Click the 'Create Entity State' button above the (currently empty) list of entity
        states.<br />
        On the next page, you can specify the descriptions and points awarded. You can also
        specify a hint to help the user if they get stuck on how to interact with the entity.<br />
        Most important is the Activation Verb. This single word is what the user will use
        to interact with the entity and change its entity state. It can be any verb you
        can think of - activate, program, open, smell, paint or greet. Once the user enters
        this with the entity name, the entity updates to the next entity state. If you do
        not wish it to do so, leave this blank and do not specify a 'Next Entity State'.<br />
        Remember to check the 'Verb Updates Room State' if you wish this entity state to
        also update the room state when entered.<br />
        You should also quickly return to the entity page and set entity's 'Start Entity
        State' to the entity state you just created in the drop-down list.
    </p>
    <h2>
        Create an Item</h2>
    <p class="pagetext">
        Finally, let's create an item for the player to use. Items can be attached to any
        room state or entity state.<br />
        For our first item, let's create it on the current entity state, that you just created.
        Click the 'Create an Item' button at the top of the entity state page and you will
        be taken to the item page, where you can create an item that is available in the
        game when that entity state is active. A key would be a good example of an item.
        Specify the description, long description and hint text, along with the parent entity
        state, then click 'Create Item'.<br />
        You can then navigate back to the entity state within which you created the item,
        and select the item from the 'Item required for Room State Update' drop-down list.
        This will mean the player will need to pick up the Item you just created in order
        to continue.<br />
    </p>
    <p class="pagetext">
        Finally, <a runat="server" href="~/Tutorial3.aspx" id="tutlink" class="storynav">Tutorial
            Part 3</a>
    </p>
</asp:Content>
