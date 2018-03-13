Imports System.Collections.Generic

Partial Class EditVisitor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            If Not IsNothing(Request.QueryString("ID")) Then
                getStaff()
                popData(CInt(Request.QueryString("ID")))
                popGV()
            End If
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
            row("Name") = vis.VisitorName
            row("Special Requirements") = vis.SpecialRequirements
            dataTable.Rows.Add(row)
        Next
        gvVisitors.DataSource = dataTable
        gvVisitors.DataBind()
    End Sub


    Private Sub getStaff()
        Dim connString As String = ConfigurationManager.ConnectionStrings("roomsSQL").ConnectionString
        Dim Con As New System.Data.SqlClient.SqlConnection(connString)
        Con.Open()
        Dim strSQL As String
        strSQL = "SELECT samAccountName, name FROM TUSERS WHERE curEmp=1 AND department < 13 ORDER BY name ASC"
        Dim Com As New System.Data.SqlClient.SqlCommand(strSQL, Con)
        Dim rdr As System.Data.SqlClient.SqlDataReader = Com.ExecuteReader()
        txtStaffArrival.Items.Insert(0, New ListItem("-- Please Select --", ""))
        While rdr.Read()
            Dim newListItem2 As New ListItem()
            newListItem2.Value = UCase(rdr.GetString(0)).ToString
            newListItem2.Text = rdr.GetString(1)
            txtStaffArrival.Items.Add(newListItem2)
        End While
        Con.Close()
    End Sub

    Protected Sub txtVisitorType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVisitorType.SelectedIndexChanged
        resetViews()
    End Sub


    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("visitorSearch.aspx")
    End Sub



    Protected Sub btnSaveChanges_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveChanges.Click
        saveChanges()
        Response.Redirect("visitorSearch.aspx")
    End Sub

    Private Sub resetViews()
        trVisitorNames.Visible = False
        trVisitorName.Visible = False
        trDeliveryDetails.Visible = False
        trJobDetails.Visible = False
        trCompanyName.Visible = False
        trSpecialRequirements.Visible = False
        btnNewVisitor.Visible = False

        If txtVisitorType.SelectedValue = "1" Then
            trVisitorNames.Visible = True
            trVisitorName.Visible = True
            trSpecialRequirements.Visible = True
            btnNewVisitor.Visible = True
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
        Dim result As Integer
        Con.Open()

        strUser = Request.ServerVariables(5).ToString
        If Left(UCase(strUser), 5) = "NICCY" Then
            strUser = Right(strUser, (Len(strUser) - 6)).ToString
        Else
            strUser = Right(strUser, (Len(strUser) - 9)).ToString
        End If
        strUser = UCase(Request.ServerVariables(5).ToString())
        strSQL = "UPDATE TVISITORS SET visitorContactOnArrival='" & txtStaffArrival.SelectedValue.ToString() + "',visitorNames='" & txtVisitorNames.Text.ToString() & "', visitorStartTime=" & txtVisitorStartTime.SelectedValue & ", visitorCompany='" & txtCompanyName.Text.ToString().Replace("'", "''").ToString() & "', visitorNo=" & txtVisitorNo.SelectedValue.ToString() & ", visitorType=" & txtVisitorType.SelectedValue.ToString() & ", visitorJobDetails='" & txtJobDetails.Text.ToString().Replace("'", "''").ToString() + "', visitorDeliveryDetails='" & txtDeliveryDetails.Text.ToString().Replace("'", "''").ToString() + "', visitorInstructions='" & txtSpecialInstructions.Text.ToString().Replace("'", "''").ToString() & "', UPDATEDBY='" & strUser & "', UPDATEDDATETIME=getDate()" & _
                     " WHERE visitorID=" & txtVisitorID.Value.ToString()
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

        'Response.Write(strSQL.ToString)
        ComV.Dispose()
        Con.Dispose()
        ComV = Nothing
        Con = Nothing
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


    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        deleteBooking()
        Response.Redirect("visitorSearch.aspx")
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

        strSQL = "UPDATE TVISITORS SET updatedBy='" + strUser + "' WHERE visitorID=" + txtVisitorID.Value.ToString()
        Dim Com3 As New System.Data.SqlClient.SqlCommand(strSQL, Con)
        Com3.ExecuteNonQuery()

        strSQL = "INSERT INTO TVISITORS_DELETE SELECT * FROM TVISITORS WHERE visitorID=" + txtVisitorID.Value.ToString()
        Dim Com2 As New System.Data.SqlClient.SqlCommand(strSQL, Con)
        Com2.ExecuteNonQuery()
        strSQL = "DELETE FROM TVISITORS WHERE visitorID=" + txtVisitorID.Value.ToString()
        Dim Com As New System.Data.SqlClient.SqlCommand(strSQL, Con)
        Com.ExecuteNonQuery()
        Com.Dispose()
        Con.Dispose()
        Com = Nothing
        Con = Nothing
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


    Private Sub popData(ByVal ID As Integer)
        Dim connString As String = ConfigurationManager.ConnectionStrings("roomsSQL").ConnectionString
        Dim strSQL As String
        Dim Con As New System.Data.SqlClient.SqlConnection(connString)
        Con.Open()
        strSQL = "SELECT v.*" & _
                 " FROM TVISITORS v WHERE v.visitorID=" + ID.ToString
        Dim Com As New System.Data.SqlClient.SqlCommand(strSQL, Con)
        Dim rdr As System.Data.SqlClient.SqlDataReader = Com.ExecuteReader()
        Dim strUser As String = ""

        txtVisitorID.Value = ID.ToString()
        While rdr.Read()

            If Not IsDBNull(rdr("visitorDate")) Then
                If IsDate(rdr("visitorDate")) Then txtVisitDate.Text = CDate(rdr("visitorDate")).Day.ToString() + "/" + CDate(rdr("visitorDate")).Month.ToString() + "/" + CDate(rdr("visitorDate")).Year.ToString()
            End If

            If Not IsDBNull(rdr("visitorType")) Then
                If IsNumeric(rdr("visitorType")) Then txtVisitorType.SelectedValue = rdr("visitorType").ToString
            End If

            If Not IsDBNull(rdr("visitorNo")) Then
                If IsNumeric(rdr("visitorNo")) Then txtVisitorNo.SelectedValue = rdr("visitorNo").ToString
            End If


            If Not IsDBNull(rdr("visitorStartTime")) Then
                If IsNumeric(rdr("visitorStartTime")) Then txtVisitorStartTime.SelectedValue = rdr("visitorStartTime").ToString
            End If

            If Not IsDBNull(rdr("visitorInstructions")) Then
                txtSpecialInstructions.Text = rdr("visitorInstructions").ToString()
            End If
            resetViews()

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


        End While

        rdr.Close()
        Com.Dispose()
        Con.Close()
        Con = Nothing


    End Sub

    Protected Sub popGV()
        Dim lstVisitors As New List(Of visitor)
        Dim v As New visitor()
        Dim json = txtVisitorNames.Text.ToString()
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



End Class
