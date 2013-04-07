
Partial Class ErrorPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("AuthorId") IsNot Nothing Then
            If Request.QueryString("Command") IsNot Nothing Then
                CommandText.Visible = True
                CommandText.Text = "The last command entered was " + Request.QueryString("Command").ToString + ". Use that in your investigations as to why the game failed."

            End If
        End If
    End Sub
End Class
