
Partial Class Secure_Entity
    Inherits System.Web.UI.Page
    Private current As BE.Entity
    Private parentisroom As Boolean = False
    Private parentisroomstate As Boolean = False

    Public Sub DoNavLinks()
        If (Session("StoryId") IsNot Nothing) And (Session("StoryName") IsNot Nothing) Then
            StoryNavLink.NavigateUrl = "~/Secure/Story.aspx?StoryId=" + Session("StoryId").ToString
            StoryNavLink.Text = Session("StoryName").ToString
        End If
        If (Session("RoomId") IsNot Nothing) And (Session("RoomName") IsNot Nothing) Then
            RoomNavLink.NavigateUrl = "~/Secure/Room.aspx?RoomId=" + Session("RoomId").ToString
            RoomNavLink.Text = Session("RoomName").ToString
            BackLink.NavigateUrl = "~/Secure/Room.aspx?RoomId=" + Session("RoomId").ToString
            BackLink.Text = "Back to " + Session("RoomName").ToString
        End If

    End Sub

    Protected Sub GatherNewAttributes(ByVal input As BE.Entity)
        ' set other attributes here
        With input
            .EntityName = EntityName.Text.Replace("'", "''")
            .Description = Description.Text.Replace("'", "''")
            .Visible = Visible.Checked
            If parentisroom Then
                .RoomId = RoomList.SelectedValue
            ElseIf parentisroomstate Then
                .RoomStateId = RoomStateList.SelectedValue
            End If
            .StartEntityStateId = EntityStateList.SelectedValue
        End With
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("RoomStateId") IsNot Nothing Then
            parentisroomstate = True
        ElseIf Request.QueryString("RoomId") IsNot Nothing Then
            parentisroom = True
        End If
        If Request.QueryString("EntityId") Is Nothing Then
            current = New BE.Entity
            CreateButton.Visible = True
            NewEntityStateButton.Visible = False
            EntityStateList.Width = 100
            StartEntityStateLabel.Visible = False
            EntityStateList.Visible = False
            SaveButton.Visible = False
            'hide the inner details table
            myGridView.Visible = False

            If parentisroom Then
                current.RoomId = Request.QueryString("RoomId")
            ElseIf parentisroomstate Then
                current.RoomStateId = Request.QueryString("RoomStateId")
            End If


        Else
            Dim entacc As New DAL.EntityAccessor
            current = entacc.GetEntity(Request.QueryString("EntityId"))
            If String.IsNullOrEmpty(current.RoomId) Then
                parentisroomstate = True
                RoomObjDS = Nothing
                RoomList.DataSource = Nothing

            ElseIf String.IsNullOrEmpty(current.RoomStateId) Then
                parentisroom = True
                RoomStateObjDS = Nothing
                RoomStateList.DataSource = Nothing
            End If
            If Not Page.IsPostBack Then
                EntityName.Text = current.EntityName
                Session("EntityId") = current.EntityId
                Session("entityName") = current.EntityName
                Visible.Checked = current.Visible
                Description.Text = current.Description
                EntityStateList.SelectedValue = current.StartEntityStateId
                If parentisroom Then
                    RoomList.SelectedValue = current.RoomId
                ElseIf parentisroomstate Then
                    RoomStateList.SelectedValue = current.RoomStateId
                End If

            End If
            CreateButton.Visible = False
            SaveButton.Visible = True
            myGridView.Visible = True
        End If
        If parentisroomstate Then
            ParentRoomStateValidator.Enabled = True
            ParentRoomStateValidator.Visible = True
            RoomStateList.Visible = True

        ElseIf parentisroom Then
            ParentRoomValidator.Enabled = True
            ParentRoomValidator.Visible = True
            RoomList.Visible = True
        Else
            BadAccessWarning.Visible = True
        End If

        If Not Page.IsPostBack Then
            DoNavLinks()
        End If
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        'load lists based on querystring values
        If Request.QueryString("EntityId") IsNot Nothing Then
            If Request.QueryString("RoomId") IsNot Nothing Then
                RoomList.SelectedValue = current.RoomId.ToString
            End If
            If Request.QueryString("RoomStateId") IsNot Nothing Then
                RoomStateList.SelectedValue = current.RoomStateId.ToString
            End If
        End If
    End Sub

    Protected Sub RoomObjDS_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles RoomObjDS.Selecting
        If parentisroom Then
            Dim roomacc As New DAL.RoomAccessor
            If Request.QueryString("RoomId") IsNot Nothing Then
                e.InputParameters("StoryId") = roomacc.GetRoom(Request.QueryString("RoomId")).StoryId
            ElseIf Not String.IsNullOrEmpty(roomacc.GetRoom(current.RoomId).StoryId) Then
                e.InputParameters("StoryId") = roomacc.GetRoom(current.RoomId).StoryId
            End If
        End If
    End Sub

    Protected Sub RoomStateObjDS_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles RoomStateObjDS.Selecting
        If parentisroomstate Then
            Dim roomstateacc As New DAL.RoomStateAccessor
            If Request.QueryString("RoomStateId") IsNot Nothing Then
                e.InputParameters("RoomId") = roomstateacc.GetRoomState(Request.QueryString("RoomstateId")).ParentRoomId
            ElseIf Not String.IsNullOrEmpty(roomstateacc.GetRoomState(current.RoomStateId).ParentRoomId) Then
                e.InputParameters("RoomId") = roomstateacc.GetRoomState(current.RoomStateId).ParentRoomId
            End If
        End If
    End Sub

    Protected Sub CreateButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CreateButton.Click
        Page.Validate()
        If Page.IsValid Then
            Dim entityacc As New DAL.EntityAccessor
            GatherNewAttributes(current)
            entityacc.Add(current)
            Response.Redirect("~/Secure/Entity.aspx?entityId=" + current.EntityId)
        End If
    End Sub

    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Page.Validate()
        SavedLabel.Visible = False
        If Page.IsValid Then
            GatherNewAttributes(current)
            'update entity with new values in the database
            Dim entityacc As New DAL.EntityAccessor
            entityacc.Update(current)
            SavedLabel.Visible = True
        End If
    End Sub


    Protected Sub ParentRoomStateValidator_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles ParentRoomStateValidator.ServerValidate
        If RoomStateList.SelectedValue = "" Then
            args.IsValid = False
        End If
    End Sub

    Protected Sub ParentRoomValidator_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles ParentRoomValidator.ServerValidate
        If RoomList.SelectedValue = "" Then
            args.IsValid = False
        End If
    End Sub

    Protected Sub NewEntityStateButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewEntityStateButton.Click
        Response.Redirect("~/Secure/EntityState.aspx?EntityId=" + current.EntityId)
    End Sub

    Protected Sub myGridView_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles myGridView.RowCommand
        Dim roomacc As New DAL.RoomAccessor
        Dim parentlb As LinkButton = CType(e.CommandSource, LinkButton)
        Dim reqid As String = CType(parentlb.Parent.FindControl("EntityStateId"), HiddenField).Value
        Select Case e.CommandName
            Case "Edit"
                Response.Redirect("~/Secure/EntityState.aspx?EntityStateid=" + reqid)
            Case "Remove"
                Dim esacc As New DAL.EntityStateAccessor
                Dim confirmdelete As MsgBoxResult = MsgBox("Are you sure you want to delete this?", MsgBoxStyle.OkCancel, "Caution!")
                If (confirmdelete = MsgBoxResult.Ok) Then
                    'check not referenced elsewhere to retain referential integrity
                    Dim referencefree As Boolean = esacc.CheckNotReferenced(reqid, roomacc.GetRoom(current.RoomId).StoryId)
                    If Not referencefree Then
                        MsgBox("This Entity State is referenced elsewhere. Delete the references before you delete it.")
                    Else
                        esacc.Delete(reqid)
                        Response.Redirect(Request.Url.ToString)
                    End If
                End If

        End Select
        myGridView.DataBind()
    End Sub

    Protected Sub myGridView_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles myGridView.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            If (e.Row.DataItem("Visible") = 0) Then
                e.Row.Cells(1).Text = "No"
            Else
                e.Row.Cells(1).Text = "Yes"
            End If
            If (e.Row.DataItem("VerbUpdatesRoomState") = 0) Then
                e.Row.Cells(4).Text = "No"
            Else
                e.Row.Cells(4).Text = "Yes"
            End If

        End If
    End Sub
End Class
