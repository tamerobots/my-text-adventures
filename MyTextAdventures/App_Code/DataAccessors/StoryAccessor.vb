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
            strSQL = "INSERT INTO @inputTypeName"
            strSQL += " VALUES ('@StoryId"
            strSQL += "', @StoryName
            strSQL += "', @AuthorId
            strSQL += "', @Description
            strSQL += "', @IsPublished"
            strSQL += ", @CreatedOn"
            strSQL += "', @PublishedOn"
            strSQL += "', @StartRoomId"
            strSQL += "')"

            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@inputTypeName", inputType.Name))
            command.Parameters.Add(New MySqlParameter("@StoryId", input.StoryId))
            command.Parameters.Add(New MySqlParameter("@StoryName", input.StoryName))
            command.Parameters.Add(New MySqlParameter("@AuthorId", input.AuthorId))
            command.Parameters.Add(New MySqlParameter("@Description", input.Description))
            command.Parameters.Add(New MySqlParameter("@IsPublished", input.IsPublished.ToString))
            command.Parameters.Add(New MySqlParameter("@CreatedOn", input.CreatedOn.ToString("yyyy-MM-dd HH:mm:ss") 'dates need to be read in in a certain way to be entered correctly into database
            command.Parameters.Add(New MySqlParameter("@PublishedOn", input.PublishedOn.ToString("yyyy-MM-dd HH:mm:ss")))
            command.Parameters.Add(New MySqlParameter("@StartRoomId", input.StartRoomId))
            strSQL += "')"

            MyBase.ExecuteCommand(command)
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
            Dim strSQL As String = "SELECT S.*, A.AuthorId, A.UserName " & _
            "FROM Story AS S " & _
            "INNER JOIN author AS A ON " & _
            "A.AuthorId = S.AuthorId " & _
            "WHERE S.AuthorId = '@AuthorId'"

            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@AuthorId", AuthorId))
            Return MyBase.GetObjectDataSet(command)
        End Function

        Public Function getPublishedStories() As DataSet
            ' no need for parameters as shows all published stories regardless of author
            Dim strSQL As String = "SELECT S.*, A.AuthorId, A.UserName " & _
            "FROM Story AS S " & _
            "INNER JOIN author AS A ON " & _
            "A.AuthorId = S.AuthorId " & _
            "WHERE S.IsPublished = 1"
            Return MyBase.GetObjectDataSet(strSQL)
        End Function

        Public Sub Update(ByVal input As BE.Story)

            strSQL = "UPDATE @inputTypeName "
            strSQL += "SET "
            strSQL += "StoryId='@StoryId'"
            strSQL += "', StoryName='@StoryName'"
            strSQL += "', AuthorId='@AuthorId'"
            strSQL += "', Description='@Description'"
            strSQL += "', IsPublished=@IsPublished'"
            strSQL += ", CreatedOn='@CreatedOn'"
            strSQL += "', PublishedOn='@PublishedOn'"
            strSQL += "', StartRoomId='@StartRoomId'"
            strSQL += "' WHERE StoryId='@StoryId'"

            Dim command As New MySql.Data.MySqlClient.MySqlCommand
            command.CommandText = strSQL
            command.Parameters.Add(New MySqlParameter("@inputTypeName", inputType.Name))
            command.Parameters.Add(New MySqlParameter("@StoryId", input.StoryId))
            command.Parameters.Add(New MySqlParameter("@StoryName", input.StoryName))
            command.Parameters.Add(New MySqlParameter("@AuthorId", input.AuthorId))
            command.Parameters.Add(New MySqlParameter("@Description", input.Description))
            command.Parameters.Add(New MySqlParameter("@IsPublished",input.IsPublished.ToString))
            command.Parameters.Add(New MySqlParameter("@CreatedOn", input.CreatedOn.ToString("yyyy-MM-dd HH:mm:ss")))
            command.Parameters.Add(New MySqlParameter("@PublishedOn", input.PublishedOn.ToString("yyyy-MM-dd HH:mm:ss")))
            command.Parameters.Add(New MySqlParameter("@StartRoomId", input.StartRoomId))

            MyBase.ExecuteCommand(command)
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
