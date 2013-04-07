
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

  

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim OpenPages As New ArrayList()
        OpenPages.Add("Play.aspx")
        OpenPages.Add("Login.aspx")
        OpenPages.Add("Default.aspx")
        OpenPages.Add("SessionExpired.aspx")
        OpenPages.Add("HowToPlay.aspx")
        OpenPages.Add("FAQ.aspx")
        OpenPages.Add("Tutorial.aspx")
        OpenPages.Add("Tutorial2.aspx")
        OpenPages.Add("Tutorial3.aspx")
        OpenPages.Add("Error.aspx")
        OpenPages.Add("PlayError.aspx")
        If String.Equals(Page.User.Identity.Name, String.Empty) Then
            Dim MatchedOpenPage As Boolean = False
            For Each x As String In OpenPages
                'If the string is found in the open pages set boolean
                If String.Compare(x, System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath).ToString) = 0 Then
                    MatchedOpenPage = True
                End If
            Next
            'If the string is not found in the open pages, it must be a secure
            'page, so redirect to the login page.
            If MatchedOpenPage = False Then
                Response.Redirect("~/Login.aspx")
            End If
            LoginLink.Visible = True
            LogoutLink.Visible = False
        Else
            LoginLink.Visible = False
            LogoutLink.Text = "Not " + Page.User.Identity.Name.ToString + "?" 'eg not Adrian? Amazon-style
            LogoutLink.Visible = True
            If Session("AuthorId") Is Nothing Then
                FormsAuthentication.SignOut()
                Response.Redirect("~/SessionExpired.aspx")
            End If
        End If

    End Sub

    Protected Sub LogoutLink_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LogoutLink.Click
        FormsAuthentication.SignOut()
        Session("AuthorId") = Nothing
        Response.Redirect("~/Default.aspx")
    End Sub
End Class

