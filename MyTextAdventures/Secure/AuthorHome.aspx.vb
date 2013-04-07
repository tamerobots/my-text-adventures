
Partial Class AuthorHome
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            myGridView.DataBind()
        End If

    End Sub


    Protected Sub myGridView_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles myGridView.RowCommand
        Dim parentlb As LinkButton = CType(e.CommandSource, LinkButton)
        Dim reqid As String = CType(parentlb.Parent.FindControl("StoryId"), HiddenField).Value
        Select Case e.CommandName
            Case "Play"
                Response.Redirect("~/Play.aspx?storyid=" + reqid)
            Case "Edit"
                Response.Redirect("~/Secure/Story.aspx?storyid=" + reqid)
            Case "Validate"
                Response.Redirect("~/Secure/Validate.aspx?storyid=" + reqid)
            Case "Publish"
                Dim storyacc As New DAL.StoryAccessor
                storyacc.setPublished(reqid, True)
            Case "Withdraw"
                Dim storyacc As New DAL.StoryAccessor
                storyacc.setPublished(reqid, False)
            Case "Delete"
                Dim storyacc As New DAL.StoryAccessor
                storyacc.Delete(reqid)
                Response.Redirect(Request.Url.ToString)

        End Select
        myGridView.DataBind()


    End Sub


    Protected Sub myGridView_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles myGridView.RowDataBound
        'turn boolean 0 and 1 values into true and false strings
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            If (e.Row.DataItem("isPublished") = 0) Then
                e.Row.Cells(2).Text = "No"
                e.Row.Cells(4).Text = "Not Published Yet"
                e.Row.Cells(6).FindControl("PublishButton").Visible = True
            Else
                e.Row.Cells(2).Text = "Yes"
                e.Row.Cells(6).FindControl("WithdrawButton").Visible = True
            End If


        End If
    End Sub

End Class
