Imports Microsoft.VisualBasic
Imports System.Attribute
Imports System.Data
Namespace DAL
    Public Class PlayerInventoryAccessor
        Inherits DataAccessor
        Private strSQL As String

        Public Sub Add(ByVal input As BE.PlayerInventory)
            strSQL = "INSERT INTO " + input.GetType.Name.ToString
            strSQL += " VALUES ('" + input.PlayerInventoryId & _
                "', '" + input.PlayerId & _
                "', '" + input.ItemId & _
                "')"
            MyBase.ExecuteCommand(strSQL)
        End Sub

        Public Function GetPlayerFullInventoryByPlayerIdStoryId(ByVal playerid As String, ByVal storyid As String) As DataSet
            Dim STRSQL As String = "SELECT PI.* " & _
           "FROM PlayerInventory AS PI " & _
           "INNER JOIN Item AS I ON I.ItemId = PI.ItemId " & _
           "WHERE PI.PlayerId = '" + playerid + "' " & _
           "AND I.StoryId='" + storyid + "'"
            Return MyBase.GetObjectDataSet(STRSQL)
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
            "WHERE PI.ItemId = '" + inputItemId + "' " & _
            "AND PI.PlayerId = '" + inputPlayerId + "'"
            PRSDS = MyBase.GetObjectDataSet(strSQL)
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
            strSQL = "UPDATE " + input.GetType.Name.ToString + " "
            strSQL += "SET " & _
            "PlayerInventoryId='" + input.PlayerInventoryId & _
            "', PlayerId='" + input.PlayerId & _
            "', ItemId='" + input.ItemId & _
            "' WHERE PlayerInventoryId='" + input.PlayerInventoryId + "'"
            MyBase.ExecuteCommand(strSQL)
        End Sub
    End Class
End Namespace