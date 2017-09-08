
Partial Class _WeekNew
    Inherits System.Web.UI.Page

    Dim arrRoom1(35) As Integer
    Dim arrShow(35) As String
    Dim arrRoomInfo1(35) As String
    Dim arrMin(35) As Integer
    Dim arrMax(35) As Integer

    Private Sub popData()
        Dim vSlotName As String = "slot"
        Dim btnRun As New Button
        Dim connString As String = ConfigurationManager.ConnectionStrings("roomsSQL").ConnectionString
        Dim strSQL As String
        Dim strShow As String = ""
        Dim curSlotID As Integer = 0
        Dim curDayMult As Integer = 0
        Dim vTrustFilter As String = ""
        Dim strTrust As String = ""
        Dim iCount As Integer = 0
        Dim i As Integer = 0
        Dim strClass As String = ""
        Dim Con As New System.Data.SqlClient.SqlConnection(connString)
        Dim stDate As New Date
        Dim enDate As New Date
        If Not IsDate(txtCurrentDate.Text) Then
            If Now.DayOfWeek > 1 Then
                txtCurrentDate.Text = DateAdd(DateInterval.Day, -(Now.DayOfWeek - 1), Now.Date)
            Else
                txtCurrentDate.Text = Now.Date
            End If
        End If
        stDate = txtCurrentDate.Text
        enDate = DateAdd(DateInterval.Day, 4, stDate)
        displayDay()
        Con.Open()
        strSQL = "SELECT TROOMBOOKINGS.roomBookingTitle, TROOMBOOKINGS.roomID, TROOMBOOKINGS.roomBookingDate, TROOMBOOKINGS.roomStartSlot, TROOMBOOKINGS.roomEndSlot, TROOMBOOKINGS.roomBookingStaffID, TROOMBOOKINGS.roomBookingID, TUSERS.name FROM TROOMBOOKINGS LEFT JOIN TUSERS ON TROOMBOOKINGS.roomBookingStaffID = TUSERS.samAccountName WHERE roomBookingDate BETWEEN '" + Month(stDate).ToString + "/" + Day(stDate).ToString + "/" + Year(stDate).ToString + "' AND '" + Month(enDate).ToString + "/" + Day(enDate).ToString + "/" + Year(enDate).ToString + "' ORDER BY roomBookingDate ASC"
        'Response.Write(strSQL.ToString)
        Dim Com As New System.Data.SqlClient.SqlCommand(strSQL, Con)
        Dim rdr As System.Data.SqlClient.SqlDataReader = Com.ExecuteReader()
        Dim varDate As Date
        For i = 1 To 35
            arrRoom1(i) = "0"
            arrRoomInfo1(i) = ""
            arrMin(i) = 100
            arrMax(i) = 0
        Next

        While rdr.Read()
            iCount = iCount + 1
            curDayMult = DateDiff(DateInterval.Day, stDate, rdr("roomBookingDate")) + 1
            If Not IsDBNull(rdr("roomID")) Then
                If rdr("roomID") > 0 Then
                    curSlotID = rdr("roomID") + (7 * (curDayMult - 1))
                    If CInt(rdr("roomStartSlot")) < CInt(arrMin(curSlotID)) Then arrMin(curSlotID) = rdr("roomStartSlot")
                    If CInt(rdr("roomEndSlot")) > CInt(arrMax(curSlotID)) Then arrMax(curSlotID) = rdr("roomEndSlot")
                    strShow = (arrRoom1(curSlotID) + 1).ToString
                    strShow = (arrMin(curSlotID) - ((rdr("roomID") - 1) * 11)).ToString + " to " + (arrMax(curSlotID) - ((rdr("roomID") - 1) * 11)).ToString
                    If (arrMin(curSlotID) - ((rdr("roomID") - 1) * 11)) <= 5 And (arrMax(curSlotID) - ((rdr("roomID") - 1) * 11)) > 5 Then
                        strShow = "AM/PM"
                    ElseIf (arrMin(curSlotID) - ((rdr("roomID") - 1) * 11)) < 5 And (arrMax(curSlotID) - ((rdr("roomID") - 1) * 11)) <= 5 Then
                        strShow = "AM"
                    ElseIf (arrMin(curSlotID) - ((rdr("roomID") - 1) * 11)) > 5 And (arrMax(curSlotID) - ((rdr("roomID") - 1) * 11)) > 5 Then
                        strShow = "PM"
                    End If
                    arrRoom1(curSlotID) = arrRoom1(curSlotID) + 1
                    arrShow(curSlotID) = strShow.ToString
                    arrRoomInfo1(curSlotID) = Left(rdr("roomBookingDate").ToString, 10).ToString
                End If
                End If
        End While
        'Response.Write(iCount.ToString)
        rdr.Close()
        Com.Dispose()
        Con.Close()
        Con = Nothing
        For i = 1 To 35
            If Not IsNothing(arrRoom1(i)) Then
                If CInt(arrRoom1(i)) > 0 Then
                    btnRun = CType(defaultForm.FindControl(vSlotName + i.ToString), Button)
                    btnRun.ToolTip = arrRoomInfo1(i)
                    btnRun.OnClientClick = "window.location.href='default.aspx?day=" + arrRoomInfo1(i).ToString + "';return false;"
                    btnRun.ForeColor = Drawing.Color.Black
                    btnRun.Text = arrShow(i).ToString
                    btnRun.Visible = True
                Else
                    If i < 7 Then
                        varDate = stDate.ToString
                    ElseIf i < 13 Then
                        varDate = DateAdd(DateInterval.Day, 1, stDate)
                    ElseIf i < 19 Then
                        varDate = DateAdd(DateInterval.Day, 2, stDate)
                    ElseIf i < 25 Then
                        varDate = DateAdd(DateInterval.Day, 3, stDate)
                    ElseIf i < 31 Then
                        varDate = DateAdd(DateInterval.Day, 4, stDate)
                    End If
                    btnRun = CType(defaultForm.FindControl(vSlotName + i.ToString), Button)
                    btnRun.Visible = True
                    btnRun.Text = " "
                    btnRun.OnClientClick = "window.location.href='default.aspx?day=" + Left(varDate.ToString, 10).ToString + "';return false;"
                    btnRun.CssClass = "freewk"
                    btnRun.ToolTip = arrRoomInfo1(i)
                End If
            End If
        Next
    End Sub

    Private Sub displayDay()
        lblDayDesc.Text = "Week Commencing " + CDate(txtCurrentDate.Text).DayOfWeek.ToString + " " + CDate(txtCurrentDate.Text).Day.ToString + " " + MonthName(CDate(txtCurrentDate.Text).Month).ToString + " " + CDate(txtCurrentDate.Text).Year.ToString
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        popData()
        If Not Page.IsPostBack Then

        End If
    End Sub


    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If IsDate(txtCurrentDate.Text) Then
            txtCurrentDate.Text = Left(DateAdd(DateInterval.Day, 7, CDate(txtCurrentDate.Text)).ToString, 10).ToString
            displayDay()
        End If
        popData()
    End Sub

    Protected Sub btnPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        If IsDate(txtCurrentDate.Text) Then
            txtCurrentDate.Text = Left(DateAdd(DateInterval.Day, -7, CDate(txtCurrentDate.Text)).ToString, 10).ToString
            displayDay()
        End If
        popData()
    End Sub




End Class