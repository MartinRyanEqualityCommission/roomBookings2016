Imports System.Collections.Generic

Partial Class editBooking
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Request.QueryString("bookID")) Then
            If Not Page.IsPostBack Then
                getStaff()
                popData(CInt(Request.QueryString("bookID")), "")
                popGV()
                TabName.Value = Request.Form(TabName.UniqueID)
            End If
        ElseIf Not IsNothing(Request.QueryString("GUID")) Then
            If Not Page.IsPostBack Then
                getStaff()
                popData(0, Request.QueryString("GUID").ToString)
                popGV()
                TabName.Value = Request.Form(TabName.UniqueID)
            End If
        Else
            Response.Write("Problem Ring 652")
        End If
    End Sub

    Sub gvVisitorsRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

        If e.CommandName = "deleteElement" Then
            Dim name As String = e.CommandArgument.ToString()
            removeVisitor(name)
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
            If btnSaveChanges.Visible = True Then
                row("Name") = vis.VisitorName
            Else
                row("Name") = "Visitor"
            End If
            row("Special Requirements") = vis.SpecialRequirements
            dataTable.Rows.Add(row)
        Next
        gvVisitors.DataSource = dataTable
        gvVisitors.DataBind()
        If btnSaveChanges.Visible = False Then
            gvVisitors.Columns(2).Visible = False
        End If
    End Sub


    Protected Sub removeVisitor(ByVal vName As String)
        Dim lstVisitors As New List(Of visitor)
        Dim v As New visitor()
        Dim json = txtVisitorNames.Text.ToString()
        Dim jss As New System.Web.Script.Serialization.JavaScriptSerializer()
        If (json.Length > 0) Then
            lstVisitors = jss.Deserialize(Of List(Of visitor))(json)
        End If
        For index As Integer = (lstVisitors.Count - 1) To 0 Step -1
            Dim vItem As visitor
            vItem = lstVisitors(index)
            If (vItem.VisitorName = vName) Then lstVisitors.Remove(vItem)
        Next

        Dim jSearializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        txtVisitorNames.Text = jSearializer.Serialize(lstVisitors)
        Dim dataTable = New Data.DataTable()
        dataTable.Columns.Add("Name")
        dataTable.Columns.Add("Special Requirements")
        For Each vis In lstVisitors
            Dim row As Data.DataRow = dataTable.NewRow()
            If btnSaveChanges.Visible = True Then
                row("Name") = vis.VisitorName
            Else
                row("Name") = "Visitor"
            End If
            row("Special Requirements") = vis.SpecialRequirements
            dataTable.Rows.Add(row)
        Next
        gvVisitors.DataSource = dataTable
        gvVisitors.DataBind()
        If btnSaveChanges.Visible = False Then
            gvVisitors.Columns(2).Visible = False
        End If
    End Sub

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



    Private Sub resetViews()
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




    Protected Sub txtVisitorType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVisitorType.SelectedIndexChanged
        resetViews()
    End Sub

    Private Sub popData(ByVal bookID As Integer, ByVal vGUID As String)
        Dim connString As String = ConfigurationManager.ConnectionStrings("roomsSQL").ConnectionString
        Dim strSQL As String
        Dim iCount As Integer = 0
        Dim i As Integer = 0
        Dim strRows As String = ""
        Dim Con As New System.Data.SqlClient.SqlConnection(connString)
        Dim vFood As String = "No"
        Dim vSR As String = "No"
        Dim vDate As New Date
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


        Dim arrRoomDesc(7) As String

        arrRoomDesc(1) = "Board Room"
        arrRoomDesc(2) = "Ante Room"
        '        arrRoomDesc(3) = "Training Room"
        arrRoomDesc(3) = "Meeting Room 3 (1st Floor)"
        arrRoomDesc(4) = "Meeting Room 1"
        arrRoomDesc(5) = "Meeting Room 2"
        arrRoomDesc(6) = "Meeting Room 4 - Glass Room (4th Floor)"

        Con.Open()
        strSQL = "SELECT roomBookingID, TROOMBOOKINGS.roomBookingTitle, isNull(comments,'') as Comments, TROOMBOOKINGS.roomID, TROOMBOOKINGS.roomSR, TROOMBOOKINGS.roomFood, TROOMBOOKINGS.roomBookingDate, TROOMBOOKINGS.roomStartSlot, TROOMBOOKINGS.roomEndSlot, TROOMBOOKINGS.roomBookingStaffID, TROOMBOOKINGS.roomBookingDESC, TROOMBOOKINGS.roomBookingID, TUSERS.name, TROOMBOOKINGS.roomNoAttending, TROOMBOOKINGS.roomSRDetail, TROOMBOOKINGS.roomFoodDetail, TROOMBOOKINGS.roomBehalfOf, v.*" & _
                 " FROM TROOMBOOKINGS LEFT JOIN TVISITORS v ON convert(nvarchar(255),TROOMBOOKINGS.visitorGUID) = convert(nvarchar(255), v.visitorGUID) LEFT JOIN TUSERS ON TROOMBOOKINGS.roomBookingStaffID = TUSERS.samAccountName WHERE roomBookingID=" + bookID.ToString
        If bookID = 0 Then
            strSQL = "SELECT roomBookingID, TROOMBOOKINGS.roomBookingTitle, isNull(comments,'') as Comments, TROOMBOOKINGS.roomID, TROOMBOOKINGS.roomSR, TROOMBOOKINGS.roomFood, TROOMBOOKINGS.roomBookingDate, TROOMBOOKINGS.roomStartSlot, TROOMBOOKINGS.roomEndSlot, TROOMBOOKINGS.roomBookingStaffID, TROOMBOOKINGS.roomBookingDESC, TROOMBOOKINGS.roomBookingID, TUSERS.name, TROOMBOOKINGS.roomNoAttending, TROOMBOOKINGS.roomSRDetail, TROOMBOOKINGS.roomFoodDetail, TROOMBOOKINGS.roomBehalfOf, v.* " & _
                    " FROM TROOMBOOKINGS JOIN TVISITORS v ON convert(nvarchar(255),TROOMBOOKINGS.visitorGUID) = convert(nvarchar(255), v.visitorGUID) LEFT JOIN TUSERS ON TROOMBOOKINGS.roomBookingStaffID = TUSERS.samAccountName WHERE convert(varchar(255), TROOMBOOKINGS.visitorGUID)='" + vGUID.ToString() + "'"
        End If

        Dim Com As New System.Data.SqlClient.SqlCommand(strSQL, Con)
        Dim rdr As System.Data.SqlClient.SqlDataReader = Com.ExecuteReader()
        Dim strUser As String = ""
        txtBookID.Text = bookID.ToString
        While rdr.Read()
            iCount = iCount + 1
            txtBookDate.Text = Left(rdr("roomBookingDate"), 10).ToString
            txtRoomBookDate.Value = Left(rdr("roomBookingDate"), 10).ToString


            If bookID = 0 Then
                If Not IsDBNull(rdr("roomBookingID")) Then
                    If IsNumeric(rdr("roomBookingID")) Then
                        txtBookID.Text = rdr("roomBookingID").ToString()
                    End If
                End If
            End If

            If Not IsDBNull(rdr("roomID")) Then
                If IsNumeric(rdr("roomID")) Then
                    txtRoomName.Text = arrRoomDesc(CInt(rdr("roomID"))).ToString
                End If
            End If

            If Not IsDBNull(rdr("visitorID")) Then
                If IsNumeric(rdr("visitorID")) Then
                    txtVisitorID.Value = rdr("visitorID").ToString()
                End If
            End If

            If Not IsDBNull(rdr("visitorGUID")) Then
                If rdr("visitorGUID").ToString.Length > 1 Then
                    txtGUID.Value = rdr("visitorGUID").ToString
                End If
            Else
                Dim sGUID As String
                sGUID = System.Guid.NewGuid.ToString()
                txtGUID.Value = sGUID
            End If

            If Not IsDBNull(rdr("roomFood")) Then
                If rdr("roomFood") = 1 Then
                    txtFood.SelectedValue = 1
                Else
                    txtFood.SelectedValue = 2
                End If
            End If

            If Not IsDBNull(rdr("roomBehalfOf")) Then
                txtBehalfOf.SelectedValue = rdr("roomBehalfOf").ToString
            End If

            If Not IsDBNull(rdr("visitorNo")) Then
                If IsNumeric(rdr("visitorNo")) Then txtVisitorNo.SelectedValue = rdr("visitorNo").ToString
            End If

            If Not IsDBNull(rdr("visitorStartTime")) Then
                If IsNumeric(rdr("visitorStartTime")) Then txtVisitorStartTime.SelectedValue = rdr("visitorStartTime").ToString
            End If


            If Not IsDBNull(rdr("visitorType")) Then
                If IsNumeric(rdr("visitorType")) Then txtVisitorType.SelectedValue = rdr("visitorType").ToString
            End If


            If Not IsDBNull(rdr("visitorContactOnArrival")) Then
                txtStaffArrival.SelectedValue = rdr("visitorContactOnArrival").ToString
            End If

            If Not IsDBNull(rdr("visitorCompany")) Then
                txtCompanyName.Text = rdr("visitorCompany").ToString
            End If

            If Not IsDBNull(rdr("visitorJobDetails")) Then
                txtJobDetails.Text = rdr("visitorJobDetails").ToString
            End If

            If Not IsDBNull(rdr("visitorDeliveryDetails")) Then
                txtDeliveryDetails.Text = rdr("visitorDeliveryDetails").ToString
            End If

            If Not IsDBNull(rdr("visitorNames")) Then
                If rdr("visitorNames").ToString().Length > 0 Then
                    txtVisitorNames.Text = rdr("visitorNames").ToString()
                End If
            End If

            If Not IsDBNull(rdr("roomSR")) Then
                If rdr("roomSR") = 1 Then
                    txtSR.SelectedValue = 1
                Else
                    txtSR.SelectedValue = 2
                End If
            End If
            txtNosAttending.Text = rdr("roomNoAttending").ToString
            lblTime.Text = arrTimeDesc(CInt((rdr("roomStartSlot")))).ToString + " to " + arrTimeDesc(CInt((rdr("roomendSlot")) + 1)).ToString + " on " + Left(rdr("roomBookingDate"), 10).ToString()
            txtTitle.Text = rdr("roomBookingTitle").ToString
            txtDetails.Text = rdr("roomBookingDesc").ToString
            txtFoodDetail.Text = rdr("roomFoodDetail").ToString
            txtPDComments.Text = rdr("comments").ToString
            txtSRDetail.Text = rdr("roomSRDetail").ToString
            strUser = Request.ServerVariables(5).ToString
            If Left(UCase(strUser), 5) = "NICCY" Then
                strUser = Right(strUser, (Len(strUser) - 6)).ToString
            Else
                strUser = Right(strUser, (Len(strUser) - 9)).ToString
            End If
            'Response.Write(strUser)
            If UCase(strUser).ToString = UCase(rdr("roomBehalfOf")).ToString Or UCase(strUser).ToString = UCase(rdr("roomBookingStaffID")).ToString Or UCase(strUser).ToString = "RECEPTION" Or UCase(strUser).ToString = "MRYAN" Or UCase(strUser).ToString = "CDARDIS" Or UCase(strUser).ToString = "PSTAWORZYNSKI" Or UCase(strUser).ToString = "JMCMANUS" Then
                btnDelete.Visible = True
                btnSaveChanges.Visible = True
                btnNewVisitor.Visible = True
            Else
                btnDelete.Visible = False
                btnSaveChanges.Visible = False
                btnNewVisitor.Visible = False
            End If
            If UCase(strUser) = "CDARDIS" Or UCase(strUser).ToString = "MRYAN" Then
                trPDComments.Visible = True
            End If
        End While

        resetViews()

        rdr.Close()
        Com.Dispose()
        Con.Close()
        Con = Nothing
    End Sub

    Private Sub getStaff()
        Dim connString As String = ConfigurationManager.ConnectionStrings("roomsSQL").ConnectionString
        Dim Con As New System.Data.SqlClient.SqlConnection(connString)
        Con.Open()
        Dim strSQL As String
        strSQL = "SELECT samAccountName, name FROM TUSERS WHERE curEmp=1 AND department < 13 ORDER BY name ASC"
        Dim Com As New System.Data.SqlClient.SqlCommand(strSQL, Con)
        Dim rdr As System.Data.SqlClient.SqlDataReader = Com.ExecuteReader()
        txtBehalfOf.Items.Insert(0, New ListItem("-- Please Select --", ""))
        txtStaffArrival.Items.Insert(0, New ListItem("-- Please Select --", ""))
        While rdr.Read()
            Dim newListItem As New ListItem()
            Dim newListItem2 As New ListItem()
            newListItem.Value = UCase(rdr.GetString(0)).ToString
            newListItem.Text = rdr.GetString(1)

            newListItem2.Value = UCase(rdr.GetString(0)).ToString
            newListItem2.Text = rdr.GetString(1)

            txtBehalfOf.Items.Add(newListItem)
            txtStaffArrival.Items.Add(newListItem2)
        End While
        Con.Close()
    End Sub

    Protected Sub btnSaveChanges_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveChanges.Click
        saveChanges()
        Response.Redirect("default.aspx?day=" + txtBookDate.Text.ToString)
    End Sub

    Private Sub saveChanges()
        Dim connString As String = ConfigurationManager.ConnectionStrings("roomsSQL").ConnectionString
        Dim strSQL As String
        Dim Con As New System.Data.SqlClient.SqlConnection(connString)
        Dim varDetail As String = "NA"
        Dim varFoodDetail As String = ""
        Dim varSRDetail As String = ""
        Dim varComments As String = ""
        Dim varNoAttending As Integer = 0
        Dim strUser As String = ""
        Con.Open()

        If Not IsNothing(txtDetails.Text.ToString) Then
            If Len(txtDetails.Text.ToString) > 0 Then
                varDetail = Replace(txtDetails.Text, "'", "''").ToString
            End If
        End If

        If Not IsNothing(txtFoodDetail.Text) Then
            If Len(txtFoodDetail.Text) > 0 Then
                varFoodDetail = Replace(txtFoodDetail.Text, "'", "''").ToString
            End If
        End If

        If Not IsNothing(txtSRDetail.Text) Then
            If Len(txtSRDetail.Text) > 0 Then
                varSRDetail = Replace(txtSRDetail.Text, "'", "''").ToString
            End If
        End If

        If Not IsNothing(txtNosAttending.Text) Then
            If IsNumeric(txtNosAttending.Text) Then
                varNoAttending = CInt(txtNosAttending.Text)
            End If
        End If

        If Not IsNothing(txtPDComments.Text) Then
            If Len(txtPDComments.Text) > 0 Then
                varComments = Replace(txtPDComments.Text, "'", "''").ToString
            End If
        End If

        strUser = Request.ServerVariables(5).ToString
        If Left(UCase(strUser), 5) = "NICCY" Then
            strUser = Right(strUser, (Len(strUser) - 6)).ToString
        Else
            strUser = Right(strUser, (Len(strUser) - 9)).ToString
        End If

        strSQL = "UPDATE TROOMBOOKINGS SET roomBookingTitle='" + Replace(txtTitle.Text, "'", "''").ToString + "', roomBookingDesc='" + Replace(varDetail, "'", "''").ToString + "', roomNoAttending=" + varNoAttending.ToString + ", roomFood=" + txtFood.SelectedValue.ToString + ",roomFoodDetail='" + varFoodDetail.ToString + "', roomSR=" + txtSR.SelectedValue.ToString + ", roomSRDetail='" + varSRDetail.ToString + "', roomBehalfOf='" + txtBehalfOf.SelectedValue.ToString + "', updatedBy='" + strUser + "', comments='" + varComments + "',visitorGUID='" + txtGUID.Value + "' WHERE roomBookingID=" + txtBookID.Text.ToString
        Dim Com As New System.Data.SqlClient.SqlCommand(strSQL, Con)
        Dim result As Integer = 0
        result = Com.ExecuteNonQuery()
        If result > 0 Then




            strUser = UCase(Request.ServerVariables(5).ToString())

            If txtVisitorID.Value = "" Then
                strSQL = "INSERT INTO [dbo].[TVISITORS] (visitorDate,visitorContactOnArrival,visitorType,visitorGUID,visitorCompany,visitorJobDetails,visitorDeliveryDetails,visitorNames,visitorBookedBy,visitorDateTimeStamp,visitorNo,visitorStartTime)" & _
          " VALUES " & _
          "('" & Month(CDate(txtRoomBookDate.Value.ToString())) & "/" & Day(CDate(txtRoomBookDate.Value.ToString())) & "/" & Year(CDate(txtRoomBookDate.Value.ToString())) & "','" & _
            txtStaffArrival.SelectedValue.ToString() + "'," & _
            txtVisitorType.SelectedValue.ToString() + "," & _
             "'" & txtGUID.Value.ToString() & "'," & _
             "'" & txtCompanyName.Text.ToString() + "'," & _
             "'" & txtJobDetails.Text.ToString() + "'," & _
           "'" & txtDeliveryDetails.Text.ToString() + "'," & _
            "'" & txtVisitorNames.Text.ToString() + "'," & _
            "'" & strUser & "',getDate(), " + txtVisitorNo.SelectedValue.ToString + ", " + txtVisitorStartTime.SelectedValue.ToString + ")"
            Else
                strSQL = "UPDATE [dbo].[TVISITORS] SET visitorContactOnArrival='" & txtStaffArrival.SelectedValue.ToString() + "',visitorType=" & txtVisitorType.SelectedValue.ToString() + ",visitorCompany='" & txtCompanyName.Text.ToString() + "',visitorJobDetails='" & txtJobDetails.Text.ToString() + "',visitorDeliveryDetails='" & txtDeliveryDetails.Text.ToString() + "',visitorNames='" & txtVisitorNames.Text.ToString() + "',visitorNo=" + txtVisitorNo.SelectedValue.ToString & ",visitorStartTime=" & txtVisitorStartTime.SelectedValue & _
                    " WHERE visitorID=" & txtVisitorID.Value.ToString()
            End If

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

            'Response.Write(strSQL.ToString)
            Com.Dispose()
            Con.Dispose()
            Com = Nothing
            Con = Nothing
    End Sub

    Private Sub deleteBooking()
        Dim connString As String = ConfigurationManager.ConnectionStrings("roomsSQL").ConnectionString
        Dim strSQL As String
        Dim strUser As String = ""

        Dim Con As New System.Data.SqlClient.SqlConnection(connString)
        Con.Open()

        strUser = Request.ServerVariables(5).ToString
        If Left(UCase(strUser), 5) = "NICCY" Then
            strUser = Right(strUser, (Len(strUser) - 6)).ToString
        Else
            strUser = Right(strUser, (Len(strUser) - 9)).ToString
        End If

        strSQL = "UPDATE TROOMBOOKINGS SET updatedBy='" + strUser + "' WHERE roomBookingID=" + txtBookID.Text.ToString
        Dim Com3 As New System.Data.SqlClient.SqlCommand(strSQL, Con)
        Com3.ExecuteNonQuery()

        strSQL = "INSERT INTO TROOMBOOKINGS_DELETE SELECT * FROM TROOMBOOKINGS WHERE roomBookingID=" + txtBookID.Text.ToString
        Dim Com2 As New System.Data.SqlClient.SqlCommand(strSQL, Con)
        Com2.ExecuteNonQuery()
        strSQL = "DELETE FROM TROOMBOOKINGS WHERE roomBookingID=" + txtBookID.Text.ToString
        Dim Com As New System.Data.SqlClient.SqlCommand(strSQL, Con)
        Com.ExecuteNonQuery()
        Com.Dispose()
        Con.Dispose()
        Com = Nothing
        Con = Nothing
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        deleteBooking()
        Response.Redirect("default.aspx?day=" + txtBookDate.Text.ToString)
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("default.aspx?day=" + txtBookDate.Text.ToString)
    End Sub
End Class
