Imports Microsoft.VisualBasic
Imports System.Attribute
Imports System.Data
Namespace DAL
    Public Class PlayerEntityStateRecordAccessor
        Inherits DataAccessor
        Private strSQL As String

        Public Sub Add(ByVal input As BE.PlayerEntityStateRecord)
            strSQL = "INSERT INTO " + input.GetType.Name.ToString
            strSQL += " VALUES ('" + input.PlayerEntityStateRecordId & _
                "', '" + input.PlayerId & _
                "', '" + input.EntityStateId & _
                "', '" + input.EntityId & _
                "')"
            MyBase.ExecuteCommand(strSQL)
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
            "WHERE PRS.EntityId = '" + inputEntityId + "'" & _
            "AND P.PlayerId = '" + PlayerId + "'"
            PRSDS = MyBase.GetObjectDataSet(strSQL)
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
            strSQL = "UPDATE " + input.GetType.Name.ToString + " "
            strSQL += "SET " & _
            "PlayerEntityStateRecordId='" + input.PlayerEntityStateRecordId & _
            "', PlayerId='" + input.PlayerId & _
            "', EntityStateId='" + input.EntityStateId & _
            "', EntityId='" + input.EntityId & _
            "' WHERE PlayerEntityStateRecordId='" + input.PlayerEntityStateRecordId + "'"
            MyBase.ExecuteCommand(strSQL)
        End Sub
    End Class
End Namespace