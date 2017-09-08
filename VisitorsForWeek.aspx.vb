Imports System.Collections.Generic
Imports System.IO
Imports Aspose.Cells

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim arrRoom1(5) As Integer
    Dim arrBookingID(5) As String
    Dim arrRoomInfo1(5) As String
    Dim arrRow(1) As String
    Dim arrCell(5) As String
    Dim arrRoomID(5) As Integer


    Public Class visitor
        Private _SpecialRequirements As String
        Private _VisitorName As String
        Public Property SpecialRequirements() As String
            Get
                Return _SpecialRequirements
            End Get
            Set(ByVal value As String)
                _SpecialRequirements = value
            End Set
        End Property

        Public Property VisitorName() As String
            Get
                Return _VisitorName
            End Get
            Set(ByVal value As String)
                _VisitorName = value
            End Set
        End Property

    End Class



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


        Dim arrRoomDesc(7) As String
        arrRoomDesc(1) = "Board Room"
        arrRoomDesc(2) = "Ante Room"
        arrRoomDesc(3) = "Meeting Room 3 (1st Floor)"
        arrRoomDesc(4) = "Meeting Room 1"
        arrRoomDesc(5) = "Meeting Room 2"
        arrRoomDesc(6) = "Meeting Room 4 - Glass Room (4th Floor)"
        arrRoomDesc(7) = ""

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
        strSQL = "SELECT *,  isNull(TUSERS.telephoneNumber,'') as vExt, isNull(TUSERS.name,'') as vName, isNull(VisitorInstructions,'') as vVisitorInstructions, isNull(TVISITORS.visitorStartTime,0) as vStartTime, isNull(TVISITORS.visitorCompany,'') as vCompany, isNull(TVISITORS.visitorjobDetails,'') as vJobDetails, isNull(TVISITORS.visitorDeliveryDetails,'') as vDeliveryDetails, roomStartTime=(SELECT isNull(roomStartSlot,0) FROM TROOMBOOKINGS WHERE Convert(VARCHAR(255), TROOMBOOKINGS.visitorGUID)=Convert(VARCHAR(255), TVISITORS.visitorGUID)), roomID=(SELECT isNull(roomID,0) FROM TROOMBOOKINGS WHERE Convert(VARCHAR(255), TROOMBOOKINGS.visitorGUID)=Convert(VARCHAR(255), TVISITORS.visitorGUID)) FROM TVISITORS LEFT JOIN TUSERS ON TVISITORS.visitorContactOnArrival = TUSERS.samAccountName WHERE visitorDate BETWEEN '" + Month(stDate).ToString + "/" + Day(stDate).ToString + "/" + Year(stDate).ToString + "' AND '" + Month(enDate).ToString + "/" + Day(enDate).ToString + "/" + Year(enDate).ToString + "' ORDER BY visitorDate, visitorStartTime ASC"
        'Response.Write(strSQL.ToString)
        Dim Com As New System.Data.SqlClient.SqlCommand(strSQL, Con)
        Dim rdr As System.Data.SqlClient.SqlDataReader = Com.ExecuteReader()
        Dim varNoAttending As Integer = 0
        Dim varComments As String = ""
        Dim BookingRow1 As New Booking
        Dim strVisitorList As String = ""
        Dim strHeading As String = ""
        Dim strBehalfoff As String = ""
        Dim strCompany As String = ""
        Dim strDeliveryDetails As String = ""
        Dim strVisitorInstructions As String = ""
        Dim strJobDetails As String = ""
        Dim strStartTime As String = ""
        Dim strRoomDesc As String = ""
        Dim strExt As String = ""
        Dim visitorNo As Integer = 0

        BookingRow1.RoomDescription = "Visitors"

        BookingRow1.Monday = ""
        BookingRow1.Tuesday = ""
        BookingRow1.Wednesday = ""
        BookingRow1.Thursday = ""
        BookingRow1.Friday = ""

        While rdr.Read()
            iCount = iCount + 1
            strCompany = ""

            strHeading = ""
            strExt = rdr("vExt")
            strBehalfoff = rdr("vName")
            strDeliveryDetails = rdr("vDeliveryDetails")
            strVisitorInstructions = rdr("vVisitorInstructions")
            strCompany = rdr("vCompany")
            strJobDetails = rdr("vJobDetails")
            strStartTime = ""
            visitorNo = 0
            If IsDate(rdr("visitorDate")) Then

                If CInt(rdr("vStartTime")) > 0 Then
                    strStartTime = arrTimeDesc(CInt(rdr("vStartTime")))
                End If


                If strStartTime = "" Then
                    If Not IsDBNull(rdr("roomStartTime")) Then
                        If CInt(rdr("roomStartTime")) > 0 Then
                            strStartTime = arrTimeDesc(CInt(rdr("roomStartTime")))
                        End If
                    End If
                End If

                If Not IsDBNull(rdr("roomID")) Then
                    If CInt(rdr("roomID")) > 0 Then
                        strRoomDesc = " in " + arrRoomDesc(CInt(rdr("roomID").ToString()))
                    End If
                End If

                If Not IsDBNull(rdr("visitorNo")) Then
                    If CInt(rdr("visitorNo")) > 0 Then
                        visitorNo = CInt(rdr("visitorNo").ToString())
                    End If
                End If



                If strVisitorInstructions.Length > 0 Then
                    strVisitorInstructions = "<br /><strong>" + strVisitorInstructions + "</strong>"
                End If

                If IsNumeric(rdr("visitorType")) Then
                    If CInt(rdr("visitorType")) = 1 Then
                        strHeading = "Stakeholder / Customer"
                        If (CDate(rdr("visitorDate")).DayOfWeek = DayOfWeek.Monday) Then
                            BookingRow1.Monday += "<div style='background-color: #e6f2ff; border: 1px solid #003166; padding: 3px'><div style='background-color: #003166; color: #FFFFFF; padding: 3px'><strong>Stakeholder / Customer</strong><br /><strong>" & strStartTime & strRoomDesc & "</strong></div>" + getVisitorListHTML(rdr("visitorNames").ToString(), visitorNo) + "<div style='color: #0066ff; padding: 3px; background-color: #b3d1ff'>Please Contact <strong>" + strBehalfoff + " " + strExt + "</strong> on Arrival" + strVisitorInstructions + "</div></div>"
                        End If
                        If (CDate(rdr("visitorDate")).DayOfWeek = DayOfWeek.Tuesday) Then
                            BookingRow1.Tuesday += "<div style='background-color: #e6f2ff; border: 1px solid #003166; padding: 3px'><div style='background-color: #003166; color: #FFFFFF; padding: 3px'><strong>Stakeholder / Customer</strong><br /><strong>" & strStartTime & strRoomDesc & "</strong></div>" + getVisitorListHTML(rdr("visitorNames").ToString(), visitorNo) + "<div style='color: #0066ff; padding: 3px; background-color: #b3d1ff'>Please Contact <strong>" + strBehalfoff + " " + strExt + "</strong> on Arrival" + strVisitorInstructions + "</div></div>"
                        End If
                        If (CDate(rdr("visitorDate")).DayOfWeek = DayOfWeek.Wednesday) Then
                            BookingRow1.Wednesday += "<div style='background-color: #e6f2ff; border: 1px solid #003166; padding: 3px'><div style='background-color: #003166; color: #FFFFFF; padding: 3px'><strong>Stakeholder / Customer</strong><br /><strong>" & strStartTime & strRoomDesc & "</strong></div>" + getVisitorListHTML(rdr("visitorNames").ToString(), visitorNo) + "<div style='color: #0066ff; padding: 3px; background-color: #b3d1ff'>Please Contact <strong>" + strBehalfoff + " " + strExt + "</strong> on Arrival" + strVisitorInstructions + "</div></div>"
                        End If
                        If (CDate(rdr("visitorDate")).DayOfWeek = DayOfWeek.Thursday) Then
                            BookingRow1.Thursday += "<div style='background-color: #e6f2ff; border: 1px solid #003166; padding: 3px'><div style='background-color: #003166; color: #FFFFFF; padding: 3px'><strong>Stakeholder / Customer</strong><br /><strong>" & strStartTime & strRoomDesc & "</strong></div>" + getVisitorListHTML(rdr("visitorNames").ToString(), visitorNo) + "<div style='color: #0066ff; padding: 3px; background-color: #b3d1ff'>Please Contact <strong>" + strBehalfoff + " " + strExt + "</strong> on Arrival" + strVisitorInstructions + "</div></div>"
                        End If
                        If (CDate(rdr("visitorDate")).DayOfWeek = DayOfWeek.Friday) Then
                            BookingRow1.Friday += "<div style='background-color: #e6f2ff; border: 1px solid #003166; padding: 3px'><div style='background-color: #003166; color: #FFFFFF; padding: 3px'><strong>Stakeholder / Customer</strong><br /><strong>" & strStartTime & strRoomDesc & "</strong></div>" + getVisitorListHTML(rdr("visitorNames").ToString(), visitorNo) + "<div style='color: #0066ff; padding: 3px; background-color: #b3d1ff'>Please Contact <strong>" + strBehalfoff + " " + strExt + "</strong> on Arrival" + strVisitorInstructions + "</div></div>"
                        End If
                    End If
                    If CInt(rdr("visitorType")) = 2 Then
                        strHeading = "Maintenance"


                        If (CDate(rdr("visitorDate")).DayOfWeek = DayOfWeek.Monday) Then
                            BookingRow1.Monday += "<div style='background-color: #ECFBEA; border: 1px solid #2e2e1f; padding: 3px'><div style='background-color: #2e2e1f; color: #FFFFFF; padding: 3px'><strong>Maintenance by " + strCompany + " " & strStartTime & "</strong></div><div style='color: #2e2e1f; padding: 3px'><strong>" & strJobDetails & "</strong></div><div style='color: #3d3d29; padding: 3px; background-color: #a2a276'>Please Contact <strong>" + strBehalfoff + " " + strExt + "</strong> on Arrival</div></div>"
                        End If
                        If (CDate(rdr("visitorDate")).DayOfWeek = DayOfWeek.Tuesday) Then
                            BookingRow1.Tuesday += "<div style='background-color: #ECFBEA; border: 1px solid #2e2e1f; padding: 3px'><div style='background-color: #2e2e1f; color: #FFFFFF; padding: 3px'><strong>Maintenance by " + strCompany + " " & strStartTime & "</strong></div><div style='color: #2e2e1f; padding: 3px'><strong>" & strJobDetails & "</strong></div><div style='color: #3d3d29; padding: 3px; background-color: #a2a276'>Please Contact <strong>" + strBehalfoff + " " + strExt + "</strong> on Arrival</div></div>"
                        End If
                        If (CDate(rdr("visitorDate")).DayOfWeek = DayOfWeek.Wednesday) Then
                            BookingRow1.Wednesday += "<div style='background-color: #ECFBEA; border: 1px solid #2e2e1f; padding: 3px'><div style='background-color: #2e2e1f; color: #FFFFFF; padding: 3px'><strong>Maintenance by " + strCompany + " " & strStartTime & "</strong></div><div style='color: #2e2e1f; padding: 3px'><strong>" & strJobDetails & "</strong></div><div style='color: #3d3d29; padding: 3px; background-color: #a2a276'>Please Contact <strong>" + strBehalfoff + " " + strExt + "</strong> on Arrival</div></div>"
                        End If
                        If (CDate(rdr("visitorDate")).DayOfWeek = DayOfWeek.Thursday) Then
                            BookingRow1.Thursday += "<div style='background-color: #ECFBEA; border: 1px solid #2e2e1f; padding: 3px'><div style='background-color: #2e2e1f; color: #FFFFFF; padding: 3px'><strong>Maintenance by " + strCompany + " " & strStartTime & "</strong></div><div style='color: #2e2e1f; padding: 3px'><strong>" & strJobDetails & "</strong></div><div style='color: #3d3d29; padding: 3px; background-color: #a2a276'>Please Contact <strong>" + strBehalfoff + " " + strExt + "</strong> on Arrival</div></div>"
                        End If
                        If (CDate(rdr("visitorDate")).DayOfWeek = DayOfWeek.Friday) Then
                            BookingRow1.Friday += "<div style='background-color: #ECFBEA; border: 1px solid #2e2e1f; padding: 3px'><div style='background-color: #2e2e1f; color: #FFFFFF; padding: 3px'><strong>Maintenance by " + strCompany + " " & strStartTime & "</strong></div><div style='color: #2e2e1f; padding: 3px'><strong>" & strJobDetails & "</strong></div><div style='color: #3d3d29; padding: 3px; background-color: #a2a276'>Please Contact <strong>" + strBehalfoff + " " + strExt + "</strong> on Arrival</div></div>"
                        End If
                    End If

                    If CInt(rdr("visitorType")) = 3 Then
                        strHeading = "Delivery"
                        If (CDate(rdr("visitorDate")).DayOfWeek = DayOfWeek.Monday) Then
                            BookingRow1.Monday += "<div style='background-color: #ffe6ef; border: 1px solid #4d001d; padding: 3px'><div style='background-color: #4d001d; color: #FFFFFF; padding: 3px'><strong>Delivery by " + strCompany + " " & strStartTime & "</strong></div><div style='color: #2e2e1f; padding: 3px'><strong>" & strDeliveryDetails & "</strong></div><div style='color: #b30041; padding: 3px; background-color: #ffb3cf'>Please Contact <strong>" + strBehalfoff + " " + strExt + "</strong> on Arrival</div></div>"
                        End If
                        If (CDate(rdr("visitorDate")).DayOfWeek = DayOfWeek.Tuesday) Then
                            BookingRow1.Tuesday += "<div style='background-color: #ffe6ef; border: 1px solid #4d001d; padding: 3px'><div style='background-color: #4d001d; color: #FFFFFF; padding: 3px'><strong>Delivery by " + strCompany + " " & strStartTime & "</strong></div><div style='color: #2e2e1f; padding: 3px'><strong>" & strDeliveryDetails & "</strong></div><div style='color: #b30041; padding: 3px; background-color: #ffb3cf'>Please Contact <strong>" + strBehalfoff + " " + strExt + "</strong> on Arrival</div></div>"
                        End If
                        If (CDate(rdr("visitorDate")).DayOfWeek = DayOfWeek.Wednesday) Then
                            BookingRow1.Wednesday += "<div style='background-color: #ffe6ef; border: 1px solid #4d001d; padding: 3px'><div style='background-color: #4d001d; color: #FFFFFF; padding: 3px'><strong>Delivery by " + strCompany + " " & strStartTime & "</strong></div><div style='color: #2e2e1f; padding: 3px'><strong>" & strDeliveryDetails & "</strong></div><div style='color: #b30041; padding: 3px; background-color: #ffb3cf'>Please Contact <strong>" + strBehalfoff + " " + strExt + "</strong> on Arrival</div></div>"
                        End If
                        If (CDate(rdr("visitorDate")).DayOfWeek = DayOfWeek.Thursday) Then
                            BookingRow1.Thursday += "<div style='background-color: #ffe6ef; border: 1px solid #4d001d; padding: 3px'><div style='background-color: #4d001d; color: #FFFFFF; padding: 3px'><strong>Delivery by " + strCompany + " " & strStartTime & "</strong></div><div style='color: #2e2e1f; padding: 3px'><strong>" & strDeliveryDetails & "</strong></div><div style='color: #b30041; padding: 3px; background-color: #ffb3cf'>Please Contact <strong>" + strBehalfoff + " " + strExt + "</strong> on Arrival</div></div>"
                        End If
                        If (CDate(rdr("visitorDate")).DayOfWeek = DayOfWeek.Friday) Then
                            BookingRow1.Friday += "<div style='background-color: #ffe6ef; border: 1px solid #4d001d; padding: 3px'><div style='background-color: #4d001d; color: #FFFFFF; padding: 3px'><strong>Delivery by " + strCompany + " " & strStartTime & "</strong></div><div style='color: #2e2e1f; padding: 3px'><strong>" & strDeliveryDetails & "</strong></div><div style='color: #b30041; padding: 3px; background-color: #ffb3cf'>Please Contact <strong>" + strBehalfoff + " " + strExt + "</strong> on Arrival</div></div>"
                        End If
                    End If


                End If


            End If
            '"<strong><a title=""" + rdr("roomBookingTitle") + """ onclick=""javascript:window.open('displayBooking.aspx?bookID=" + CInt(rdr("roomBookingID")).ToString + "','','scrollbars=1,width=500,height=400,resizable=yes,location=no');return false;"" href=""#"">" + arrTimeDesc(CInt(rdr("roomStartSlot"))) + " - " + arrTimeDesc(vEndSlot) + "</a></strong><br>" + rdr("roomSRDetail").ToString + " (" + varNoAttending.ToString + " Attendees)" + varComments
        End While
        'Response.Write(iCount.ToString)
        rdr.Close()
        Com.Dispose()
        Con.Close()
        Con = Nothing
        arrRow(1) = "<tr style=""background-color: #ECFBEA;""><th style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px; min-height: 60px;"">" & BookingRow1.RoomDescription & "</th><td style=""background-color: #E3F9E3; padding: 4px;"" valign=""top"" width=""16%"">" + BookingRow1.Monday.ToString + "</td><td style=""padding: 5px;"" valign=""top"" width=""16%"">" + BookingRow1.Tuesday.ToString + "</td><td style=""background-color: #E3F9E3; padding: 5px;"" valign=""top"" width=""16%"">" + BookingRow1.Wednesday.ToString + "</td><td valign=""top"" style=""padding: 5px;"" width=""16%"">" + BookingRow1.Thursday.ToString + "</td><td style=""background-color: #E3F9E3; padding: 5px;"" valign=""top"" width=""16%"">" + BookingRow1.Friday.ToString + "</td></tr>"
        strRows = arrRow(1)
        strRows = "<table width=""98%"" cellspacing=""1px""><tr><th width=""170px"">&nbsp;</th><th style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"">MON</th><th style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"">TUE</th><th style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"">WED</th><th style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"">THU</th><th style=""text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"">FRI</th></tr>" + strRows.ToString + "</table>"
        weekSetupDisplay.InnerHtml = strRows
    End Sub


    Public Function getVisitorListHTML(ByVal VisitorNames As String, Optional ByVal visitorNo As Integer = 0) As String
        Dim lstVisitors As New List(Of visitor)
        Dim retVisitorListHTML As String = ""
        Dim v As New visitor()
        Dim json = VisitorNames.ToString()
        Dim jss As New System.Web.Script.Serialization.JavaScriptSerializer()
        Dim strColor As String = ""
        Dim i As Integer = 0

        If (json.Length > 0) Then
            lstVisitors = jss.Deserialize(Of List(Of visitor))(json)
        End If
        Dim jSearializer As New System.Web.Script.Serialization.JavaScriptSerializer()

        If (lstVisitors.Count > 0) Then
            retVisitorListHTML += "<div style='background-color: #0063cc; padding: 3px; color: #FFFFFF;'><strong>Visitors (" & visitorNo & ")</strong></div>"
        End If
        For Each vis In lstVisitors
            strColor = "#efefef"
            i += 1
            If i Mod 2 > 0 Then
                strColor = "#FFFFFF"
            End If
            retVisitorListHTML += "<div style='background-color: " & strColor & "; padding: 3px;'><strong>" + vis.VisitorName + "</strong></div>"
            If vis.SpecialRequirements.Length > 0 Then retVisitorListHTML += "<div style='background-color: " & strColor & "; padding: 3px;'><span style='color: darkgrey; font-size: smaller'>" + vis.SpecialRequirements + "</span></div>"
            'retVisitorListHTML += "<br />"
        Next
        Return retVisitorListHTML
    End Function


    Private Sub displayDay()
        lblDayDesc.Text = "<span style=""color: #000; text-decoration: underline;"">Room Setup Schedule</span> : Week Commencing " + CDate(txtCurrentDate.Text).DayOfWeek.ToString + " " + CDate(txtCurrentDate.Text).Day.ToString + " " + MonthName(CDate(txtCurrentDate.Text).Month).ToString
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

    Public Class singlevisitor

        Private strFullName As String
        Private strSpecialRequirements As String


        Public Property FullName() As String
            Get
                Return strFullName
            End Get
            Set(ByVal Value As String)
                strFullName = Value
            End Set
        End Property

        Public Property SpecialRequirements() As String
            Get
                Return strSpecialRequirements
            End Get
            Set(ByVal Value As String)
                strSpecialRequirements = Value
            End Set
        End Property

    End Class

    Public Class visitorBooking

        Private strVisitStartTime As String
        Private strDetails As String
        Private strVisitType As String
        Private strVisitContact As String
        Private strRoomDesc As String
        Private intVisitorNo As Integer
        Private lstVisitors As New Generic.List(Of visitor)

        Public Property VisitorNo() As Integer
            Get
                Return intVisitorNo
            End Get
            Set(ByVal Value As Integer)
                intVisitorNo = Value
            End Set
        End Property

        Public Property VisitorRoomDesc() As String
            Get
                Return strRoomDesc
            End Get
            Set(ByVal Value As String)
                strRoomDesc = Value
            End Set
        End Property

        Public Property VisitorStartTime() As String
            Get
                Return strVisitStartTime
            End Get
            Set(ByVal Value As String)
                strVisitStartTime = Value
            End Set
        End Property

        Public Property Details() As String
            Get
                Return strDetails
            End Get
            Set(ByVal Value As String)
                strDetails = Value
            End Set
        End Property


        Public Property VisitType() As String
            Get
                Return strVisitType
            End Get
            Set(ByVal Value As String)
                strVisitType = Value
            End Set
        End Property


        Public Property VisitContact() As String
            Get
                Return strVisitContact
            End Get
            Set(ByVal Value As String)
                strVisitContact = Value
            End Set
        End Property

        Public Property Visitors() As Generic.List(Of visitor)
            Get
                Return lstVisitors
            End Get
            Set(ByVal Value As Generic.List(Of visitor))
                lstVisitors = Value
            End Set
        End Property
    End Class






    Public Function popReport(ByVal vday As Integer) As List(Of visitorBooking)

        Dim BookingRecs As New List(Of visitorBooking)()

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

        Dim arrRoomDesc(7) As String
        arrRoomDesc(1) = "Board Room"
        arrRoomDesc(2) = "Ante Room"
        arrRoomDesc(3) = "Meeting Room 3 (1st Floor)"
        arrRoomDesc(4) = "Meeting Room 1"
        arrRoomDesc(5) = "Meeting Room 2"
        arrRoomDesc(6) = "Meeting Room 4 - Glass Room (4th Floor)"
        arrRoomDesc(7) = ""

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

        strSQL = "SELECT *, isNull(TUSERS.name,'') as vName, isNull(visitorNo,0) as vVisitorNo, isNull(visitorInstructions,'') as vInstructions, isNull(TVISITORS.visitorStartTime,0) as vStartTime, isNull(TVISITORS.visitorType,0) as vType, isNull(TVISITORS.visitorCompany,'') as vCompany, isNull(TVISITORS.visitorjobDetails,'') as vJobDetails, isNull(TVISITORS.visitorDeliveryDetails,'') as vDeliveryDetails , roomStartTime=(SELECT isNull(roomStartSlot,0) FROM TROOMBOOKINGS WHERE Convert(VARCHAR(255), TROOMBOOKINGS.visitorGUID)=Convert(VARCHAR(255), TVISITORS.visitorGUID)), roomID=(SELECT isNull(roomID,0) FROM TROOMBOOKINGS WHERE Convert(VARCHAR(255), TROOMBOOKINGS.visitorGUID)=Convert(VARCHAR(255), TVISITORS.visitorGUID)) FROM TVISITORS LEFT JOIN TUSERS ON TVISITORS.visitorContactOnArrival = TUSERS.samAccountName WHERE visitorDate BETWEEN convert(smalldatetime,'" + stDate.ToString() + "',103) AND convert(smalldatetime,'" + enDate.ToString + "',103) ORDER BY visitorDate, visitorStartTime ASC"
        'Response.Write(strSQL.ToString)
        Dim Com As New System.Data.SqlClient.SqlCommand(strSQL, Con)
        Dim rdr As System.Data.SqlClient.SqlDataReader = Com.ExecuteReader()
        Dim varNoAttending As Integer = 0
        Dim varComments As String = ""

        While rdr.Read()
            If (IsDate(rdr("visitorDate").ToString())) Then
                If CDate(rdr("visitorDate").ToString()).Day = vday Then
                    iCount = iCount + 1
                    Dim v As New visitorBooking()
                    Dim lstVisitors As New List(Of visitor)
                    v.VisitorStartTime = ""
                    v.VisitType = "No Type Selected"
                    v.VisitContact = rdr("vName").ToString
                    v.Details = "No Detail"
                    v.VisitorRoomDesc = ""

                    v.VisitorStartTime = arrTimeDesc(CInt(rdr("vStartTime")))

                    If CInt(rdr("vStartTime")) > 0 Then
                        v.VisitorStartTime = arrTimeDesc(CInt(rdr("vStartTime")))
                    End If



                    If rdr("visitorNames").ToString().Length > 0 Then
                        Dim json = rdr("visitorNames").ToString()
                        Dim jss As New System.Web.Script.Serialization.JavaScriptSerializer()
                        Dim strColor As String = ""

                        If (json.Length > 0) Then
                            lstVisitors = jss.Deserialize(Of List(Of visitor))(json)
                        End If
                        Dim jSearializer As New System.Web.Script.Serialization.JavaScriptSerializer()
                        If (lstVisitors.Count > 0) Then
                            v.Visitors = lstVisitors
                        End If
                    End If

                    If v.VisitorStartTime = "" Then
                        If Not IsDBNull(rdr("roomStartTime")) Then
                            If CInt(rdr("roomStartTime")) > 0 Then
                                v.VisitorStartTime = arrTimeDesc(CInt(rdr("roomStartTime")))
                            End If
                        End If
                    End If

                    If Not IsDBNull(rdr("roomID")) Then
                        If CInt(rdr("roomID")) > 0 Then
                            v.VisitorRoomDesc = arrRoomDesc(CInt(rdr("roomID").ToString()))
                        End If
                    End If

                    If CInt(rdr("vType")) > 0 Then
                        If CInt(rdr("vType")) = 1 Then
                            v.VisitType = "Stakeholder / Customer"
                            v.Details = rdr("vInstructions").ToString
                        End If
                        If CInt(rdr("vType")) = 2 Then
                            v.VisitType = "Maintenance"
                            v.Details = rdr("vCompany").ToString & " " & rdr("vJobDetails").ToString
                        End If

                        If CInt(rdr("vType")) = 3 Then
                            v.VisitType = "Delivery"
                            v.Details = rdr("vCompany").ToString & " " & rdr("vDeliveryDetails").ToString
                        End If
                    End If
                    BookingRecs.Add(v)

                End If

            End If

        End While
        rdr.Close()
        Com.Dispose()
        Con.Close()
        Con = Nothing
        Return BookingRecs
    End Function


    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintOut.Click
        Dim dataDir As String = "E:\inetpub\MISDOTNET\VisitorRoomBookingSystem"
        Dim row As Integer = -1
        Dim rowPlus As Integer = 0

        Dim BookingRecs As New List(Of visitorBooking)
        BookingRecs = popReport(1)
        Dim fstream As FileStream = New FileStream(Server.MapPath(".") & "\visitorPrintOut.xlsx", FileMode.Open)
        Dim workbook As Aspose.Cells.Workbook = New Workbook(fstream)

        For Each Booking In BookingRecs
            row = row + 1
            Dim A As Cell = workbook.Worksheets(0).Cells("A" & (row + 2 + rowPlus).ToString())
            A.HtmlString = BookingRecs(row).VisitorStartTime.ToString()
            Dim B As Cell = workbook.Worksheets(0).Cells("B" & (row + 2 + rowPlus).ToString())
            B.HtmlString = BookingRecs(row).VisitType.ToString()
            Dim C As Cell = workbook.Worksheets(0).Cells("C" & (row + 2 + rowPlus).ToString())
            C.HtmlString = BookingRecs(row).VisitContact.ToString()
            Dim D As Cell = workbook.Worksheets(0).Cells("D" & (row + 2 + rowPlus).ToString())
            D.HtmlString = BookingRecs(row).VisitorRoomDesc.ToString()
            Dim Ec As Cell = workbook.Worksheets(0).Cells("E" & (row + 2 + rowPlus).ToString())
            Ec.HtmlString = BookingRecs(row).Details.ToString()
            Dim style As Style = A.GetStyle()
            style.IsTextWrapped = True
            style.VerticalAlignment = TextAlignmentType.Top
            A.SetStyle(style)
            B.SetStyle(style)
            C.SetStyle(style)
            D.SetStyle(style)
            Ec.SetStyle(style)


            Dim vstyle As Style = A.GetStyle()
            vstyle.IsTextWrapped = True
            vstyle.VerticalAlignment = TextAlignmentType.Top
            vstyle.Font.IsBold = True
            If Booking.Visitors.Count > 0 Then
                For Each v In Booking.Visitors
                    rowPlus = rowPlus + 1
                    Dim vcell As Cell = workbook.Worksheets(0).Cells("E" & (row + 2 + rowPlus).ToString())
                    If v.SpecialRequirements.Length > 0 Then
                        vcell.HtmlString = v.VisitorName.ToString() + " [" + v.SpecialRequirements + "]"
                    Else
                        vcell.HtmlString = v.VisitorName.ToString()
                    End If
                    vcell.SetStyle(vstyle)
                Next
            End If
        Next

        ' workbook.Worksheets(0).Cells("B1").HtmlString = "Room Setup Schedule : Week Commencing " + CDate(txtCurrentDate.Text).DayOfWeek.ToString + " " + CDate(txtCurrentDate.Text).Day.ToString + " " + MonthName(CDate(txtCurrentDate.Text).Month).ToString
        workbook.Worksheets(0).AutoFitRows()
        workbook.Save(HttpContext.Current.Response, "Output.xlsx", ContentDisposition.Attachment, New OoxmlSaveOptions(SaveFormat.Xlsx))
        fstream.Close()
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