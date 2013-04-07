Imports Microsoft.VisualBasic
Imports System.Attribute
Imports System.Data

Namespace DAL
    Public Class PlayerAccessor
        Inherits DataAccessor

        Private strSQL As String
        Public Sub Add(ByVal input As BE.Player)
            strSQL = "INSERT INTO " + input.GetType.Name.ToString
            strSQL += " VALUES ('" + input.PlayerId
            strSQL += "', '" + input.PlayerFirstName
            strSQL += "', '" + input.PlayerLastName
            strSQL += "', '" + input.AuthorId
            strSQL += "', '" + input.CurrentRoomId
            strSQL += "', " + input.Points.ToString
            strSQL += ", '" + input.CreatedOn.ToString("yyyy-MM-dd HH:mm:ss")
            strSQL += "', '" + input.LastPlayed.ToString("yyyy-MM-dd HH:mm:ss")
            strSQL += "')"
            MyBase.ExecuteCommand(strSQL)
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
            "WHERE P.AuthorId = '" + AuthorId + "'"
            playerDataSet = MyBase.GetObjectDataSet(STRSQL)
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
            strSQL = "UPDATE " + input.GetType.Name.ToString + " "
            ' strSQL += "SET UserName='" + input.UserName
            strSQL += "SET PlayerFirstName='" + input.PlayerFirstName
            strSQL += "', PlayerLastName='" + input.PlayerLastName
            strSQL += "', AuthorId='" + input.AuthorId
            strSQL += "', CurrentRoomId='" + input.CurrentRoomId
            strSQL += "', Points=" + input.Points.ToString
            strSQL += ", CreatedOn='" + input.CreatedOn.ToString("yyyy-MM-dd HH:mm:ss")
            strSQL += "', LastPlayed='" + input.LastPlayed.ToString("yyyy-MM-dd HH:mm:ss")
            strSQL += "' WHERE playerid='" + input.PlayerId + "'"
            MyBase.ExecuteCommand(strSQL)
        End Sub

        Public Overloads Sub Delete(ByVal playerid As String)
            MyBase.Delete(GetType(BE.Player), "PlayerId", playerid)
        End Sub

    End Class
End Namespace
