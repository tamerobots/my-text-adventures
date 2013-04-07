Imports Microsoft.VisualBasic
Imports System.Data
Namespace DAL
    Public Class RoomAccessor
        Inherits DataAccessor

        Private strSQL As String
        Public Sub Add(ByVal input As BE.Room)
            strSQL = "INSERT INTO " + input.GetType.Name.ToString
            strSQL += " VALUES ('" + input.RoomId & _
              "', '" + input.StoryId & _
              "', '" + input.RoomName & _
              "', '" + input.StartRoomStateId & _
              "', '" + input.NorthRoomId & _
              "', '" + input.EastRoomId & _
              "', '" + input.SouthRoomId & _
              "', '" + input.WestRoomId & _
              "')"
            MyBase.ExecuteCommand(strSQL)
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
            Dim STRSQL As String = "SELECT R.* " & _
            "FROM Room AS R " & _
            "WHERE R.StoryId = '" + StoryId + "'"
            Return MyBase.GetObjectDataSet(STRSQL)            
        End Function

        Public Sub Update(ByVal input As BE.Room)
            strSQL = "UPDATE " + input.GetType.Name.ToString + " "
            strSQL += "SET " & _
            "RoomId='" + input.RoomId & _
            "', StoryId='" + input.StoryId & _
            "', RoomName='" + input.RoomName & _
            "', StartRoomStateId='" + input.StartRoomStateId & _
            "', NorthRoomId='" + input.NorthRoomId & _
            "', EastRoomId='" + input.EastRoomId & _
            "', SouthRoomId='" + input.SouthRoomId & _
            "', WestRoomId='" + input.WestRoomId & _
            "' WHERE RoomId='" + input.RoomId + "'"
            MyBase.ExecuteCommand(strSQL)
        End Sub

    

        Public Overloads Sub Delete(ByVal roomid As String)
            MyBase.Delete(GetType(BE.Room), "RoomId", roomid)
        End Sub
    End Class
End Namespace