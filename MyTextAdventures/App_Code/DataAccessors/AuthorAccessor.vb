Imports Microsoft.VisualBasic
Imports System.Attribute
Imports System.Data
Namespace DAL
    Public Class AuthorAccessor
        Inherits DataAccessor
        Private strSQL As String
        Public Function GetAuthor(ByVal AuthorId As String) As BE.Author
            Dim authordataset As New DataSet
            Dim outputauthor As New BE.Author
            authorDataSet = MyBase.GetObjectDataSet(GetType(BE.Author), "authorId", AuthorId)
            Dim row As DataRow = authordataset.Tables(0).Rows(0)
            With outputauthor
                .AuthorId = row.Item("AuthorId").ToString
                .UserName = row.Item("UserName").ToString
                .FirstName = row.Item("FirstName").ToString
                .LastName = row.Item("LastName").ToString
                .Password = row.Item("Password").ToString
                .Email = row.Item("Email").ToString
                .CreatedOn = row.Item("CreatedOn").ToString
            End With

            Return outputauthor
        End Function
    End Class
End Namespace