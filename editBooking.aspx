<%@ Page Language="VB" MasterPageFile="~/roomLook.master" AutoEventWireup="false" CodeFile="editBooking.aspx.vb" Inherits="editBooking" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="mainContent">
<div class="row">
<div class="col-lg-12" style="background-color: #EFEFEF">
<div class="well well-sm">
<form id="form1" runat="server">
<div  id="Tabs" role="tabpanel">

<ul class="nav nav-tabs">
        <li class="nav"><a href="#Booking" data-toggle="tab">Booking</a></li>
        <li class="nav"><a href="#Visitors" data-toggle="tab">Visitors</a></li>
    </ul>

    <!-- Tab panes -->
    <div class="tab-content">
        <div class="tab-pane fade in active" id="Booking">
        <asp:HiddenField ID="TabName" runat="server" />
        <table width="90%">
        <tr><th width="20%" style="vertical-align: top; text-align: right; background-color: #DDEBF5; border-top: 1px solid #003399;  border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;">Room</th><td style="padding: 3px;">
<asp:Label ID="txtRoomName" Width="300px" CssClass="form-control" runat="server" Enabled="false" Text="Label"></asp:Label>
</td></tr>
        <tr><th width="20%" style="vertical-align: top; text-align: right; background-color: #DDEBF5; border-top: 1px solid #003399;  border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;">Title</th><td style="padding: 3px;">
<asp:TextBox ID="txtTitle" Width="300px" CssClass="form-control" runat="server"></asp:TextBox>
</td></tr>
<tr><th style="text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;">On Behalf of</th><td style="padding: 3px;" colspan="2"><asp:DropDownList ID="txtBehalfOf" CssClass="form-control" runat="server"></asp:DropDownList></td></tr>
<tr><th style="text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;">Time</th><td style="padding: 3px;" colspan="2"><asp:Label ID="lblTime" CssClass="form-control" runat="server" Enabled="false" Text="Label"></asp:Label></td></tr>
<tr><th style="text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;">No. Attending</th><td style="padding: 3px;" colspan="2"><asp:textbox Width="40" ID="txtNosAttending" CssClass="form-control" runat="server"></asp:textbox><asp:RangeValidator ID="valRangeName" MaximumValue="500" MinimumValue="0" runat="server" ControlToValidate="txtNosAttending" Type="Integer" Display="Dynamic" ErrorMessage="*"></asp:RangeValidator></td></tr>
<tr><th style="text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;">Food Required</th><td style="padding: 3px;" colspan="2">
<asp:DropDownList CssClass="form-control" ID="txtFood" runat="server">
<asp:ListItem Value="1">Yes</asp:ListItem>
<asp:ListItem Value="2">No</asp:ListItem>
</asp:DropDownList>
</td></tr>
<tr><th valign="top" style="vertical-align: top; text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;">Food Details<br />&nbsp;<br /></th>
<td style="padding: 3px;" colspan="2"><asp:TextBox ID="txtFoodDetail" Width="500px" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
</td></tr>
<tr><th valign="top" style="vertical-align: top; text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;">Room Setup</th>
<td style="padding: 3px;" colspan="2">
<asp:DropDownList ID="txtSR" CssClass="form-control" runat="server">
<asp:ListItem Value="1">Yes</asp:ListItem>
<asp:ListItem Value="2">No</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr><th valign="top" style="vertical-align: top; text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;">Room Setup Details<br />&nbsp;<br /></th><td style="padding: 3px;"><asp:TextBox ID="txtSRDetail" Width="60%" TextMode="MultiLine" Rows="4" CssClass="form-control" runat="server"></asp:TextBox></td>
</tr>
<tr><th valign="top" style="vertical-align: top; text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;">Booking Event Details<br />&nbsp;<br /></th>
<td style="padding: 3px;" colspan="2"><asp:TextBox ID="txtDetails" CssClass="form-control" Width="60%" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox></td></tr>
<tr runat="server" id="trPDComments" visible="false"><th valign="top" style="vertical-align: top; text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;">Further Details<br />&nbsp;<br /></th><td style="padding: 3px;" colspan="2"><asp:TextBox CssClass="form-control" ID="txtPDComments" Width="60%" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox></td></tr>
</table>


        </div>
        <div class="tab-pane fade" id="Visitors">
        
        <table width="90%">
    <tr>
    <td colspan="3">
    <asp:HiddenField ID="txtRoomBookDate" runat="server" />
    <asp:HiddenField ID="txtGUID" runat="server" />
    <asp:HiddenField ID="txtVisitorID" runat="server" />
    <table style="border: 1px; margin-top: 0px; padding-top: 0px;" width="100%">
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
<asp:TextBox ID="TextBox1" CssClass="form-control" Visible="false" TextMode="MultiLine" runat="server"></asp:TextBox>
<asp:GridView EmptyDataText="No Visitors" GridLines="None" Width="100%" AlternatingRowStyle-BorderColor="#EFEFEF" AlternatingRowStyle-BackColor="#EFEFEF" HeaderStyle-BackColor="AliceBlue" BorderWidth="0" BackColor="#FFFFFF" AlternatingRowStyle-BorderStyle="None" AutoGenerateColumns="false" runat="server" CssClass="table table-condensed" CellPadding="5" OnRowCommand="gvVisitorsRowCommand" ID="gvVisitors">
 <emptydatarowstyle backcolor="White" forecolor="Red" Font-Bold="true"/>
        <emptydatatemplate>
            No Visitors Added  
        </emptydatatemplate>
<Columns>
<asp:TemplateField HeaderText="Visitor Name">
<ItemTemplate>
<span style="padding: 5px;">
<%# Eval("Name")%>
</span>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Special Requirement">
<ItemTemplate>
<span style="padding: 5px;">
<%# Eval("Special Requirements")%>
</span>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="">
<ItemTemplate>
<asp:ImageButton style="padding: 5px;" runat="server" CommandName="deleteElement" OnClientClick="return confirm('Are you sure you want to Delete this Visitor?')" ImageUrl="~/images/Delete.png" CommandArgument='<%# Eval("Name")%>' />
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
<asp:TextBox ID="txtVisitorNames" CssClass="form-control" TextMode="MultiLine" Visible="false" runat="server"></asp:TextBox>
<br />
</td>
    </tr>
</table>
        
        </div>
    </div>

</div>

<div class="container">
<div style="float: right">
&nbsp;
    <asp:Button ID="btnDelete" CssClass="btn btn-primary" OnClientClick="return confirm('Are you sure you want to delete this Booking?')" Width="140px" runat="server" Text="Delete" />
&nbsp;
    <asp:Button ID="btnSaveChanges" CssClass="btn btn-primary" Width="140px" runat="server" Text="Save Changes" />
    &nbsp;
    <asp:Button ID="btnBack" Width="140px" CssClass="btn btn-primary" runat="server" Text="Back" />
</div>
</div>


<asp:textbox Visible="false" Width="40" ID="txtBookID" runat="server"></asp:textbox>
<asp:textbox Visible="false" Width="40" ID="txtBookDate" runat="server"></asp:textbox>
</form>
</div>
</div>
</div>

<script type="text/javascript">
    $(function () {
        var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "Booking";
        $('#Tabs a[href="#' + tabName + '"]').tab('show');
        $("#Tabs a").click(function () {
            $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
        });
    });

</script>

</asp:Content>
