
Partial Class Secure_RoomState
    Inherits System.Web.UI.Page

    Private roomstate As BE.RoomState

    Private Sub DoNavLinks()
        If (Session("StoryId") IsNot Nothing) And (Session("StoryName") IsNot Nothing) Then
            StoryNavLink.NavigateUrl = "~/Secure/Story.aspx?StoryId=" + Session("StoryId").ToString
            StoryNavLink.Text = Session("StoryName").ToString
            'Master.Controls
        End If
        If (Session("RoomId") IsNot Nothing) And (Session("RoomName") IsNot Nothing) Then
            RoomNavLink.NavigateUrl = "~/Secure/Room.aspx?RoomId=" + Session("RoomId").ToString
            RoomNavLink.Text = Session("RoomName").ToString
            BackLink.NavigateUrl = "~/Secure/Room.aspx?RoomId=" + Session("RoomId").ToString
            BackLink.Text = "Return to " + Session("RoomName").ToString
            'Master.Controls
        End If

    End Sub

    Protected Sub GatherNewAttributes(ByVal input As BE.RoomState)
        With input
            ' .ParentRoomId = Request.QueryString("RoomId").ToString
            .RoomStateName = RoomStateName.Text.Replace("'", "''")
            .Description = Description.Text.Replace("'", "''")
            .LongDescription = LongDescription.Text.Replace("'", "''")
            .PointsAwarded = PointsAwarded.Text.ToString '.Replace("'", "''")
            .canGoEast = canGoEast.Checked
            .canGoNorth = canGoNorth.Checked
            .canGoSouth = canGoSouth.Checked
            .canGoWest = canGoWest.Checked
            .isEndGameTrigger = isEndGameTrigger.Checked
            .nextRoomStateId = RoomStateList.SelectedValue
        End With
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("RoomStateId") Is Nothing Then
            roomstate = New BE.RoomState
            roomstate.ParentRoomId = Request.QueryString("RoomId")
            CreateButton.Visible = True
            'hide the inner details table
            myGridView.Visible = False
            NewEntityButton.Visible = False
            EntityGridView.Visible = False
            NewItemButton.Visible = False

        Else
            Dim roomstateacc As New DAL.RoomStateAccessor
            roomstate = roomstateacc.GetRoomState(Request.QueryString("roomstateId"))

            If Not Page.IsPostBack Then
                DoNavLinks()
                RoomStateName.Text = roomstate.RoomStateName
                PointsAwarded.Text = roomstate.PointsAwarded.ToString
                Description.Text = roomstate.Description
                LongDescription.Text = roomstate.LongDescription
                isEndGameTrigger.Checked = roomstate.isEndGameTrigger
                canGoNorth.Checked = roomstate.canGoNorth
                canGoEast.Checked = roomstate.canGoEast
                canGoSouth.Checked = roomstate.canGoSouth
                canGoWest.Checked = roomstate.canGoWest
            End If
            CreateButton.Visible = False
            SaveButton.Visible = True
        End If
    End Sub

    Protected Sub CreateButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CreateButton.Click
        Page.Validate()
        If Page.IsValid Then
            Dim roomstateacc As New DAL.RoomStateAccessor
            GatherNewAttributes(roomstate)
            roomstateacc.Add(roomstate)
            Response.Redirect("~/Secure/RoomState.aspx?roomstateId=" + roomstate.RoomStateId)
        End If
    End Sub

    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Page.Validate()
        If Page.IsValid Then
            GatherNewAttributes(roomstate)
            Dim storyacc As New DAL.RoomStateAccessor
            storyacc.Update(roomstate)
            SavedLabel.Visible = True
        End If
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Request.QueryString("RoomStateId") IsNot Nothing Then
            RoomStateList.SelectedValue = roomstate.nextRoomStateId.ToString
        End If
    End Sub

    Protected Sub RoomStateObjDS_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles RoomStateObjDS.Selecting
        e.InputParameters("RoomId") = roomstate.ParentRoomId
    End Sub

    Protected Sub myGridView_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles myGridView.RowCommand
        Dim parentlb As LinkButton = CType(e.CommandSource, LinkButton)
        Dim reqid As String = CType(parentlb.Parent.FindControl("ItemId"), HiddenField).Value
        Select Case e.CommandName
            Case "Edit"
                Response.Redirect("~/Secure/Item.aspx?itemid=" + reqid)
            Case "Delete"
                Dim itemacc As New DAL.ItemAccessor
                Dim confirmdelete As MsgBoxResult = MsgBox("Are you sure you want to delete this?", MsgBoxStyle.OkCancel, "Caution!")
                If confirmdelete = MsgBoxResult.Ok Then
                    itemacc.Delete(reqid)
                    Response.Redirect(Request.Url.ToString)
                End If

        End Select
        myGridView.DataBind()


    End Sub

    Protected Sub NewItemButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewItemButton.Click
        Response.Redirect("~/Secure/Item.aspx?RoomStateId=" + roomstate.RoomStateId)
    End Sub

    Protected Sub NewEntityButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewEntityButton.Click
        Response.Redirect("~/Secure/Entity.aspx?RoomStateId=" + roomstate.RoomStateId)
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

    Protected Sub EntityObjDS_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles EntityObjDS.Selecting
        If Request.QueryString("RoomStateId") IsNot Nothing Then
            e.InputParameters("RoomStateId") = Request.QueryString("RoomStateId")
        ElseIf Not String.IsNullOrEmpty(roomstate.RoomStateId) Then
            e.InputParameters("RoomStateId") = roomstate.RoomStateId.ToString
        End If
    End Sub


End Class
