Imports Microsoft.VisualBasic
Imports System.Data
Namespace DAL

    Public Class RoomStateAccessor
        Inherits DataAccessor

        Private strSQL As String
        Public Sub Add(ByVal input As BE.RoomState)
            strSQL = "INSERT INTO " + input.GetType.Name.ToString
            strSQL += " VALUES ('" + input.RoomStateId & _
             "', '" + input.RoomStateName & _
             "', '" + input.ParentRoomId & _
             "', " + input.canGoNorth.ToString & _
             "," + input.canGoEast.ToString & _
             "," + input.canGoSouth.ToString & _
             "," + input.canGoWest.ToString & _
             ", " + input.PointsAwarded.ToString & _
             ", '" + input.Description & _
             "', '" + input.LongDescription & _
             "', " + input.isEndGameTrigger.ToString & _
             ", '" + input.nextRoomStateId & _
             "')"
            MyBase.ExecuteCommand(strSQL)
        End Sub

        Public Function GetRoomState(ByVal RoomStateId As String) As BE.RoomState
            Dim DataSet = New DataSet
            Dim output As New BE.RoomState
            DataSet = MyBase.GetObjectDataSet(GetType(BE.RoomState), "RoomStateId", RoomStateId)
            If DataSet.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                With DataSet.Tables(0).Rows(0)
                    output.RoomStateId = .Item("RoomStateId").ToString
                    output.RoomStateName = .Item("RoomStateName").ToString
                    output.ParentRoomId = .Item("ParentRoomId").ToString
                    output.canGoNorth = .Item("canGoNorth").ToString
                    output.canGoEast = .Item("canGoEast").ToString
                    output.canGoSouth = .Item("canGoSouth").ToString
                    output.canGoWest = .Item("canGoWest").ToString
                    output.PointsAwarded = .Item("PointsAwarded").ToString
                    output.Description = .Item("Description").ToString
                    output.LongDescription = .Item("LongDescription").ToString
                    output.isEndGameTrigger = .Item("isEndGameTrigger").ToString

                    output.nextRoomStateId = .Item("nextRoomstateid").ToString
                End With
                Return output
            End If
        End Function

        Public Function getRoomStatesbyRoomId(ByVal RoomId As String) As DataSet
            Dim STRSQL As String = "SELECT R.* " & _
            "FROM RoomState AS R " & _
            "WHERE R.ParentRoomId = '" + RoomId + "'"
            Return MyBase.GetObjectDataSet(STRSQL)
            ' Dim mysql As New MySql.Data.MySqlClient.MySqlCommand
        End Function

        Public Sub Update(ByVal input As BE.RoomState)
            strSQL = "UPDATE " + input.GetType.Name.ToString + " "
            strSQL += "SET " & _
            "RoomStateId='" + input.RoomStateId & _
            "', RoomStateName='" + input.RoomStateName & _
            "', ParentRoomId='" + input.ParentRoomId & _
            "', canGoNorth=" + input.canGoNorth.ToString & _
            ", canGoEast=" + input.canGoEast.ToString & _
            ", canGoSouth=" + input.canGoSouth.ToString & _
            ", canGoWest=" + input.canGoWest.ToString & _
            ", PointsAwarded=" + input.PointsAwarded.ToString & _
            ", Description='" + input.Description & _
            "', LongDescription='" + input.LongDescription & _
            "', isEndGameTrigger=" + input.isEndGameTrigger.ToString & _
            ", nextroomstateid='" + input.nextRoomStateId & _
            "' WHERE RoomStateId='" + input.RoomStateId + "'"

            MyBase.ExecuteCommand(strSQL)
        End Sub



        Public Overloads Sub Delete(ByVal roomstateid As String)
            MyBase.Delete(GetType(BE.RoomState), "RoomStateId", roomstateid)
        End Sub
    End Class
End Namespace

