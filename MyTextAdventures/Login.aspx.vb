Imports System.Data
Imports MySql.Data.MySqlClient
Partial Class Login
    Inherits System.Web.UI.Page

    Private Sub ValidateUser(ByVal inputUser As String, ByVal inputPwd As String)
        Dim ValidUser As Boolean
        ValidUser = False
        Dim strSQL As String = "SELECT AuthorId, UserName, Password " & _
        " FROM Author WHERE UserName=@inputUser" & _
        " AND Password=@inputpwd"
        Dim command As New MySql.Data.MySqlClient.MySqlCommand
        command.CommandText = strSQL
        command.Parameters.Add(New MySqlParameter("@inputUser", inputUser))
        command.Parameters.Add(New MySqlParameter("@inputpwd", inputPwd))
        Dim DBConnection = New MySqlConnection(ConfigurationManager.ConnectionStrings("MTAConnectionString").ConnectionString)
        Dim DataReader As MySqlDataReader
        command.Connection = DBConnection
        command.CommandType = CommandType.Text
        Try
            DBConnection.Open()
            DataReader = command.ExecuteReader
            Do While DataReader.Read()
                'If the statement returned a row then it's true.
                ValidUser = True
                'Create session variable for authorid
                Session("AuthorId") = DataReader("AuthorId")
                Session("UserName") = DataReader("UserName")
            Loop
            If ValidUser Then
                'Creates cookie for session
                FormsAuthentication.RedirectFromLoginPage(inputUser, PersistCheckBox.Checked)
                FormsAuthentication.SetAuthCookie(inputUser, PersistCheckBox.Checked)
                DBConnection.Close()
                Response.Redirect("Secure/AuthorHome.aspx")
            Else
                ErrorLabel.Text = "Invalid Username or Password"
            End If

        Catch ex As Exception
            ErrorLabel.Text = "There was a problem communicating with the database."
        Finally
            DBConnection.Close()
        End Try

    End Sub

    Protected Sub SubmitButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubmitButton.Click
        ValidateUser(UserNameTextBox.Text, PasswordTextBox.Text)
    End Sub

End Class
