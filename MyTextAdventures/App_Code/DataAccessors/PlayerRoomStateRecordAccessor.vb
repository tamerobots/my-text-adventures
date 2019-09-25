Imports Microsoft.VisualBasic
Imports System.Attribute
Imports System.Data
Namespace DAL
    Public Class PlayerRoomStateRecordAccessor
        Inherits DataAccessor
        Private strSQL As String

        Public Sub Add(ByVal input As BE.PlayerRoomStateRecord)
            strSQL = "INSERT INTO " + @inputName
            strSQL += " VALUES ('@PlayerRoomStateRecordId" & _
              "', '@PlayerId" & _
              "', '@RoomStateId" & _
              "', '@RoomId" & _
              "')"
            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@inputTypeName", input.GetType.Name.ToString))
            command.Parameters.Add(New MySqlParameter("@PlayerRoomStateRecordId", input.PlayerRoomStateRecordId))
            command.Parameters.Add(New MySqlParameter("@PlayerRoomStateRecordId", input.PlayerRoomStateRecordId))
            command.Parameters.Add(New MySqlParameter("@PlayerId", input.PlayerId))
            command.Parameters.Add(New MySqlParameter("@RoomStateId", input.RoomStateId))
            command.Parameters.Add(New MySqlParameter("@RoomId", input.RoomId))
            MyBase.ExecuteCommand(command)
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
            "WHERE PRS.RoomId = '@inputRoomId' " & _
            "AND P.PlayerId = '@playerid'"

            Dim myConnection = New MySqlConnection(ConfigurationManager.ConnectionStrings("MTAConnectionString").ConnectionString)
            command.Connection = myConnection
            command.CommandType = CommandType.Text
            command.Parameters.Add(New MySqlParameter("@playerID", playerid))
            command.Parameters.Add(New MySqlParameter("@inputRoomId", inputRoomId))
            PRSDS = MyBase.GetObjectDataSet(command)

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
            "PlayerRoomStateRecordId='@PlayerRoomStateRecordId" & _
            "', PlayerId='@PlayerId" & _
            "', RoomStateId='@RoomStateId" & _
            "', RoomId='@RoomId" & _
            "' WHERE PlayerRoomStateRecordId='@PlayerRoomStateRecordId'"

            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@PlayerRoomStateRecordId", input.PlayerRoomStateRecordId))
            command.Parameters.Add(New MySqlParameter("@PlayerId", input.PlayerId ))
            command.Parameters.Add(New MySqlParameter("@RoomStateId", input.RoomStateId ))
            command.Parameters.Add(New MySqlParameter("@RoomId", input.RoomId ))

            MyBase.ExecuteCommand(command)
        End Sub
    End Class
End Namespace
