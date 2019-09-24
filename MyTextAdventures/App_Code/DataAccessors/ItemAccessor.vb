Imports Microsoft.VisualBasic
Imports System.Data
Namespace DAL
    Public Class ItemAccessor
        Inherits DataAccessor

        Private strSQL As String
        Public Sub Add(ByVal input As BE.Item)
            strSQL = "INSERT INTO @inputTypeName"
            strSQL += " VALUES ('@ItemId & _
             "', '@ItemName & _
             "', '@Description & _
             "', '@LongDescription & _
             "', '@ParentStateId & _
             "', '@Hint & _
             "', '@StoryId & _
                  "')"

            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@inputTypeName", input.GetType.Name))
            command.Parameters.Add(New MySqlParameter("@ItemName, input.ItemName))
            command.Parameters.Add(New MySqlParameter("@Description, input.Description))
            command.Parameters.Add(New MySqlParameter("@LongDescription, input.LongDescription))
            command.Parameters.Add(New MySqlParameter("@ParentStateId, input.ParentStateId))
            command.Parameters.Add(New MySqlParameter("@Hint, input.Hint))
            command.Parameters.Add(New MySqlParameter("@StoryId, input.StoryId))

            MyBase.ExecuteCommand(command)
        End Sub

        Public Function GetItem(ByVal ItemId As String) As BE.Item
            Dim DataSet = New DataSet
            Dim output As New BE.Item
            DataSet = MyBase.GetObjectDataSet(GetType(BE.Item), "ItemId", ItemId)
            If DataSet.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                With DataSet.Tables(0).Rows(0)
                    output.ItemId = .Item("ItemId").ToString
                    output.ItemName = .Item("ItemName").ToString
                    output.Description = .Item("Description").ToString
                    output.LongDescription = .Item("LongDescription").ToString
                    output.ParentStateId = .Item("ParentStateId").ToString
                    output.Hint = .Item("Hint").ToString
                    output.StoryId = .Item("StoryId").ToString
                End With
                Return output
            End If
        End Function

        Public Function getItemsbyParentStateId(ByVal ParentStateId As String) As DataSet
            Dim strSQL As String = "SELECT I.* " & _
            "FROM Item AS I " & _
            "WHERE I.ParentStateId = '@ParentStateId'"
            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@ParentStateId", ParentStateId))
            Return MyBase.GetObjectDataSet(command)
        End Function

        Public Function getItemsbyStoryId(ByVal StoryId As String) As DataSet
            Dim strSQL As String = "SELECT I.* " & _
            "FROM Item AS I " & _
            "WHERE I.StoryId = '@StoryId'"
            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@StoryId", StoryId))
            Return MyBase.GetObjectDataSet(command)
        End Function

        Public Sub Update(ByVal input As BE.Item)
            strSQL = "UPDATE " + input.GetType.Name.ToString + " "
            strSQL += "SET " & _
            "ItemId='@ItemId'"
            "', ItemName='@ItemName'"
            "', Description='@Description'"
            "', longDescription='@LongDescription'"
            "', ParentStateId='@ParentStateId'"
            "', hint='@Hint'"
            "', StoryId='@StoryId'"
            "' WHERE ItemId='@ItemId'"

            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@ItemId", input.ItemId ))
            command.Parameters.Add(New MySqlParameter("@ItemName, input.ItemName))
            command.Parameters.Add(New MySqlParameter("@Description, input.Description))
            command.Parameters.Add(New MySqlParameter("@LongDescription, input.LongDescription))
            command.Parameters.Add(New MySqlParameter("@ParentStateId, input.ParentStateId))
            command.Parameters.Add(New MySqlParameter("@Hint, input.Hint))
            command.Parameters.Add(New MySqlParameter("@StoryId, input.StoryId))
            MyBase.ExecuteCommand(command)
        End Sub

        Public Overloads Sub Delete(ByVal Itemid As String)
            MyBase.Delete(GetType(BE.Item), "ItemId", Itemid)
        End Sub
    End Class
End Namespace

