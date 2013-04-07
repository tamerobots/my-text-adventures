Imports Microsoft.VisualBasic
Imports System.Attribute
Imports System.Data
Namespace DAL
    Public Class PlayerRoomStateRecordAccessor
        Inherits DataAccessor
        Private strSQL As String

        Public Sub Add(ByVal input As BE.PlayerRoomStateRecord)
            strSQL = "INSERT INTO " + input.GetType.Name.ToString
            strSQL += " VALUES ('" + input.PlayerRoomStateRecordId & _
              "', '" + input.PlayerId & _
              "', '" + input.RoomStateId & _
              "', '" + input.RoomId & _
              "')"
            MyBase.ExecuteCommand(strSQL)
        End Sub

        Public Function GetPlayerRoomStateRecord(ByVal PlayerRoomStateRecordId As String) As BE.PlayerRoomStateRecord
            Dim PRSDS As New DataSet
            Dim output As New BE.PlayerRoomStateRecord
            PRSDS = MyBase.GetObjectDataSet(GetType(BE.PlayerRoomStateRecord), "PlayerRoomStateRecordId", PlayerRoomStateRecordId)
            If Not PRSDS.Tables.Count = 0 Then
                Dim row As DataRow = PRSDS.Tables(0).Rows(0)
                With output
                    .PlayerRoomStateRecordId = row.Item("PlayerRoomStateRecordId").ToString
                    .PlayerId = row.Item("PlayerId").ToString
                    .RoomStateId = row.Item("RoomStateId").ToString
                    .RoomId = row.Item("RoomId").ToString
                End With
                Return output
            Else
                Return Nothing
            End If
        End Function

        Public Function GetPlayerRoomStateRecordByRoomIdAndPlayerId(ByVal inputRoomId As String, ByVal playerid As String) As BE.PlayerRoomStateRecord
            'must specify both roomid and playerid to get room state record unique to player 
            Dim PRSDS As New DataSet
            Dim output As New BE.PlayerRoomStateRecord
            strSQL = "SELECT PRS.* " & _
            "FROM PlayerRoomStateRecord AS PRS " & _
            "INNER JOIN Player AS P ON " & _
            "P.PlayerId = PRS.PlayerId " & _
            "WHERE PRS.RoomId = '" + inputRoomId + "'" & _
            "AND P.PlayerId = '" + playerid + "'"
            PRSDS = MyBase.GetObjectDataSet(strSQL)
            If Not PRSDS.Tables(0).Rows.Count = 0 Then
                Dim row As DataRow = PRSDS.Tables(0).Rows(0)
                With output
                    .PlayerRoomStateRecordId = row.Item("PlayerRoomStateRecordId").ToString
                    .PlayerId = row.Item("PlayerId").ToString
                    .RoomStateId = row.Item("RoomStateId").ToString
                    .RoomId = row.Item("RoomId").ToString
                End With

                Return output
            End If
            Return Nothing
        End Function

        Public Sub Update(ByVal input As BE.PlayerRoomStateRecord)
            strSQL = "UPDATE " + input.GetType.Name.ToString + " "
            strSQL += "SET " & _
            "PlayerRoomStateRecordId='" + input.PlayerRoomStateRecordId & _
            "', PlayerId='" + input.PlayerId & _
            "', RoomStateId='" + input.RoomStateId & _
            "', RoomId='" + input.RoomId & _
            "' WHERE PlayerRoomStateRecordId='" + input.PlayerRoomStateRecordId + "'"
            MyBase.ExecuteCommand(strSQL)
        End Sub
    End Class
End Namespace