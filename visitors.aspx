<%@ Page Title="" Language="VB" MasterPageFile="~/roomLook.master" AutoEventWireup="false" CodeFile="visitors.aspx.vb" Inherits="visitors" %>
<asp:Content ID="Content3" ContentPlaceHolderID="navVisitors" Runat="Server">
                      <li class="dropdown active">
                <a href="#" data-toggle="dropdown" role="button" aria-haspopup="true" class="dropdown-toggle">Visitors <span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a href="visitorSearch.aspx">Visitor List</a></li>
                  <li><a href="visitors.aspx">New Visitor</a></li>
                </ul>
              </li>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="mainContent" Runat="Server">
    <form id="defaultForm" runat="server">
<div class="row">
<div class="col-lg-12" style="background-color: #EFEFEF">
<div class="well well-sm">
<table style="border: 1px; margin-top: 0px; padding-top: 0px;" width="60%">
<tr><td colspan="2">
<h3>New Visitor Record</h3>
</td></tr>
<tr><th style="text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-top: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;" width="30%">Visit Date</th>
<td><asp:TextBox ID="txtVisitDate" CssClass="form-control" Enabled="true" AutoPostBack="true" Visible="true" runat="server"></asp:TextBox></td>
</tr>
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
<tr  runat="server" id="trSpecialInstructions" visible="true">
<th style="text-align: right; background-color: #DDEBF5; border-left: 1px solid #003399; border-bottom: 1px solid #003399; border-right: 1px solid #003399; color: #003399; padding-right: 5px;" width="30%">Special Instructions on Arrival</th>
<td class="style1">
<asp:TextBox ID="txtSpecialInstructions" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
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
</td></tr><tr runat="server" id="trCompanyName" visible="false">
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
<asp:TextBox ID="txtVisitorNames" CssClass="form-control" TextMode="MultiLine" Visible="false" runat="server"></asp:TextBox>
<br />
<asp:GridView CssClass="table table-condensed" OnRowCommand="gvVisitorsRowCommand" EmptyDataText="No Visitors" GridLines="None" Width="100%" AlternatingRowStyle-BorderColor="#EFEFEF" AlternatingRowStyle-BackColor="#EFEFEF" HeaderStyle-BackColor="AliceBlue" BorderWidth="0" BackColor="#FFFFFF" AlternatingRowStyle-BorderStyle="None" AutoGenerateColumns="false" CellPadding="5" runat="server" ID="gvVisitors">
 <emptydatarowstyle backcolor="#ccffff" ForeColor="DarkSlateBlue" Font-Size="Larger" Font-Bold="true"/>
        <emptydatatemplate>
            <div style="padding: 5px;">No Visitors Added</div>  
        </emptydatatemplate>
<Columns>
<asp:TemplateField HeaderText="Visitor Name">
<ItemTemplate>
<%# Eval("Name")%>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Special Requirements">
<ItemTemplate>
<%# Eval("Special Requirements")%>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderStyle-Width="10%" ItemStyle-VerticalAlign="Middle" HeaderText="">
<ItemTemplate>
<asp:ImageButton runat="server" OnClientClick="return confirm('Are you sure you want to Delete this Visitor?')" ImageUrl="~/images/delete.png" CommandName="deleteElement" CommandArgument='<%# Container.DataItemIndex %>' />
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView></td></tr>
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
<tr id="trNewVisitorButton" runat="server" visible="true"><th>&nbsp;</th><td><asp:Button runat="server" ID="btnNewVisitor" CausesValidation="false" Text="Add Visitor" CssClass="btn btn-primary" />
<asp:Label runat="server" id="lblNewVisitorWarning" Font-Bold="true" ForeColor="Red"></asp:Label>
</td></tr>
<tr id="tr1" runat="server" visible="true"><th>&nbsp;
<asp:Label runat="server" id="lblMainWarning" Font-Bold="true" ForeColor="Red"></asp:Label>
</th><td style="padding: 5px; float: right;"><asp:Button runat="server" ID="btnSubmit" CausesValidation="false" Text="Submit" CssClass="btn btn-primary btn-lg" />
<asp:Label runat="server" id="Label1" Font-Bold="true" ForeColor="Red"></asp:Label>
</td></tr>
</table>
</div>
</div>
</div>
    </form>
<script type="text/javascript">
    $(document).ready(function () {
        $('#<%=txtVisitDate.ClientID%>').datepicker({ dateFormat: 'dd-mm-yy' });
    });
    </script>
</asp:Content>



