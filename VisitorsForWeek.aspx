<%@ Page MaintainScrollPositionOnPostback="true" Language="VB" MasterPageFile="~/roomLook.master" AutoEventWireup="true" CodeFile="VisitorsForWeek.aspx.vb" Inherits="_Default" %>
<asp:Content runat="server" ContentPlaceHolderID="mainContent">
<div class="row">
<div class="col-lg-12" style="background-color: #EFEFEF">
<div class="well well-sm">

<form id="defaultForm" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<asp:Panel ID="weekGrid" runat="server">
<table width="98%" class="table table-striped" cellspacing="0px">
<tr><th width="170px"><asp:Button CssClass="btn btn-primary" ID="btnPrev" runat="server" Text="Prev" />&nbsp;<asp:Button CssClass="btn btn-primary" ID="btnNext" runat="server" Text="Next" /></th><th colspan="5"><asp:Label ID="lblDayDesc" runat="server" Text="Today"></asp:Label><span style="float: right;"><a href="reports.aspx">Back to Reports Menu</a></span></th></tr>
</table>
<div id="weekSetupDisplay" runat="server">

</div>
<asp:Button CssClass="btn btn-primary" ID="btnPrintOut" runat="server" Text="Print" />
<asp:TextBox ID="txtCurrentDate" Visible="false" runat="server"></asp:TextBox>
</asp:Panel>
</form>
</div>
</div>
</div>

</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="navReports">
<li id="current"><a href="reports.aspx">Reports</a></li>
</asp:Content>