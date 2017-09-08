<%@ Page MaintainScrollPositionOnPostback="true" Language="VB" MasterPageFile="~/roomLook.master" AutoEventWireup="true" CodeFile="week.aspx.vb" Inherits="_WeekNew" %>
<asp:Content runat="server" ContentPlaceHolderID="mainContent">
<div class="row">
<div class="col-lg-12" style="background-color: #EFEFEF">
<div class="well well-sm">
<form id="defaultForm" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<asp:Panel ID="dayGrid" runat="server">
<table cellspacing="1px" class="table-condensed table-striped">
<tr>
<th rowspan="2" style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; border-top: 1px solid #003399; color: #003399; padding: 5px;"><asp:Button CssClass="btn btn-primary" ID="btnPrev" runat="server" Text="Prev" />&nbsp;<asp:Button CssClass="btn btn-primary" ID="btnNext" runat="server" Text="Next" /></th>
<th colspan="5" style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px; border-top: 1px solid #003399;"><asp:Label ID="lblDayDesc" runat="server" Text="Today"></asp:Label></th>
</tr>
<tr>
<th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;">MON</th>
<th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;">TUE</th>
<th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;">WED</th>
<th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;">THU</th>
<th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;">FRI</th></tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;">Board Room</th><td><asp:Button CssClass="freewk" ID="slot1" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot8" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot15" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot22" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot29" runat="server" Text="" /></td></tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;">Ante Room</th><td><asp:Button CssClass="freewk" ID="slot2" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot9" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot16" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot23" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot30" runat="server" Text="" /></td></tr>
<tr style="display: none;"><th>Training Room</th><td><asp:Button CssClass="freewk" ID="slot3" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot10" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot17" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot24" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot31" runat="server" Text="" /></td></tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;">Meeting Room 3</th><td><asp:Button CssClass="freewk" ID="slot4" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot11" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot18" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot25" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot32" runat="server" Text="" /></td></tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;">Meeting Room 1</th><td><asp:Button CssClass="freewk" ID="slot5" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot12" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot19" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot26" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot33" runat="server" Text="" /></td></tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;">Meeting Room 2</th><td><asp:Button CssClass="freewk" ID="slot6" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot13" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot20" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot27" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot34" runat="server" Text="" /></td></tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;">Glass Room</th><td><asp:Button CssClass="freewk" ID="slot7" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot14" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot21" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot28" runat="server" Text="" /></td><td><asp:Button CssClass="freewk" ID="slot35" runat="server" Text="" /></td></tr>
<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td><asp:TextBox ID="txtCurrentDate" Visible="false" runat="server"></asp:TextBox></td><td>&nbsp;</td></tr>
</table>
</asp:Panel>
<asp:Panel Visible="false" ID="newBooking" runat="server">
<table width="60%">
<tr><th width="30%">&nbsp;</th><th>
    <asp:Label ID="lblRoomName" runat="server" Text="Label"></asp:Label></th></tr>
<tr><th>Booking Officer</th><td class="style1"><asp:Label runat="server" ID="lblOfficer"></asp:Label></td></tr>
<tr><th>Day</th><td class="style1"><asp:Label runat="server" ID="lblDay"></asp:Label></td></tr>
<tr><th>Start Time</th><td class="style1"><asp:Label runat="server" ID="lblStartTime"></asp:Label></td></tr>
<tr><th>End Time</th><td class="style1"><asp:Label runat="server" ID="lblEndTime"></asp:Label></td></tr>
<tr><th>Event Name</th><td class="style1"><asp:TextBox Width="280px" ID="txtTitle" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="valEventName" ControlToValidate="txtTitle" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
</td></tr>
<tr><th>Number Attending</th><td class="style1">
<asp:TextBox ID="txtNoAttending" runat="server"></asp:TextBox>
<asp:RangeValidator ID="valRangeName" MaximumValue="500" MinimumValue="0" runat="server" ControlToValidate="txtNoAttending" Type="Integer" ErrorMessage="*"></asp:RangeValidator>
</td></tr>
<tr><th>Details</th><td class="style1"><asp:TextBox Width="280px" TextMode="MultiLine" Rows="3" ID="txtDetail" runat="server"></asp:TextBox></td></tr>
<tr><th>Catering Required</th><td class="style1">
    <asp:DropDownList AutoPostBack="true" ID="txtCatering" runat="server">
    <asp:ListItem Selected="True" Value="2" Text="No"></asp:ListItem>
    <asp:ListItem value="1" Text="Yes"></asp:ListItem>
    </asp:DropDownList>
</td></tr>
</table>
</asp:Panel>
<asp:Panel Visible="false" ID="food" runat="server">
<table width="60%">
<tr><th width="30%">Time of which food is Required</th><td class="style1"><asp:TextBox Width="260px" TextMode="MultiLine" Rows="3" ID="TextBox2" runat="server"></asp:TextBox></td></tr>
<tr><th>Food Types Required</th><td class="style1"><asp:TextBox TextMode="MultiLine" Width="260px" Rows="3" ID="TextBox4" runat="server"></asp:TextBox></td></tr>
<tr><th>Any Special Requirments</th><td class="style1"><asp:TextBox TextMode="MultiLine" Width="260px" Rows="3" ID="TextBox5" runat="server"></asp:TextBox></td></tr>
</table>
</asp:Panel>
<asp:Panel Visible="false" ID="submit" runat="server">
<table>
<tr><td><asp:Button ID="btnSubmit" CssClass="button" runat="server" Text="Submit" /></td></tr>
</table>
</asp:Panel>
</form>
</div>
</div>
</div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="navWeek">
<li id="current"><a href="week.aspx">Week View</a></li>
</asp:Content>