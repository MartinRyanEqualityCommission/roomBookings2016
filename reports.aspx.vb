
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim strUser As String = ""
            strUser = Request.ServerVariables(5).ToString
            If Left(UCase(strUser), 5) = "NICCY" Then
                strUser = Right(strUser, (Len(strUser) - 6)).ToString
            Else
                strUser = Right(strUser, (Len(strUser) - 9)).ToString
            End If
            If strUser.ToUpper = "RECEPTION" Or strUser.ToUpper = "MRYAN" Then
                visitorReport.Visible = True
            End If
        End If
    End Sub
End Class