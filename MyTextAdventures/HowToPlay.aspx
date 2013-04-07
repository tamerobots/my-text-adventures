<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="HowToPlay.aspx.vb" Inherits="HowToPlay" title="My Text Adventures - How to Play" %>

<asp:Content ID="Content1" ContentPlaceHolderID="leftmenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" Runat="Server">
<h1>How to Play</h1>
<h2>How each game works</h2>
<p class="pagetext">
Each game has a collection of <span class="b">rooms</span>. Each of these rooms can hold <span class="b">entities</span> and <span class="b">items</span>.<br />
An entity can be anything - a person, an object, use your imagination! <br />
An item can also be anything, except the player can pick an item up 
and carry it with them to any room in the story, unlike entities,
 which must stay in one room.<br />
Each room and entity has a current <span class="b">state</span>. For example, a room may have a
state where the lights are off, or an entity may have a state where it is on fire. The
author can make different items and entities available depending on which state the room is in, 
for example a flashlight item may only be available when the room's state is set to one 
where there are no lights on.<br />
</p>
<h2>What is the aim of the game?</h2>
<p class="pagetext">
The basic aim of every game is to find all the items and entities that the author has created,
and use them together in some way to reach the end of the game. You are awarded points for doing certain
things or collecting certain items. At the end of the game these will be tallied up to give you a final score.
</p>
<h2>Where are the controls?</h2>
<p class="pagetext">
There are no buttons to click or things to drop and drop - the game works like a command line interface.<br />
That is to say, you must only use text to interact with the game. Enter a line of text into the entry box below
the Story on the 'Play a game' page, press the 'Enter' key and the story will display some text depending
on which commands you entered.
</p>
<h2>Ok, what commands can I enter?</h2>
<p class="pagetext">
There are a theoretically infinite amount of commands you can enter, but the set ones are:

</p>
<ul class="pagetextlist">
<li>
Look - This states the description of an item or entity, e.g.
 '<span class="b">look at table</span>' would show the description of a table.<br />
 If just '<span class="b">look</span>' is typed, the description of the room is stated.
</li>
<li>
Go - Each room can have a room to the North, East, South or West of it. If you think you can go west
from the current room, enter '<span class="b">go west</span>'.
</li>
<li>
Hint - The author can specify some hint text for each entity or item, to help if the player gets stuck.
If you want to view the hint on a 'book' item, enter '<span class="b">hint book</span>'.
</li>
<li>
Pick Up - This allows a user to pick up an item, if they are aware it exists in an entity or room.<br /> Example - '<span class="b">pick up key</span>'.
</li>
<li>
Inventory - Type '<span class="b">inventory</span>' to print out all the items the player has in their possession. 
</li>
<li>
Restart - Type '<span class="b">restart</span>' to restart the game.
</li>
</ul>
<h2>Are these the only commands I can use?</h2>
<p class="pagetext">
No! In addition to these set words, each entity has a verb to 'activate' it,
which is specified by the author. Part of the challenge of the game is to find these
words, using trial and error, and the information given to the user in the description.<br />
These are only ever a <span class="b">single word</span>, however. This makes it easier for
the user to guess.<br />
For example, an candle entity may have a verb 'ignite'. So you would enter '<span class="b">ignite candle</span>'.
<br />
<br />
Hopefully these tips were helpful. Happy adventuring!
</p>
</asp:Content>

