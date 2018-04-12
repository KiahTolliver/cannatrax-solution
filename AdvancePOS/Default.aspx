<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="AdvancePOS._Default" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <h1>
                Dashboard <small>Control panel</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#" ><i class="fa fa-dashboard"></i>Home</a></li>
                <li class="active">Dashboard</li>
            </ol>
        </div>
        <!-- Main content -->
        <div class="content">
            <!-- Small boxes (Stat box) -->
            <div class="row">
                <div class="col-lg-3 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-aqua">
                        <div class="inner">
                            <h3>
                                <asp:Literal ID="ltrOrder" runat="server" Text="0" /></h3>
                            <p>
                                Orders</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-bag"></i>
                        </div>
                        <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i>
                        </a>
                    </div>
                </div>
                <!-- ./col -->
                <div class="col-lg-3 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-green">
                        <div class="inner">
                            <h3>
                                <asp:Literal ID="ltrProducts" runat="server" Text="0" /></h3>
                            <p>
                                Products</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-stats-bars"></i>
                        </div>
                        <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i>
                        </a>
                    </div>
                </div>
                <!-- ./col -->
                <div class="col-lg-3 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-yellow">
                        <div class="inner">
                            <h3>
                                <asp:Literal ID="ltrTotalSale" runat="server" Text="0" /></h3>
                            <p>
                                Total Sales</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-person-add"></i>
                        </div>
                        <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i>
                        </a>
                    </div>
                </div>
                <!-- ./col -->
                <div class="col-lg-3 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-red">
                        <div class="inner">
                            <h3>
                                <asp:Literal ID="ltrTodaySale" runat="server" Text="0" /></h3>
                            <p>
                                Today Sales</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-pie-graph"></i>
                        </div>
                        <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i>
                        </a>
                    </div>
                </div>
                <!-- ./col -->
            </div>
            <!-- /.row -->
            <!-- Main row -->
            <div class="row">
                <!-- Left col -->
                <div class="col-lg-12 connectedSortable">
                    <div class="box">
                        <div class="box-header with-border">
                            <h3 class="box-title">
                                Monthly Sales Report</h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="chart">
                                        <!-- Sales Chart Canvas -->
                                        <canvas id="salesChart" style="height: 250px;"></canvas>
                                    </div>
                                    <!-- /.chart-responsive -->
                                    <div id="saleData"> </div>                                    
                                </div>
                            </div>
                            <!-- /.row -->
                        </div>
                    </div>
                </div>
                <!-- /.Left col -->
            </div>
            <!-- /.row (main row) -->
        </div>
        <!-- /.content -->
    </div>
    
    <script type="text/javascript">
        $(function () {

            var salesChartCanvas = $("#salesChart").get(0).getContext("2d");
            var salesChart = new Chart(salesChartCanvas);

            var salesChartOptions = {
                //Boolean - If we should show the scale at all
                showScale: true,
                //Boolean - Whether grid lines are shown across the chart
                scaleShowGridLines: false,
                //String - Colour of the grid lines
                scaleGridLineColor: "rgba(0,0,0,.05)",
                //Number - Width of the grid lines
                scaleGridLineWidth: 1,
                //Boolean - Whether to show horizontal lines (except X axis)
                scaleShowHorizontalLines: true,
                //Boolean - Whether to show vertical lines (except Y axis)
                scaleShowVerticalLines: true,
                //Boolean - Whether the line is curved between points
                bezierCurve: true,
                //Number - Tension of the bezier curve between points
                bezierCurveTension: 0.3,
                //Boolean - Whether to show a dot for each point
                pointDot: false,
                //Number - Radius of each point dot in pixels
                pointDotRadius: 4,
                //Number - Pixel width of point dot stroke
                pointDotStrokeWidth: 1,
                //Number - amount extra to add to the radius to cater for hit detection outside the drawn point
                pointHitDetectionRadius: 20,
                //Boolean - Whether to show a stroke for datasets
                datasetStroke: true,
                //Number - Pixel width of dataset stroke
                datasetStrokeWidth: 2,
                //Boolean - Whether to fill the dataset with a color
                datasetFill: true,
                //String - A legend template                
                //Boolean - whether to maintain the starting aspect ratio or not when responsive, if set to false, will take up entire container
                maintainAspectRatio: true,
                //Boolean - whether to make the chart responsive to window resizing
                responsive: true
            };

            jQuery.ajax({
                type: "POST",
                url: "/Helper/AdvancePOS.asmx/MonthlySaleStatistic",
                cache: false,
                contentType: "application/json; charset=utf-8",
                data: "{ItemID:'" + 4 + "'}",
                dataType: "json",
                success: handleHtml,
                error: ajaxFailed
            });

            function handleHtml(data) {
                var sales = data.d;
                $('#saleData').html(sales);
                //alert(sales);
                salesChart.Line(salesChartData, salesChartOptions);
            }

            function ajaxFailed(xmlRequest) {
                alert("error");
            }
        });
    </script>
</asp:Content>
