Imports Microsoft.VisualBasic
Imports System.Attribute
Imports System.Data

Namespace DAL
    Public Class EntityAccessor
        Inherits DataAccessor


        Private strSQL As String

        Public Sub Add(ByVal input As BE.Entity)
            strSQL = "INSERT INTO @inputGetType.Name.ToString
            strSQL += " VALUES ('@EntityId'
            strSQL += "', '@EntityName"
            strSQL += "', '@Description"
            strSQL += "', '@RoomId"
            strSQL += "', '@RoomStateId"
            strSQL += "', '@Visible"
            strSQL += "', '@StartEntityStateId'
            strSQL += "')"
            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@EntityId", input.EntityId))
            command.Parameters.Add(New MySqlParameter("@EntityName", input.EntityName))
            command.Parameters.Add(New MySqlParameter("@Description", input.Description))
            command.Parameters.Add(New MySqlParameter("@RoomId", input.RoomId))
            command.Parameters.Add(New MySqlParameter("@RoomStateId", input.RoomStateId))
            command.Parameters.Add(New MySqlParameter("@Visible", input.Visible.ToString))
            command.Parameters.Add(New MySqlParameter("@StartEntityStateId", input.StartEntityStateId))
            command.Parameters.Add(New MySqlParameter("@EntityName", input.EntityName))
            MyBase.ExecuteCommand(command)
        End Sub

        Public Function GetEntity(ByVal EntityId As String) As BE.Entity
            Dim DataSet = New DataSet
            Dim outputEntity As New BE.Entity
            DataSet = MyBase.GetObjectDataSet(GetType(BE.Entity), "EntityId", EntityId)
            If DataSet.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                With DataSet.Tables(0).Rows(0)
                    outputEntity.EntityId = .Item("EntityId").ToString
                    outputEntity.EntityName = .Item("EntityName").ToString
                    outputEntity.Description = .Item("Description").ToString
                    outputEntity.RoomId = .Item("RoomId").ToString
                    outputEntity.RoomStateId = .Item("RoomStateId").ToString
                    outputEntity.Visible = .Item("Visible").ToString
                    outputEntity.StartEntityStateId = .Item("StartEntityStateId").ToString

                End With
                Return outputEntity
            End If
        End Function
        Public Function getEntitiesByRoomStateId(ByVal RoomStateId As String) As DataSet
            Dim strSQL As String = "SELECT E.* " & _
            "FROM Entity AS E " & _
            "WHERE E.RoomStateId = @RoomStateId"
            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@RoomStateId", input.RoomStateId))
            Return MyBase.GetObjectDataSet(command)
        End Function

        Public Function getEntitiesByRoomId(ByVal RoomId As String) As DataSet
            Dim strSQL As String = "SELECT E.* " & _
            "FROM Entity AS E " & _
            "WHERE E.RoomId = @RoomId"
            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@RoomId", input.RoomId))
            Return MyBase.GetObjectDataSet(command)
        End Function


        Public Sub Update(ByVal input As BE.Entity)
            strSQL = "UPDATE @inputName "
            strSQL += "SET Entityid='@EntityId
            strSQL += "', EntityName='@EntityName
            strSQL += "', RoomId='@RoomId
            strSQL += "', RoomStateId='@RoomStateId
            strSQL += "', Visible=@Visible
            strSQL += ", StartEntityStateId='@StartEntityStateId
            strSQL += "' WHERE Entityid='@EntityId + "'"

            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@inputName", input.Name.ToString))
            command.Parameters.Add(New MySqlParameter("@EntityId", input.EntityId))
            command.Parameters.Add(New MySqlParameter("@EntityName", input.EntityId))
            command.Parameters.Add(New MySqlParameter("@RoomId", input.RoomId))
            command.Parameters.Add(New MySqlParameter("@RoomStateId", input.RoomStateId))
            command.Parameters.Add(New MySqlParameter("@Visible", input.Visible))
            command.Parameters.Add(New MySqlParameter("@StartEntityStateId", input.StartEntityStateId))
            command.Parameters.Add(New MySqlParameter("@EntityId", input.EntityId))                        
            MyBase.ExecuteCommand(command)
        End Sub

        Public Overloads Sub Delete(ByVal Entityid As String)
            MyBase.Delete(GetType(BE.Entity), "EntityId", Entityid)
        End Sub

    End Class
End Namespace
