Imports System.Data
Imports System.Attribute
Partial Class Secure_EntityState
    Inherits System.Web.UI.Page

    Private current As BE.EntityState

    Private Sub DoNavLinks()
        If (Session("StoryId") IsNot Nothing) And (Session("StoryName") IsNot Nothing) Then
            StoryNavLink.NavigateUrl = "~/Secure/Story.aspx?StoryId=" + Session("StoryId").ToString
            StoryNavLink.Text = Session("StoryName").ToString
        End If
        If (Session("RoomId") IsNot Nothing) And (Session("RoomName") IsNot Nothing) Then
            RoomNavLink.NavigateUrl = "~/Secure/Room.aspx?RoomId=" + Session("RoomId").ToString
            RoomNavLink.Text = Session("RoomName").ToString
        End If
        If (Session("EntityId") IsNot Nothing) And (Session("EntityName") IsNot Nothing) Then
            EntityNavLink.NavigateUrl = "~/Secure/Entity.aspx?EntityId=" + Session("EntityId").ToString
            EntityNavLink.Text = Session("EntityName").ToString
            BackLink.NavigateUrl = "~/Secure/Entity.aspx?EntityId=" + Session("EntityId").ToString
            BackLink.Text = "Back to " + Session("EntityName").ToString
        End If
    End Sub

    Protected Sub GatherNewAttributes(ByVal input As BE.EntityState)
        ' set other attributes here
        With input
            .EntityStateName = EntityStateName.Text
            If Request.QueryString("EntityId") IsNot Nothing Then
                .EntityId = Request.QueryString("EntityId").ToString
            Else
                .EntityId = current.EntityId
            End If

            .Visible = Visible.Checked.ToString
            .Description = Description.Text.Replace("'", "''")
            .NextEntityStateId = EntityStateList.SelectedValue
            .ItemIdRequiredforRoomStateUpdate = ItemReqList.SelectedValue
            .LongDescription = LongDescription.Text.Replace("'", "''")
            .PointsAwarded = PointsAwarded.Text.Replace("'", "''")
            .Hint = Hint.Text.Replace("'", "''")
            .ActivationVerb = ActivationVerb.Text.ToLower.Replace("'", "''")
            .ActivationText = ActivationText.Text.Replace("'", "''")
            .VerbUpdatesRoomState = VerbUpdatesRoomState.Checked

        End With
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim EntitystateAcc As New DAL.EntityStateAccessor
        'If id is nothing, it is time for creation, not edition.
        If Request.QueryString("EntityStateId") Is Nothing Then
            CreateButton.Visible = True
            EntityStateList.Width = 100
            EntityStateList.Visible = False
            NextEntityStateLabel.Visible = False
            ItemReqList.Visible = False
            ItemRequiredLabel.Visible = False
            SaveButton.Visible = False
            ItemGridView.Visible = False
            NewItemButton.Visible = False
        Else
            Dim entstateacc As New DAL.EntityStateAccessor
            current = entstateacc.GetEntityState(Request.QueryString("EntitystateId"))
            If Not Page.IsPostBack Then
                DoNavLinks()
                EntityStateName.Text = current.EntityStateName
                Visible.Checked = current.Visible.ToString
                Description.Text = current.Description
                EntityStateList.SelectedValue = current.NextEntityStateId
                ItemReqList.SelectedValue = current.ItemIdRequiredforRoomStateUpdate
                LongDescription.Text = current.LongDescription
                PointsAwarded.Text = current.PointsAwarded.ToString
                Hint.Text = current.Hint
                ActivationVerb.Text = current.ActivationVerb
                ActivationText.Text = current.ActivationText
                VerbUpdatesRoomState.Checked = current.VerbUpdatesRoomState
            End If
            CreateButton.Visible = False
            SaveButton.Visible = True
            ItemGridView.Visible = True
            NewItemButton.Visible = True
        End If

    End Sub

    Protected Sub CreateButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CreateButton.Click
        Page.Validate()
        If Page.IsValid Then
            Dim entitystateacc As New DAL.EntityStateAccessor
            current = New BE.EntityState
            GatherNewAttributes(current)
            entitystateacc.Add(current)
            Response.Redirect("~/Secure/EntityState.aspx?EntityStateId=" + current.EntityStateId.ToString)
        End If
    End Sub

    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Page.Validate()
        SavedLabel.Visible = False
        If Page.IsValid Then
            GatherNewAttributes(current)
            Dim entitystateacc As New DAL.EntityStateAccessor
            entitystateacc.Update(current)
            SavedLabel.Visible = True
        End If
    End Sub

    Protected Sub ActivationVerbValidator_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles ActivationVerbValidator.ServerValidate
        If ActivationVerb.Text = "" Then
            args.IsValid = False
        End If
        'IF TIME, IMPLEMENT A FUNCTION TO FIND ALL VERBS IN CURRENT ROOM.
        'Dim verbdataset As DataSet
        'Dim entityacc As New DAL.EntityAccessor
        'Dim entitystatacc As New DAL.EntityStateAccessor
        'Dim entities As ArrayList
        ''first entities

        'verbdataset = entityacc.getEntitiesByRoomId(StoryState.Room.RoomId)
        'If Not RoomDataSet.Tables(0).Rows.Count = 0 Then
        '    For Each row As DataRow In RoomDataSet.Tables(0).Rows
        '        StoryState.currententities.Add(entityacc.GetEntity(row.Item("EntityId").ToString))
        '    Next
        'End If
        'RoomStateDataSet = entityacc.getEntitiesByRoomStateId(StoryState.RoomState.RoomStateId)
        'If Not RoomStateDataSet.Tables(0).Rows.Count = 0 Then
        '    For Each row As DataRow In RoomStateDataSet.Tables(0).Rows
        '        StoryState.currententities.Add(entityacc.GetEntity(row.Item("EntityId").ToString))
        '    Next
        'End If
    End Sub

    'Protected Sub ItemObjDS_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ItemObjDS.Selecting
    '    e.InputParameters("EntityId") = current.EntityId
    'End Sub

    Protected Sub EntityStateObjDS_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles EntityStateObjDS.Selecting
        If current IsNot Nothing Then
            e.InputParameters("EntityId") = current.EntityId
        Else
            e.InputParameters("EntityId") = String.Empty
        End If

    End Sub

    Protected Sub NewItemButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewItemButton.Click
        Response.Redirect("~/Secure/Item.aspx?EntityStateId=" + current.EntityStateId)
    End Sub

    Protected Sub ItemGridView_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles ItemGridView.RowCommand
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
        ItemGridView.DataBind()
    End Sub

    Protected Sub StoryItemObjDS_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles StoryItemObjDS.Selecting
        If Session("StoryId") Is Nothing Then
            Response.Redirect("~/SessionExpired.aspx")
        End If
        e.InputParameters("StoryId") = Session("StoryId").ToString
    End Sub
End Class
