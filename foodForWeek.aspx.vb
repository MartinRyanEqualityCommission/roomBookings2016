Imports Aspose.Cells
Imports System.IO
Imports System.Collections.Generic



Partial Class _Default
    Inherits System.Web.UI.Page

    Dim arrRoom1(35) As Integer
    Dim arrBookingID(35) As String
    Dim arrRoomInfo1(35) As String
    Dim arrRow(7) As String
    Dim arrCell(35) As String
    Dim arrRoomID(35) As Integer

    Private Sub popData()
        Dim vSlotName As String = "slot"
        Dim btnRun As New Button
        Dim connString As String = ConfigurationManager.ConnectionStrings("roomsSQL").ConnectionString
        Dim strSQL As String
        Dim strShow As String = ""
        Dim curSlotID As Integer = 0
        Dim curDayMult As Integer = 0
        Dim strRows As String = ""
        Dim strTrust As String = ""
        Dim iCount As Integer = 0
        Dim i As Integer = 0
        Dim strClass As String = ""
        Dim Con As New System.Data.SqlClient.SqlConnection(connString)
        Dim stDate As New Date
        Dim enDate As New Date

        Dim arrTimeDesc(133) As String

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
        strSQL = "SELECT TROOMBOOKINGS.roomFoodDetail, isNull(COMMENTS,'') as Comments, TROOMBOOKINGS.roomBookingTitle, TROOMBOOKINGS.roomID, TROOMBOOKINGS.roomBookingDate, TROOMBOOKINGS.roomStartSlot, TROOMBOOKINGS.roomEndSlot, TROOMBOOKINGS.roomBookingStaffID, TROOMBOOKINGS.roomBookingID, TROOMBOOKINGS.roomNoAttending, TUSERS.name, TUSERS.telephoneNumber FROM TROOMBOOKINGS LEFT JOIN TUSERS ON TROOMBOOKINGS.roomBehalfOf = TUSERS.samAccountName WHERE roomFood=1 AND roomBookingDate BETWEEN '" + Month(stDate).ToString + "/" + Day(stDate).ToString + "/" + Year(stDate).ToString + "' AND '" + Month(enDate).ToString + "/" + Day(enDate).ToString + "/" + Year(enDate).ToString + "' ORDER BY roomBookingDate ASC, roomStartSlot ASC"
        'Response.Write(strSQL.ToString)
        Dim Com As New System.Data.SqlClient.SqlCommand(strSQL, Con)
        Dim rdr As System.Data.SqlClient.SqlDataReader = Com.ExecuteReader()
        Dim varNoAttending As Integer = 0
        Dim varComments As String = ""
        For i = 1 To 35
            arrRoom1(i) = "0"
            arrRoomInfo1(i) = ""
            arrCell(i) = ""
            arrRoomID(i) = 0
        Next

        While rdr.Read()
            iCount = iCount + 1
            curDayMult = DateDiff(DateInterval.Day, stDate, rdr("roomBookingDate")) + 1
            If Not IsDBNull(rdr("roomID")) Then
                If rdr("roomID") > 0 Then
                    curSlotID = rdr("roomID") + (7 * (curDayMult - 1))
                    If IsDBNull(rdr("roomNoAttending")) Then
                        varNoAttending = 0
                    Else
                        varNoAttending = rdr("roomNoAttending")
                    End If
                    If IsDBNull(rdr("Comments")) Then
                        varComments = ""
                    Else
                        varComments = "<br /><span style='color: red; font-weight: bold'>" + rdr("comments").ToString() + "</span>"
                    End If


                    arrRoomID(curSlotID) = rdr("roomID")
                    arrRoom1(curSlotID) = arrRoom1(curSlotID) + 1
                    arrRoomInfo1(curSlotID) = arrRoomInfo1(curSlotID) + "<strong><a title=""" + rdr("roomBookingTitle") + """ onclick=""javascript:window.open('displayBooking.aspx?bookID=" + CInt(rdr("roomBookingID")).ToString + "','','scrollbars=1,width=550,height=600,resizable=yes,location=no');return false;"" href=""#"">" + arrTimeDesc(CInt(rdr("roomStartSlot"))) + " - " + arrTimeDesc(CInt(rdr("roomEndSlot")) + 1) + "</a></strong><br>" + rdr("roomFoodDetail").ToString + " (" + varNoAttending.ToString + " Attendees)<br><strong>" + rdr("Name").ToString + " " + rdr("telephoneNumber").ToString + "</strong>" + varComments
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
                    arrCell(i) = arrCell(i) + arrRoomInfo1(i).ToString
                Else
                    arrRoomInfo1(i) = ""
                End If
            End If
        Next
        arrRow(1) = "<tr style=""background-color: #ffe6e6""><th style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"" valign=""top"">Board Room</th><td valign=""top"" width=""16%"" style=""background-color: #FFE1E1;"">" + arrCell(1).ToString + "</td><td valign=""top"" style=""padding: 5px;"" width=""16%"">" + arrCell(8).ToString + "</td><td valign=""top"" width=""16%"" style=""background-color: #FFE1E1; padding: 5px;"">" + arrCell(15).ToString + "</td><td valign=""top"" style=""padding: 5px;"" width=""16%"">" + arrCell(22).ToString + "</td><td valign=""top"" style=""background-color: #FFE1E1; padding: 5px;"" width=""16%"">" + arrCell(29).ToString + "</td></tr>"
        arrRow(2) = "<tr style=""background-color: #ffcccc""><th style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"" valign=""top"">Ante Room</th><td style=""padding: 5px; background-color: #FFC2C1;"" valign=""top"">" + arrCell(2).ToString + "</td><td style=""padding: 5px;"" valign=""top"">" + arrCell(9).ToString + "</td><td style=""padding: 5px; background-color: #FFC2C1;"" valign=""top"">" + arrCell(16).ToString + "</td><td style=""padding: 5px;"" valign=""top"">" + arrCell(23).ToString + "</td><td valign=""top"" style=""padding: 5px; background-color: #FFC2C1;"">" + arrCell(30).ToString + "</td></tr>"
        arrRow(3) = "<tr style=""display: none;""><th>Training Room</th><td>" + arrCell(3).ToString + "</td><td style=""border-bottom: 1px solid #808080;"">" + arrCell(10).ToString + "</td><td style=""border-bottom: 1px solid #808080;"">" + arrCell(17).ToString + "</td><td style=""border-bottom: 1px solid #808080;"">" + arrCell(24).ToString + "</td><td style=""border-bottom: 1px solid #808080;"">" + arrCell(31).ToString + "</td></tr>"
        arrRow(4) = "<tr style=""background-color: #ffe6e6; min-height: 60px;""><th valign=""top"" style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"">Meeting Room 3</th><td valign=""top"" style=""background-color: #FFE1E1; padding: 5px;"">" + arrCell(4).ToString + "</td><td valign=""top"">" + arrCell(11).ToString + "</td><td valign=""top"" style=""background-color: #FFE1E1; padding: 5px;"">" + arrCell(18).ToString + "</td><td valign=""top"">" + arrCell(25).ToString + "</td><td valign=""top"" style=""background-color: #FFE1E1; padding: 5px;"">" + arrCell(32).ToString + "</td></tr>"
        arrRow(5) = "<tr style=""background-color: #ffcccc; min-height: 60px;""><th valign=""top"" style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"">Meeting Room 1</th><td style=""padding: 5px; background-color: #FFC2C1;"" valign=""top"">" + arrCell(5).ToString + "</td><td valign=""top"">" + arrCell(12).ToString + "</td><td valign=""top"" style=""padding: 5px; background-color: #FFC2C1;"">" + arrCell(19).ToString + "</td><td valign=""top"">" + arrCell(26).ToString + "</td><td valign=""top"" style=""padding: 5px; background-color: #FFC2C1;"">" + arrCell(33).ToString + "</td></tr>"
        arrRow(6) = "<tr style=""background-color: #ffe6e6; min-height: 60px;""><th valign=""top"" style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"">Meeting Room 2 </th><td valign=""top"" style=""background-color: #FFE1E1; padding: 5px;"">" + arrCell(6).ToString + "</td><td valign=""top"">" + arrCell(13).ToString + "</td><td valign=""top"" style=""background-color: #FFE1E1; padding: 5px;"">" + arrCell(20).ToString + "</td><td valign=""top"">" + arrCell(27).ToString + "</td><td valign=""top"" style=""background-color: #FFE1E1; padding: 5px;"">" + arrCell(34).ToString + "</td></tr>"
        arrRow(7) = "<tr style=""background-color: #ffcccc; min-height: 60px;""><th valign=""top"" style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"">Glass Room </th><td valign=""top"" style=""padding: 5px; background-color: #FFC2C1;"">" + arrCell(7).ToString + "</td><td valign=""top"">" + arrCell(14).ToString + "</td><td valign=""top"" style=""padding: 5px; background-color: #FFC2C1;"">" + arrCell(21).ToString + "</td><td valign=""top"">" + arrCell(28).ToString + "</td><td valign=""top"" style=""padding: 5px; background-color: #FFC2C1;"">" + arrCell(35).ToString + "</td></tr>"
        strRows = arrRow(1) + arrRow(2) + arrRow(3) + arrRow(4) + arrRow(5) + arrRow(6) + arrRow(7)
        strRows = "<table width=""98%"" cellspacing=""0px"" cellpadding=""5px""><tr><th width=""170px"">&nbsp;</th><th style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"">MON</th><th style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"">TUE</th><th style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"">WED</th><th style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"">THU</th><th style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"">FRI</th></tr>" + strRows.ToString + "</table>"
        weekFoodDisplay.InnerHtml = strRows
    End Sub



    Public Class Booking

        Private strRoomDescription As String
        Private strMonday As String
        Private strTuesday As String
        Private strWednesday As String
        Private strThursday As String
        Private strFriday As String


        Public Property RoomDescription() As String
            Get
                Return strRoomDescription
            End Get
            Set(ByVal Value As String)
                strRoomDescription = Value
            End Set
        End Property

        Public Property Monday() As String
            Get
                Return strMonday
            End Get
            Set(ByVal Value As String)
                strMonday = Value
            End Set
        End Property


        Public Property Tuesday() As String
            Get
                Return strTuesday
            End Get
            Set(ByVal Value As String)
                strTuesday = Value
            End Set
        End Property


        Public Property Wednesday() As String
            Get
                Return strWednesday
            End Get
            Set(ByVal Value As String)
                strWednesday = Value
            End Set
        End Property


        Public Property Thursday() As String
            Get
                Return strThursday
            End Get
            Set(ByVal Value As String)
                strThursday = Value
            End Set
        End Property


        Public Property Friday() As String
            Get
                Return strFriday
            End Get
            Set(ByVal Value As String)
                strFriday = Value
            End Set
        End Property




    End Class


    Private Function popReport() As List(Of Booking)

        Dim BookingRecs As New List(Of Booking)()

        Dim vSlotName As String = "slot"
        Dim btnRun As New Button
        Dim connString As String = ConfigurationManager.ConnectionStrings("roomsSQL").ConnectionString
        Dim strSQL As String
        Dim strShow As String = ""
        Dim curSlotID As Integer = 0
        Dim curDayMult As Integer = 0
        Dim strRows As String = ""
        Dim strTrust As String = ""
        Dim iCount As Integer = 0
        Dim i As Integer = 0
        Dim strClass As String = ""
        Dim Con As New System.Data.SqlClient.SqlConnection(connString)
        Dim stDate As New Date
        Dim enDate As New Date

        Dim arrTimeDesc(133) As String

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
        strSQL = "SELECT TROOMBOOKINGS.roomFoodDetail, isNull(COMMENTS,'') as Comments, TROOMBOOKINGS.roomBookingTitle, TROOMBOOKINGS.roomID, TROOMBOOKINGS.roomBookingDate, TROOMBOOKINGS.roomStartSlot, TROOMBOOKINGS.roomEndSlot, TROOMBOOKINGS.roomBookingStaffID, TROOMBOOKINGS.roomBookingID, TROOMBOOKINGS.roomNoAttending, TUSERS.name, TUSERS.telephoneNumber FROM TROOMBOOKINGS LEFT JOIN TUSERS ON TROOMBOOKINGS.roomBehalfOf = TUSERS.samAccountName WHERE roomFood=1 AND roomBookingDate BETWEEN '" + Month(stDate).ToString + "/" + Day(stDate).ToString + "/" + Year(stDate).ToString + "' AND '" + Month(enDate).ToString + "/" + Day(enDate).ToString + "/" + Year(enDate).ToString + "' ORDER BY roomBookingDate ASC, roomStartSlot ASC"
        'Response.Write(strSQL.ToString)
        Dim Com As New System.Data.SqlClient.SqlCommand(strSQL, Con)
        Dim rdr As System.Data.SqlClient.SqlDataReader = Com.ExecuteReader()
        Dim varNoAttending As Integer = 0
        Dim varComments As String = ""
        For i = 1 To 35
            arrRoom1(i) = "0"
            arrRoomInfo1(i) = ""
            arrCell(i) = ""
            arrRoomID(i) = 0
        Next

        While rdr.Read()
            iCount = iCount + 1
            curDayMult = DateDiff(DateInterval.Day, stDate, rdr("roomBookingDate")) + 1
            If Not IsDBNull(rdr("roomID")) Then
                If rdr("roomID") > 0 Then
                    curSlotID = rdr("roomID") + (7 * (curDayMult - 1))
                    If IsDBNull(rdr("roomNoAttending")) Then
                        varNoAttending = 0
                    Else
                        varNoAttending = rdr("roomNoAttending")
                    End If
                    If IsDBNull(rdr("Comments")) Then
                        varComments = ""
                    Else
                        varComments = "<br /><span style='color: red; font-weight: bold'>" + rdr("comments").ToString() + "</span>"
                    End If


                    arrRoomID(curSlotID) = rdr("roomID")
                    arrRoom1(curSlotID) = arrRoom1(curSlotID) + 1
                    arrRoomInfo1(curSlotID) = arrRoomInfo1(curSlotID) + "<Font Style='FONT-FAMILY: Arial;FONT-SIZE: 9pt;COLOR: #539EFB;TEXT-ALIGN: left;FONT-WEIGHT: bold;'>" + rdr("roomBookingTitle").ToString().Replace("&", "&amp;") + " " + arrTimeDesc(CInt(rdr("roomStartSlot"))) + " - " + arrTimeDesc(CInt(rdr("roomEndSlot")) + 1) + "</Font><br /><Font Style='FONT-FAMILY: Arial;FONT-SIZE: 9pt;COLOR: #000000;TEXT-ALIGN: left;'>" + rdr("roomFoodDetail").ToString + " (" + varNoAttending.ToString + " Attendees)</Font><br /><Font Style='FONT-FAMILY: Arial;FONT-SIZE: 9pt;COLOR: #000000;TEXT-ALIGN: left;FONT-WEIGHT: bold;'>" + rdr("Name").ToString + " " + rdr("telephoneNumber").ToString + "</Font><br /><br />"
                End If
            End If
        End While
        rdr.Close()
        Com.Dispose()
        Con.Close()
        Con = Nothing
        For i = 1 To 35
            If Not IsNothing(arrRoom1(i)) Then
                If CInt(arrRoom1(i)) > 0 Then
                    arrCell(i) = arrCell(i) + arrRoomInfo1(i).ToString
                Else
                    arrRoomInfo1(i) = ""
                End If
            End If
        Next



        Dim BookingRow1 As New Booking
        BookingRow1.RoomDescription = "Board Room"
        BookingRow1.Monday = arrCell(1).ToString()
        BookingRow1.Tuesday = arrCell(8).ToString()
        BookingRow1.Wednesday = arrCell(15).ToString()
        BookingRow1.Thursday = arrCell(22).ToString()
        BookingRow1.Friday = arrCell(29).ToString()

        Dim BookingRow2 As New Booking
        BookingRow2.RoomDescription = "Ante Room"
        BookingRow2.Monday = arrCell(2).ToString()
        BookingRow2.Tuesday = arrCell(9).ToString()
        BookingRow2.Wednesday = arrCell(16).ToString()
        BookingRow2.Thursday = arrCell(23).ToString()
        BookingRow2.Friday = arrCell(30).ToString()

        Dim BookingRow3 As New Booking
        BookingRow3.RoomDescription = "Meeting Room 3"
        BookingRow3.Monday = arrCell(4).ToString()
        BookingRow3.Tuesday = arrCell(11).ToString()
        BookingRow3.Wednesday = arrCell(18).ToString()
        BookingRow3.Thursday = arrCell(25).ToString()
        BookingRow3.Friday = arrCell(32).ToString()


        Dim BookingRow4 As New Booking
        BookingRow4.RoomDescription = "Meeting Room 1"
        BookingRow4.Monday = arrCell(5).ToString()
        BookingRow4.Tuesday = arrCell(12).ToString()
        BookingRow4.Wednesday = arrCell(19).ToString()
        BookingRow4.Thursday = arrCell(26).ToString()
        BookingRow4.Friday = arrCell(33).ToString()



        Dim BookingRow5 As New Booking
        BookingRow5.RoomDescription = "Meeting Room 2"
        BookingRow5.Monday = arrCell(6).ToString()
        BookingRow5.Tuesday = arrCell(13).ToString()
        BookingRow5.Wednesday = arrCell(20).ToString()
        BookingRow5.Thursday = arrCell(27).ToString()
        BookingRow5.Friday = arrCell(34).ToString()


        Dim BookingRow6 As New Booking
        BookingRow6.RoomDescription = "Glass Room"
        BookingRow6.Monday = arrCell(7).ToString()
        BookingRow6.Tuesday = arrCell(14).ToString()
        BookingRow6.Wednesday = arrCell(21).ToString()
        BookingRow6.Thursday = arrCell(28).ToString()
        BookingRow6.Friday = arrCell(35).ToString()
        arrRow(1) = "<tr style=""background-color: #ffe6e6""><th style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"" valign=""top"">Board Room</th><td valign=""top"" width=""16%"" style=""background-color: #FFE1E1;"">" + arrCell(1).ToString + "</td><td valign=""top"" style=""padding: 5px;"" width=""16%"">" + arrCell(8).ToString + "</td><td valign=""top"" width=""16%"" style=""background-color: #FFE1E1; padding: 5px;"">" + arrCell(15).ToString + "</td><td valign=""top"" style=""padding: 5px;"" width=""16%"">" + arrCell(22).ToString + "</td><td valign=""top"" style=""background-color: #FFE1E1; padding: 5px;"" width=""16%"">" + arrCell(29).ToString + "</td></tr>"
        arrRow(2) = "<tr style=""background-color: #ffcccc""><th style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"" valign=""top"">Ante Room</th><td style=""padding: 5px; background-color: #FFC2C1;"" valign=""top"">" + arrCell(2).ToString + "</td><td style=""padding: 5px;"" valign=""top"">" + arrCell(9).ToString + "</td><td style=""padding: 5px; background-color: #FFC2C1;"" valign=""top"">" + arrCell(16).ToString + "</td><td style=""padding: 5px;"" valign=""top"">" + arrCell(23).ToString + "</td><td valign=""top"" style=""padding: 5px; background-color: #FFC2C1;"">" + arrCell(30).ToString + "</td></tr>"
        arrRow(3) = "<tr style=""display: none;""><th>Training Room</th><td>" + arrCell(3).ToString + "</td><td style=""border-bottom: 1px solid #808080;"">" + arrCell(10).ToString + "</td><td style=""border-bottom: 1px solid #808080;"">" + arrCell(17).ToString + "</td><td style=""border-bottom: 1px solid #808080;"">" + arrCell(24).ToString + "</td><td style=""border-bottom: 1px solid #808080;"">" + arrCell(31).ToString + "</td></tr>"
        arrRow(4) = "<tr style=""background-color: #ffe6e6; min-height: 60px;""><th valign=""top"" style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"">Meeting Room 3</th><td valign=""top"" style=""background-color: #FFE1E1; padding: 5px;"">" + arrCell(4).ToString + "</td><td valign=""top"">" + arrCell(11).ToString + "</td><td valign=""top"" style=""background-color: #FFE1E1; padding: 5px;"">" + arrCell(18).ToString + "</td><td valign=""top"">" + arrCell(25).ToString + "</td><td valign=""top"" style=""background-color: #FFE1E1; padding: 5px;"">" + arrCell(32).ToString + "</td></tr>"
        arrRow(5) = "<tr style=""background-color: #ffcccc; min-height: 60px;""><th valign=""top"" style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"">Meeting Room 1</th><td style=""padding: 5px; background-color: #FFC2C1;"" valign=""top"">" + arrCell(5).ToString + "</td><td valign=""top"">" + arrCell(12).ToString + "</td><td valign=""top"" style=""padding: 5px; background-color: #FFC2C1;"">" + arrCell(19).ToString + "</td><td valign=""top"">" + arrCell(26).ToString + "</td><td valign=""top"" style=""padding: 5px; background-color: #FFC2C1;"">" + arrCell(33).ToString + "</td></tr>"
        arrRow(6) = "<tr style=""background-color: #ffe6e6; min-height: 60px;""><th valign=""top"" style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"">Meeting Room 2 </th><td valign=""top"" style=""background-color: #FFE1E1; padding: 5px;"">" + arrCell(6).ToString + "</td><td valign=""top"">" + arrCell(13).ToString + "</td><td valign=""top"" style=""background-color: #FFE1E1; padding: 5px;"">" + arrCell(20).ToString + "</td><td valign=""top"">" + arrCell(27).ToString + "</td><td valign=""top"" style=""background-color: #FFE1E1; padding: 5px;"">" + arrCell(34).ToString + "</td></tr>"
        arrRow(7) = "<tr style=""background-color: #ffcccc; min-height: 60px;""><th valign=""top"" style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"">Glass Room </th><td valign=""top"" style=""padding: 5px; background-color: #FFC2C1;"">" + arrCell(7).ToString + "</td><td valign=""top"">" + arrCell(14).ToString + "</td><td valign=""top"" style=""padding: 5px; background-color: #FFC2C1;"">" + arrCell(21).ToString + "</td><td valign=""top"">" + arrCell(28).ToString + "</td><td valign=""top"" style=""padding: 5px; background-color: #FFC2C1;"">" + arrCell(35).ToString + "</td></tr>"
        strRows = arrRow(1) + arrRow(2) + arrRow(3) + arrRow(4) + arrRow(5) + arrRow(6) + arrRow(7)
        strRows = "<table width=""98%"" cellspacing=""0px"" cellpadding=""5px""><tr><th width=""170px"">&nbsp;</th><th style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"">MON</th><th style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"">TUE</th><th style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"">WED</th><th style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"">THU</th><th style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"">FRI</th></tr>" + strRows.ToString + "</table>"
        weekFoodDisplay.InnerHtml = strRows

        BookingRecs.Add(BookingRow1)
        BookingRecs.Add(BookingRow2)
        BookingRecs.Add(BookingRow3)
        BookingRecs.Add(BookingRow4)
        BookingRecs.Add(BookingRow5)
        BookingRecs.Add(BookingRow6)

        Return BookingRecs
    End Function

    Private Sub displayDay()
        lblDayDesc.Text = "<span style=""color: #000; text-decoration: underline;"">Housekeeper Schedule</span> : Week Commencing " + CDate(txtCurrentDate.Text).DayOfWeek.ToString + " " + CDate(txtCurrentDate.Text).Day.ToString + " " + MonthName(CDate(txtCurrentDate.Text).Month).ToString
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


    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintOut.Click
        Dim dataDir As String = "E:\inetpub\MISDOTNET\VisitorRoomBookingSystem"
        Dim row As Integer = -1

        Dim BookingRecs As New List(Of Booking)
        BookingRecs = popReport()

        Dim fstream As FileStream = New FileStream("E:\inetpub\MISDOTNET\VisitorRoomBookingSystem\FoodPrintOut.xlsx", FileMode.Open)
        Dim workbook As Workbook = New Workbook(fstream)

        For Each Booking In BookingRecs
            row = row + 1
            Dim B3 As Cell = workbook.Worksheets(0).Cells("B" & (row + 3).ToString())
            B3.HtmlString = BookingRecs(row).Monday.ToString()
            Dim style As Style = B3.GetStyle()
            style.IsTextWrapped = True
            style.VerticalAlignment = TextAlignmentType.Top
            B3.SetStyle(style)

            Dim C3 As Cell = workbook.Worksheets(0).Cells("C" & (row + 3).ToString())
            C3.HtmlString = BookingRecs(row).Tuesday.ToString()
            C3.SetStyle(style)

            Dim D3 As Cell = workbook.Worksheets(0).Cells("D" & (row + 3).ToString())
            D3.HtmlString = BookingRecs(row).Wednesday.ToString()
            D3.SetStyle(style)

            Dim E3 As Cell = workbook.Worksheets(0).Cells("E" & (row + 3).ToString())
            E3.HtmlString = BookingRecs(row).Thursday.ToString()
            E3.SetStyle(style)

            Dim F3 As Cell = workbook.Worksheets(0).Cells("F" & (row + 3).ToString())
            F3.HtmlString = BookingRecs(row).Friday.ToString()
            F3.SetStyle(style)
        Next

        workbook.Worksheets(0).Cells("B1").HtmlString = "Housekeeper Schedule : Week Commencing " + CDate(txtCurrentDate.Text).DayOfWeek.ToString + " " + CDate(txtCurrentDate.Text).Day.ToString + " " + MonthName(CDate(txtCurrentDate.Text).Month).ToString

        workbook.Worksheets(0).AutoFitRows()
        workbook.Save(HttpContext.Current.Response, "Output.xlsx", ContentDisposition.Attachment, New OoxmlSaveOptions(SaveFormat.Xlsx))
        fstream.Close()
    End Sub

    Protected Sub btnPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        If IsDate(txtCurrentDate.Text) Then
            txtCurrentDate.Text = Left(DateAdd(DateInterval.Day, -7, CDate(txtCurrentDate.Text)).ToString, 10).ToString
            displayDay()
        End If
        popData()
    End Sub

End Class