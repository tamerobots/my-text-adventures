Imports Microsoft.VisualBasic
Imports System.Data
Namespace DAL
    Public Class ItemAccessor
        Inherits DataAccessor

        Private strSQL As String
        Public Sub Add(ByVal input As BE.Item)
            strSQL = "INSERT INTO " + input.GetType.Name.ToString
            strSQL += " VALUES ('" + input.ItemId & _
             "', '" + input.ItemName & _
             "', '" + input.Description & _
             "', '" + input.LongDescription & _
             "', '" + input.ParentStateId & _
             "', '" + input.Hint & _
             "', '" + input.StoryId & _
                  "')"
            MyBase.ExecuteCommand(strSQL)
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
            Dim STRSQL As String = "SELECT I.* " & _
            "FROM Item AS I " & _
            "WHERE I.ParentStateId = '" + ParentStateId + "'"
            Return MyBase.GetObjectDataSet(STRSQL)
        End Function

        Public Function getItemsbyStoryId(ByVal StoryId As String) As DataSet
            Dim STRSQL As String = "SELECT I.* " & _
            "FROM Item AS I " & _
            "WHERE I.StoryId = '" + StoryId + "'"
            Return MyBase.GetObjectDataSet(STRSQL)
        End Function

        Public Sub Update(ByVal input As BE.Item)
            strSQL = "UPDATE " + input.GetType.Name.ToString + " "
            strSQL += "SET " & _
            "ItemId='" + input.ItemId & _
            "', ItemName='" + input.ItemName & _
            "', Description='" + input.Description & _
            "', longDescription='" + input.LongDescription & _
            "', ParentStateId='" + input.ParentStateId & _
            "', hint='" + input.Hint & _
            "', StoryId='" + input.StoryId & _
            "' WHERE ItemId='" + input.ItemId + "'"

            MyBase.ExecuteCommand(strSQL)
        End Sub



        Public Overloads Sub Delete(ByVal Itemid As String)
            MyBase.Delete(GetType(BE.Item), "ItemId", Itemid)
        End Sub
    End Class
End Namespace

