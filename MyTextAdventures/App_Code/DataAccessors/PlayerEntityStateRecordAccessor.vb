Imports Microsoft.VisualBasic
Imports System.Attribute
Imports System.Data
Namespace DAL
    Public Class PlayerEntityStateRecordAccessor
        Inherits DataAccessor
        Private strSQL As String

        Public Sub Add(ByVal input As BE.PlayerEntityStateRecord)
            strSQL = "INSERT INTO @inputTypeName"
            strSQL += " VALUES ('@PlayerEntityStateRecordId" & _
                "', '@PlayerId" & _
                "', '@EntityStateId" & _
                "', '@EntityId" & _
                "')"

            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@inputTypeName", inputType.Name))
            command.Parameters.Add(New MySqlParameter("@PlayerEntityStateRecordId", input.PlayerEntityStateRecordId))
            command.Parameters.Add(New MySqlParameter("@PlayerId", input.PlayerId))
            command.Parameters.Add(New MySqlParameter("@EntityStateId", input.EntityStateId))
            command.Parameters.Add(New MySqlParameter("@EntityId", input.EntityId))

            MyBase.ExecuteCommand(command)
        End Sub

        Public Function GetPlayerEntityStateRecord(ByVal PlayerEntityStateRecordId As String) As BE.PlayerEntityStateRecord
            Dim PRSDS As New DataSet
            Dim output As New BE.PlayerEntityStateRecord
            PRSDS = MyBase.GetObjectDataSet(GetType(BE.PlayerEntityStateRecord), "PlayerEntityStateRecordId", PlayerEntityStateRecordId)
            If Not PRSDS.Tables.Count = 0 Then
                Dim row As DataRow = PRSDS.Tables(0).Rows(0)
                With output
                    .PlayerEntityStateRecordId = row.Item("PlayerEntityStateRecordId").ToString
                    .PlayerId = row.Item("PlayerId").ToString
                    .EntityStateId = row.Item("EntityStateId").ToString
                    .EntityId = row.Item("EntityId").ToString
                End With
                Return output
            Else
                Return Nothing
            End If
        End Function

        Public Function GetPlayerEntityStateRecordByEntityIdPlayerId(ByVal inputEntityId As String, ByVal PlayerId As String) As BE.PlayerEntityStateRecord
            Dim PRSDS As New DataSet
            Dim output As New BE.PlayerEntityStateRecord
            strSQL = "SELECT PRS.* " & _
            "FROM PlayerEntityStateRecord AS PRS " & _
            "INNER JOIN Player AS P ON P.PlayerId = PRS.PlayerId " & _
            "WHERE PRS.EntityId = @inputEntityId " & _
            "AND P.PlayerId = @PlayerId"
            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@inputEntityId", input.inputEntityId))
            command.Parameters.Add(New MySqlParameter("@PlayerId", input.PlayerId))
            PRSDS = MyBase.GetObjectDataSet(command)

            If Not PRSDS.Tables(0).Rows.Count = 0 Then
                Dim row As DataRow = PRSDS.Tables(0).Rows(0)
                With output
                    .PlayerEntityStateRecordId = row.Item("PlayerEntityStateRecordId").ToString
                    .PlayerId = row.Item("PlayerId").ToString
                    .EntityStateId = row.Item("EntityStateId").ToString
                    .EntityId = row.Item("EntityId").ToString
                End With

                Return output
            End If
            Return Nothing
        End Function

        Public Sub Update(ByVal input As BE.PlayerEntityStateRecord)
            strSQL = "UPDATE @inputTypeName "
            strSQL += "SET " & _
            "PlayerEntityStateRecordId='@PlayerEntityStateRecordId" & _
            "', PlayerId='@PlayerId" & _
            "', EntityStateId='@EntityStateId" & _
            "', EntityId='@EntityId" & _
            "' WHERE PlayerEntityStateRecordId='@PlayerEntityStateRecordId'"
            
            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@inputTypeName", inputType.Name))
            command.Parameters.Add(New MySqlParameter("@PlayerEntityStateRecordId", input.PlayerEntityStateRecordId))
            command.Parameters.Add(New MySqlParameter("@PlayerId", input.PlayerId))
            command.Parameters.Add(New MySqlParameter("@EntityStateId", input.EntityStateId))
            command.Parameters.Add(New MySqlParameter("@EntityId", input.EntityId))

            MyBase.ExecuteCommand(command)
        End Sub
    End Class
End Namespace
