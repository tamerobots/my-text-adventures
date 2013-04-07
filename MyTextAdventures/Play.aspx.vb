Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Text
Partial Class _Default
    Inherits System.Web.UI.Page
    Private actionhandler As MTATools.StoryActionHandler
    Private storystate As MTATools.StoryState
    Private storyparser As New MTATools.StoryParser
    Private wordcollection As StringCollection
    Private enteredtext As String

    Protected Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        'Handle errors just in case the story has not been properly written 
        'and slipped past validation
        If enteredtext IsNot Nothing Then
            Response.Redirect("~/PlayError.aspx?Command=" + enteredtext.ToString)
        Else
            Response.Redirect("~/PlayError.aspx")
        End If
        Server.ClearError()
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim loadstatus As String = String.Empty
        If Page.IsPostBack Then
            storystate = ViewState.Item("StoryState")
            actionhandler = New MTATools.StoryActionHandler(storystate)
            storyparser = New MTATools.StoryParser
        End If
        If Not Page.IsPostBack Then
            If Request.QueryString("StoryId") IsNot Nothing Then
                'create story state and data accessors from classes and database, using storyid querystring value
                storystate = New MTATools.StoryState(Request.QueryString("StoryId"))
                actionhandler = New MTATools.StoryActionHandler(storystate)
                storyparser = New MTATools.StoryParser
                'format the page to show the information
                myGridView.Visible = False
                StoryName.Text = storystate.Story.StoryName
                storyh1.InnerText = storystate.Story.StoryName
                AuthorName.Text = "Author: " + storystate.Author.FirstName + " " + storystate.Author.LastName
                'Show stories based on user's authentication status, whether
                'the user is the author of the story in question, as well as
                'the published status of story
                Dim published As Boolean = True
                If storystate.Story.PublishedOn = Date.MinValue Then
                    ResultTextBox.Text = "This story is not published yet." + vbCrLf
                    published = False
                Else
                    PublishedOn.Text = "Published: " + Date.Now.Date
                    published = True
                End If
                Dim authorknown As Boolean = True
                If Session("AuthorId") Is Nothing Then
                    authorknown = False
                ElseIf storystate.Author.AuthorId <> Session("AuthorId").ToString Then
                    authorknown = False
                End If
                Dim playeracc As New DAL.PlayerAccessor
                If authorknown Then
                    'deal with player generation or load progress into player from a previous play
                    'of the game by this particular author
                    Dim currentauthorplayer As BE.Player = playeracc.GetPlayerByAuthorId(Session("AuthorId").ToString)
                    If currentauthorplayer IsNot Nothing Then
                        'also loads items in storystate.availableitems
                        loadstatus = actionhandler.LoadPlayer(currentauthorplayer.PlayerId) + vbCrLf
                    Else
                        Dim newplayer As BE.Player = New BE.Player
                        newplayer.AuthorId = Session("AuthorId").ToString
                        playeracc.Add(newplayer)
                        storystate.Player = newplayer
                        loadstatus = "New Player."
                    End If
                Else
                    'author is not playing, so just create a blank player
                    'for either a random non-authenticated user
                    'or another author (that did not author this story)
                    Dim newplayer As BE.Player = New BE.Player
                    If Session("AuthorId") IsNot Nothing Then
                        newplayer.AuthorId = Session("AuthorId").ToString
                    End If
                    playeracc.Add(newplayer)
                    storystate.Player = newplayer
                    loadstatus = "New Player." + vbCrLf
                End If


                If authorknown Or published Then
                    'user/author is authorised to play this game so print story data and first room name
                    ResultTextBox.Text = loadstatus + storystate.Story.StoryName & _
                    " by " + storystate.Author.UserName + "." + vbCrLf + storystate.Story.Description + vbCrLf & _
                   actionhandler.EnterRoom(storystate.Room.RoomId) + vbCrLf
                    'Session("StoryState") = storystate
                    ViewState.Add("StoryState", storystate)
                Else
                    EntryButton.Enabled = False
                    EntryTextBox.Enabled = False
                End If
            Else
                'StoryId is nothing, so show available stories
                myGridView.Visible = True
                EntryButton.Visible = False
                EntryTextBox.Visible = False
                ResultTextBox.Visible = False
                myGridView.DataSourceID = "StoryObjDS"
                myGridView.DataBind()
            End If
        End If
    End Sub

    Protected Sub EntryButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EntryButton.Click
        'Remove older lines within the box.
        Dim currentstr As String() = ResultTextBox.Text.Split("^")
        Dim x As Integer = currentstr.Length - 1
        ResultTextBox.Text = String.Empty
        While ResultTextBox.Text.Length < 550 And x >= 0
            ResultTextBox.Text = ResultTextBox.Text.Insert(0, (currentstr(x)) + "^")
            x -= 1
        End While
        'parse the entered string
        enteredtext = EntryTextBox.Text.ToLower
        'small guard against SQL injection - needs to be beefed up if time allows
        enteredtext = enteredtext.Replace("'", "''")
        wordcollection = New StringCollection
        wordcollection = storyparser.ParseString(enteredtext)
        If wordcollection.Count <> 0 Then
            '*unused
            'Dim generickeyword As Boolean
            'generickeyword = storyparser.isgenerickeyword(wordcollection(0))

            'debug
            'For Each value As String In wordcollection
            'ResultTextBox.Text += value
            'Next
            ResultTextBox.Text += enteredtext
            ResultTextBox.Text += vbCrLf
            Select Case wordcollection(0).ToString.ToLower
                Case "go"
                    ResultTextBox.Text += actionhandler.Go(wordcollection)
                Case "look"
                    ResultTextBox.Text += actionhandler.Look(wordcollection)
                Case "hint"
                    ResultTextBox.Text += actionhandler.Hint(wordcollection)
                Case "pick"
                    If String.Equals(wordcollection(1).ToString.ToLower, "up") Then
                        ResultTextBox.Text += actionhandler.AttemptItemGet(wordcollection)
                    End If
                Case "restart"
                    'restarts the game
                    If Session("AuthorId") IsNot Nothing Then
                        ResultTextBox.Text += actionhandler.ResetAuthorPlayer(Session("AuthorId").ToString)
                    Else
                        ResultTextBox.Text += actionhandler.ResetAuthorPlayer(String.Empty)
                    End If
                    'must enter the first room to reset everything fully
                    ResultTextBox.Text += actionhandler.EnterRoom(storystate.Story.StartRoomId)
                Case "inventory"
                    If storystate.inventoryitems IsNot Nothing Then
                        ResultTextBox.Text += "Inventory:" + vbCrLf
                        If storystate.inventoryitems.Count > 0 Then
                            For Each ite As BE.Item In storystate.inventoryitems
                                ResultTextBox.Text += ite.ItemName + " : " + ite.Description + vbCrLf
                            Next
                        Else
                            ResultTextBox.Text += "You currently have no items in your inventory."
                        End If
                    End If
                Case Else
                    ResultTextBox.Text += actionhandler.AttemptVerbUse(wordcollection)
                    ' ResultTextBox.Text += "I'm sorry, I don't understand that command."

            End Select

            EntryTextBox.Text = String.Empty
            EntryTextBox.DataBind()
            ResultTextBox.Text += vbCrLf
            ResultTextBox.DataBind()
            SetFocus(EntryTextBox)
            ViewState.Add("StoryState", storystate)
        End If

    End Sub

    Protected Sub myGridView_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles myGridView.RowCommand
        Dim parentlb As LinkButton = CType(e.CommandSource, LinkButton)
        Dim reqid As String = CType(parentlb.Parent.FindControl("StoryId"), HiddenField).Value
        Select Case e.CommandName
            Case "Play"
                Response.Redirect("~/Play.aspx?storyid=" + reqid)

        End Select

    End Sub

End Class
