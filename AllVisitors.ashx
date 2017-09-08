<%@ WebHandler Language="VB" Class=" Handler" %>
Imports System
Imports System.Web
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Imports System.Collections.Generic

Imports System.Web.Script.Serialization

 

Public Class Handler : Implements IHttpHandler

    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        Dim callback As String = context.Request.QueryString("callback")

        Dim customerId As Integer = 0

        Integer.TryParse(context.Request.QueryString("customerId"), customerId)

        Dim json As String = Me.GetCustomersJSON(customerId)

        If Not String.IsNullOrEmpty(callback) Then
            json = String.Format("{0}({1});", callback, json)
        End If
        context.Response.ContentType = "text/json"
        context.Response.Write(json)

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
    

    Private Function GetCustomersJSON(customerId As Integer) As String
        Dim visitors As New List(Of visitorData)()
        Dim strSQL = "SELECT TVISITORS.*, isNull(visitorNo,0) as vNumber, isNull(visitorType,1) as vType, convert(nvarchar(12),visitorDate,103) as vDate, convert(nvarchar(5),108) as vTime, isNull(visitorGUID,'') as GUID, visitRoom=(SELECT isNull(roomID,0) FROM TROOMBOOKINGS WHERE Convert(VARCHAR(255), TROOMBOOKINGS.visitorGUID)=Convert(VARCHAR(255), TVISITORS.visitorGUID)) FROM TVISITORS"
        Dim strFilter = ""
        Using conn As New SqlConnection()
            conn.ConnectionString = ConfigurationManager.ConnectionStrings("roomsSQL").ConnectionString
            Using cmd As New SqlCommand()
                '                cmd.Parameters.AddWithValue("@CustomerId", customerId)
                
                strFilter = " WHERE REPLACE(visitorBookedBy,'EQUALITY\','')=REPLACE('" + HttpContext.Current.Request.ServerVariables(5).ToString().ToUpper() + "','EQUALITY\','') OR REPLACE(visitorContactOnArrival,'EQUALITY\','')=REPLACE('" + HttpContext.Current.Request.ServerVariables(5).ToString().ToUpper() + "','EQUALITY\','')"
                
                If HttpContext.Current.Request.ServerVariables(5).ToString().ToUpper() = "EQUALITY\MRYAN" Then
                    strFilter = ""
                End If
                
                strSQL = strSQL + strFilter
                cmd.CommandText = strSQL                
                cmd.Connection = conn
                conn.Open()
                Using sdr As SqlDataReader = cmd.ExecuteReader()

                    While sdr.Read()
                        Dim v As New visitorData
                        Dim dt As New DateTime
                        v.OfficerName = sdr("visitorBookedby").ToString().Replace("EQUALITY\", "")
                        v.ContactName = sdr("visitorContactOnArrival").ToString().Replace("EQUALITY\", "")
                        v.VisitDate = sdr("vDate")
                        v.VisitType = "Stakeholder/Customer"
                        v.VisitNo = sdr("vNumber")
                        v.VisitNames = sdr("visitorNames")
                        v.GUID = sdr("GUID")
                        
                        
                        If IsDate(sdr("visitorDate").ToString()) Then
                            dt = DateTime.Parse(sdr("visitorDate").ToString())
                        End If
                        v.VisitDateTicks = dt.Ticks
                        v.VisitID = sdr("visitorID")
                        If (sdr("visitRoom").ToString() = "1") Then v.VisitRoom = "Board Room"
                        If (sdr("visitRoom").ToString() = "2") Then v.VisitRoom = "Ante Room"
                        If (sdr("visitRoom").ToString() = "3") Then v.VisitRoom = "Meeting Room 3"
                        If (sdr("visitRoom").ToString() = "4") Then v.VisitRoom = "Meeting Room 1"
                        If (sdr("visitRoom").ToString() = "5") Then v.VisitRoom = "Meeting Room 2"
                        If (sdr("visitRoom").ToString() = "6") Then v.VisitRoom = "Glass Room"
                        If (v.VisitNames.Length > 0) Then
                            Dim lstVisitors As New List(Of visitor)
                            Dim json = v.VisitNames.ToString()
                            Dim jss As New System.Web.Script.Serialization.JavaScriptSerializer()
                            If (json.Length > 0) Then
                                lstVisitors = jss.Deserialize(Of List(Of visitor))(json)
                            End If
                            Dim jSearializer As New System.Web.Script.Serialization.JavaScriptSerializer()
                            v.VisitNames = ""
                            For Each vis In lstVisitors
                                v.VisitNames += vis.VisitorName + " "
                            Next
                        End If
                        
                        
                        If (sdr("vType") = "2") Then v.VisitType = "Maintenance"
                        If (sdr("vType") = "3") Then v.VisitType = "Delivery"
                        visitors.Add(v)
                    End While
                End Using
                conn.Close()
            End Using

            Return (New JavaScriptSerializer().Serialize(visitors))

        End Using
    End Function

    
    Public Class visitorData
        Private _OfficerName As String
        Private _ContactName As String
        Private _VisitDate As String
        Private _VisitNo As String
        Private _VisitType As String
        Private _VisitNames As String
        Private _VisitRoom As String
        Private _GUID As String
        Private _VisitID As String
        Private _VisitDateTicks As Long

        Public Property VisitID() As String
            Get
                Return _VisitID
            End Get
            Set(ByVal value As String)
                _VisitID = value
            End Set
        End Property
        
        
        Public Property VisitNames() As String
            Get
                Return _VisitNames
            End Get
            Set(ByVal value As String)
                _VisitNames = value
            End Set
        End Property
        
        Public Property OfficerName() As String
            Get
                Return _OfficerName
            End Get
            Set(ByVal value As String)
                _OfficerName = value
            End Set
        End Property

        Public Property ContactName() As String
            Get
                Return _ContactName
            End Get
            Set(ByVal value As String)
                _ContactName = value
            End Set
        End Property

        Public Property VisitDateTicks() As Long
            Get
                Return _VisitDateTicks
            End Get
            Set(ByVal value As Long)
                _VisitDateTicks = value
            End Set
        End Property
        
        
        
        Public Property VisitDate() As String
            Get
                Return _VisitDate
            End Get
            Set(ByVal value As String)
                _VisitDate = value
            End Set
        End Property

        Public Property VisitNo() As String
            Get
                Return _VisitNo
            End Get
            Set(ByVal value As String)
                _VisitNo = value
            End Set
        End Property
        
        Public Property VisitType() As String
            Get
                Return _VisitType
            End Get
            Set(ByVal value As String)
                _VisitType = value
            End Set
        End Property
        
        Public Property VisitRoom() As String
            Get
                Return _VisitRoom
            End Get
            Set(ByVal value As String)
                _VisitRoom = value
            End Set
        End Property

        Public Property GUID() As String
            Get
                Return _GUID
            End Get
            Set(ByVal value As String)
                _GUID = value
            End Set
        End Property

    End Class


        Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
            Get
                Return False
            End Get
        End Property
    End Class




