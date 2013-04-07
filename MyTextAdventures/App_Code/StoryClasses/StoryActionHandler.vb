Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Attribute

Namespace MTATools
    <Serializable()> _
    Public Class StoryActionHandler
        'This class handles all the actions that can be done upon the storystate object. 
        'The storystate is equivalent to a BE object, while this is equivalent to a DAL object.
        Private _storystate As MTATools.StoryState
        Private roomacc As New DAL.RoomAccessor
        Private playeracc As New DAL.PlayerAccessor
        Private roomstateacc As New DAL.RoomStateAccessor
        Private authoracc As New DAL.AuthorAccessor
        Private storyacc As New DAL.StoryAccessor
        Private entityacc As New DAL.EntityAccessor
        Private itemacc As New DAL.ItemAccessor
        Private entitystateacc As New DAL.EntityStateAccessor
        Private roomstaterecordacc As New DAL.PlayerRoomStateRecordAccessor
        Private entitystaterecordacc As New DAL.PlayerEntityStateRecordAccessor
        Private inventoryacc As New DAL.PlayerInventoryAccessor

        '*****Is ByRef correct here? is it actually changing the state?
        Public Sub New(ByRef input As MTATools.StoryState)
            Me.StoryState = input
        End Sub

        Public Sub SavePlayer()
            playeracc.Update(StoryState.Player)
            'Return "Player saved."
        End Sub

        Public Function LoadPlayer(ByVal playerid As String) As String
            'load old player stuff
            StoryState.Player = playeracc.GetPlayer(playerid)
            Dim ItemDS As DataSet
            ItemDS = inventoryacc.GetPlayerFullInventoryByPlayerIdStoryId(playerid, StoryState.Story.StoryId)
            If ItemDS.Tables(0).Rows.Count = 0 Then
                ' no items stored in an inventory, so just return.
                Return "Player loaded - Empty Inventory."
            Else
                For Each row As DataRow In ItemDS.Tables(0).Rows
                    StoryState.inventoryitems.Add(itemacc.GetItem(row.Item("ItemId").ToString))
                Next
                Return "Player and Inventory loaded."
            End If
            Return "Player loaded."

        End Function

        Public Function ResetAuthorPlayer(ByVal authorid As String) As String
            ' this results in orphaned records and if time allows, will need to 
            ' add some code to clean up the orphaned records.
            Dim oldplayerid As String
            oldplayerid = StoryState.Player.PlayerId
            Dim newplayer As New BE.Player
            If Not String.Equals(authorid, String.Empty) Then
                newplayer.AuthorId = authorid
            End If
            playeracc.Add(newplayer)
            StoryState.Player = newplayer
            playeracc.Delete(GetType(BE.Player), "PlayerId", oldplayerid)
            Return "Restarted. New Player Created." + vbCrLf

        End Function

        Public Function EndGame() As String
            Dim retstring As String = String.Empty
            retstring += StoryState.RoomState.LongDescription & _
            vbCrLf + "Game Finished! You scored " + StoryState.Player.Points.ToString + vbCrLf
            'retstring += vbCrLf + "You started this story on " + StoryState.Player.CreatedOn.Date.ToString & _
            ' " and finished it on " + Date.Now.Date 
            retstring += "You can RESTART the game or play another by clicking the 'Play' link at the top of this page."
            Return retstring
        End Function

        Public Function UpdateToNextEntityState(ByVal entityid As String) As String
            For Each ent As BE.Entity In StoryState.currententities
                If String.Equals(ent.EntityId, entityid) Then
                    Dim playerentitystaterecord As BE.PlayerEntityStateRecord
                    playerentitystaterecord = entitystaterecordacc.GetPlayerEntityStateRecordByEntityIdPlayerId(ent.EntityId, StoryState.Player.PlayerId)
                    Dim nextentstatid As String
                    For Each entstat As BE.EntityState In StoryState.currententitystates
                        If (entstat.EntityId = entityid) And (Not String.IsNullOrEmpty(entstat.NextEntityStateId)) Then
                            Dim newentstat As BE.EntityState
                            nextentstatid = entstat.NextEntityStateId
                            StoryState.currententitystates.Remove(entstat)
                            newentstat = entitystateacc.GetEntityState(nextentstatid)
                            StoryState.currententitystates.Add(newentstat)
                            playerentitystaterecord.EntityStateId = nextentstatid
                            entitystaterecordacc.Update(playerentitystaterecord)
                            Return newentstat.ActivationText + vbCrLf + ent.EntityName + vbCrLf + newentstat.LongDescription
                        End If

                    Next
                End If

            Next
            Return "Error - the next entity state was not found on object " + entityacc.GetEntity(entityid).EntityName
        End Function

        Public Function UpdateToNextRoomState() As String
            Dim playerroomstaterecord As BE.PlayerRoomStateRecord
            playerroomstaterecord = roomstaterecordacc.GetPlayerRoomStateRecordByRoomIdAndPlayerId(StoryState.Room.RoomId, StoryState.Player.PlayerId)
            If Not String.IsNullOrEmpty(StoryState.RoomState.nextRoomStateId) Then
                playerroomstaterecord.RoomStateId = StoryState.RoomState.nextRoomStateId
                roomstaterecordacc.Update(playerroomstaterecord)
                StoryState.RoomState = roomstateacc.GetRoomState(StoryState.RoomState.nextRoomStateId)
                
                StoryState.Player.Points += StoryState.RoomState.PointsAwarded
                If StoryState.RoomState.isEndGameTrigger = True Then
                    Return EndGame()
                End If
                UpdateRoomVariables()
            End If

            Return StoryState.RoomState.LongDescription
        End Function

        Public Function AttemptItemGet(ByVal words As StringCollection) As String
            Dim possibleitemname As String = String.Empty
            Dim i As Integer = 2
            'make the item name bigger each time if it not found, in case it is two words
            'i.e. 'broken light' instead of 'light'
            possibleitemname = words(i)
            While i <= (words.Count - 1)
                For Each ite As BE.Item In StoryState.availableitems
                    If String.Equals(possibleitemname, ite.ItemName.ToLower) Then
                        Return AddItemtoInventory(ite.ItemId)
                    End If
                Next
                i += 1
                If i <= (words.Count - 1) Then
                    possibleitemname = possibleitemname + " " + words(i)
                End If
            End While
            'if not, state this.
            Return "Are you sure you can pick that up? Try again."
        End Function

        Public Function AddItemtoInventory(ByVal itemid As String) As String
            Dim item As BE.Item
            item = itemacc.GetItem(itemid)
            StoryState.inventoryitems.Add(item)
            Dim inventoryitem As New BE.PlayerInventory(StoryState.Player.PlayerId, itemid)
            inventoryacc.Add(inventoryitem)
            Return "You added the " + item.ItemName + " to your inventory." + vbCrLf
        End Function

        Public Function UpdateRoomVariables() As String
            Dim RoomStateDataSet As DataSet
            Dim RoomDataSet As DataSet
            Dim AvailableItemDataSet As DataSet
            Dim playerentitystaterecord As BE.PlayerEntityStateRecord
            Dim item As BE.Item
            'clear existing sets
            StoryState.currententities.Clear()
            StoryState.currententitystates.Clear()
            StoryState.availableitems.Clear()
            'first entities
            RoomDataSet = entityacc.getEntitiesByRoomId(StoryState.Room.RoomId)
            If Not RoomDataSet.Tables(0).Rows.Count = 0 Then
                For Each row As DataRow In RoomDataSet.Tables(0).Rows
                    StoryState.currententities.Add(entityacc.GetEntity(row.Item("EntityId").ToString))
                Next
            End If
            RoomStateDataSet = entityacc.getEntitiesByRoomStateId(StoryState.RoomState.RoomStateId)
            If Not RoomStateDataSet.Tables(0).Rows.Count = 0 Then
                For Each row As DataRow In RoomStateDataSet.Tables(0).Rows
                    StoryState.currententities.Add(entityacc.GetEntity(row.Item("EntityId").ToString))
                Next
            End If

            'then entity states
            For Each ent As BE.Entity In StoryState.currententities
                'check if there is a record of the player reaching an entity state on this entity
                playerentitystaterecord = entitystaterecordacc.GetPlayerEntityStateRecordByEntityIdPlayerId(ent.EntityId, StoryState.Player.PlayerId)
                If playerentitystaterecord Is Nothing Then
                    playerentitystaterecord = New BE.PlayerEntityStateRecord
                    playerentitystaterecord.PlayerId = StoryState.Player.PlayerId
                    playerentitystaterecord.EntityId = ent.EntityId
                    playerentitystaterecord.EntityStateId = ent.StartEntityStateId
                    entitystaterecordacc.Add(playerentitystaterecord)
                    StoryState.currententitystates.Add(entitystateacc.GetEntityState(ent.StartEntityStateId))
                Else
                    'if the playerentitystaterecords' entitystateid has not been set, there is an error.
                    'this occured early on in development, but should never occur again.
                    If String.IsNullOrEmpty(playerentitystaterecord.EntityStateId) Then
                        entitystaterecordacc.Delete(GetType(BE.PlayerEntityStateRecord), "PlayerEntityStateRecordId", playerentitystaterecord.PlayerEntityStateRecordId)
                        Return "There is a critical error in this story - " & _
                        "The StartEntityStateId has not been set on the " + ent.EntityName + " entity. Please contact the author."
                    Else
                        'create a new record
                        StoryState.currententitystates.Add(entitystateacc.GetEntityState(playerentitystaterecord.EntityStateId))
                    End If
                End If
            Next
            'get items available in this roomstate
            AvailableItemDataSet = itemacc.getItemsbyParentStateId(StoryState.RoomState.RoomStateId)
            If Not AvailableItemDataSet.Tables(0).Rows.Count = 0 Then
                For Each row As DataRow In AvailableItemDataSet.Tables(0).Rows
                    item = itemacc.GetItem(row.Item("ItemId").ToString)
                    Dim inventoryitem As BE.PlayerInventory = inventoryacc.GetPlayerInventoryByItemIdPlayerId(item.ItemId, StoryState.Player.PlayerId)
                    'if there isn't a record of the player having this item in their inventory, add it to available items.
                    If inventoryitem Is Nothing Then
                        StoryState.availableitems.Add(item)
                    End If

                Next
            End If
            'now get items available on each entity state
            For Each entstat As BE.EntityState In StoryState.currententitystates
                If entstat IsNot Nothing Then
                    AvailableItemDataSet = itemacc.getItemsbyParentStateId(entstat.EntityStateId)
                    If Not AvailableItemDataSet.Tables(0).Rows.Count = 0 Then
                        For Each row As DataRow In AvailableItemDataSet.Tables(0).Rows
                            item = itemacc.GetItem(row.Item("ItemId").ToString)
                            If inventoryacc.GetPlayerInventoryByItemIdPlayerId(item.ItemId, StoryState.Player.PlayerId) Is Nothing Then
                                StoryState.availableitems.Add(item)
                            End If
                        Next
                    End If
                End If
            Next
            Return Nothing
        End Function

        Public Function EnterRoom(ByVal ToRoomId As String) As String
            

            Dim retstring As String

            Dim playerroomstaterecord As BE.PlayerRoomStateRecord

            'Empty the current room state and entity  and entity state arrays
            StoryState.currententities.Clear()
            StoryState.currententitystates.Clear()
            StoryState.RoomState = Nothing
            '**done need to load the room state from the playercurrentroomstate
            '**done need to load all the entities for the room into the storystate's entities arraylist
            '** done also need to do the same with the entities that are specific to that room state
            '** done also need to check for specific entity states for each as may be stored in playercurrententitystate

            StoryState.Room = roomacc.GetRoom(ToRoomId)
            playerroomstaterecord = roomstaterecordacc.GetPlayerRoomStateRecordByRoomIdAndPlayerId(ToRoomId, StoryState.Player.PlayerId)
            If playerroomstaterecord Is Nothing Then
                playerroomstaterecord = New BE.PlayerRoomStateRecord
                playerroomstaterecord.PlayerId = StoryState.Player.PlayerId
                playerroomstaterecord.RoomId = ToRoomId
                playerroomstaterecord.RoomStateId = StoryState.Room.StartRoomStateId
                roomstaterecordacc.Add(playerroomstaterecord)
                StoryState.RoomState = roomstateacc.GetRoomState(StoryState.Room.StartRoomStateId)
                retstring = StoryState.Room.RoomName + vbCrLf + StoryState.RoomState.LongDescription
            Else
                StoryState.RoomState = roomstateacc.GetRoomState(playerroomstaterecord.RoomStateId)
                retstring = StoryState.Room.RoomName + vbCrLf + StoryState.RoomState.Description
            End If
            If StoryState.RoomState.isEndGameTrigger Then
                Return EndGame()
            End If
            UpdateRoomVariables()
            'list available items for this roomstate
            For Each it As BE.Item In StoryState.availableitems
                If String.Equals(it.ParentStateId, StoryState.RoomState.RoomStateId) Then
                    retstring += vbCrLf + ("There is a " + it.ItemName + " here." + vbCrLf)
                End If
            Next
            StoryState.Player.CurrentRoomId = StoryState.Room.RoomId
            StoryState.Player.LastPlayed = Date.Now

            'save the player's current room and points values to db
            playeracc.Update(StoryState.Player)

            Return retstring
        End Function

        Public Function Go(ByVal words As StringCollection) As String
            'select 2nd word as first will be 'Go'
            Dim retstr = "You can't go that way."
            If words.Count = 1 Then
                Return "Go Where? North, East, South, or West?"
            End If
            Select Case words(1)
                Case "south"
                    If Not String.IsNullOrEmpty(StoryState.Room.SouthRoomId) Then
                        retstr = "You head south." + vbCrLf
                        retstr += EnterRoom(StoryState.Room.SouthRoomId)
                    End If
                Case "north"
                    If Not String.IsNullOrEmpty(StoryState.Room.NorthRoomId) Then
                        retstr = "You head north." + vbCrLf
                        retstr += EnterRoom(StoryState.Room.NorthRoomId)
                    End If
                Case "east"
                    If Not String.IsNullOrEmpty(StoryState.Room.EastRoomId) Then
                        retstr = "You head east." + vbCrLf
                        retstr += EnterRoom(StoryState.Room.EastRoomId)
                    End If
                Case "west"
                    If Not String.IsNullOrEmpty(StoryState.Room.WestRoomId) Then
                        retstr = "You head west." + vbCrLf
                        retstr += EnterRoom(StoryState.Room.WestRoomId)
                    End If

            End Select
            Return retstr
        End Function

        Public Function Look(ByVal words As StringCollection) As String
            Dim retstr = "What are you looking at?"
            'If it's look at, it could be roomstate
            If (words.Count = 1) Then
                retstr = StoryState.Room.RoomName + vbCrLf + StoryState.RoomState.LongDescription
            Else
                If (words(1) = "around") Then
                    retstr = StoryState.Room.RoomName + vbCrLf + StoryState.RoomState.LongDescription
                    For Each it As BE.Item In StoryState.availableitems
                        If String.Equals(it.ParentStateId, StoryState.RoomState.RoomStateId) Then
                            retstr += vbCrLf + ("There is a " + it.ItemName + " here." + vbCrLf)
                        End If
                    Next
                ElseIf (String.Equals(words(1), "at")) Or (String.Equals(words(1), "in")) Or (String.Equals(words(1), "inside")) And (words.Count > 2) Then

                    For Each ent As BE.Entity In StoryState.currententities
                        If ent.EntityName.ToLower = words(2) Then
                            'the entity is found so print the desc and find the entitystate
                            retstr = ent.Description
                            For Each entstat As BE.EntityState In StoryState.currententitystates
                                If String.Equals(entstat.EntityId, ent.EntityId) Then
                                    retstr += (vbCrLf + entstat.LongDescription)
                                    'Don't specify an available item here, the author should describe it in the description
                                End If

                            Next
                        End If
                    Next
                    Dim x As Integer = 2
                    Dim itemfound As Boolean = False
                    Dim possibleitemname As String = words(2)
                    While x <= words.Count - 1 And itemfound = False
                        For Each ite As BE.Item In StoryState.availableitems
                            If ite.ItemName.ToLower = possibleitemname Then
                                itemfound = True
                                retstr = ite.ItemName + vbCrLf + ite.LongDescription
                            End If
                        Next
                        x += 1
                        'while the word hasn't been found and not at end of array, add another word to search terms.                        
                        If x <= words.Count - 1 Then
                            possibleitemname += " " + words(x)
                        End If
                    End While


                End If
            End If

            Return retstr
        End Function

        Public Function Hint(ByVal words As StringCollection) As String
            'show the hint for any entitystate or item
            Dim retstr As String = "There is no hint for this item specified."
            If words.Count = 1 Then
                Return "Hint.. at what? specify an entity or item!"
            End If
            'search entities for hint text
            For Each ent As BE.Entity In StoryState.currententities
                If ent IsNot Nothing Then
                    If String.Equals(ent.EntityName.ToLower, words(1)) Then
                        For Each entstat As BE.EntityState In StoryState.currententitystates
                            If entstat IsNot Nothing Then
                                If String.Equals(entstat.EntityId, ent.EntityId) Then
                                    retstr = entstat.Hint
                                End If
                            End If
                        Next
                    End If
                End If
            Next

            Return retstr
        End Function

        Public Function AttemptVerbUse(ByVal words As StringCollection) As String
            'default the return string to an error message.
            Dim returnstring As String = "I don't understand that command."
            Dim currentent As BE.Entity
            Dim found As Boolean = False
            If words.Count > 1 Then
                If Not StoryState.currententitystates.Count = 0 Then
                    For Each entstat As BE.EntityState In StoryState.currententitystates
                        currentent = entityacc.GetEntity(entstat.EntityId)
                        If String.Equals(entstat.ActivationVerb.ToLower, words(0).ToString) Then
                            'check name is entity name as well
                            Dim x As Integer = words.Count - 1
                            Dim possibleentname As String = words(x)

                            While x > 0 And found = False
                                If String.Equals(possibleentname, currentent.EntityName.ToLower) Then
                                    found = True
                                    returnstring = entstat.ActivationText + vbCrLf
                                End If
                                x -= 1
                                possibleentname = words(x) + " " + possibleentname
                            End While
                            If found Then
                                If Not String.IsNullOrEmpty(entstat.NextEntityStateId) Then
                                    'don't need to return the new entity state desc
                                    UpdateToNextEntityState(entstat.EntityId)
                                End If
                                If entstat.VerbUpdatesRoomState = True Then
                                    Dim itemok As Boolean = False
                                    'check an item is not needed in order to update the roomstate
                                    If String.IsNullOrEmpty(entstat.ItemIdRequiredforRoomStateUpdate) Then
                                        itemok = True
                                    Else
                                        'an item may be required to update room state, if so check the user has it in their inventory
                                        For Each ite As BE.Item In StoryState.inventoryitems
                                            If String.Equals(ite.ItemId, entstat.ItemIdRequiredforRoomStateUpdate) Then
                                                itemok = True
                                            Else
                                                itemok = False

                                            End If
                                        Next
                                        If itemok = False Then
                                            returnstring = "You need a particular item to do that."
                                        End If
                                    End If
                                    'just in case the user has set verbupdates room state to true but not actually set a next entity state
                                    If (Not String.IsNullOrEmpty(entstat.NextEntityStateId)) And itemok Then
                                        returnstring += UpdateToNextRoomState()
                                    End If
                                End If
                            End If

                            If found Then
                                Return returnstring
                            End If

                        End If
                    Next

                End If
            End If


            Return returnstring
        End Function


        Public Property StoryState() As MTATools.StoryState
            Get
                Return _storystate
            End Get
            Set(ByVal value As MTATools.StoryState)
                _storystate = value
            End Set
        End Property

    End Class
End Namespace