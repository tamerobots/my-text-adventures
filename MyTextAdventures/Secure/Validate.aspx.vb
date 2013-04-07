Imports System.Data
Imports System.Attribute
Partial Class Secure_Validate
    Inherits System.Web.UI.Page

    Dim storyId As String
    'total errors will increment with errors 
    'encountered, to finally report to the user
    Dim totalerrors As Integer = 0
    Dim RoomDataSet As DataSet
    Dim RoomStateDataSet As DataSet
    Dim EntityDataSet As DataSet
    Dim EntityStateDataSet As DataSet
    Dim ItemDataSet As DataSet

    Dim roomacc As New DAL.RoomAccessor
    Dim roomstateacc As New DAL.RoomStateAccessor
    Dim entityacc As New DAL.EntityAccessor
    Dim entitystatacc As New DAL.EntityStateAccessor
    Dim itemacc As New DAL.ItemAccessor
    Dim storyacc As New DAL.StoryAccessor
    Dim story As BE.Story
    Dim room As BE.Room
    Dim roomstate As BE.RoomState
    Dim entity As BE.Entity
    Dim entitystate As BE.EntityState
    Dim reportstring As String

    Public Sub DoNavLinks()
        BackLink.NavigateUrl = "~/Secure/AuthorHome.aspx"
        BackLink.Text = "Back to Author Home"
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            DoNavLinks()
            ResultTextBox.Text = "Validation checks your story for inconsistencies, " & _
            "where you may have forgotten to make links between various entities, " & _
            "rooms, states or items. You can use validation to help fix the problems within your story." & _
            vbCrLf + "This stops you publishing a story that may have unseen problems." & _
            vbCrLf + "It is strongly recommended that you validate your story before publishing it. " & _
            vbCrLf + "Click the 'Validate Now' button below to begin."
        End If
    End Sub

    Private Sub ValidateEntityStates(ByVal EntityDataSet As DataSet)
        If EntityDataSet.Tables(0).Rows.Count > 0 Then
            For Each entrow As DataRow In EntityDataSet.Tables(0).Rows
                entity = entityacc.GetEntity(entrow.Item("EntityId").ToString)
                If String.IsNullOrEmpty(entity.StartEntityStateId) Then
                    reportstring += "Entity " + entity.EntityName & _
                    " has no Start Entity State specified. " + vbCrLf
                    totalerrors += 1
                End If
                If String.IsNullOrEmpty(entity.Description) Then
                    reportstring += "Entity " + entity.EntityName & _
                    " has no Description text. " + vbCrLf
                    totalerrors += 1
                End If
                'get entity states for this entity
                EntityStateDataSet = entitystatacc.getEntityStatesbyEntityId(entity.EntityId)
                If EntityStateDataSet.Tables(0).Rows.Count > 0 Then
                    For Each entstatrow As DataRow In EntityStateDataSet.Tables(0).Rows
                        entitystate = entitystatacc.GetEntityState(entstatrow.Item("EntityStateId").ToString)
                        'check it's actually possible to update the roomstate
                        If entitystate.VerbUpdatesRoomState = True Then
                            If RoomStateDataSet.Tables(0).Rows.Count < 2 Then
                                reportstring += "entity " + entity.EntityName + "'s activation verb " & _
                                "updates the Room State but it's parent Room has no Room States."
                                totalerrors += 1
                            End If
                        End If
                        'check item specified actually still exists
                        If (Not String.IsNullOrEmpty(entitystate.ItemIdRequiredforRoomStateUpdate)) And ItemDataSet.Tables(0).Rows.Count > 0 Then

                            Dim found As Boolean = False
                            For Each itemrow As DataRow In ItemDataSet.Tables(0).Rows
                                If String.Equals(itemrow.Item("ItemId"), entitystate.ItemIdRequiredforRoomStateUpdate) Then
                                    found = True
                                End If
                                If found = False Then
                                    'the item specified was not found so it's an error.
                                    reportstring += "The Item specified in Entity State " + entitystate.EntityStateName & _
                                    " of Entity " + entity.EntityName + " as needed for the Room State Update was not found."
                                    totalerrors += 1
                                End If
                            Next
                        End If
                    Next


                End If

            Next
        End If


    End Sub


    Protected Sub ValidateButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ValidateButton.Click
        reportstring = String.Empty
        storyId = Request.QueryString("StoryId").ToString
        story = storyacc.GetStory(storyId)
        totalerrors = 0
        If Request.QueryString("StoryId") IsNot Nothing Then

            If String.IsNullOrEmpty(story.StartRoomId) Then
                reportstring += "Story has no Start Room specified" + vbCrLf
                totalerrors += 1
            End If

            RoomDataSet = roomacc.getRoomsbyStoryId(storyId)
            ItemDataSet = itemacc.getItemsbyStoryId(storyId)
            If RoomDataSet.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In RoomDataSet.Tables(0).Rows
                    'check for startroomstate blanks
                    room = roomacc.GetRoom(row.Item("RoomId").ToString)
                    RoomStateDataSet = roomstateacc.getRoomStatesbyRoomId(room.RoomId)
                    If String.IsNullOrEmpty(room.StartRoomStateId) Then
                        reportstring += "Room " + room.RoomName & _
                        " has no Start Room State specified. " + vbCrLf
                        totalerrors += 1
                    End If
                    If RoomStateDataSet.Tables(0).Rows.Count > 0 Then
                        Dim hasendgametrigger As Boolean = False
                        For Each roomstatrow As DataRow In RoomStateDataSet.Tables(0).Rows
                            roomstate = roomstateacc.GetRoomState(roomstatrow.Item("RoomStateId").ToString)
                            EntityDataSet = entityacc.getEntitiesByRoomStateId(roomstate.RoomStateId)
                            ValidateEntityStates(EntityDataSet)
                            If roomstate.isEndGameTrigger Then
                                hasendgametrigger = True
                            End If
                        Next
                        ' if there is no end game trigger, this is obviously an error. report to the user
                        ' and increment errors.
                        If hasendgametrigger = False Then
                            reportstring += "This Story has no end game trigger specified. " & _
                            "Make a Room State to end the game with." + vbCrLf
                            totalerrors += 1
                        End If
                    End If
                    'first do entities by roomid, roomstateid catered for above
                    EntityDataSet = entityacc.getEntitiesByRoomId(room.RoomId)
                    ValidateEntityStates(EntityDataSet)

                Next

            End If
            reportstring += "Validation Complete. You have " + totalerrors.ToString + " errors."
            If totalerrors = 0 Then
                PlayStoryButton.Enabled = True
            Else
                PlayStoryButton.Enabled = False
            End If
        Else
            'if the storyid was not specified, there's obviously an error.
            reportstring = "You have navigated here from an incorrect location."
        End If
        ResultTextBox.Text = reportstring
        PlayStoryButton.DataBind()
        ResultTextBox.DataBind()
    End Sub
End Class
