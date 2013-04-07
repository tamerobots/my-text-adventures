
Partial Class Secure_Item
    Inherits System.Web.UI.Page

    Private item As BE.Item
    Private parentisentitystate As Boolean = False
    Private parentisroomstate As Boolean = False

    Private Sub DoNavLinks()
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

    Protected Sub GatherNewAttributes(ByVal input As BE.Item)
        With input
            .ItemName = ItemName.Text.Replace("'", "''")
            .Description = Description.Text.Replace("'", "''")
            .LongDescription = LongDescription.Text.Replace("'", "''")
            .Hint = Hint.Text.Replace("'", "''")
            If parentisentitystate Then
                .ParentStateId = EntityStateList.SelectedValue.ToString
            ElseIf parentisroomstate Then
                .ParentStateId = RoomStateList.SelectedValue.ToString
            End If
            If Session("StoryId") Is Nothing Then
                Response.Redirect("~/SessionExpired.aspx")
            End If
            .StoryId = Session("StoryId").ToString

        End With
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
        If Request.QueryString("ItemId") Is Nothing Then
            item = New BE.Item
            If Request.QueryString("RoomStateId") IsNot Nothing Then
                parentisroomstate = True                
            ElseIf Request.QueryString("EntityStateId") IsNot Nothing Then
                parentisentitystate = True               
            End If
            CreateButton.Visible = True
        Else
            Dim itemacc As New DAL.ItemAccessor
            Dim roomstateacc As New DAL.RoomStateAccessor
            Dim entitystateacc As New DAL.EntityStateAccessor
            item = itemacc.GetItem(Request.QueryString("ItemId"))
            Dim roomstate As BE.RoomState = roomstateacc.GetRoomState(item.ParentStateId.ToString)
            Dim entitystate As BE.EntityState = entitystateacc.GetEntityState(item.ParentStateId.ToString)
            'check whether parent is roomstate or entitystate
            If roomstate IsNot Nothing Then
                parentisroomstate = True
                EntityStateObjDS = Nothing
                EntityStateList.DataSourceID = Nothing
            End If
            If entitystate IsNot Nothing Then
                RoomStateObjDS = Nothing
                RoomStateList.DataSourceID = Nothing
                parentisentitystate = True
            End If

            If Not Page.IsPostBack Then
                DoNavLinks()
                ItemName.Text = item.ItemName
                Description.Text = item.Description
                LongDescription.Text = item.LongDescription
                Hint.Text = item.Hint
                If parentisroomstate Then
                    RoomStateList.SelectedValue = item.ParentStateId
                ElseIf parentisentitystate Then
                    EntityStateList.SelectedValue = item.ParentStateId
                End If
            End If
            CreateButton.Visible = False
            SaveButton.Visible = True
        End If
        'show appropriate validator
        If parentisroomstate Then
            ParentRoomStateValidator.Enabled = True
            ParentRoomStateValidator.Visible = True
            RoomStateList.Visible = True

        ElseIf parentisentitystate Then
            ParentEntityStateValidator.Enabled = True
            ParentEntityStateValidator.Visible = True
            EntityStateList.Visible = True
        Else
            BadAccessWarning.Visible = True
        End If

    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Request.QueryString("ItemId") IsNot Nothing Then
            If Request.QueryString("RoomStateId") IsNot Nothing Then
                RoomStateList.SelectedValue = item.ParentStateId.ToString
            End If
            If Request.QueryString("EntityStateId") IsNot Nothing Then
                EntityStateList.SelectedValue = item.ParentStateId.ToString
            End If
        End If
    End Sub

    Protected Sub RoomStateObjDS_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles RoomStateObjDS.Selecting
        If parentisroomstate Then
            Dim roomStateacc As New DAL.RoomStateAccessor
            If Request.QueryString("RoomStateId") IsNot Nothing Then
                e.InputParameters("RoomId") = roomStateacc.GetRoomState(Request.QueryString("RoomStateId")).ParentRoomId
            ElseIf Not String.IsNullOrEmpty(roomStateacc.GetRoomState(item.ParentStateId).ParentRoomId) Then
                e.InputParameters("RoomId") = roomStateacc.GetRoomState(item.ParentStateId).ParentRoomId
            End If
        End If
    End Sub


    Protected Sub EntityStateObjDS_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles EntityStateObjDS.Selecting
        If parentisentitystate Then
            Dim entitystateacc As New DAL.EntityStateAccessor
            If Request.QueryString("EntityStateId") IsNot Nothing Then
                e.InputParameters("EntityId") = entitystateacc.GetEntityState(Request.QueryString("EntityStateId")).EntityId
            ElseIf Not String.IsNullOrEmpty(entitystateacc.GetEntityState(item.ParentStateId).EntityId) Then
                e.InputParameters("EntityId") = entitystateacc.GetEntityState(item.ParentStateId).EntityId
            End If
        End If
    End Sub

    Protected Sub CreateButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CreateButton.Click
        'validate the page, if it is valid, create the item
        Page.Validate()
        If Page.IsValid Then
            Dim itemacc As New DAL.ItemAccessor
            GatherNewAttributes(item)
            itemacc.Add(item)
            Response.Redirect("~/Secure/Item.aspx?itemId=" + item.ItemId)
        End If
    End Sub

    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        'validate the page, if it is valid, update the item
        Page.Validate()
        SavedLabel.Visible = False
        If Page.IsValid Then
            GatherNewAttributes(item)
            Dim itemacc As New DAL.ItemAccessor
            itemacc.Update(item)
            SavedLabel.Visible = True
        End If
    End Sub

    Protected Sub ParentEntityStateValidator_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles ParentEntityStateValidator.ServerValidate
        If EntityStateList.SelectedValue = "" Then
            args.IsValid = False
        End If
    End Sub

    Protected Sub ParentRoomStateValidator_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles ParentRoomStateValidator.ServerValidate
        If RoomStateList.SelectedValue = "" Then
            args.IsValid = False
        End If
    End Sub
End Class
