Imports Microsoft.VisualBasic
Imports System.Attribute
Imports System.Data

Namespace DAL
    Public Class EntityStateAccessor
        Inherits DataAccessor

        Private strSQL As String
        Public Sub Add(ByVal input As BE.EntityState)
            strSQL = "INSERT INTO @inputTypeName" & _
             " VALUES ('@EntityStateId & _
             "', '@EntityStateName" & _
             "', '@EntityId" & _
             "', '@Description" & _
             "', '@LongDescription" & _
             "', @Visible" & _
             ", '@ActivationVerb" & _
             "', '@ActivationText" & _
             "', @PointsAwarded" & _
             ", @VerbUpdatesRoomState" & _
             ", '@Hint" & _
             "', '@NextEntityStateId" & _
             "', '@ItemIdRequiredforRoomStateUpdate" & _
             "')"
              Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@inputTypeName", inputType.Name))
            command.Parameters.Add(New MYSqlParameter("@EntityStateId", input.EntityStateId)
            command.Parameters.Add(New MYSqlParameter("@EntityStateName", input.EntityStateName)
            command.Parameters.Add(New MYSqlParameter("@EntityId", input.EntityId)
            command.Parameters.Add(New MYSqlParameter("@Description", input.Description)
            command.Parameters.Add(New MYSqlParameter("@LongDescription", input.LongDescription)
            command.Parameters.Add(New MYSqlParameter("@Visib", input.Visible)
            command.Parameters.Add(New MYSqlParameter("@ActivationVerb", input.ActivationVerb)
            command.Parameters.Add(New MYSqlParameter("@ActivationText", input.ActivationText)
            command.Parameters.Add(New MYSqlParameter("@PointsAward", input.PointsAwarded)
            command.Parameters.Add(New MYSqlParameter("@VerbUpdatesRoomSta", input.VerbUpdatesRoomState)
            command.Parameters.Add(New MYSqlParameter("@Hint", input.Hint)
            command.Parameters.Add(New MYSqlParameter("@NextEntityStateId", input.NextEntityStateId)
            command.Parameters.Add(New MYSqlParameter("@ItemIdRequiredforRoomStateUpdate", input.ItemIdRequiredforRoomStateUpdate)
            MyBase.ExecuteCommand(command)
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
            strSQL = "UPDATE @Name " & _
            "SET EntityStateid='@EntityStateId & _
            "', EntityStateName='@EntityStateName & _
            "', EntityId='@EntityId & _
            "', Description='@Description & _
            "', longDescription='@LongDescription & _
            "', Visible=@Visible.ToString & _
            ", ActivationVerb='@ActivationVerb & _
            "', ActivationText='@ActivationText & _
            "', PointsAwarded=@PointsAwarded.ToString & _
            ", VerbUpdatesRoomState=@VerbUpdatesRoomState.ToString & _
            ", Hint='@Hint & _
            "', NextEntityStateId='@NextEntityStateId & _
            "', ItemIdRequiredforRoomStateUpdate='@ItemIdRequiredforRoomStateUpdate & _
            "' WHERE EntityStateid='@EntityStateId'"

            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@Name", input.Name))
            command.Parameters.Add(New MySqlParameter("@EntityStateid", input.EntityStateId))
            command.Parameters.Add(New MySqlParameter("@EntityStateName", input.EntityStateName ))
            command.Parameters.Add(New MySqlParameter("@EntityId", input.EntityId ))
            command.Parameters.Add(New MySqlParameter("@Description", input.Description ))
            command.Parameters.Add(New MySqlParameter("@longDescription", input.LongDescription ))
            command.Parameters.Add(New MySqlParameter("@Visible", input.Visible.ToString ))
            command.Parameters.Add(New MySqlParameter("@ActivationVerb", input.ActivationVerb ))
            command.Parameters.Add(New MySqlParameter("@ActivationText", input.ActivationText ))
            command.Parameters.Add(New MySqlParameter("@PointsAwarded", input.PointsAwarded.ToString ))
            command.Parameters.Add(New MySqlParameter("@VerbUpdatesRoomState", input.VerbUpdatesRoomState.ToString ))
            command.Parameters.Add(New MySqlParameter("@Hint", input.Hint ))
            command.Parameters.Add(New MySqlParameter("@NextEntityStateId", input.NextEntityStateId ))
            command.Parameters.Add(New MySqlParameter("@ItemIdRequiredforRoomStateUpdate", input.ItemIdRequiredforRoomStateUpdate ))
            MyBase.ExecuteCommand(command)
        End Sub

        Public Function getEntityStatesbyEntityId(ByVal EntityId As String) As DataSet
            Dim STRSQL As String = "SELECT ES.* " & _
            "FROM EntityState AS ES " & _
            "WHERE ES.EntityId = '@EntityId'"
            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@EntityId", EntityId))
            Return MyBase.GetObjectDataSet(command)
        End Function

        Public Overloads Sub Delete(ByVal EntityStateid As String)
            MyBase.Delete(GetType(BE.EntityState), "EntityStateId", EntityStateid)
        End Sub

    End Class
End Namespace
