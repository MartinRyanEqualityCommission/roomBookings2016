<%@ Page MaintainScrollPositionOnPostback="true" Language="VB" MasterPageFile="~/roomLook.master" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Home" %>
<asp:Content runat="server" ContentPlaceHolderID="mainContent">
    <form id="defaultForm" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<Triggers>
<asp:PostBackTrigger ControlID="txtCurrentDate" />
</Triggers>
<ContentTemplate>
<div class="row">
<div class="col-lg-12" style="background-color: #EFEFEF">
<div class="well well-sm">
<asp:Panel ID="dayGrid" runat="server">
<table cellspacing="0px" cellpadding="0" id="mainTable" class="table-condensed table-striped">
<tr><th rowspan="2" style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding: 5px;"><asp:Button CssClass="btn btn-primary" ID="btnPrev" runat="server" Text="Prev" />&nbsp;<asp:Button CssClass="btn btn-primary" ID="btnNext" runat="server" Text="Next" /><br /><br />Click on the Room Name<br />to view more details<br />(capacity)</th>
<th colspan="3" style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-top: 1px solid #003399; color: #003399;"><asp:Label ID="lblDayDesc" runat="server" Text="Today"></asp:Label></th>
<th colspan="3" style="text-align: center; background-color: #DDEBF5; border-top: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">
<asp:TextBox ID="txtCurrentDate" CssClass="form-control" Enabled="true" AutoPostBack="true" Visible="true" runat="server"></asp:TextBox></th></tr>
<tr>
<th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">
<div style="color: #004b82; cursor: pointer;" class="boardRoom" id="boardRoom">Board<br />Room<br />(10-32)</div></th>
<th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;"><div style="color: #004b82; cursor: pointer;" class="boardRoom" id="anteRoom">Ante<br />Room<br />(6-16)</div></th>
<th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;"><div style="color: #004b82; cursor: pointer;" class="boardRoom" id="meet3Room">Meeting<br />Room 3<br />1st floor<br />(4-8)</div></th>
<th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;"><div style="color: #004b82; cursor: pointer;" class="boardRoom" id="meet1Room">Meeting<br />Room 1<br />(2-6)</div></th>
<th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;"><div style="color: #004b82; cursor: pointer;" class="boardRoom" id="meet2Room">Meeting<br />Room 2<br />(2-6)</div></th>
<th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;"><div style="color: #004b82; cursor: pointer;" class="boardRoom" id="glassRoom">Meeting<br />Room 4<br />Glass<br />Room<br />4th floor<br />(2-6)</div></th></tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">8:00</th>
<td valign="top">
<asp:Button CssClass="booked" Visible="false" ID="book1" runat="server" Text="" />
<asp:Button CssClass="free" ID="slot1" runat="server" Text="" />
</td>
<td>
<asp:Button Visible="false" CssClass="booked" ID="book23" runat="server" Text="" />
<asp:Button CssClass="free" ID="slot23" runat="server" style="cursor: pointer;" Text="" />
</td>
<td>
<asp:Button Visible="false" CssClass="booked" ID="book45" runat="server" Text="" />
<asp:Button CssClass="free" ID="slot45" runat="server" Text="" />
</td>
<td>
<asp:Button Visible="false" CssClass="booked" ID="book67" runat="server" Text="" />
<asp:Button CssClass="free" ID="slot67" runat="server" Text="" />
</td>
<td>
<asp:Button Visible="false" CssClass="booked" ID="book89" runat="server" Text="" />
<asp:Button CssClass="free" ID="slot89" runat="server" Text="" />
</td>
<td>
<asp:Button Visible="false" CssClass="booked" ID="book111" runat="server" Text="" />
<asp:Button CssClass="free" ID="slot111" runat="server" Text="" />
</td>
</tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">8:30</th>
<td>
    <asp:Button CssClass="free" ID="slot2" runat="server" Text="" />
    <asp:Button CssClass="booked" Visible="false" ID="book2" runat="server" Text="" />
</td>
<td>
<asp:Button Visible="false" CssClass="booked" ID="book24" runat="server" Text="" />
<asp:Button CssClass="free" ID="slot24" runat="server" style="cursor: pointer;" Text="" />
</td>
<td>
<asp:Button Visible="false" CssClass="booked" ID="book46" runat="server" Text="" />
<asp:Button CssClass="free" ID="slot46" runat="server" Text="" />
</td>
<td>
<asp:Button Visible="false" CssClass="booked" ID="book68" runat="server" Text="" />
<asp:Button CssClass="free" ID="slot68" runat="server" Text="" />
</td>
<td>
<asp:Button Visible="false" CssClass="booked" ID="book90" runat="server" Text="" />
<asp:Button CssClass="free" ID="slot90" runat="server" Text="" />
</td>
<td>
<asp:Button Visible="false" CssClass="booked" ID="book112" runat="server" Text="" />
<asp:Button CssClass="free" ID="slot112" runat="server" Text="" />
</td>
</tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">9:00</th>
    <td>
    <asp:Button CssClass="booked" Visible="false" ID="book3" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot3" runat="server" Text="" />
    </td>
    <td><asp:Button Visible="false" CssClass="booked" ID="book25" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot25" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book47" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot47" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book69" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot69" runat="server" Text="" /></td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book91" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot91" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book113" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot113" runat="server" Text="" />
    </td>
    </tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">9:30</th>
    <td><asp:Button CssClass="booked" Visible="false" ID="book4" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot4" runat="server" Text="" />
</td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book26" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot26" runat="server" Text="" />
    </td>
    <td><asp:Button Visible="false" CssClass="booked" ID="book48" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot48" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book70" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot70" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book92" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot92" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book114" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot114" runat="server" Text="" />
    </td>
</tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">10:00</th>
    <td>
    <asp:Button CssClass="booked" Visible="false" ID="book5" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot5" runat="server" Text="" />
    </td>
    <td><asp:Button Visible="false" CssClass="booked" ID="book27" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot27" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book49" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot49" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book71" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot71" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book93" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot93" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book115" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot115" runat="server" Text="" />
    </td>
</tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">10:30</th>
    <td>
    <asp:Button CssClass="booked" Visible="false" ID="book6" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot6" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book28" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot28" runat="server" Text="" />
    </td>
    <td><asp:Button Visible="false" CssClass="booked" ID="book50" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot50" runat="server" Text="" />
    </td>
    <td><asp:Button Visible="false" CssClass="booked" ID="book72" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot72" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book94" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot94" runat="server" Text="" /></td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book116" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot116" runat="server" Text="" />
    </td>
</tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">11:00</th>
    <td>
    <asp:Button CssClass="booked" Visible="false" ID="book7" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot7" runat="server" Text="" />
    </td>
    <td><asp:Button Visible="false" CssClass="booked" ID="book29" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot29" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book51" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot51" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book73" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot73" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book95" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot95" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book117" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot117" runat="server" Text="" />
    </td>
</tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">11:30</th>
    <td>
    <asp:Button CssClass="booked" Visible="false" ID="book8" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot8" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book30" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot30" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book52" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot52" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book74" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot74" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book96" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot96" runat="server" Text="" />
    </td>
    <td><asp:Button Visible="false" CssClass="booked" ID="book118" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot118" runat="server" Text="" />
    </td>
    </tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">12:00</th>
    <td>
    <asp:Button CssClass="booked" Visible="false" ID="book9" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot9" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book31" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot31" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book53" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot53" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book75" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot75" runat="server" Text="" />
    </td>
    <td><asp:Button Visible="false" CssClass="booked" ID="book97" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot97" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book119" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot119" runat="server" Text="" />
    </td>
</tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">12:30</th>
    <td>
    <asp:Button CssClass="booked" Visible="false" ID="book10" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot10" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book32" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot32" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book54" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot54" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book76" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot76" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book98" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot98" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book120" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot120" runat="server" Text="" />
    </td>
    </tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">13:00</th>
    <td>
    <asp:Button CssClass="booked" Visible="false" ID="book11" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot11" runat="server" Text="" />
    </td>
    <td><asp:Button Visible="false" CssClass="booked" ID="book33" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot33" runat="server" Text="" /></td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book55" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot55" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book77" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot77" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book99" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot99" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book121" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot121" runat="server" Text="" />
    </td>
</tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">13:30</th>
    <td>
    <asp:Button CssClass="booked" Visible="false" ID="book12" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot12" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book34" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot34" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book56" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot56" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book78" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot78" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book100" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot100" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book122" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot122" runat="server" Text="" />
    </td>
</tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">14:00</th>
    <td>
    <asp:Button CssClass="booked" Visible="false" ID="book13" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot13" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book35" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot35" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book57" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot57" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book79" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot79" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book101" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot101" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book123" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot123" runat="server" Text="" />
    </td>
</tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">14:30</th>
    <td>
    <asp:Button CssClass="booked" Visible="false" ID="book14" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot14" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book36" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot36" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book58" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot58" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book80" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot80" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book102" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot102" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book124" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot124" runat="server" Text="" /></td>
</tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">15:00</th>
    <td>
    <asp:Button CssClass="booked" Visible="false" ID="book15" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot15" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book37" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot37" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book59" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot59" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book81" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot81" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book103" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot103" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book125" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot125" runat="server" Text="" />
    </td>
</tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">15:30</th>
    <td>
    <asp:Button CssClass="booked" Visible="false" ID="book16" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot16" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book38" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot38" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book60" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot60" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book82" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot82" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book104" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot104" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book126" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot126" runat="server" Text="" />
    </td>
</tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">16:00</th>
    <td>
    <asp:Button CssClass="booked" Visible="false" ID="book17" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot17" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book39" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot39" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book61" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot61" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book83" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot83" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book105" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot105" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book127" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot127" runat="server" Text="" />
    </td>
</tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">16:30</th>
    <td>
    <asp:Button CssClass="booked" Visible="false" ID="book18" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot18" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book40" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot40" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book62" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot62" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book84" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot84" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book106" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot106" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book128" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot128" runat="server" Text="" />
    </td>
</tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">17:00</th>
    <td>
    <asp:Button CssClass="booked" Visible="false" ID="book19" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot19" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book41" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot41" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book63" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot63" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book85" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot85" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book107" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot107" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book129" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot129" runat="server" Text="" />
    </td>
</tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">17:30</th>
    <td>
    <asp:Button CssClass="booked" Visible="false" ID="book20" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot20" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book42" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot42" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book64" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot64" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book86" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot86" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book108" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot108" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book130" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot130" runat="server" Text="" />
    </td>
</tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">18:00</th>
    <td>
    <asp:Button CssClass="booked" Visible="false" ID="book21" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot21" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book43" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot43" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book65" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot65" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book87" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot87" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book109" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot109" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book131" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot131" runat="server" Text="" />
    </td>
</tr>
<tr><th style="text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">18:30</th>
    <td>
    <asp:Button CssClass="booked" Visible="false" ID="book22" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot22" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book44" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot44" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book66" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot66" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book88" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot88" runat="server" Text="" /></td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book110" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot110" runat="server" Text="" />
    </td>
    <td>
    <asp:Button Visible="false" CssClass="booked" ID="book132" runat="server" Text="" />
    <asp:Button CssClass="free" ID="slot132" runat="server" Text="" />
    </td>
</tr>
<tr><td>&nbsp;</td><td><asp:TextBox Width="20px" ID="txtStart1" Visible="false" Text="0" runat="server"></asp:TextBox><asp:TextBox Visible="false" Width="20px" ID="txtEnd1" Text="0" runat="server"></asp:TextBox></td><td><asp:TextBox Width="20px" ID="txtRoom" Visible="false" Text="0" runat="server"></asp:TextBox></td><td colspan="2">&nbsp;</td><td><asp:Button CssClass="btn btn-primary"  ID="btnClear1" runat="server" Text="Clear" /></td><td><asp:Button CssClass="btn btn-primary" ID="btnBook1" runat="server" Text="Book" /></td></tr>
</table>
</asp:Panel>
<asp:Panel Visible="false" ID="newBooking" runat="server">
<asp:TextBox ID="txtGuid" Visible="false" runat="server"></asp:TextBox>
<table width="60%">
<tr><th width="30%">&nbsp;</th><th>
    <h3><asp:Label ID="lblRoomName" runat="server" Text="Label"></asp:Label></h3></th></tr>
<tr><th style="text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-top: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;"><label>Booking Officer</label></th><td class="style1"><asp:Label runat="server" CssClass="form-control" style="background-color: #EFEFEF;" ID="lblOfficer"></asp:Label></td></tr>
<tr><th style="text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-top: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;"><label>Day</label></th><td class="style1"><asp:Label CssClass="form-control" style="background-color: #EFEFEF;" runat="server" ID="lblDay"></asp:Label></td></tr>
<tr><th style="text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-top: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;"><label>Start Time</label></th><td class="style1"><asp:Label CssClass="form-control" style="background-color: #EFEFEF;" runat="server" ID="lblStartTime"></asp:Label></td></tr>
<tr><th style="text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-top: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;"><label>End Time</label></th><td class="style1"><asp:Label runat="server" CssClass="form-control" style="background-color: #EFEFEF;" ID="lblEndTime"></asp:Label></td></tr>
<tr><th style="text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-top: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;"><label>On behalf of</label></th><td class="style1"><asp:DropDownList CssClass="form-control" ID="txtBehalfOf" runat="server"></asp:DropDownList></td></tr>
<tr><th style="text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-top: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;"><label>Event Name</label></th><td class="style1"><asp:TextBox CssClass="form-control" Width="280px" ID="txtTitle" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="valEventName" ControlToValidate="txtTitle" runat="server" Font-Bold="true" ForeColor="red" Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
</td></tr>
<tr><th style="text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-top: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;"><label>Number Attending</label></th><td class="style1">
<asp:TextBox CssClass="form-control" ID="txtNoAttending" runat="server"></asp:TextBox>
<asp:RangeValidator ID="valRangeName" MaximumValue="500" MinimumValue="0" runat="server" ControlToValidate="txtNoAttending" Type="Integer" Font-Bold="true" ForeColor="red" Display="Dynamic" ErrorMessage="Number Only"></asp:RangeValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtNoAttending" runat="server" Font-Bold="true" ForeColor="red" Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
</td></tr>
<tr><th style="text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-top: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;"><label>Details</label></th><td class="style1">
<asp:TextBox CssClass="form-control" Width="280px" TextMode="MultiLine" Rows="3" ID="txtDetail" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDetail" runat="server" Font-Bold="true" ForeColor="red" Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
</td></tr>
<tr><th style="text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-top: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;"><label>Catering Required</label></th><td class="style1">
    <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="txtFood" runat="server">
    <asp:ListItem Selected="True" Value="2" Text="No"></asp:ListItem>
    <asp:ListItem value="1" Text="Yes"></asp:ListItem>
    </asp:DropDownList>
</td></tr>
<tr><th style="text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-top: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;"><label>Room Setup</label></th><td class="style1">
    <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="txtSR" runat="server">
    <asp:ListItem Selected="True" Value="2" Text="No"></asp:ListItem>
    <asp:ListItem value="1" Text="Yes"></asp:ListItem>
    </asp:DropDownList>
</td></tr>
</table>
</asp:Panel>
<asp:Panel Visible="false" ID="food" runat="server">
<table style="border: 1px; margin-top: 0px; padding-top: 0px;" width="60%">
<tr><th style="text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;" width="30%">Food Details</th><td class="style1"><asp:TextBox CssClass="form-control" Width="260px" TextMode="MultiLine" Rows="3" ID="txtFoodDetails" runat="server"></asp:TextBox></td></tr>
</table>
</asp:Panel>
<asp:Panel Visible="false" ID="SR" runat="server">
<table width="60%">
<tr><th style="text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;" width="30%">Room<br />Setup<br />Details</th><td class="style1"><asp:TextBox CssClass="form-control" TextMode="MultiLine" Width="260px" Rows="3" ID="txtSRDetails" runat="server"></asp:TextBox></td></tr>
</table>
</asp:Panel>
<asp:Panel Visible="false" ID="visitors" runat="server">
<table style="border: 1px; margin-top: 0px; padding-top: 0px;" width="60%">
<tr><td colspan="2">
<h3>Visitors</h3>
</td></tr>
<tr>
<th style="text-align: right; background-color: #DDEBF5; border-top: 1px solid #003399; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;" width="30%">Staff Contact on Arrival</th>
<td class="style1">
<asp:DropDownList CssClass="form-control" ID="txtStaffArrival" runat="server"></asp:DropDownList>
</td></tr>

<tr>
<th style="text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;" width="30%">Estimated Arrival Time</th>
<td class="style1">
<asp:DropDownList CssClass="form-control" ID="txtVisitorStartTime" runat="server">
<asp:ListItem Value="0">-- Select Arrival Time --</asp:ListItem>
<asp:ListItem Value="1">08:00am</asp:ListItem>
<asp:ListItem Value="2">08:30am</asp:ListItem>
<asp:ListItem Value="3">09:00am</asp:ListItem>
<asp:ListItem Value="4">09:30am</asp:ListItem>
<asp:ListItem Value="5">10:00am</asp:ListItem>
<asp:ListItem Value="6">10:30am</asp:ListItem>
<asp:ListItem Value="7">11:00am</asp:ListItem>
<asp:ListItem Value="8">11:30am</asp:ListItem>
<asp:ListItem Value="9">12:00pm</asp:ListItem>
<asp:ListItem Value="10">12:30pm</asp:ListItem>
<asp:ListItem Value="11">13:00pm</asp:ListItem>
<asp:ListItem Value="12">13:30pm</asp:ListItem>
<asp:ListItem Value="13">14:00pm</asp:ListItem>
<asp:ListItem Value="14">14:30pm</asp:ListItem>
<asp:ListItem Value="15">15:00pm</asp:ListItem>
<asp:ListItem Value="16">15:30pm</asp:ListItem>
<asp:ListItem Value="17">16:00pm</asp:ListItem>
<asp:ListItem Value="18">16:30pm</asp:ListItem>
<asp:ListItem Value="19">17:00pm</asp:ListItem>
<asp:ListItem Value="20">17:30pm</asp:ListItem>
<asp:ListItem Value="21">18:00pm</asp:ListItem>
<asp:ListItem Value="22">18:30pm</asp:ListItem>
</asp:DropDownList>
</td></tr>

<tr>
<th style="text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;" width="30%">Visitor Type</th>
<td class="style1">
<asp:DropDownList CssClass="form-control" ID="txtVisitorType" AutoPostBack="true" runat="server">
<asp:ListItem Value="1">Stakeholder / Customer</asp:ListItem>
<asp:ListItem Value="2">Maintenance</asp:ListItem>
<asp:ListItem Value="3">Delivery</asp:ListItem>
</asp:DropDownList>
</td></tr>
<tr runat="server" id="trVisitorNo">
<th style="text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;" width="30%">Visitor No</th>
<td class="style1">
<asp:DropDownList CssClass="form-control" ID="txtVisitorNo" runat="server">
<asp:ListItem Value="0">--Please Select--</asp:ListItem>
<asp:ListItem Value="1">1</asp:ListItem>
<asp:ListItem Value="2">2</asp:ListItem>
<asp:ListItem Value="3">3</asp:ListItem>
<asp:ListItem Value="4">4</asp:ListItem>
<asp:ListItem Value="5">5</asp:ListItem>
<asp:ListItem Value="6">6</asp:ListItem>
<asp:ListItem Value="7">7</asp:ListItem>
<asp:ListItem Value="8">8</asp:ListItem>
<asp:ListItem Value="9">9</asp:ListItem>
<asp:ListItem Value="10">10</asp:ListItem>
<asp:ListItem Value="11">11</asp:ListItem>
<asp:ListItem Value="12">12</asp:ListItem>
<asp:ListItem Value="13">13</asp:ListItem>
<asp:ListItem Value="14">14</asp:ListItem>
<asp:ListItem Value="15">15</asp:ListItem>
<asp:ListItem Value="16">16</asp:ListItem>
<asp:ListItem Value="17">17</asp:ListItem>
<asp:ListItem Value="18">18</asp:ListItem>
<asp:ListItem Value="19">19</asp:ListItem>
<asp:ListItem Value="20">20</asp:ListItem>
<asp:ListItem Value="21">21</asp:ListItem>
<asp:ListItem Value="22">22</asp:ListItem>
<asp:ListItem Value="23">23</asp:ListItem>
<asp:ListItem Value="24">24</asp:ListItem>
<asp:ListItem Value="25">25</asp:ListItem>
<asp:ListItem Value="26">26</asp:ListItem>
<asp:ListItem Value="27">27</asp:ListItem>
<asp:ListItem Value="28">28</asp:ListItem>
<asp:ListItem Value="29">29</asp:ListItem>
<asp:ListItem Value="30">30</asp:ListItem>
<asp:ListItem Value="31">31</asp:ListItem>
<asp:ListItem Value="32">32</asp:ListItem>
<asp:ListItem Value="33">33</asp:ListItem>
<asp:ListItem Value="34">34</asp:ListItem>
<asp:ListItem Value="35">35</asp:ListItem>
<asp:ListItem Value="36">36</asp:ListItem>
<asp:ListItem Value="37">37</asp:ListItem>
<asp:ListItem Value="38">38</asp:ListItem>
<asp:ListItem Value="39">39</asp:ListItem>
<asp:ListItem Value="40">40</asp:ListItem>
<asp:ListItem Value="41">41</asp:ListItem>
<asp:ListItem Value="42">42</asp:ListItem>
<asp:ListItem Value="43">43</asp:ListItem>
<asp:ListItem Value="44">44</asp:ListItem>
<asp:ListItem Value="45">45</asp:ListItem>
<asp:ListItem Value="46">46</asp:ListItem>
<asp:ListItem Value="47">47</asp:ListItem>
<asp:ListItem Value="48">48</asp:ListItem>
<asp:ListItem Value="49">49</asp:ListItem>
<asp:ListItem Value="50">50</asp:ListItem>
</asp:DropDownList>
</td></tr>
<tr runat="server" id="trCompanyName" visible="false">
<th style="text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;" width="30%">Company Name</th>
<td class="style1">
<asp:TextBox ID="txtCompanyName" CssClass="form-control" runat="server"></asp:TextBox>
</td></tr>
<tr  runat="server" id="trJobDetails" visible="false">
<th style="text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;" width="30%">Job Details</th>
<td class="style1">
<asp:TextBox ID="txtJobDetails" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
</td></tr>
<tr runat="server" id="trDeliveryDetails" visible="false">
<th style="text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;" width="30%">Delivery Details</th>
<td class="style1">
<asp:TextBox ID="txtDeliveryDetails" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
</td></tr>
<tr runat="server" id="trVisitorNames" visible="true">
<td class="style1" colspan="2">
<h4>Visitor Names</h4>
<div class="well well-sm" style="background-color: #FFFFFF;">
<asp:TextBox ID="txtVisitorNames" CssClass="form-control" Visible="false" TextMode="MultiLine" runat="server"></asp:TextBox>
<asp:GridView EmptyDataText="No Visitors" GridLines="None" Width="100%" AlternatingRowStyle-BorderColor="#EFEFEF" AlternatingRowStyle-BackColor="#EFEFEF" HeaderStyle-BackColor="AliceBlue" BorderWidth="0" BackColor="#FFFFFF" AlternatingRowStyle-BorderStyle="None" AutoGenerateColumns="false" runat="server" CssClass="table table-condensed" ID="gvVisitors">
 <emptydatarowstyle backcolor="LightBlue"  forecolor="Red" Font-Bold="true"/>
        <emptydatatemplate>
            No Visitors Added  
        </emptydatatemplate>
<Columns>
<asp:TemplateField HeaderText="Visitor Name">
<ItemTemplate>
<%# Eval("Name")%>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Special Requirement">
<ItemTemplate>
<%# Eval("Special Requirements")%>
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>
</div>
</td></tr>
<tr runat="server" id="trVisitorName" visible="true">
<th style="text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; border-top: 1px solid #003399; color: #003399; padding-right: 5px;" width="30%">Name</th>
<td class="style1">
<asp:TextBox ID="txtVisitorName" CssClass="form-control" runat="server"></asp:TextBox>
</td></tr>
<tr runat="server" id="trSpecialRequirements" visible="true">
<th style="text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;" width="30%">Special Requirements</th>
<td class="style1">
<asp:TextBox ID="txtSpecialRequirements" CssClass="form-control" runat="server"></asp:TextBox>
</td></tr>
<tr><th></th><td><asp:Button runat="server" ID="btnNewVisitor" CausesValidation="false" Text="Add Visitor" CssClass="btn btn-primary" />
<asp:Label runat="server" id="lblNewVisitorWarning" Font-Bold="true" ForeColor="Red"></asp:Label>
</td></tr>
</table>
</asp:Panel>
<asp:Panel Visible="false" ID="submit" runat="server">
<table>
<tr><td><asp:Button ID="btnSubmit" CssClass="btn btn-lg btn-primary" runat="server" Text="Submit" /></td></tr>
</table>
</asp:Panel>

</div
</div>
</div>


                        <div class="modal" id="myModalNewCompany">
                                <div class="modal-dialog" style="text-align: center; width: auto;">
   <table width="auto">
   <tr><td colspan="2" style="text-align: center; padding: 5px;"><img title="Room Image" id="roomPic" src="images/anteRoom.jpg" /></td></tr>
   <tr><th style="padding: 5px; width: 40%; text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-top: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">Capacity</th>
   <td style="padding: 5px; width: 60%; text-align: left; background-color: #FFFFFF; border-left: 1px solid #003399; border-top: 1px solid #003399; border-right: 1px solid #003399; color: #000000; font-weight: bold;" id="roomCapacity"></td></tr>
   <tr><th style="padding: 5px; width: 40%; text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">Location</th>
   <td style="padding: 5px; width: 60%; text-align: left; background-color: #EFEFEF; border-left: 1px solid #003399; border-top: 1px solid #003399; border-right: 1px solid #003399; color: #000000; font-weight: bold;" id="roomLocation"></td></tr>
   <tr><th style="padding: 5px; width: 40%; text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">Projector</th>
   <td style="padding: 5px; width: 60%; text-align: left; background-color: #FFFFFF; border-left: 1px solid #003399; border-top: 1px solid #003399; border-right: 1px solid #003399; color: #000000; font-weight: bold;" id="roomAV"></td></tr>
   <tr>
   <th style="padding: 5px; width: 40%; text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">Accessibility</th>
   <td style="padding: 5px; width: 40%; text-align: left; background-color: #EFEFEF; border-left: 1px solid #003399; border-top: 1px solid #003399; border-right: 1px solid #003399; color: #000000; font-weight: bold;" id="roomAccessibility"></td></tr>
   <tr><th style="padding: 5px; width: 40%; text-align: center; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399;">Connectivity</th>
   <td style="padding: 5px; width: 40%; text-align: left; background-color: #FFFFFF; border-left: 1px solid #003399; border-top: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #000000; font-weight: bold;" id="roomConnectivity">&nbsp;</td></tr>
   </table>
   <label style="display: none;" id="roomTitle"></label>
                                </div>
                            </div>
    <asp:SqlDataSource ID="sqlVisitors" runat="server"></asp:SqlDataSource>
</ContentTemplate>
</asp:UpdatePanel>
</form>


<!-- Modal -->
                            
                            <!-- /.modal -->







 
<script type="text/javascript">
    $(document).ready(function () {
        initialize();
    });

    var prm = Sys.WebForms.PageRequestManager.getInstance();

    prm.add_endRequest(function () {
        initialize();
    });


    function initialize() {
        $("#myModalNewCompany").dialog({ autoOpen: false });

        $("#boardRoom").click(function () {
            $("#roomTitle").text("Board Room");
            $("#roomPic").attr("src", "images/boardRoom.jpg");
            $("#roomCapacity").text("32 (boardroom) 60 (theatre)");
            $("#roomLocation").text("6th Floor");
            $("#roomAV").text("Data projector and wall screen");
            $("#roomAccessibility").text("Built in Loop System for hearing impaired");
            $("#roomConnectivity").text("WiFi available (see IT dept)");
            openModalPopupWindow();
        });


        $("#anteRoom").click(function () {
            $("#roomTitle").text("Ante Room");
            $("#roomPic").attr("src", "images/anteRoom.jpg");
            $("#roomCapacity").text("16 (boardroom) 30 (theatre)");
            $("#roomLocation").text("6th Floor");
            $("#roomAV").text("Data projector");
            $("#roomAccessibility").text("Built in Loop System for hearing impaired");
            $("#roomConnectivity").text("WiFi available (see IT dept)");
            openModalPopupWindow();
        });

        $("#trainingRoom").click(function () {
            $("#roomTitle").text("Training Room");
            $("#roomPic").attr("src", "images/trainingRoom.jpg");
            $("#roomCapacity").html("26 (Board Room style)<br>70 (Theatre Style)<br>36 (Cabaret Style 6 tables each with 6 chairs)");
            $("#roomLocation").text("2nd Floor");
            $("#roomAV").text("Data projector, wall screen and speaker system");
            $("#roomAccessibility").text("Built in Loop System for hearing impaired");
            $("#roomConnectivity").text("WiFi available (see IT dept)");
            openModalPopupWindow();
        });

        $("#meet3Room").click(function () {
            $("#roomTitle").text("Meeting Room 3");
            $("#roomPic").attr("src", "images/meetingRoom3.jpg");
            $("#roomCapacity").html("8 (boardroom) 15 (theatre)");
            $("#roomLocation").text("1st Floor");
            $("#roomAV").text("Clickshare facility");
            $("#roomAccessibility").text("Portable Loop System in hallway outside room");
            $("#roomConnectivity").text("Wifi");
            openModalPopupWindow();
        });

        $("#meet1Room").click(function () {
            $("#roomTitle").text("Meeting Room 1");
            $("#roomPic").attr("src", "images/meetingRoom1.jpg");
            $("#roomCapacity").html("6 (Small Board Room style)");
            $("#roomLocation").text("Ground Floor");
            $("#roomAV").text("No assigned AV in room");
            $("#roomAccessibility").text("Portable Loop System available in room");
            openModalPopupWindow();
        });

        $("#meet2Room").click(function () {
            $("#roomTitle").text("Meeting Room 2");
            $("#roomPic").attr("src", "images/meetingRoom2.jpg");
            $("#roomCapacity").html("8 (boardroom) 20 (theatre)");
            $("#roomLocation").text("Glassroom 1st floor");
            $("#roomAV").text("Clickshare facility");
            $("#roomAccessibility").text("Portable Loop System available in room");
            $("#roomConnectivity").text("Wifi");
            openModalPopupWindow();
        });


        $("#glassRoom").click(function () {
            $("#roomTitle").text("Meeting Room 4");
            $("#roomPic").attr("src", "images/glassRoom.jpg");
            $("#roomCapacity").html("6 (Small Board Room style)");
            $("#roomLocation").text("Glassroom 4th floor");
            $("#roomAV").text("No assigned AV in room");
            $("#roomAccessibility").text("Loop System available upon request when booked");
            $("#roomConnectivity").text("Wifi");
            openModalPopupWindow();
        });

        $("#closeModal").click(function () {
            $("#roomTitle").text("");
            closeModalPopupWindow();
        });

        $('#<%=txtCurrentDate.ClientID%>').datepicker({ dateFormat: 'dd-mm-yy' });
    }


    function openModalPopupWindow() {
        var opt = {
            autoOpen: false,
            modal: true,
            width: 450,
            height: 680,
            title: $("#roomTitle").text()
        };
        $('#myModalNewCompany').dialog(opt).dialog('open').prev(".ui-dialog-titlebar").css("background", "#DDEBF5").css("color", "#003399");
    }

    function closeModalPopupWindow() {
        $("#myModalNewCompany").dialog("close");
    }
</script>

</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="navDay">
   <li class="active"><a href="default.aspx">Day View</a></li>
</asp:Content>
