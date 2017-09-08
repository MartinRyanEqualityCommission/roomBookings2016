Imports System.Collections.Generic

Partial Class _Home
    Inherits System.Web.UI.Page

    Dim arrRoom1(132) As Integer
    Dim arrRoomInfo1(132) As String
    Dim arrInitial(132) As String
    Dim arrCss(132) As Integer


    Private Sub getStaff()
        Dim connString As String = ConfigurationManager.ConnectionStrings("roomsSQL").ConnectionString
        Dim Con As New System.Data.SqlClient.SqlConnection(connString)
        Con.Open()
        Dim strSQL As String
        strSQL = "SELECT samAccountName, name FROM TUSERS WHERE curEmp=1 ORDER BY name ASC"
        Dim Com As New System.Data.SqlClient.SqlCommand(strSQL, Con)
        Dim rdr As System.Data.SqlClient.SqlDataReader = Com.ExecuteReader()
        txtBehalfOf.Items.Insert(0, New ListItem("-- Please Select --", ""))
        txtStaffArrival.Items.Insert(0, New ListItem("-- Please Select --", ""))
        While rdr.Read()
            Dim newListItem As New ListItem()
            newListItem.Value = UCase(rdr.GetString(0)).ToString
            newListItem.Text = rdr.GetString(1)
            Dim newListItem2 As New ListItem()
            newListItem2.Value = UCase(rdr.GetString(0)).ToString
            newListItem2.Text = rdr.GetString(1)

            txtBehalfOf.Items.Add(newListItem)
            txtStaffArrival.Items.Add(newListItem2)
        End While
        Con.Close()
    End Sub


    Private Sub popData()
        Dim vSlotName As String = "slot"
        Dim vBookName As String = "book"
        Dim vSlotName2 As String = "slot2"
        Dim vBookName2 As String = "book2"
        Dim btnRun As New Button
        Dim connString As String = ConfigurationManager.ConnectionStrings("roomsSQL").ConnectionString
        Dim strSQL As String
        Dim vTrustFilter As String = ""
        Dim strTrust As String = ""
        Dim iCount As Integer = 0
        Dim i As Integer = 0
        Dim strClass As String = ""
        Dim Con As New System.Data.SqlClient.SqlConnection(connString)
        Dim vDate As New Date
        If Not IsDate(txtCurrentDate.Text) Then
            txtCurrentDate.Text = Now.Date
        End If
        vDate = txtCurrentDate.Text
        Con.Open()
        strSQL = "SELECT TROOMBOOKINGS.roomBookingTitle, TROOMBOOKINGS.roomBehalfOf, TROOMBOOKINGS.roomID, TROOMBOOKINGS.roomBookingDate, TROOMBOOKINGS.roomStartSlot, TROOMBOOKINGS.roomEndSlot, TROOMBOOKINGS.roomBookingStaffID, TROOMBOOKINGS.roomBookingID, TUSERS.name, TUSERS_1.department AS dept" & _
                " FROM (TROOMBOOKINGS LEFT JOIN TUSERS ON TROOMBOOKINGS.roomBookingStaffID = TUSERS.samaccountName) LEFT JOIN TUSERS AS TUSERS_1 ON TROOMBOOKINGS.roomBehalfOf = TUSERS_1.samaccountName" & _
                " WHERE month(roomBookingDate)=" + Month(vDate).ToString + " AND Day(roomBookingDate)=" + Day(vDate).ToString + " AND year(roomBookingDate)=" + Year(vDate).ToString
        'Response.Write(strSQL.ToString)
        'Response.End()
        Dim Com As New System.Data.SqlClient.SqlCommand(strSQL, Con)
        Dim rdr As System.Data.SqlClient.SqlDataReader = Com.ExecuteReader()
        For i = 1 To 132
            arrRoomInfo1(i) = ""
            arrRoom1(i) = "0"
            arrInitial(i) = "NA"
        Next

        While rdr.Read()
            iCount = iCount + 1
            If Not IsDBNull(rdr("roomID")) Then
                If rdr("roomID") > 0 Then
                    For i = 1 To 132
                        If i >= rdr("roomStartSlot") And i <= rdr("roomEndSlot") Then
                            arrRoom1(i) = rdr("roomBookingID").ToString
                            arrRoomInfo1(i) = rdr("roomBookingTitle").ToString + " Booked by " + rdr("name").ToString
                            arrInitial(i) = Left(UCase(rdr("roomBehalfOf")).ToString, 2).ToString
                            If Not IsDBNull(rdr("dept")) Then
                                arrCss(i) = rdr("dept")
                            Else
                                arrCss(i) = 11
                            End If
                        End If
                    Next
                End If
            End If
        End While
        rdr.Close()
        Com.Dispose()
        Con.Close()
        Con = Nothing
        For i = 1 To 132
            If Not IsNothing(arrRoom1(i)) Then
                If CInt(arrRoom1(i)) > 0 Then
                    btnRun = CType(defaultForm.FindControl(vSlotName + i.ToString), Button)
                    btnRun.Visible = False
                    btnRun = CType(defaultForm.FindControl(vBookName + i.ToString), Button)
                    btnRun.ToolTip = arrRoomInfo1(i)
                    btnRun.OnClientClick = "window.open('editBooking.aspx?bookID=" + arrRoom1(i).ToString + "','_self')"
                    btnRun.Text = arrInitial(i).ToString
                    btnRun.Visible = True
                    btnRun.CssClass = "blocked" + arrCss(i).ToString
                Else
                    btnRun = CType(defaultForm.FindControl(vSlotName + i.ToString), Button)
                    btnRun.Visible = True
                    btnRun.Text = "F"
                    btnRun.ForeColor = Drawing.Color.White
                    btnRun.CssClass = "free"
                    btnRun = CType(defaultForm.FindControl(vBookName + i.ToString), Button)
                    btnRun.ToolTip = arrRoomInfo1(i)
                    btnRun.Visible = False
                End If
            End If
        Next
        displayDay()
    End Sub

    Private Sub displayDay()
        lblDayDesc.Text = CDate(txtCurrentDate.Text).DayOfWeek.ToString + " " + CDate(txtCurrentDate.Text).Day.ToString + " " + MonthName(CDate(txtCurrentDate.Text).Month).ToString + " " + CDate(txtCurrentDate.Text).Year.ToString
    End Sub


    Private Sub btnClicked(ByVal roomID As Integer, ByVal slotID As Integer)
        Dim btnRun As Button
        Dim vSlotName As String = "slot"
        Dim i As Integer = 0
        Dim txtStart As TextBox = CType(defaultForm.FindControl("txtStart1"), TextBox)
        Dim txtEnd As TextBox = CType(defaultForm.FindControl("txtEnd1"), TextBox)
        Dim btn As Button = CType(defaultForm.FindControl(vSlotName + slotID.ToString), Button)
        If roomID <> txtRoom.Text Then
            txtStart.Text = 0
            txtEnd.Text = 0
            txtRoom.Text = roomID
        End If
        If CInt(txtStart.Text) = 0 And CInt(txtEnd.Text) = 0 Then
            btn.CssClass = "booked"
            btn.Text = "T"
            btn.ForeColor = System.Drawing.ColorTranslator.FromHtml("#C1C1FF")
            txtStart.Text = slotID
            txtEnd.Text = slotID
        ElseIf txtStart.Text > 0 And txtEnd.Text > 0 Then
            If slotID > CInt(txtEnd.Text) Then
                '                Response.Write("If after end")
                For i = txtEnd.Text To slotID
                    btnRun = CType(defaultForm.FindControl(vSlotName + i.ToString), Button)
                    If btnRun.Visible = True Then
                        btnRun.CssClass = "booked"
                        btnRun.Text = "Y"
                        btnRun.ForeColor = System.Drawing.ColorTranslator.FromHtml("#C1C1FF")
                        txtEnd.Text = i
                    Else
                        txtEnd.Text = i - 1
                        Exit For
                    End If
                Next
            ElseIf slotID = CInt(txtEnd.Text) And slotID <> CInt(txtStart.Text) Then
                '               Response.Write("Equal to end")
                btnRun = CType(defaultForm.FindControl(vSlotName + slotID.ToString), Button)
                btnRun.CssClass = "free"
                If Not (txtEnd.Text - 1 < txtStart.Text) Then
                    txtEnd.Text = slotID - 1
                End If
            ElseIf slotID = CInt(txtEnd.Text) And slotID = CInt(txtStart.Text) Then
                '              Response.Write("Blank")
                btnRun = CType(defaultForm.FindControl(vSlotName + slotID.ToString), Button)
                btnRun.CssClass = "free"
                txtEnd.Text = 0
                txtStart.Text = 0
            ElseIf slotID > CInt(txtStart.Text) And slotID < CInt(txtEnd.Text) Then
                txtEnd.Text = slotID
            End If
        End If
        runVisual(1)
    End Sub

    Private Sub runVisual(ByVal roomID As Integer)
        Dim i As Integer
        Dim btnRun As New Button
        Dim vSlotName As String = "slot"
        Dim ctEnd As Boolean = False
        Dim txtStart As TextBox = CType(defaultForm.FindControl("txtStart" + roomID.ToString), TextBox)
        Dim txtEnd As TextBox = CType(defaultForm.FindControl("txtEnd" + roomID.ToString), TextBox)
        '        If CInt(txtStart.Text) > 0 And CInt(txtEnd.Text) > 0 Then
        For i = 1 To 132
            btnRun = CType(defaultForm.FindControl(vSlotName + i.ToString), Button)
            If i >= txtStart.Text And i <= txtEnd.Text Then
                If btnRun.Enabled = True And ctEnd = False Then
                    btnRun.CssClass = "booked"
                    btnRun.ForeColor = System.Drawing.ColorTranslator.FromHtml("#C1C1FF")
                Else
                    ctEnd = True
                End If
            Else
                If btnRun.Enabled = True Then
                    btnRun.CssClass = "free"
                Else
                    btnRun.CssClass = "blocked"
                End If
            End If
        Next
        'End If
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not IsNothing(Request.QueryString("day")) Then
                If IsDate(Request.QueryString("day")) Then
                    txtCurrentDate.Text = Request.QueryString("day").ToString
                    displayDay()
                End If
            End If
            getStaff()
        End If
        popData()
    End Sub

    Protected Sub txtCurrentDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCurrentDate.TextChanged
        popData()
    End Sub



    Protected Sub btnClear1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear1.Click
        txtStart1.Text = "0"
        txtEnd1.Text = "0"
        runVisual(1)
    End Sub

    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If IsDate(txtCurrentDate.Text) Then
            txtStart1.Text = "0"
            txtEnd1.Text = "0"

            If CDate(txtCurrentDate.Text).DayOfWeek = 5 Then
                txtCurrentDate.Text = Left(DateAdd(DateInterval.Day, 3, CDate(txtCurrentDate.Text)).ToString, 10).ToString
            Else
                txtCurrentDate.Text = Left(DateAdd(DateInterval.Day, 1, CDate(txtCurrentDate.Text)).ToString, 10).ToString
            End If
            displayDay()
        End If
        popData()
    End Sub

    Protected Sub btnPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        If IsDate(txtCurrentDate.Text) Then
            txtStart1.Text = "0"
            txtEnd1.Text = "0"
            If CDate(txtCurrentDate.Text).DayOfWeek = 1 Then
                txtCurrentDate.Text = Left(DateAdd(DateInterval.Day, -3, CDate(txtCurrentDate.Text)).ToString, 10).ToString
            Else
                txtCurrentDate.Text = Left(DateAdd(DateInterval.Day, -1, CDate(txtCurrentDate.Text)).ToString, 10).ToString
            End If
            displayDay()
        End If
        popData()
    End Sub

    Protected Sub btnBook1_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles btnBook1.Command
        Dim strUser As String = ""
        Dim arrRoomDesc(7) As String
        Dim arrTimeDesc(133) As String
        

        arrRoomDesc(1) = "Board Room"
        arrRoomDesc(2) = "Ante Room"
        arrRoomDesc(3) = "Training Room"
        arrRoomDesc(4) = "Meeting Room 3 (1st Floor)"
        arrRoomDesc(5) = "Meeting Room 1"
        arrRoomDesc(6) = "Meeting Room 2"
        arrRoomDesc(7) = "Meeting Room 4 - Glass Room (4th Floor)"

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

        If CInt(txtStart1.Text) > 0 And CInt(txtEnd1.Text) > 0 Then
            lblRoomName.Text = arrRoomDesc(CInt(txtRoom.Text) + 1).ToString
            lblDay.Text = txtCurrentDate.Text
            lblStartTime.Text = arrTimeDesc(CInt(txtStart1.Text))
            If CInt(txtEnd1.Text) = 22 Or CInt(txtEnd1.Text) = 44 Or CInt(txtEnd1.Text) = 66 Or CInt(txtEnd1.Text) = 88 Or CInt(txtEnd1.Text) = 110 Or CInt(txtEnd1.Text) = 132 Then
                lblEndTime.Text = "19:00pm"
            Else
                lblEndTime.Text = arrTimeDesc(CInt(txtEnd1.Text) + 1)
            End If
            strUser = Request.ServerVariables(5).ToString
            If Left(UCase(strUser), 5) = "NICCY" Then
                lblOfficer.Text = Right(strUser, (Len(strUser) - 6)).ToString
            Else
                lblOfficer.Text = Right(strUser, (Len(strUser) - 9)).ToString
            End If
            txtBehalfOf.SelectedValue = UCase(lblOfficer.Text.ToString).ToString
            txtStaffArrival.SelectedValue = UCase(lblOfficer.Text.ToString).ToString
            dayGrid.Visible = False
            visitors.Visible = True
            popGV()
            If (CInt(txtRoom.Text) = 1) Then
                valRangeName.MaximumValue = "32"
                valRangeName.ErrorMessage = "Number between 1 and 32"
            End If
            If (CInt(txtRoom.Text) = 2) Then
                valRangeName.MaximumValue = "16"
                valRangeName.ErrorMessage = "Number between 1 and 16"
            End If
            If (CInt(txtRoom.Text) = 3) Then
                valRangeName.MaximumValue = "26"
                valRangeName.ErrorMessage = "Number between 1 and 26"
            End If
            If (CInt(txtRoom.Text) = 4) Then
                valRangeName.MaximumValue = "8"
                valRangeName.ErrorMessage = "Number between 1 and 8"
            End If
            If (CInt(txtRoom.Text) = 5) Then
                valRangeName.MaximumValue = "6"
                valRangeName.ErrorMessage = "Number between 1 and 6"
            End If
            If (CInt(txtRoom.Text) = 6) Then
                valRangeName.MaximumValue = "12"
                valRangeName.ErrorMessage = "Number between 1 and 12"
            End If
            If (CInt(txtRoom.Text) = 7) Then
                valRangeName.MaximumValue = "6"
                valRangeName.ErrorMessage = "Number between 1 and 6"
            End If
            newBooking.Visible = True
            visitors.Visible = True
            Dim sGUID As String
            sGUID = System.Guid.NewGuid.ToString()
            txtGuid.Text = sGUID
            submit.Visible = True
        End If
    End Sub


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


    Protected Sub bntNewVisitor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNewVisitor.Click
        If txtVisitorName.Text.ToString() = "" Then
            lblNewVisitorWarning.Text = "Must Enter a Visitor Name"
        Else
            addVisitor()
            txtVisitorName.Text = ""
            txtSpecialRequirements.Text = ""
        End If
    End Sub


    Protected Sub addVisitor()
        Dim lstVisitors As New List(Of visitor)
        Dim v As New visitor()
        Dim json = txtVisitorNames.Text.ToString()
        Dim jss As New System.Web.Script.Serialization.JavaScriptSerializer()
        If (json.Length > 0) Then
            lstVisitors = jss.Deserialize(Of List(Of visitor))(json)
        End If
        v.SpecialRequirements = txtSpecialRequirements.Text
        v.VisitorName = txtVisitorName.Text
        lstVisitors.Add(v)
        Dim jSearializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        txtVisitorNames.Text = jSearializer.Serialize(lstVisitors)
        Dim dataTable = New Data.DataTable()
        dataTable.Columns.Add("Name")
        dataTable.Columns.Add("Special Requirements")
        For Each vis In lstVisitors
            Dim row As Data.DataRow = dataTable.NewRow()
            row("Name") = vis.VisitorName
            row("Special Requirements") = vis.SpecialRequirements
            dataTable.Rows.Add(row)
        Next
        gvVisitors.DataSource = dataTable
        gvVisitors.DataBind()
    End Sub


    Protected Sub popGV()
        Dim lstVisitors As New List(Of visitor)
        Dim v As New visitor()
        Dim json = txtVisitorNames.Text.ToString()
        '"{'type':'clientlist','client_list':['client 1','client 2']}"
        Dim jss As New System.Web.Script.Serialization.JavaScriptSerializer()
        If (json.Length > 0) Then
            lstVisitors = jss.Deserialize(Of List(Of visitor))(json)
        End If
      
        Dim jSearializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        txtVisitorNames.Text = jSearializer.Serialize(lstVisitors)

        Dim dataTable = New Data.DataTable()
        dataTable.Columns.Add("Name")
        dataTable.Columns.Add("Special Requirements")


        For Each vis In lstVisitors
            Dim row As Data.DataRow = dataTable.NewRow()
            row("Name") = vis.VisitorName
            row("Special Requirements") = vis.SpecialRequirements
            dataTable.Rows.Add(row)
        Next
        gvVisitors.DataSource = dataTable
        gvVisitors.DataBind()
    End Sub



    Protected Sub txtFood_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFood.SelectedIndexChanged
        If txtFood.SelectedValue = "1" Then
            food.Visible = True
        Else
            food.Visible = False
        End If
    End Sub


    Protected Sub txtVisitorType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVisitorType.SelectedIndexChanged
        trVisitorNames.Visible = False
        trVisitorName.Visible = False
        trDeliveryDetails.Visible = False
        trJobDetails.Visible = False
        trCompanyName.Visible = False
        trSpecialRequirements.Visible = False

        If txtVisitorType.SelectedValue = "1" Then
            trVisitorNames.Visible = True
            trVisitorName.Visible = True
            trSpecialRequirements.Visible = True
        End If

        If txtVisitorType.SelectedValue = "3" Then
            trCompanyName.Visible = True
            trDeliveryDetails.Visible = True
        End If

        If txtVisitorType.SelectedValue = "2" Then
            trCompanyName.Visible = True
            trJobDetails.Visible = True
        End If


    End Sub





    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        addNewSlot()
    End Sub

    Private Sub addNewSlot()
        Dim connString As String = ConfigurationManager.ConnectionStrings("roomsSQL").ConnectionString
        Dim strSQL As String
        Dim Con As New System.Data.SqlClient.SqlConnection(connString)
        Dim varDetail As String = ""
        Dim varFoodDetail As String = ""
        Dim varSRDetail As String = ""
        Dim varNoAttending As Integer = 0
        Dim result As Integer = 0

        Con.Open()
        If Not IsNothing(txtDetail.Text) Then
            If Len(txtDetail.Text) > 0 Then
                varDetail = Replace(txtDetail.Text, "'", "''").ToString
            End If
        End If

        If Not IsNothing(txtFoodDetails.Text) Then
            If Len(txtFoodDetails.Text) > 0 Then
                varFoodDetail = Replace(txtFoodDetails.Text, "'", "''").ToString
            End If
        End If

        If Not IsNothing(txtSRDetails.Text) Then
            If Len(txtSRDetails.Text) > 0 Then
                varSRDetail = Replace(txtSRDetails.Text, "'", "''").ToString
            End If
        End If

        If Not IsNothing(txtNoAttending.Text) Then
            If IsNumeric(txtNoAttending.Text) Then
                varNoAttending = CInt(txtNoAttending.Text)
            End If
        End If
        strSQL = "INSERT INTO TROOMBOOKINGS (roomID, roomBookingDate, roomStartSlot, roomEndSlot, roomBookingStaffID, roomBookingTitle, roomBookingDesc, roomNoAttending, roomFood, roomFoodDetail, roomSR, roomSRDetail, roomBehalfOf, roomTimeStamp, visitorGUID) VALUES (" + txtRoom.Text + ",'" + Month(CDate(txtCurrentDate.Text)).ToString + "/" + Day(CDate(txtCurrentDate.Text)).ToString + "/" + Year(CDate(txtCurrentDate.Text)).ToString + "'," + CInt(txtStart1.Text).ToString + "," + CInt(txtEnd1.Text).ToString + ",'" + lblOfficer.Text + "','" + Replace(txtTitle.Text, "'", "''").ToString + "','" + varDetail.ToString + "'," + varNoAttending.ToString + "," + txtFood.SelectedValue.ToString + ",'" + varFoodDetail.ToString + "'," + txtSR.SelectedValue.ToString + ",'" + varSRDetail.ToString + "','" + txtBehalfOf.SelectedValue.ToString + "','" + Month(Now()).ToString + "/" + Day(Now()).ToString + "/" + Year(Now()).ToString + " " + Hour(Now()).ToString + ":" + Minute(Now()).ToString + ":" + Second(Now()).ToString + "','" + txtGuid.Text.ToString() + "')"
        Dim Com As New System.Data.SqlClient.SqlCommand(strSQL, Con)
        result = Com.ExecuteNonQuery()
        If result > 0 And txtVisitorNames.Text.ToString.Length > 2 Then
            Dim strUser = UCase(Request.ServerVariables(5).ToString())
            strSQL = "INSERT INTO [dbo].[TVISITORS] (visitorDate,visitorContactOnArrival,visitorType,visitorGUID,visitorCompany,visitorJobDetails,visitorDeliveryDetails,visitorNames,visitorBookedBy,visitorDateTimeStamp,visitorNo,visitorStartTime)" & _
      " VALUES " & _
      "('" & Month(CDate(txtCurrentDate.Text.ToString())) & "/" & Day(CDate(txtCurrentDate.Text.ToString())) & "/" & Year(CDate(txtCurrentDate.Text.ToString())) & "','" & _
        txtStaffArrival.SelectedValue.ToString() + "'," & _
        txtVisitorType.SelectedValue.ToString() + "," & _
         "'" & txtGuid.Text.ToString() & "'," & _
         "'" & txtCompanyName.Text.ToString() + "'," & _
         "'" & txtJobDetails.Text.ToString() + "'," & _
       "'" & txtDeliveryDetails.Text.ToString() + "'," & _
        "'" & txtVisitorNames.Text.ToString() + "'," & _
        "'" & strUser & "',getDate(), " + txtVisitorNo.SelectedValue.ToString + "," + txtVisitorStartTime.SelectedValue + ")"
            Dim ComV As New System.Data.SqlClient.SqlCommand(strSQL, Con)
            result = ComV.ExecuteNonQuery()
            ComV.Dispose()


            If Left(UCase(strUser), 5) = "NICCY" Then
                txtStaffArrival.SelectedValue = Right(strUser, (Len(strUser) - 6)).ToString
            Else
                txtStaffArrival.SelectedValue = Right(strUser, (Len(strUser) - 9)).ToString
            End If


            txtVisitorNames.Text = ""
            Dim dataTable = New Data.DataTable()
            dataTable.Columns.Add("Name")
            dataTable.Columns.Add("Special Requirements")
            gvVisitors.DataSource = dataTable
            gvVisitors.DataBind()

        End If

        Com.Dispose()
        Con.Dispose()
        Com = Nothing
        Con = Nothing
        txtTitle.Text = ""
        lblOfficer.Text = ""
        lblStartTime.Text = ""
        lblEndTime.Text = ""
        txtStart1.Text = 0
        txtEnd1.Text = 0
        txtRoom.Text = 0
        txtDetail.Text = ""
        txtNoAttending.Text = ""
        newBooking.Visible = False
        visitors.Visible = False
        dayGrid.Visible = True
        txtFood.SelectedValue = "2"
        txtSR.SelectedValue = "2"
        txtFoodDetails.Text = ""
        txtSRDetails.Text = ""
        food.Visible = False
        SR.Visible = False

        submit.Visible = False
        popData()
    End Sub


    Protected Sub slot1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot1.Click
        btnClicked(1, 1)
    End Sub

    Protected Sub slot2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot2.Click
        btnClicked(1, 2)
    End Sub

    Protected Sub slot3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot3.Click
        btnClicked(1, 3)
    End Sub

    Protected Sub slot4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot4.Click
        btnClicked(1, 4)
    End Sub

    Protected Sub slot5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot5.Click
        btnClicked(1, 5)
    End Sub

    Protected Sub slot6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot6.Click
        btnClicked(1, 6)
    End Sub

    Protected Sub slot7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot7.Click
        btnClicked(1, 7)
    End Sub

    Protected Sub slot8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot8.Click
        btnClicked(1, 8)
    End Sub

    Protected Sub slot9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot9.Click
        btnClicked(1, 9)
    End Sub

    Protected Sub slot10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot10.Click
        btnClicked(1, 10)
    End Sub

    Protected Sub slot11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot11.Click
        btnClicked(1, 11)
    End Sub



    Protected Sub slot12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot12.Click
        btnClicked(1, 12)
    End Sub

    Protected Sub slot13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot13.Click
        btnClicked(1, 13)
    End Sub

    Protected Sub slot14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot14.Click
        btnClicked(1, 14)
    End Sub

    Protected Sub slot15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot15.Click
        btnClicked(1, 15)
    End Sub

    Protected Sub slot16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot16.Click
        btnClicked(1, 16)
    End Sub

    Protected Sub slot17_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot17.Click
        btnClicked(1, 17)
    End Sub

    Protected Sub slot18_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot18.Click
        btnClicked(1, 18)
    End Sub

    Protected Sub slot19_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot19.Click
        btnClicked(1, 19)
    End Sub

    Protected Sub slot20_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot20.Click
        btnClicked(1, 20)
    End Sub

    Protected Sub slot21_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot21.Click
        btnClicked(1, 21)
    End Sub

    Protected Sub slot22_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles slot22.Command
        btnClicked(1, 22)
    End Sub

    Protected Sub slot23_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot23.Click
        btnClicked(2, 23)
    End Sub

    Protected Sub slot24_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot24.Click
        btnClicked(2, 24)
    End Sub

    Protected Sub slot25_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot25.Click
        btnClicked(2, 25)
    End Sub

    Protected Sub slot26_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot26.Click
        btnClicked(2, 26)
    End Sub

    Protected Sub slot27_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot27.Click
        btnClicked(2, 27)
    End Sub

    Protected Sub slot28_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot28.Click
        btnClicked(2, 28)
    End Sub

    Protected Sub slot29_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot29.Click
        btnClicked(2, 29)
    End Sub

    Protected Sub slot30_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot30.Click
        btnClicked(2, 30)
    End Sub

    Protected Sub slot31_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot31.Click
        btnClicked(2, 31)
    End Sub

    Protected Sub slot32_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot32.Click
        btnClicked(2, 32)
    End Sub

    Protected Sub slot33_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot33.Click
        btnClicked(2, 33)
    End Sub

    Protected Sub slot34_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot34.Click
        btnClicked(2, 34)
    End Sub

    Protected Sub slot35_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot35.Click
        btnClicked(2, 35)
    End Sub

    Protected Sub slot36_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot36.Click
        btnClicked(2, 36)
    End Sub

    Protected Sub slot37_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot37.Click
        btnClicked(2, 37)
    End Sub

    Protected Sub slot38_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot38.Click
        btnClicked(2, 38)
    End Sub

    Protected Sub slot39_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot39.Click
        btnClicked(2, 39)
    End Sub

    Protected Sub slot40_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot40.Click
        btnClicked(2, 40)
    End Sub

    Protected Sub slot41_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot41.Click
        btnClicked(2, 41)
    End Sub

    Protected Sub slot42_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot42.Click
        btnClicked(2, 42)
    End Sub

    Protected Sub slot43_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot43.Click
        btnClicked(2, 43)
    End Sub

    Protected Sub slot44_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot44.Click
        btnClicked(2, 44)
    End Sub

    Protected Sub txtSR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSR.SelectedIndexChanged
        If txtSR.SelectedValue = "1" Then
            SR.Visible = True
        Else
            SR.Visible = False
        End If
    End Sub

    Protected Sub slot45_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot45.Click
        btnClicked(3, 45)
    End Sub

    Protected Sub slot46_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot46.Click
        btnClicked(3, 46)
    End Sub

    Protected Sub slot47_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot47.Click
        btnClicked(3, 47)
    End Sub

    Protected Sub slot48_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot48.Click
        btnClicked(3, 48)
    End Sub

    Protected Sub slot49_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot49.Click
        btnClicked(3, 49)
    End Sub

    Protected Sub slot50_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot50.Click
        btnClicked(3, 50)
    End Sub

    Protected Sub slot51_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot51.Click
        btnClicked(3, 51)
    End Sub

    Protected Sub slot52_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot52.Click
        btnClicked(3, 52)
    End Sub

    Protected Sub slot53_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot53.Click
        btnClicked(3, 53)
    End Sub

    Protected Sub slot54_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot54.Click
        btnClicked(3, 54)
    End Sub

    Protected Sub slot55_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot55.Click
        btnClicked(3, 55)
    End Sub

    Protected Sub slot56_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot56.Click
        btnClicked(3, 56)
    End Sub


    Protected Sub slot57_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot57.Click
        btnClicked(3, 57)
    End Sub

    Protected Sub slot58_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot58.Click
        btnClicked(3, 58)
    End Sub

    Protected Sub slot59_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot59.Click
        btnClicked(3, 59)
    End Sub

    Protected Sub slot60_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot60.Click
        btnClicked(3, 60)
    End Sub

    Protected Sub slot61_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot61.Click
        btnClicked(3, 61)
    End Sub

    Protected Sub slot62_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot62.Click
        btnClicked(3, 62)
    End Sub

    Protected Sub slot63_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot63.Click
        btnClicked(3, 63)
    End Sub

    Protected Sub slot64_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot64.Click
        btnClicked(3, 64)
    End Sub

    Protected Sub slot65_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot65.Click
        btnClicked(3, 65)
    End Sub

    Protected Sub slot66_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot66.Click
        btnClicked(3, 66)
    End Sub

    Protected Sub slot67_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot67.Click
        btnClicked(4, 67)
    End Sub

    Protected Sub slot68_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot68.Click
        btnClicked(4, 68)
    End Sub

    Protected Sub slot69_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot69.Click
        btnClicked(4, 69)
    End Sub

    Protected Sub slot70_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot70.Click
        btnClicked(4, 70)
    End Sub

    Protected Sub slot71_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot71.Click
        btnClicked(4, 71)
    End Sub

    Protected Sub slot72_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot72.Click
        btnClicked(4, 72)
    End Sub

    Protected Sub slot73_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot73.Click
        btnClicked(4, 73)
    End Sub

    Protected Sub slot74_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot74.Click
        btnClicked(4, 74)
    End Sub

    Protected Sub slot75_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot75.Click
        btnClicked(4, 75)
    End Sub

    Protected Sub slot76_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot76.Click
        btnClicked(4, 76)
    End Sub

    Protected Sub slot77_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot77.Click
        btnClicked(4, 77)
    End Sub

    Protected Sub slot78_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot78.Click
        btnClicked(4, 78)
    End Sub

    Protected Sub slot79_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot79.Click
        btnClicked(4, 79)
    End Sub

    Protected Sub slot80_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot80.Click
        btnClicked(4, 80)
    End Sub

    Protected Sub slot81_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot81.Click
        btnClicked(4, 81)
    End Sub

    Protected Sub slot82_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot82.Click
        btnClicked(4, 82)
    End Sub

    Protected Sub slot83_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot83.Click
        btnClicked(4, 83)
    End Sub

    Protected Sub slot84_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot84.Click
        btnClicked(4, 84)
    End Sub

    Protected Sub slot85_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot85.Click
        btnClicked(4, 85)
    End Sub

    Protected Sub slot86_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot86.Click
        btnClicked(4, 86)
    End Sub

    Protected Sub slot87_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot87.Click
        btnClicked(4, 87)
    End Sub

    Protected Sub slot88_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot88.Click
        btnClicked(4, 88)
    End Sub

    Protected Sub slot89_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot89.Click
        btnClicked(5, 89)
    End Sub

    Protected Sub slot90_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot90.Click
        btnClicked(5, 90)
    End Sub

    Protected Sub slot91_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot91.Click
        btnClicked(5, 91)
    End Sub

    Protected Sub slot92_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot92.Click
        btnClicked(5, 92)
    End Sub

    Protected Sub slot93_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot93.Click
        btnClicked(5, 93)
    End Sub

    Protected Sub slot94_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot94.Click
        btnClicked(5, 94)
    End Sub

    Protected Sub slot95_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot95.Click
        btnClicked(5, 95)
    End Sub

    Protected Sub slot96_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot96.Click
        btnClicked(5, 96)
    End Sub

    Protected Sub slot97_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot97.Click
        btnClicked(5, 97)
    End Sub

    Protected Sub slot98_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot98.Click
        btnClicked(5, 98)
    End Sub

    Protected Sub slot99_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot99.Click
        btnClicked(5, 99)
    End Sub

    Protected Sub slot100_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot100.Click
        btnClicked(5, 100)
    End Sub

    Protected Sub slot101_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot101.Click
        btnClicked(5, 101)
    End Sub

    Protected Sub slot102_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot102.Click
        btnClicked(5, 102)
    End Sub

    Protected Sub slot103_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot103.Click
        btnClicked(5, 103)
    End Sub

    Protected Sub slot104_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot104.Click
        btnClicked(5, 104)
    End Sub

    Protected Sub slot105_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot105.Click
        btnClicked(5, 105)
    End Sub

    Protected Sub slot106_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot106.Click
        btnClicked(5, 106)
    End Sub

    Protected Sub slot107_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot107.Click
        btnClicked(5, 107)
    End Sub

    Protected Sub slot108_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot108.Click
        btnClicked(5, 108)
    End Sub

    Protected Sub slot109_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot109.Click
        btnClicked(5, 109)
    End Sub

    Protected Sub slot110_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot110.Click
        btnClicked(5, 110)
    End Sub

    Protected Sub slot111_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot111.Click
        btnClicked(6, 111)
    End Sub

    Protected Sub slot112_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot112.Click
        btnClicked(6, 112)
    End Sub

    Protected Sub slot113_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot113.Click
        btnClicked(6, 113)
    End Sub

    Protected Sub slot114_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot114.Click
        btnClicked(6, 114)
    End Sub

    Protected Sub slot115_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot115.Click
        btnClicked(6, 115)
    End Sub

    Protected Sub slot116_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot116.Click
        btnClicked(6, 116)
    End Sub

    Protected Sub slot117_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot117.Click
        btnClicked(6, 117)
    End Sub

    Protected Sub slot118_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot118.Click
        btnClicked(6, 118)
    End Sub

    Protected Sub slot119_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot119.Click
        btnClicked(6, 119)
    End Sub

    Protected Sub slot120_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot120.Click
        btnClicked(6, 120)
    End Sub

    Protected Sub slot121_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot121.Click
        btnClicked(6, 121)
    End Sub

    Protected Sub slot122_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot122.Click
        btnClicked(6, 122)
    End Sub

    Protected Sub slot123_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot123.Click
        btnClicked(6, 123)
    End Sub

    Protected Sub slot124_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot124.Click
        btnClicked(6, 124)
    End Sub

    Protected Sub slot125_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot125.Click
        btnClicked(6, 125)
    End Sub

    Protected Sub slot126_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot126.Click
        btnClicked(6, 126)
    End Sub

    Protected Sub slot127_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot127.Click
        btnClicked(6, 127)
    End Sub

    Protected Sub slot128_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot128.Click
        btnClicked(6, 128)
    End Sub

    Protected Sub slot129_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot129.Click
        btnClicked(6, 129)
    End Sub

    Protected Sub slot130_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot130.Click
        btnClicked(6, 130)
    End Sub

    Protected Sub slot131_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot131.Click
        btnClicked(6, 131)
    End Sub

    Protected Sub slot132_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles slot132.Click
        btnClicked(6, 132)
    End Sub


End Class