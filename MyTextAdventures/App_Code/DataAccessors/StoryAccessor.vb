Imports Microsoft.VisualBasic
Imports System.Data
Namespace DAL
    Public Class StoryAccessor
        Inherits DataAccessor
        'inherits all of dataaccessor's methods, so can just customise parameters and 
        'call it's methods
        Private strSQL As String
        Public Sub Add(ByVal input As BE.Story)
            'piece together sql statement from input story's properties 
            strSQL = "INSERT INTO " + input.GetType.Name.ToString
            strSQL += " VALUES ('" + input.StoryId
            strSQL += "', '" + input.StoryName
            strSQL += "', '" + input.AuthorId
            strSQL += "', '" + input.Description
            strSQL += "', " + input.IsPublished.ToString
            strSQL += ", '" + input.CreatedOn.ToString("yyyy-MM-dd HH:mm:ss") 'dates need to be read in in a certain way to be entered correctly into database
            strSQL += "', '" + input.PublishedOn.ToString("yyyy-MM-dd HH:mm:ss")
            strSQL += "', '" + input.StartRoomId
            strSQL += "')"
            MyBase.ExecuteCommand(strSQL)
        End Sub

        Public Function GetStory(ByVal StoryId As String) As BE.Story
            Dim DataSet = New DataSet
            Dim output As New BE.Story
            DataSet = MyBase.GetObjectDataSet(GetType(BE.Story), "StoryId", StoryId)
            If DataSet.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                With DataSet.Tables(0).Rows(0)
                    ' there should only be one row returned, so
                    'read dataset row properties into output story
                    output.StoryId = .Item("StoryId").ToString
                    output.StoryName = .Item("StoryName").ToString
                    output.AuthorId = .Item("AuthorId").ToString
                    output.Description = .Item("Description").ToString
                    output.IsPublished = .Item("isPublished")
                    output.CreatedOn = .Item("CreatedOn").ToString
                    If .Item("PublishedOn") IsNot Nothing Then
                        output.PublishedOn = .Item("PublishedOn").ToString
                    End If
                    output.StartRoomId = .Item("StartRoomId").ToString
                End With

                Return output
            End If
        End Function

        Public Function getStoriesByAuthorId(ByVal AuthorId As String) As DataSet
            'custom dataset request, so build sql string, including joins, manually
            Dim STRSQL As String = "SELECT S.*, A.AuthorId, A.UserName " & _
            "FROM Story AS S " & _
            "INNER JOIN author AS A ON " & _
            "A.AuthorId = S.AuthorId " & _
            "WHERE S.AuthorId = '" + AuthorId + "'"
            Return MyBase.GetObjectDataSet(STRSQL)
            ' Dim mysql As New MySql.Data.MySqlClient.MySqlCommand
        End Function

        Public Function getPublishedStories() As DataSet
            ' no need for parameters as shows all published stories regardless of author
            Dim STRSQL As String = "SELECT S.*, A.AuthorId, A.UserName " & _
            "FROM Story AS S " & _
            "INNER JOIN author AS A ON " & _
            "A.AuthorId = S.AuthorId " & _
            "WHERE S.IsPublished = 1"
            Return MyBase.GetObjectDataSet(STRSQL)
        End Function

        Public Sub Update(ByVal input As BE.Story)

            strSQL = "UPDATE " + input.GetType.Name.ToString + " "
            strSQL += "SET "
            strSQL += "StoryId='" + input.StoryId
            strSQL += "', StoryName='" + input.StoryName
            strSQL += "', AuthorId='" + input.AuthorId
            strSQL += "', Description='" + input.Description
            strSQL += "', IsPublished=" + input.IsPublished.ToString
            strSQL += ", CreatedOn='" + input.CreatedOn.ToString("yyyy-MM-dd HH:mm:ss")
            strSQL += "', PublishedOn='" + input.PublishedOn.ToString("yyyy-MM-dd HH:mm:ss")
            strSQL += "', StartRoomId='" + input.StartRoomId
            strSQL += "' WHERE StoryId='" + input.StoryId + "'"
            MyBase.ExecuteCommand(strSQL)
        End Sub

        Public Sub setPublished(ByVal StoryId As String, ByVal makePublished As Boolean)
            'quick, more efficient statement to set published status
            Dim story As BE.Story = GetStory(StoryId)
            If makePublished Then
                story.PublishedOn = Date.Now
            Else
                story.PublishedOn = Date.MinValue
            End If
            story.IsPublished = makePublished
            Update(story)
        End Sub

        Public Overloads Sub Delete(ByVal storyid As String)
            'call dataaccessor delete method
            MyBase.Delete(GetType(BE.Story), "StoryId", storyid)
        End Sub


    End Class
End Namespace