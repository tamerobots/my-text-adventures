
Partial Class Secure_Room
    Inherits System.Web.UI.Page

    Private current As BE.Room

    Private Sub DoNavLinks()
        'setup nav links on the left navigation bar from various session values
        If (Session("StoryId") IsNot Nothing) And (Session("StoryName") IsNot Nothing) Then
            StoryNavLink.NavigateUrl = "~/Secure/Story.aspx?StoryId=" + Session("StoryId").ToString
            StoryNavLink.Text = Session("StoryName").ToString

        End If
        If (Session("RoomId") IsNot Nothing) And (Session("RoomName") IsNot Nothing) Then
            RoomNavLink.NavigateUrl = "~/Secure/Room.aspx?RoomId=" + Session("RoomId").ToString
            RoomNavLink.Text = Session("RoomName").ToString
        End If
        If (Session("StoryId") IsNot Nothing) And (Session("StoryName") IsNot Nothing) Then
            BackLink.NavigateUrl = "~/Secure/Story.aspx?StoryId=" + Session("StoryId").ToString
            BackLink.Text = "Back to " + Session("StoryName").ToString
        End If
    End Sub

    Protected Sub GatherNewAttributes(ByVal input As BE.Room)
        ' get attributes from various input boxes etc
        With input
            .RoomName = RoomName.Text.Replace("'", "''")
            .NorthRoomId = NorthList.SelectedValue
            .EastRoomId = EastList.SelectedValue
            .SouthRoomId = SouthList.SelectedValue
            .WestRoomId = WestList.SelectedValue
            .StartRoomStateId = StartRoomStateList.SelectedValue
        End With
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim AuthorAcc As New DAL.AuthorAccessor
        'If id is nothing, it is time for creation, not edition.
        If Request.QueryString("RoomId") Is Nothing Then
            current = New BE.Room
            current.StoryId = Request.QueryString("StoryId")
            CreateButton.Visible = True
            NewEntityButton.Visible = False
            NewRoomStateButton.Visible = False
            SaveButton.Visible = False
            'hide the inner details table
            myGridView.Visible = False
            EntityGridView.Visible = False
            EntityGridView.DataSource = Nothing
            StartRoomStateLabel.Visible = False
            StartRoomStateList.Visible = False
        Else

            Dim roomacc As New DAL.RoomAccessor
            current = roomacc.GetRoom(Request.QueryString("roomId"))
            If Not Page.IsPostBack Then
                Session("RoomId") = current.RoomId
                Session("RoomName") = current.RoomName
                DoNavLinks()
                RoomName.Text = current.RoomName
                StartRoomStateList.SelectedValue = current.StartRoomStateId
                NorthList.SelectedValue = current.NorthRoomId
                EastList.SelectedValue = current.EastRoomId
                SouthList.SelectedValue = current.SouthRoomId
                WestList.SelectedValue = current.WestRoomId
            End If
            NewRoomStateButton.Visible = True
            CreateButton.Visible = False
            SaveButton.Visible = True
            myGridView.Visible = True
            ' if there are no rows then show placement text
            If myGridView.Rows.Count = 0 Then
                StartRoomStateList.Items(0).Text = "No Room States yet."
                StartRoomStateList.Enabled = False
            End If
        End If
    End Sub

    Protected Sub CreateButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CreateButton.Click
        Page.Validate()
        If Page.IsValid Then
            Dim roomacc As New DAL.RoomAccessor
            GatherNewAttributes(current)
            roomacc.Add(current)
            Response.Redirect("~/Secure/Room.aspx?roomid=" + current.RoomId)
        End If
    End Sub

    Protected Sub myGridView_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles myGridView.RowCommand
        Dim parentlb As LinkButton = CType(e.CommandSource, LinkButton)
        Dim reqid As String = CType(parentlb.Parent.FindControl("RoomstateId"), HiddenField).Value
        Select Case e.CommandName
            Case "Edit"
                Response.Redirect("~/Secure/RoomState.aspx?roomStateid=" + reqid)
            Case "Delete"
                Dim roomstateacc As New DAL.RoomStateAccessor
                Dim confirmdelete As MsgBoxResult = MsgBox("Are you sure you want to delete this?", MsgBoxStyle.OkCancel, "Caution!")
                If confirmdelete = MsgBoxResult.Ok Then
                    roomstateacc.Delete(reqid)
                    Response.Redirect(Request.Url.ToString)
                End If
        End Select
        myGridView.DataBind()
    End Sub

    Protected Sub myGridView_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles myGridView.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            For Each cell As TableCell In e.Row.Cells
                If cell.Text = "1" Then
                    cell.Text = "Yes"
                ElseIf cell.Text = "0" Then
                    cell.Text = "No"
                End If
            Next
        End If
    End Sub

    Protected Sub NewRoomStateButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewRoomStateButton.Click
        Response.Redirect("~/Secure/RoomState.aspx?RoomId=" + current.RoomId)
    End Sub

    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Page.Validate()
        If Page.IsValid Then
            If Session("AuthorId") Is Nothing Then
                FormsAuthentication.SignOut()
                Response.Redirect("~/SessionExpired.aspx")
            End If
            GatherNewAttributes(current)
            Dim roomacc As New DAL.RoomAccessor
            roomacc.Update(current)
            SavedLabel.Visible = True
        End If
    End Sub

    Protected Sub RoomObjDS_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles RoomObjDS.Selecting
        e.InputParameters("StoryId") = current.StoryId
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Request.QueryString("RoomId") IsNot Nothing Then
            NorthList.SelectedValue = current.NorthRoomId.ToString
            EastList.SelectedValue = current.EastRoomId.ToString
            SouthList.SelectedValue = current.SouthRoomId.ToString
            WestList.SelectedValue = current.WestRoomId.ToString

        End If
    End Sub

    Protected Sub NewEntityButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewEntityButton.Click
        Response.Redirect("~/Secure/Entity.aspx?RoomId=" + current.RoomId)
    End Sub

    Protected Sub EntityGridView_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles EntityGridView.RowCommand
        Dim parentlb As LinkButton = CType(e.CommandSource, LinkButton)
        Dim reqid As String = CType(parentlb.Parent.FindControl("EntityId"), HiddenField).Value
        Select Case e.CommandName
            Case "Edit"
                Response.Redirect("~/Secure/Entity.aspx?Entityid=" + reqid)
            Case "Delete"
                Dim entityacc As New DAL.EntityAccessor
                Dim confirmdelete As MsgBoxResult = MsgBox("Are you sure you want to delete this?", MsgBoxStyle.OkCancel, "Caution!")
                If confirmdelete = MsgBoxResult.Ok Then
                    entityacc.Delete(reqid)
                    Response.Redirect(Request.Url.ToString)
                End If

        End Select
        EntityGridView.DataBind()
    End Sub

End Class
