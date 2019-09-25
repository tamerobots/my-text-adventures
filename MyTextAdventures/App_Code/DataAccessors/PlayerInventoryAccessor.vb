Imports Microsoft.VisualBasic
Imports System.Attribute
Imports System.Data
Namespace DAL
    Public Class PlayerInventoryAccessor
        Inherits DataAccessor
        Private strSQL As String

        Public Sub Add(ByVal input As BE.PlayerInventory)
            strSQL = "INSERT INTO @inputTypeName"
            strSQL += " VALUES ('@PlayerInventoryId" & _
                "', '@PlayerId" & _
                "', '@ItemId" & _
                "')"

            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@inputTypeName", inputType.Name))
            command.Parameters.Add(New MySqlParameter("@PlayerInventoryId", input.PlayerInventoryId ))
            command.Parameters.Add(New MySqlParameter("@PlayerId", input.PlayerId & _
            command.Parameters.Add(New MySqlParameter("@ItemId", input.ItemId & _

            MyBase.ExecuteCommand(command)
        End Sub

        Public Function GetPlayerFullInventoryByPlayerIdStoryId(ByVal playerid As String, ByVal storyid As String) As DataSet
            Dim strSQL As String = "SELECT PI.* " & _
           "FROM PlayerInventory AS PI " & _
           "INNER JOIN Item AS I ON I.ItemId = PI.ItemId " & _
           "WHERE PI.PlayerId = '@playerId' " & _
           "AND I.StoryId='@Storyid'"

           Dim command As New MySql.Data.MySqlClient.MySqlCommand
           command.CommandText = strSQL
           command.Parameters.Add(New MySqlParameter("@PlayerId", playerId))
           command.Parameters.Add(New MySqlParameter("@StoryId", storyId))
           Return MyBase.GetObjectDataSet(command)

        End Function

        Public Function GetPlayerInventory(ByVal PlayerInventoryId As String) As BE.PlayerInventory
            Dim PRSDS As New DataSet
            Dim output As New BE.PlayerInventory
            PRSDS = MyBase.GetObjectDataSet(GetType(BE.PlayerInventory), "PlayerInventoryId", PlayerInventoryId)
            If Not PRSDS.Tables.Count = 0 Then
                Dim row As DataRow = PRSDS.Tables(0).Rows(0)
                With output
                    .PlayerInventoryId = row.Item("PlayerInventoryId").ToString
                    .PlayerId = row.Item("PlayerId").ToString
                    .ItemId = row.Item("ItemId").ToString
                End With
                Return output
            Else
                Return Nothing
            End If
        End Function

        Public Function GetPlayerInventoryByItemIdPlayerId(ByVal inputItemId As String, ByVal inputPlayerId As String) As BE.PlayerInventory
            Dim PRSDS As New DataSet
            Dim output As New BE.PlayerInventory
            strSQL = "SELECT PI.* " & _
            "FROM PlayerInventory AS PI " & _
            "WHERE PI.ItemId = '@inputItemId' " & _
            "AND PI.PlayerId = '@inputPlayerId'"
            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@inputPlayerId", inputPlayerId))
            command.Parameters.Add(New MySqlParameter("@inputItemId", inputItemId))
            PRSDS = MyBase.GetObjectDataSet(command)

            If Not PRSDS.Tables(0).Rows.Count = 0 Then
                Dim row As DataRow = PRSDS.Tables(0).Rows(0)
                With output
                    .PlayerInventoryId = row.Item("PlayerInventoryId").ToString
                    .PlayerId = row.Item("PlayerId").ToString
                    .ItemId = row.Item("ItemId").ToString
                End With
                Return output
            End If
            Return Nothing
        End Function

        Public Sub Update(ByVal input As BE.PlayerInventory)
            strSQL = "UPDATE @inputName "
            strSQL += "SET " & _
            "PlayerInventoryId='@PlayerInventoryId" & _
            "', PlayerId='@PlayerId" & _
            "', ItemId='@ItemId" & _
            "' WHERE PlayerInventoryId='@PlayerInventoryId'"

            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@inputName", input.GetType.Name.ToString))
            command.Parameters.Add(New MySqlParameter("@PlayerInventoryId", input.PlayerInventoryId))
            command.Parameters.Add(New MySqlParameter("@ItemId", input.ItemId))
            command.Parameters.Add(New MySqlParameter("@PlayerId", input.PlayerId))
            MyBase.ExecuteCommand(command)
        End Sub
    End Class
End Namespace

