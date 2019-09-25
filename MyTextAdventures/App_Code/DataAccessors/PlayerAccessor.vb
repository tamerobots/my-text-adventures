Imports Microsoft.VisualBasic
Imports System.Attribute
Imports System.Data

Namespace DAL
    Public Class PlayerAccessor
        Inherits DataAccessor

        Private strSQL As String
        Public Sub Add(ByVal input As BE.Player)
            strSQL = "INSERT INTO @inputTypeName"
            " VALUES ('@PlayerId" & _
            "', '@PlayerFirstName" & _
            "', '@PlayerLastName" & _
            "', '@AuthorId" & _
            "', '@CurrentRoomId" & _
            "', @Points" & _
            ", '@CreatedOn" & _
            "', '@LastPlayed" & _
            "')"

            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@inputTypeName", inputType.Name))
            command.Parameters.Add(New MySqlParameter("@PlayerFirstName", input.PlayerFirstName))
            command.Parameters.Add(New MySqlParameter("@PlayerLastName", input.PlayerLastName))
            command.Parameters.Add(New MySqlParameter("@AuthorId", input.AuthorId))
            command.Parameters.Add(New MySqlParameter("@CurrentRoomId", input.CurrentRoomId))
            command.Parameters.Add(New MySqlParameter("@Points", input.Points.ToString))
            command.Parameters.Add(New MySqlParameter("@CreatedOn", input.CreatedOn.ToString("yyyy-MM-dd HH:mm:ss")))
            command.Parameters.Add(New MySqlParameter("@LastPlayed", input.LastPlayed.ToString("yyyy-MM-dd HH:mm:ss")))
            MyBase.ExecuteCommand(command)
        End Sub

        Public Function GetPlayer(ByVal PlayerId As String) As BE.Player
            Dim playerDataSet = New DataSet
            Dim outputPlayer As New BE.Player
            playerDataSet = MyBase.GetObjectDataSet(GetType(BE.Player), "PlayerId", PlayerId)
            If playerDataSet.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                With playerDataSet.Tables(0).Rows(0)
                    outputPlayer.PlayerId = .Item("PlayerId").ToString
                    outputPlayer.PlayerFirstName = .Item("PlayerFirstName").ToString
                    outputPlayer.PlayerLastName = .Item("PlayerLastName").ToString
                    outputPlayer.AuthorId = .Item("AuthorId").ToString
                    outputPlayer.CurrentRoomId = .Item("CurrentRoomId").ToString
                    outputPlayer.Points = .Item("Points")
                    outputPlayer.CreatedOn = .Item("CreatedOn").ToString
                    outputPlayer.LastPlayed = .Item("LastPlayed").ToString
                End With
                Return outputPlayer
            End If
        End Function


        Public Function GetPlayerByAuthorId(ByVal AuthorId As String) As BE.Player
            Dim playerDataSet = New DataSet
            Dim outputPlayer As New BE.Player
            Dim STRSQL As String = "SELECT P.* " & _
            "FROM Player AS P " & _
            "WHERE P.AuthorId = '@AuthorId'"
            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@AuthorId", AuthorId))
            playerDataSet = MyBase.GetObjectDataSet(command)
            If playerDataSet.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                With playerDataSet.Tables(0).Rows(0)
                    outputPlayer.PlayerId = .Item("PlayerId").ToString
                    outputPlayer.PlayerFirstName = .Item("PlayerFirstName").ToString
                    outputPlayer.PlayerLastName = .Item("PlayerLastName").ToString
                    outputPlayer.AuthorId = .Item("AuthorId").ToString
                    outputPlayer.CurrentRoomId = .Item("CurrentRoomId").ToString
                    outputPlayer.Points = .Item("Points")
                    outputPlayer.CreatedOn = .Item("CreatedOn").ToString
                    outputPlayer.LastPlayed = .Item("LastPlayed").ToString
                End With
                Return outputPlayer
            End If
        End Function

        Public Sub Update(ByVal input As BE.Player)
            strSQL = "UPDATE @inputTypeName "
            strSQL += "SET PlayerFirstName='@PlayerFirstName"
            strSQL += "', PlayerLastName='@PlayerLastName"
            strSQL += "', AuthorId='@AuthorId"
            strSQL += "', CurrentRoomId='@CurrentRoomId"
            strSQL += "', Points=@Points"
            strSQL += ", CreatedOn='@CreatedOn"
            strSQL += "', LastPlayed='@LastPlayed"
            strSQL += "' WHERE playerid='@PlayerId"

            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@inputTypeName", inputType.Name))
            command.Parameters.Add(New MySqlParameter("@PlayerFirstName", input.PlayerFirstName))
            command.Parameters.Add(New MySqlParameter("@PlayerLastName", input.PlayerLastName))
            command.Parameters.Add(New MySqlParameter("@AuthorId", input.AuthorId))
            command.Parameters.Add(New MySqlParameter("@CurrentRoomId", input.CurrentRoomId))
            command.Parameters.Add(New MySqlParameter("@Points", input.Points.ToString))
            command.Parameters.Add(New MySqlParameter("@CreatedOn", input.CreatedOn.ToString("yyyy-MM-dd HH:mm:ss")))
            command.Parameters.Add(New MySqlParameter("@LastPlayed", input.LastPlayed.ToString("yyyy-MM-dd HH:mm:ss")))
            command.Parameters.Add(New MySqlParameter("@PlayerId", input.PlayerId))

            MyBase.ExecuteCommand(command)
        End Sub

        Public Overloads Sub Delete(ByVal playerid As String)
            MyBase.Delete(GetType(BE.Player), "PlayerId", playerid)
        End Sub

    End Class
End Namespace
