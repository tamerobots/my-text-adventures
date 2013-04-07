
Partial Class Secure_Story
    Inherits System.Web.UI.Page

    Private currentstory As BE.Story

    Private Sub DoNavLinks()
        'top level page so very few links needed
        If (Session("StoryId") IsNot Nothing) And (Session("StoryName") IsNot Nothing) Then
            StoryNavLink.NavigateUrl = "~/Secure/Story.aspx?StoryId=" + Session("StoryId").ToString
            StoryNavLink.Text = Session("StoryName").ToString
            BackLink.NavigateUrl = "~/Secure/AuthorHome.aspx"
            BackLink.Text = "Back to Author Home"
        End If
    End Sub

    Protected Sub GatherNewAttributes(ByVal input As BE.Story)
        With input
            .StoryName = StoryName.Text.Replace("'", "''")
            .Description = Description.Text.Replace("'", "''")
            .StartRoomId = StartRoomList.SelectedValue
        End With
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'authentication check
        If Session("AuthorId") Is Nothing Then
            FormsAuthentication.SignOut()
            Response.Redirect("~/SessionExpired.aspx")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim AuthorAcc As New DAL.AuthorAccessor
        If Session("AuthorId") IsNot Nothing Then
            AuthorName.Text = AuthorAcc.GetAuthor(Session("AuthorId").ToString).UserName
        End If
        'If storyid is nothing, it is time for creation, not edition.
        If Request.QueryString("StoryId") Is Nothing Then
            CreateButton.Visible = True
            currentstory = New BE.Story
            currentstory.AuthorId = Session("AuthorId").ToString
            'hide fields that should only be visible when the
            'story exists in the database
            NewRoomButton.Visible = False
            StartRoomLabel.Visible = False
            StartRoomList.Visible = False
            'hide the inner details table
            myGridView.Visible = False
        Else

            Dim storyacc As New DAL.StoryAccessor
            currentstory = storyacc.GetStory(Request.QueryString("StoryId"))

            If Not Page.IsPostBack Then
                'if page is loading for the first time, and the story exists, populate the fields with 
                'values from the database
                Session("StoryId") = currentstory.StoryId
                Session("StoryName") = currentstory.StoryName
                DoNavLinks()
                StoryName.Text = currentstory.StoryName
                Description.Text = currentstory.Description
                StartRoomList.SelectedValue = currentstory.StartRoomId
                NewRoomButton.Visible = True
                CreateButton.Visible = False
                SaveButton.Visible = True
                myGridView.Visible = True
                CreateWarning.Visible = True
                If myGridView.Rows.Count = 0 Then
                    StartRoomList.Items(0).Text = "No Rooms yet."
                    StartRoomList.Enabled = False
                End If

            End If
        End If

    End Sub

    Protected Sub CreateButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CreateButton.Click
        'check authorid still available
        If Session("AuthorId") Is Nothing Then
            FormsAuthentication.SignOut()
            Response.Redirect("~/SessionExpired.aspx")
        End If
        Dim storyacc As New DAL.StoryAccessor
        GatherNewAttributes(currentstory)
        storyacc.Add(currentstory)
        SavedLabel.Visible = True
        'redirect to the same page with the new just-generated storyid as a querystring
        'argument, so the page will display the new values
        Response.Redirect(Request.RawUrl + "?StoryId=" + currentstory.StoryId)
    End Sub

    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        If Session("AuthorId") Is Nothing Then
            FormsAuthentication.SignOut()
            Response.Redirect("~/SessionExpired.aspx")
        End If
        GatherNewAttributes(currentstory)
        Dim storyacc As New DAL.StoryAccessor
        storyacc.Update(currentstory)
        SavedLabel.Visible = True
    End Sub


    Protected Sub myGridView_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles myGridView.RowCommand
        Dim parentlb As LinkButton = CType(e.CommandSource, LinkButton)
        Dim reqid As String = CType(parentlb.Parent.FindControl("RoomId"), HiddenField).Value
        Select Case e.CommandName
            Case "Edit"
                Response.Redirect("~/Secure/Room.aspx?roomid=" + reqid)
            Case "Delete"
                Dim roomacc As New DAL.RoomAccessor
                Dim confirmdelete As MsgBoxResult = MsgBox("Are you sure you want to delete this?", MsgBoxStyle.OkCancel, "Caution!")
                If confirmdelete = MsgBoxResult.Ok Then
                    roomacc.Delete(reqid)
                    Response.Redirect(Request.Url.ToString)
                End If
        End Select
        myGridView.DataBind()
    End Sub


    Protected Sub NewRoomButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewRoomButton.Click
        Response.Redirect("~/Secure/Room.aspx?StoryId=" + currentstory.StoryId)
    End Sub




End Class
