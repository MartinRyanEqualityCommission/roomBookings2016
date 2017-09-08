
Partial Class user
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strUser As String
        strUser = Request.ServerVariables(5).ToString
        Response.Write(Right(strUser, (Len(strUser) - 9)).ToString)
        Response.Write("RCOREY-WRIGHT")
    End Sub
End Class
