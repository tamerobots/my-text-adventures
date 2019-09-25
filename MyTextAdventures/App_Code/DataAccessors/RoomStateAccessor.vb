Imports Microsoft.VisualBasic
Imports System.Data
Namespace DAL

    Public Class RoomStateAccessor
        Inherits DataAccessor

        Private strSQL As String
        Public Sub Add(ByVal input As BE.RoomState)
            strSQL = "INSERT INTO @inputTypeName"
            strSQL += " VALUES ('@RoomStateId" & _
             "', '@RoomStateName" & _
             "', '@ParentRoomId" & _
             "', @canGoNorth" & _
             ",@canGoEast" & _
             ",@canGoSouth" & _
             ",@canGoWest" & _
             ", @PointsAwarded" & _
             ", '@Description" & _
             "', '@LongDescription" & _
             "', @isEndGameTrigger" & _
             ", '@nextRoomStateId" & _
             "')"

            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@inputTypeName", input.GetType.Name.ToString))
            command.Parameters.Add(New MySqlParameter("@RoomStateId", input.RoomStateId))
            command.Parameters.Add(New MySqlParameter("@RoomStateName", input.RoomStateName))
            command.Parameters.Add(New MySqlParameter("@ParentRoomId", input.ParentRoomId))
            command.Parameters.Add(New MySqlParameter("@canGoNorth", input.canGoNorth))
            command.Parameters.Add(New MySqlParameter("@canGoEast", input.canGoEast))
            command.Parameters.Add(New MySqlParameter("@canGoSouth", input.canGoSouth))
            command.Parameters.Add(New MySqlParameter("@canGoWest", input.canGoWest))
            command.Parameters.Add(New MySqlParameter("@PointsAwarded", input.PointsAwarded))
            command.Parameters.Add(New MySqlParameter("@Description", input.Description))
            command.Parameters.Add(New MySqlParameter("@LongDescription", input.LongDescription))
            command.Parameters.Add(New MySqlParameter("@isEndGameTrigger", input.isEndGameTrigger))
            command.Parameters.Add(New MySqlParameter("@nextRoomStateId", input.nextRoomStateId))

            MyBase.ExecuteCommand(command)
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
            Dim strSQL As String = "SELECT R.* " & _
            "FROM RoomState AS R " & _
            "WHERE R.ParentRoomId = '@RoomId'"

            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@RoomId", input.RoomId))
            Return MyBase.GetObjectDataSet(command)
        End Function

        Public Sub Update(ByVal input As BE.RoomState)
            strSQL = "UPDATE @inputTypeName"
            strSQL += " SET " & _
            "RoomStateId='@RoomStateId" & _
            "', RoomStateName='@RoomStateName" & _
            "', ParentRoomId='@ParentRoomId" & _
            "', canGoNorth=@canGoNorth" & _
            ", canGoEast=@canGoEast" & _
            ", canGoSouth=@canGoSouth" & _
            ", canGoWest=@canGoWest" & _
            ", PointsAwarded=@PointsAwarded" & _
            ", Description='@Description" & _
            "', LongDescription='@LongDescription" & _
            "', isEndGameTrigger=@isEndGameTrigger" & _
            ", nextroomstateid='@nextRoomStateId" & _
            "' WHERE RoomStateId='@RoomStateId"

            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@RoomId", input.RoomId))
            command.Parameters.Add(New MySqlParameter("@inputTypeName", input.GetType.Name.ToString))
            command.Parameters.Add(New MySqlParameter("@RoomStateId", input.RoomStateId ))
            command.Parameters.Add(New MySqlParameter("@RoomStateName", input.RoomStateName))
            command.Parameters.Add(New MySqlParameter("@ParentRoomId", input.ParentRoomId))
            command.Parameters.Add(New MySqlParameter("@canGoNorth", input.canGoNorth))
            command.Parameters.Add(New MySqlParameter("@canGoEast", input.canGoEast))
            command.Parameters.Add(New MySqlParameter("@canGoSouth", input.canGoSouth))
            command.Parameters.Add(New MySqlParameter("@canGoWest", input.canGoWest))
            command.Parameters.Add(New MySqlParameter("@PointsAwarded", input.PointsAwarded))
            command.Parameters.Add(New MySqlParameter("@Description", input.Description))
            command.Parameters.Add(New MySqlParameter("@LongDescription", input.LongDescription))
            command.Parameters.Add(New MySqlParameter("@isEndGameTrigger", input.isEndGameTrigger))
            command.Parameters.Add(New MySqlParameter("@nextRoomStateId", input.nextRoomStateId))
            
            MyBase.ExecuteCommand(command)
        End Sub



        Public Overloads Sub Delete(ByVal roomstateid As String)
            MyBase.Delete(GetType(BE.RoomState), "RoomStateId", roomstateid)
        End Sub
    End Class
End Namespace

