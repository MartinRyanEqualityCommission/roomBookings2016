
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        errorMsg.InnerHtml = "<h3>An Error has Occurred</h3><p>" + Session("CurrentError") + "<br><br>Contact Martin on ext: 652</p>"
    End Sub
End Class