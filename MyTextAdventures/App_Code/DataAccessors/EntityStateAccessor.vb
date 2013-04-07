Imports Microsoft.VisualBasic
Imports System.Attribute
Imports System.Data

Namespace DAL
    Public Class EntityStateAccessor
        Inherits DataAccessor

        Private strSQL As String
        Public Sub Add(ByVal input As BE.EntityState)
            strSQL = "INSERT INTO " + input.GetType.Name.ToString & _
             " VALUES ('" + input.EntityStateId & _
             "', '" + input.EntityStateName & _
             "', '" + input.EntityId & _
             "', '" + input.Description & _
             "', '" + input.LongDescription & _
             "', " + input.Visible.ToString & _
             ", '" + input.ActivationVerb & _
             "', '" + input.ActivationText & _
             "', " + input.PointsAwarded.ToString & _
             ", " + input.VerbUpdatesRoomState.ToString & _
             ", '" + input.Hint & _
             "', '" + input.NextEntityStateId & _
             "', '" + input.ItemIdRequiredforRoomStateUpdate & _
             "')"
            MyBase.ExecuteCommand(strSQL)
        End Sub

        Public Function GetEntityState(ByVal EntityStateId As String) As BE.EntityState
            Dim EntityStateDataSet = New DataSet
            Dim outputEntityState As New BE.EntityState
            EntityStateDataSet = MyBase.GetObjectDataSet(GetType(BE.EntityState), "EntityStateId", EntityStateId)
            If EntityStateDataSet.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                With EntityStateDataSet.Tables(0).Rows(0)
                    outputEntityState.EntityStateId = .Item("EntityStateId").ToString
                    outputEntityState.EntityStateName = .Item("EntityStateName").ToString
                    outputEntityState.EntityId = .Item("EntityId").ToString
                    outputEntityState.Description = .Item("Description").ToString
                    outputEntityState.LongDescription = .Item("LongDescription").ToString
                    outputEntityState.Visible = .Item("Visible").ToString
                    outputEntityState.ActivationVerb = .Item("ActivationVerb").ToString
                    outputEntityState.ActivationText = .Item("ActivationText").ToString
                    outputEntityState.PointsAwarded = .Item("PointsAwarded").ToString
                    outputEntityState.VerbUpdatesRoomState = .Item("VerbUpdatesRoomState").ToString
                    outputEntityState.Hint = .Item("Hint").ToString
                    outputEntityState.NextEntityStateId = .Item("NextEntityStateId").ToString
                    outputEntityState.ItemIdRequiredforRoomStateUpdate = .Item("ItemIdRequiredforRoomStateUpdate").ToString

                End With
                Return outputEntityState
            End If
        End Function

        Public Function CheckNotReferenced(ByVal entitystateid As String, ByVal storyid As String) As Boolean
            'This is a function that checks whether it is appropriate to delete a certain entitystate
            'depending on whether it is referenced.
            Dim entityacc As New DAL.EntityAccessor
            Dim entity As BE.Entity = entityacc.GetEntity(GetEntityState(entitystateid).EntityId)
            Dim itemacc As New DAL.ItemAccessor
            Dim EntityDataSet As New DataSet
            Dim ItemDataSet As New DataSet
            ItemDataSet = itemacc.getItemsbyStoryId(storyid)
            If Not String.IsNullOrEmpty(entity.RoomId) Then
                EntityDataSet = entityacc.getEntitiesByRoomId(entity.RoomId)
            ElseIf Not String.IsNullOrEmpty(entity.RoomStateId) Then
                EntityDataSet = entityacc.getEntitiesByRoomStateId(entity.RoomStateId)
            End If
            If EntityDataSet.Tables(0).Rows.Count > 0 Then
                For Each entrow As DataRow In EntityDataSet.Tables(0).Rows
                    If String.Equals(entrow.Item("StartEntityStateId").ToString, entitystateid) Then
                        Return False
                    End If
                    'check items do not have this entitystate as parent
                    If ItemDataSet.Tables(0).Rows.Count > 0 Then
                        For Each iterow As DataRow In ItemDataSet.Tables(0).Rows
                            If String.Equals(iterow.Item("ParentStateId").ToString, entrow.Item("EntityId").ToString) Then
                                Return False
                            End If
                        Next
                    End If
                Next
            End If

            Return True
        End Function

        Public Sub Update(ByVal input As BE.EntityState)
            strSQL = "UPDATE " + input.GetType.Name.ToString + " " & _
            "SET EntityStateid='" + input.EntityStateId & _
            "', EntityStateName='" + input.EntityStateName & _
            "', EntityId='" + input.EntityId & _
            "', Description='" + input.Description & _
            "', longDescription='" + input.LongDescription & _
            "', Visible=" + input.Visible.ToString & _
            ", ActivationVerb='" + input.ActivationVerb & _
            "', ActivationText='" + input.ActivationText & _
            "', PointsAwarded=" + input.PointsAwarded.ToString & _
            ", VerbUpdatesRoomState=" + input.VerbUpdatesRoomState.ToString & _
            ", Hint='" + input.Hint & _
            "', NextEntityStateId='" + input.NextEntityStateId & _
            "', ItemIdRequiredforRoomStateUpdate='" + input.ItemIdRequiredforRoomStateUpdate & _
            "' WHERE EntityStateid='" + input.EntityStateId + "'"
            MyBase.ExecuteCommand(strSQL)
        End Sub

        Public Function getEntityStatesbyEntityId(ByVal EntityId As String) As DataSet
            Dim STRSQL As String = "SELECT ES.* " & _
            "FROM EntityState AS ES " & _
            "WHERE ES.EntityId = '" + EntityId + "'"
            Return MyBase.GetObjectDataSet(STRSQL)
        End Function

        Public Overloads Sub Delete(ByVal EntityStateid As String)
            MyBase.Delete(GetType(BE.EntityState), "EntityStateId", EntityStateid)
        End Sub

    End Class
End Namespace
