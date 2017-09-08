<%@ Page Title="" Language="VB" MasterPageFile="~/roomLook.master" AutoEventWireup="false" CodeFile="visitorSearch.aspx.vb" Inherits="visitorSearch" %>
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
 <div class="row">
                <div class="col-lg-12" style="background-color: #EFEFEF">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div id="panelDataLoading"></div>                         
    <table width="100%" class="display table-condensed table-striped" id="visitors" cellspacing="0">
        <thead>
            <tr>
                <th>Date</th>
                <th>Contact</th>
                <th>Enquiry Type</th>
            </tr>
        </thead>
         <tfoot>
            <tr>
                <th style="text-align: right;">Total:</th>
                <th>0</th>
                <th>3</th>
            </tr>
        </tfoot>
        <tbody>
        </tbody>
    </table>
 </div>
 </div>
</div>
</div>
    <link href="css/jquery.dataTables.min.css" rel="stylesheet" type="text/css" />
<script  type="text/javascript" src="js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="js/dataTables.bootstrap.min.js"></script>
<script type="text/javascript">

    $(document).ready(function () {
        popEnquiries();
        $("#selOfficer").change(function () {
            popEnquiries();
        });
    });




 function popEnquiries() {
            var localAPI = "allVisitors.ashx";
            var jsonData = [];
            var offNo = 0;
            var period = 0;
            var table = $('#visitors').DataTable();
            var requestData = { "officer": offNo, "period": period };
            jsonData.push(requestData);
            var colDefs = [];
            colDefs = [{ title: "Visit Date", data: "VisitDate", type: "date-euro", orderData: [7], targets: 0 }, { title: "Booked By", data: "OfficerName" }, { title: "Contact", data: "ContactName" }, { title: "Number", data: "VisitNo" }, { title: "Type", data: "VisitType" }, { title: "Visitors", data: "VisitNames", width: "30%" }, { title: "Room", data: "VisitRoom", width: "10%", "render": function (data, type, row) { if (row.VisitRoom != null) { return '<a href="editBooking.aspx?GUID=' + row.GUID + '" class="btn btn-primary">' + row.VisitRoom + '</a>'; } else { return '<a href="editVisitor.aspx?ID=' + row.VisitID + '" class="btn btn-info">Edit</a>'; } } }, { title: "", data: "VisitDateTicks", visible: false}];
            $.ajax(
        {
            url: localAPI,
            dataType: 'json',
            cache: false,
            contentType: "application/json; charset=utf-8",
            data: { 'dataRequest': JSON.stringify(jsonData) },
            beforeSend: function () {
                $('#example').empty();
                $('#panelDataLoading').html("<img src='images/loading.gif' />");
            },
            success: function (data) {
                if (data != null) {
                    table.destroy();
                    $('#visitors').empty();
                    table = $('#visitors').DataTable({
                        lengthMenu: [[50, 100, 200], [50, 100, 200]],
                        data: data,
                        order: [[0,"desc"]],
                        columns: colDefs
                    });
                }

                $('#example').on('click', 'td .box', function () {
                    popEnquiry($(this).attr("data-id"));
                });
            },
            error: function () {
                alert('Error Pop Val Auth');
            },
            complete: function () {
                $('#example').fadeIn();
                $('#panelDataLoading').html("");
            }
        }
           );
           }

</script>
</asp:Content>

