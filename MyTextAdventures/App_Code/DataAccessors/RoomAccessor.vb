Imports Microsoft.VisualBasic
Imports System.Data
Namespace DAL
    Public Class RoomAccessor
        Inherits DataAccessor

        Private strSQL As String
        Public Sub Add(ByVal input As BE.Room)
            strSQL = "INSERT INTO @inputTypeName" & _
            strSQL += " VALUES ('@RoomId" & _
              "', '@StoryId" & _
              "', '@RoomName" & _
              "', '@StartRoomStateId" & _
              "', '@NorthRoomId" & _
              "', '@EastRoomId" & _
              "', '@SouthRoomId" & _
              "', '@WestRoomId" & _
              "')"

                Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@inputTypeName", inputType.Name))
            command.Parameters.Add(New MySqlParameter("@RoomId", input.RoomId))
            command.Parameters.Add(New MySqlParameter("@StoryId", input.StoryId))
            command.Parameters.Add(New MySqlParameter("@RoomName", input.RoomName))
            command.Parameters.Add(New MySqlParameter("@StartRoomStateId", input.StartRoomStateId))
            command.Parameters.Add(New MySqlParameter("@NorthRoomId", input.NorthRoomId))
            command.Parameters.Add(New MySqlParameter("@EastRoomId", input.EastRoomId))
            command.Parameters.Add(New MySqlParameter("@SouthRoomId", input.SouthRoomId))
            command.Parameters.Add(New MySqlParameter("@WestRoomId", input.WestRoomId))

            MyBase.ExecuteCommand(command)
        End Sub

        Public Function GetRoom(ByVal RoomId As String) As BE.Room
            Dim DataSet = New DataSet
            Dim output As New BE.Room
            DataSet = MyBase.GetObjectDataSet(GetType(BE.Room), "RoomId", RoomId)
            If DataSet.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                With DataSet.Tables(0).Rows(0)
                    output.RoomId = .Item("RoomId").ToString
                    output.StoryId = .Item("StoryId").ToString
                    output.StartRoomStateId = .Item("StartRoomStateId").ToString
                    output.RoomName = .Item("RoomName").ToString
                    output.NorthRoomId = .Item("NorthRoomId").ToString
                    output.EastRoomId = .Item("EastRoomId").ToString
                    output.SouthRoomId = .Item("SouthRoomId").ToString
                    output.WestRoomId = .Item("WestRoomId").ToString
                End With
                Return output
            End If
        End Function

        Public Function getRoomsbyStoryId(ByVal StoryId As String) As DataSet
            Dim strSQL As String = "SELECT R.* " & _
            "FROM Room AS R " & _
            "WHERE R.StoryId = '@StoryId'"
            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@StoryId", StoryId))
            Return MyBase.GetObjectDataSet(command)
        End Function

        Public Sub Update(ByVal input As BE.Room)
            strSQL = "UPDATE @inputTypeName "
            strSQL += "SET " & _
            "RoomId='@RoomId" & _
            "', StoryId='@StoryId" & _
            "', RoomName='@RoomName" & _
            "', StartRoomStateId='@StartRoomStateId" & _
            "', NorthRoomId='@NorthRoomId" & _
            "', EastRoomId='@EastRoomId" & _
            "', SouthRoomId='@SouthRoomId" & _
            "', WestRoomId='@WestRoomId" & _
            "' WHERE RoomId='@RoomId'"

            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@inputTypeName", input.GetType.Name.ToString))
            command.Parameters.Add(New MySqlParameter("@RoomId", input.RoomId))
            command.Parameters.Add(New MySqlParameter("@StoryId", input.StoryId))
            command.Parameters.Add(New MySqlParameter("@RoomName", input.RoomName))
            command.Parameters.Add(New MySqlParameter("@StartRoomStateId", input.StartRoomStateId))
            command.Parameters.Add(New MySqlParameter("@NorthRoomId", input.NorthRoomId))
            command.Parameters.Add(New MySqlParameter("@EastRoomId", input.EastRoomId))
            command.Parameters.Add(New MySqlParameter("@SouthRoomId", input.SouthRoomId))
            command.Parameters.Add(New MySqlParameter("@WestRoomId", input.WestRoomId))
            command.Parameters.Add(New MySqlParameter("@RoomId", input.RoomId))

            MyBase.ExecuteCommand(command)
        End Sub



        Public Overloads Sub Delete(ByVal roomid As String)
            MyBase.Delete(GetType(BE.Room), "RoomId", roomid)
        End Sub
    End Class
End Namespace
