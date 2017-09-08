<%@ Application Language="VB" %>

<script runat="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
        Try
            Dim lic As Aspose.Cells.License = New Aspose.Cells.License()
            lic.SetLicense("C:\inetpub\wwwroot\Aspose LIC\Aspose.Total.lic")
        Catch ex As Exception

        End Try

    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
        'Session("CurrentError") = "Global: " + Server.GetLastError.Message
        ' Server.Transfer("lasterr.aspx")
        Try
            Dim strUser As String = ""
            strUser = Request.ServerVariables(5).ToString
            strUser = Right(strUser, (Len(strUser) - 6)).ToString

            If UCase(strUser) <> "MARTIN.RYAN" Then

                Dim CurrentException As Exception = Server.GetLastError()
                Dim ErrorDetails As String = CurrentException.ToString()


                Dim Email As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
                Email.IsBodyHtml = True
                Dim xFrom As System.Net.Mail.MailAddress
                xFrom = New System.Net.Mail.MailAddress("No-Reply@nihrc.org")
                Dim xTo As System.Net.Mail.MailAddress
                xTo = New System.Net.Mail.MailAddress("mryan@equalityni.org")
                Email.From = xFrom
                Email.To.Add(xTo)
                Email.Subject = "WEB SITE ERROR : " + strUser.ToString
                Email.Body = ErrorDetails
                Email.Priority = System.Net.Mail.MailPriority.High
                Dim sc As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient("192.168.100.16")
                sc.Credentials = New System.Net.NetworkCredential("martin.ryan", "Password77")
                sc.Send(Email)
                ' Session("ErrorDetails") = ErrorDetails
                Server.ClearError()
                'Response.Redirect("error.aspx")
                'Server.Transfer("error.aspx")
                '        Response.Redirect("myerror.aspx", False)
            End If


        Catch ex As Exception

        End Try



    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub

</script>