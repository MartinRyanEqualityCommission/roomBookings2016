<%@ Page MaintainScrollPositionOnPostback="False" Language="VB" MasterPageFile="~/roomLook.master" AutoEventWireup="true" CodeFile="reports.aspx.vb" Inherits="_Default" %>
<asp:Content runat="server" ContentPlaceHolderID="mainContent">
<div class="row">
<div class="col-lg-12" style="background-color: #EFEFEF">
<div class="well well-sm">
<table width="80%" class="table table-striped">
<tr><th colspan="2">Report Name</th></tr>
<tr><td>&nbsp;</td><td><a href="foodForWeek.aspx">Housekeeper Report</a> - Weekly Display of all bookings that have Catering Requirements</td></tr>
<tr><td>&nbsp;</td><td><a href="setupForWeek.aspx">Room Setup Report</a> - Weekly Display of all bookings that have Special Requirements</td></tr>
<tr runat="server" visible="false" id="visitorReport"><td>&nbsp;</td><td><a href="visitorsForWeek.aspx">Visitors Report</a> - Weekly Display of all Visitors</td></tr>
</table>
</div>
</div>
</div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="navReports">
<li id="current"><a href="reports.aspx">Reports</a></li>
</asp:Content>