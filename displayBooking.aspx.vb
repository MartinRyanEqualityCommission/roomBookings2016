
Partial Class displayBooking
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Request.QueryString("bookID")) Then
            popData(CInt(Request.QueryString("bookID")))
        Else
            Response.Write("Problem Ring 652")
        End If
    End Sub

    Private Sub popData(ByVal bookID As Integer)
        Dim connString As String = ConfigurationManager.ConnectionStrings("roomsSQL").ConnectionString
        Dim strSQL As String
        Dim iCount As Integer = 0
        Dim i As Integer = 0
        Dim strRows As String = ""
        Dim Con As New System.Data.SQLClient.SQLConnection(connString)
        Dim vFood As String = "No"
        Dim vSR As String = "No"
        Dim vEndSlot As Integer
        Dim vDate As New Date
        Dim arrTimeDesc(133) As String
        Dim strIMG As String = ""

        arrTimeDesc(1) = "08:00am"
        arrTimeDesc(2) = "08:30am"
        arrTimeDesc(3) = "09:00am"
        arrTimeDesc(4) = "09:30am"
        arrTimeDesc(5) = "10:00am"
        arrTimeDesc(6) = "10:30am"
        arrTimeDesc(7) = "11:00pm"
        arrTimeDesc(8) = "11:30pm"
        arrTimeDesc(9) = "12:00pm"
        arrTimeDesc(10) = "12:30pm"
        arrTimeDesc(11) = "13:00pm"
        arrTimeDesc(12) = "13:30am"
        arrTimeDesc(13) = "14:00am"
        arrTimeDesc(14) = "14:30am"
        arrTimeDesc(15) = "15:00am"
        arrTimeDesc(16) = "15:30pm"
        arrTimeDesc(17) = "16:00pm"
        arrTimeDesc(18) = "16:30pm"
        arrTimeDesc(19) = "17:00pm"
        arrTimeDesc(20) = "17:30pm"
        arrTimeDesc(21) = "18:00pm"
        arrTimeDesc(22) = "18:30pm"

        arrTimeDesc(23) = "08:00am"
        arrTimeDesc(24) = "08:30am"
        arrTimeDesc(25) = "09:00am"
        arrTimeDesc(26) = "09:30am"
        arrTimeDesc(27) = "10:00am"
        arrTimeDesc(28) = "10:30am"
        arrTimeDesc(29) = "11:00pm"
        arrTimeDesc(30) = "11:30pm"
        arrTimeDesc(31) = "12:00pm"
        arrTimeDesc(32) = "12:30pm"
        arrTimeDesc(33) = "13:00pm"
        arrTimeDesc(34) = "13:30am"
        arrTimeDesc(35) = "14:00am"
        arrTimeDesc(36) = "14:30am"
        arrTimeDesc(37) = "15:00am"
        arrTimeDesc(38) = "15:30pm"
        arrTimeDesc(39) = "16:00pm"
        arrTimeDesc(40) = "16:30pm"
        arrTimeDesc(41) = "17:00pm"
        arrTimeDesc(42) = "17:30pm"
        arrTimeDesc(43) = "18:00pm"
        arrTimeDesc(44) = "18:30pm"

        arrTimeDesc(45) = "08:00am"
        arrTimeDesc(46) = "08:30am"
        arrTimeDesc(47) = "09:00am"
        arrTimeDesc(48) = "09:30am"
        arrTimeDesc(49) = "10:00am"
        arrTimeDesc(50) = "10:30am"
        arrTimeDesc(51) = "11:00pm"
        arrTimeDesc(52) = "11:30pm"
        arrTimeDesc(53) = "12:00pm"
        arrTimeDesc(54) = "12:30pm"
        arrTimeDesc(55) = "13:00pm"
        arrTimeDesc(56) = "13:30am"
        arrTimeDesc(57) = "14:00am"
        arrTimeDesc(58) = "14:30am"
        arrTimeDesc(59) = "15:00am"
        arrTimeDesc(60) = "15:30pm"
        arrTimeDesc(61) = "16:00pm"
        arrTimeDesc(62) = "16:30pm"
        arrTimeDesc(63) = "17:00pm"
        arrTimeDesc(64) = "17:30pm"
        arrTimeDesc(65) = "18:00pm"
        arrTimeDesc(66) = "18:30pm"

        arrTimeDesc(67) = "08:00am"
        arrTimeDesc(68) = "08:30am"
        arrTimeDesc(69) = "09:00am"
        arrTimeDesc(70) = "09:30am"
        arrTimeDesc(71) = "10:00am"
        arrTimeDesc(72) = "10:30am"
        arrTimeDesc(73) = "11:00pm"
        arrTimeDesc(74) = "11:30pm"
        arrTimeDesc(75) = "12:00pm"
        arrTimeDesc(76) = "12:30pm"
        arrTimeDesc(77) = "13:00pm"
        arrTimeDesc(78) = "13:30am"
        arrTimeDesc(79) = "14:00am"
        arrTimeDesc(80) = "14:30am"
        arrTimeDesc(81) = "15:00am"
        arrTimeDesc(82) = "15:30pm"
        arrTimeDesc(83) = "16:00pm"
        arrTimeDesc(84) = "16:30pm"
        arrTimeDesc(85) = "17:00pm"
        arrTimeDesc(86) = "17:30pm"
        arrTimeDesc(87) = "18:00pm"
        arrTimeDesc(88) = "18:30pm"

        arrTimeDesc(89) = "08:00am"
        arrTimeDesc(90) = "08:30am"
        arrTimeDesc(91) = "09:00am"
        arrTimeDesc(92) = "09:30am"
        arrTimeDesc(93) = "10:00am"
        arrTimeDesc(94) = "10:30am"
        arrTimeDesc(95) = "11:00pm"
        arrTimeDesc(96) = "11:30pm"
        arrTimeDesc(97) = "12:00pm"
        arrTimeDesc(98) = "12:30pm"
        arrTimeDesc(99) = "13:00pm"
        arrTimeDesc(100) = "13:30am"
        arrTimeDesc(101) = "14:00am"
        arrTimeDesc(102) = "14:30am"
        arrTimeDesc(103) = "15:00am"
        arrTimeDesc(104) = "15:30pm"
        arrTimeDesc(105) = "16:00pm"
        arrTimeDesc(106) = "16:30pm"
        arrTimeDesc(107) = "17:00pm"
        arrTimeDesc(108) = "17:30pm"
        arrTimeDesc(109) = "18:00pm"
        arrTimeDesc(110) = "18:30pm"

        arrTimeDesc(111) = "08:00am"
        arrTimeDesc(112) = "08:30am"
        arrTimeDesc(113) = "09:00am"
        arrTimeDesc(114) = "09:30am"
        arrTimeDesc(115) = "10:00am"
        arrTimeDesc(116) = "10:30am"
        arrTimeDesc(117) = "11:00pm"
        arrTimeDesc(118) = "11:30pm"
        arrTimeDesc(119) = "12:00pm"
        arrTimeDesc(120) = "12:30pm"
        arrTimeDesc(121) = "13:00pm"
        arrTimeDesc(122) = "13:30am"
        arrTimeDesc(123) = "14:00am"
        arrTimeDesc(124) = "14:30am"
        arrTimeDesc(125) = "15:00am"
        arrTimeDesc(126) = "15:30pm"
        arrTimeDesc(127) = "16:00pm"
        arrTimeDesc(128) = "16:30pm"
        arrTimeDesc(129) = "17:00pm"
        arrTimeDesc(130) = "17:30pm"
        arrTimeDesc(131) = "18:00pm"
        arrTimeDesc(132) = "18:30pm"
        arrTimeDesc(133) = "19:00pm"

        Con.Open()
        strSQL = "SELECT TROOMBOOKINGS.roomBookingTitle, TROOMBOOKINGS.roomBehalfOf, TROOMBOOKINGS.roomID, TROOMBOOKINGS.roomSR, TROOMBOOKINGS.roomFood, TROOMBOOKINGS.roomBookingDate, TROOMBOOKINGS.roomStartSlot, TROOMBOOKINGS.roomEndSlot, TROOMBOOKINGS.roomBookingStaffID, TROOMBOOKINGS.roomBookingDESC, TROOMBOOKINGS.roomBookingID, TUSERS.name, TROOMBOOKINGS.roomNoAttending, TROOMBOOKINGS.roomSRDetail, TROOMBOOKINGS.roomFoodDetail, TUSERS_1.department AS dept, TUSERS_1.name as beHalfName, TUSERS_1.telephoneNumber" & _
                " FROM (TROOMBOOKINGS LEFT JOIN TUSERS ON TROOMBOOKINGS.roomBookingStaffID = TUSERS.samaccountName) LEFT JOIN TUSERS AS TUSERS_1 ON TROOMBOOKINGS.roomBehalfOf = TUSERS_1.samaccountName" & _
                " WHERE roomBookingID=" + bookID.ToString

        Dim Com As New System.Data.SqlClient.SQLCommand(strSQL, Con)
        Dim rdr As System.Data.SQLClient.SQLDataReader = Com.ExecuteReader()
        While rdr.Read()
            iCount = iCount + 1
            If Not IsDBNull(rdr("roomFood")) Then
                If rdr("roomFood") = 1 Then
                    vFood = "Yes"
                Else
                    vFood = "No"
                End If
            End If
            If Not IsDBNull(rdr("roomSR")) Then
                If rdr("roomSR") = 1 Then
                    vSR = "Yes"
                Else
                    vSR = "No"
                End If
            End If

            If CInt((rdr("roomendSlot"))) = 11 Or CInt((rdr("roomendSlot"))) = 22 Or CInt((rdr("roomendSlot"))) = 33 Or CInt((rdr("roomendSlot"))) = 44 Or CInt((rdr("roomendSlot"))) = 55 Or CInt((rdr("roomendSlot"))) = 66 Then
                vEndSlot = CInt((rdr("roomendSlot")))
            Else
                vEndSlot = CInt((rdr("roomendSlot")) + 1)
            End If

            If UCase(rdr("roomBookingStaffID").ToString) = UCase(rdr("roomBehalfOf").ToString) Then
                strIMG = ""
            Else
                strIMG = " style=""background-repeat: no-repeat; background-image: url('http://intranet/staff/pics/" + rdr("roomBookingStaffID").ToString + ".jpg')"""
                '                strIMG = "<img border=""0"" width=""77px"" height=""102px"" src=""http://intranet/staff/pics/" + rdr("roomBookingStaffID").ToString + ".jpg"">"
            End If


            strRows = "<table width=""90%"">"
            strRows = strRows + "<tr><th>Title</th><td style=""padding: 3px;"">" + rdr("roomBookingTitle").ToString + "</td><td style=""background-image: url('http://intranet/staff/pics/" + rdr("roomBehalfOf").ToString + ".jpg'); background-repeat: no-repeat;"" width=""154px"" height=""160px"" rowspan=""4"">&nbsp;</td></tr>"
            strRows = strRows + "<tr><th>Booked by</th><td style=""padding: 3px;"">" + rdr("roomBookingStaffID").ToString + " Ext: " + rdr("telephoneNumber").ToString + "</td></tr>"
            strRows = strRows + "<tr><th>On Behalf of</th><td style=""padding: 3px;"">" + rdr("beHalfName").ToString + "</td></tr>"
            strRows = strRows + "<tr><th>Time</th><td style=""padding: 3px;"">" + arrTimeDesc(CInt((rdr("roomStartSlot")))).ToString + " to " + arrTimeDesc(vEndSlot).ToString + "</td></tr>"
            strRows = strRows + "<tr><th>No. Attending</th><td style=""padding: 3px;"">" + rdr("roomNoAttending").ToString + "</td><td" + strIMG.ToString + " height=""160px"" rowspan=""3"">&nbsp;</td></tr>"
            strRows = strRows + "<tr><th>Food Required</th><td style=""padding: 3px;"">" + vFood.ToString + "</td></tr>"
            strRows = strRows + "<tr><th>Room Setup</th><td style=""padding: 3px;"">" + vSR.ToString + "</td></tr>"
            strRows = strRows + "<tr><th>Details</th><td style=""padding: 3px;"" colspan=""2"">" + rdr("roomBookingDesc").ToString + "</td></tr>"
            If vSR = "Yes" Then
                strRows = strRows + "<tr><th>Room Setup Details</th><td style=""padding: 3px;"" colspan=""2"">" + rdr("roomSRDetail").ToString + "</td></tr>"
            End If
            If vFood = "Yes" Then
                strRows = strRows + "<tr><th>Food Details</th><td style=""padding: 3px;"" colspan=""2"">" + rdr("roomFoodDetail").ToString + "</td></tr>"
            End If
        End While
        strRows = strRows + "<tr><td colspan=""2"">&nbsp;</td><td style=""text-align: center;""><A href=""javascript;"" onClick=""opener.location='editBooking.aspx?bookID=" + bookID.ToString + "'; self.close()"">Edit booking</a></td></tr></table>"
        rdr.Close()
            Com.Dispose()
            Con.Close()
            Con = Nothing
            booking.InnerHtml = strRows.ToString
    End Sub




End Class
