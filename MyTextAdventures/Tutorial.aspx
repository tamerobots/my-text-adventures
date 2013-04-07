<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Tutorial.aspx.vb" Inherits="Tutorial" Title="My Text Adventures - Tutorial 1" %>

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
        Author Tutorial Part One</h1>
    <h2>
        How do I write my own Story for people to play?</h2>
    <p class="pagetext">
        Before you start writing anything, you should learn the basic components of each
        story and how they relate to each other. The basic components for every story are:
    </p>
    <ul class="pagetextlist">
        <li>Rooms</li>
        <li>Room States</li>
        <li>Entities</li>
        <li>Entity States</li>
        <li>Items</li>
    </ul>
    <p class="pagetext">
        There is no limit to how many of these you can include in your story. The more you
        have, the harder they can be to keep track of!
    </p>
    <h2>
        Rooms</h2>
    <p class="pagetext">
        Rooms are the fundamental component of every story.
        <br />
        The Player starts in a room specified by the Author, and works their way through
        the story until they reach the end. Each room may have other rooms related to it
        through the points of the compass, which allows the player to navigate between rooms.<br />
        Obviously, a room is a room only in name - a room does not have to have 4 walls,
        it can be outside, it can be a cloud, it can be the size of an entire continent.<br />
        As long as you can go North, East, South or West from it, it can be any sort of
        location you wish.
    </p>
    <h2>
        Room States</h2>
    <p class="pagetext">
        Room States are individual states for a certain room.<br />
        On entering a new room, the room's specified room state is retrieved. This room
        state's description is shown to the player.<br />
        A room may have multiple room states, each with different items and entities available
        within it (see below.)<br />
        Each room state may have link to another room state, also. When an event happens
        such as an Entity changing State, it may specify that a room state update should
        occur. This means that the room's current room state will be updated to the next
        room state. You can thus chain room states together or make them loop back on each
        other.<br />
        A room state may enable or disable navigation from that room to other rooms, for
        example a player may enter a room with locked doors, then need to pull a lever in
        order to transition to the next room state where all the doors are then unlocked,
        and the player can visit the other rooms to the North, East, South and West.<br />
    </p>
    <h2>
        Entities</h2>
    <p class="pagetext">
        Entities are non-movable things that may be related to a room or room state.<br />
        When the Player is currently in a room or a room in a certain room state, the entity
        will be available, and can be interacted with by the player. An entity can
        be anything - a person, an alien, an inanimate object, a group of anthropomorphic
        hamsters if you wish!<br />
        The most important thing to remember about entities is that they cannot be removed
        from the Room (or Room State) by the Player, unlike items which are explained below.
    </p>
    <h2>
        Entity States</h2>
    <p class="pagetext">
        Similar to the relationship between rooms and room states, each entity can have
        a number of different entity states. As before, an entity MUST have at least one
        entity state or an error will occur in the story.<br />
        A relatively large amount of data is held in an entity state. The most important
        is the Activation Verb. This single word is used to allow the player to interact
        with the entity. If the player uses the activation verb in combination with the
        entity name, for example
        <br />
        'feed hamster'<br />
        then the entity state will use it's 'Next Entity State' property to update the entity
        to the next entity state - the hamster could start being small, then after feeding,
        would become big.<br />
        You can also set the entity state to update the room to the next room state if the
        activation verb is entered, and also set a condition that the Player needs a certain
        item in order to do so.<br />
        When the activation verb is used, you can also specify text that would be displayed
        immediately afterwards, for example entering 'feed hamster' could print the text
        'The Hamster ate your food! it looks happier now. It runs off into a hole in the
        skirting board.'<br />
    </p>
    <h2>
        Items</h2>
    <p class="pagetext">
        Items are relatively simple objects that the Player can carry around in their Inventory,
        independent of which room the Player is in.<br />
        An item should ideally be something the Player could actually realistically carry,
        i.e. a key, book, or lightsaber. (Although if you decide you want your player to
        play the story from the perspective of a city-sized robot, this shouldn't matter.)
        <br />
        An Item may be required by an entity state for a room state update.<br />
        You can also change the parent entity state or room state of an item, as it can
        be related to either (i.e. an item may be present on the floor of the room, or may
        be contained in an entity within that room, such as a chest or the pocket of a bartender.
    </p>
    <p class="pagetext">
        On to <a runat="server" href="~/Tutorial2.aspx" id="tutlink" class="storynav">Tutorial
            Part 2</a>
    </p>
</asp:Content>
