Imports System.Collections.Generic

Partial Class visitors
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            getStaff()
            popGV()
        End If
    End Sub

    Private Sub getStaff()
        Dim connString As String = ConfigurationManager.ConnectionStrings("roomsSQL").ConnectionString
        Dim Con As New System.Data.SqlClient.SqlConnection(connString)
        Con.Open()
        Dim strSQL As String
        strSQL = "SELECT samAccountName, name FROM TUSERS WHERE curEmp=1 ORDER BY name ASC"
        Dim Com As New System.Data.SqlClient.SqlCommand(strSQL, Con)
        Dim rdr As System.Data.SqlClient.SqlDataReader = Com.ExecuteReader()
        While rdr.Read()
            Dim newListItem As New ListItem()
            newListItem.Value = UCase(rdr.GetString(0)).ToString
            newListItem.Text = rdr.GetString(1)
            txtStaffArrival.Items.Add(newListItem)
        End While
        Con.Close()


        Dim strUser = UCase(Request.ServerVariables(5).ToString())
        If Left(UCase(strUser), 5) = "NICCY" Then
            txtStaffArrival.SelectedValue = Right(strUser, (Len(strUser) - 6)).ToString
        Else
            txtStaffArrival.SelectedValue = Right(strUser, (Len(strUser) - 9)).ToString
        End If
    End Sub


    Protected Sub txtVisitorType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVisitorType.SelectedIndexChanged
        trVisitorNames.Visible = False
        trVisitorName.Visible = False
        trDeliveryDetails.Visible = False
        trJobDetails.Visible = False
        trCompanyName.Visible = False
        trSpecialRequirements.Visible = False
        trNewVisitorButton.Visible = False
        trVisitorNo.Visible = False

        If txtVisitorType.SelectedValue = "1" Then
            trVisitorNames.Visible = True
            trVisitorName.Visible = True
            trSpecialRequirements.Visible = True
            trNewVisitorButton.Visible = True
            trVisitorNo.Visible = True
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

    Protected Sub bntNewVisitor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNewVisitor.Click
        If txtVisitorName.Text.ToString() = "" Then
            lblNewVisitorWarning.Text = "Must Enter a Visitor Name"
        Else
            addVisitor()
            txtVisitorName.Text = ""
            txtSpecialRequirements.Text = ""
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


    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

        If txtVisitDate.Text.Length > 0 Then
            If IsDate(txtVisitDate.Text.ToString()) Then
                addNewVisitorRec()
            Else
                lblMainWarning.Text = "Must Enter a Valid Visit Date"
            End If
        Else
            lblMainWarning.Text = "Must Enter a Valid Visit Date"
        End If
    End Sub


    Protected Sub removeVisitor(vIndex As Integer)
        Dim lstVisitors As New List(Of visitor)
        Dim v As New visitor()
        Dim json = txtVisitorNames.Text.ToString()
        Dim jss As New System.Web.Script.Serialization.JavaScriptSerializer()
        If (json.Length > 0) Then
            lstVisitors = jss.Deserialize(Of List(Of visitor))(json)
        End If
        lstVisitors.RemoveAt(vIndex)
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



    Sub gvVisitorsRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

        If e.CommandName = "deleteElement" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            removeVisitor(index)
        End If

    End Sub





    Private Sub addNewVisitorRec()
        Dim connString As String = ConfigurationManager.ConnectionStrings("roomsSQL").ConnectionString
        Dim strSQL As String
        Dim Con As New System.Data.SqlClient.SqlConnection(connString)
        Dim varDetail As String = ""
        Dim varDeliveryDetails As String = ""
        Dim varJobDetails As String = ""
        Dim varNoAttending As Integer = 0
        Dim varSpecialInstructions As String = ""
        Dim iresult As Integer
        Con.Open()
        If Not IsNothing(txtDeliveryDetails.Text) Then
            If Len(txtDeliveryDetails.Text) > 0 Then
                varDeliveryDetails = Replace(txtDeliveryDetails.Text, "'", "''").ToString
            End If
        End If

        If Not IsNothing(txtJobDetails.Text) Then
            If Len(txtJobDetails.Text) > 0 Then
                varJobDetails = Replace(txtJobDetails.Text, "'", "''").ToString
            End If
        End If

        If Not IsNothing(txtSpecialInstructions.Text) Then
            If Len(txtSpecialInstructions.Text) > 0 Then
                varSpecialInstructions = Replace(txtSpecialInstructions.Text, "'", "''").ToString
            End If
        End If

        Dim strUser = UCase(Request.ServerVariables(5).ToString())

        strSQL = "INSERT INTO [dbo].[TVISITORS] (visitorDate,visitorContactOnArrival,visitorType,visitorGUID,visitorCompany,visitorJobDetails,visitorDeliveryDetails,visitorNames,visitorBookedBy,visitorDateTimeStamp,visitorNo, visitorStartTime, visitorInstructions)" & _
        " VALUES " & _
        "('" & Month(CDate(txtVisitDate.Text.ToString())) & "/" & Day(CDate(txtVisitDate.Text.ToString())) & "/" & Year(CDate(txtVisitDate.Text.ToString())) & "','" & _
          txtStaffArrival.SelectedValue.ToString() + "'," & _
          txtVisitorType.SelectedValue.ToString() + "," & _
           "''," & _
           "'" & txtCompanyName.Text.ToString() + "'," & _
           "'" & txtJobDetails.Text.ToString() + "'," & _
         "'" & txtDeliveryDetails.Text.ToString() + "'," & _
          "'" & txtVisitorNames.Text.ToString() + "'," & _
          "'" & strUser & "',getDate(), " & txtVisitorNo.SelectedValue.ToString() & "," & txtVisitorStartTime.SelectedValue.ToString() & ",'" + varSpecialInstructions + "')"
        Dim Com As New System.Data.SqlClient.SqlCommand(strSQL, Con)
        iresult = Com.ExecuteNonQuery()
        If iresult > 0 Then
            lblMainWarning.ForeColor = Drawing.Color.Green
            txtVisitDate.Text = ""
            lblMainWarning.Text = "Successfully added New Record"
            txtVisitorType.SelectedValue = 1
            txtVisitorNo.SelectedValue = 1
            txtSpecialInstructions.Text = ""
            txtVisitorStartTime.SelectedValue = "0"
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
    End Sub


End Class
