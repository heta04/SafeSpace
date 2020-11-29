<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Covid_19.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="css/covid-analysis.css" />
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="http://code.jquery.com/ui/1.9.1/jquery-ui.js"></script>

    <script type="text/javascript">  
        $(function () {
            google.load('visualization', '1', { packages: ['corechart'] });


        });

        function counter() {
            $('.counter-count').each(function () {
                $(this).prop('Counter', 0).animate({
                    Counter: $(this).text()
                }, {
                    duration: 1500,
                    easing: 'swing',
                    step: function (now) {
                        $(this).text(Math.ceil(now));
                    }
                });
            });
        }

        $("[id*=rdbprov]").live("change", function () {
            active();

        });

        $("[id*=rdbp2]").live("change", function () {
            combo();

        });

        function weeklyavg() {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                url: 'Covid_19.aspx/Getaverageweekly',
                success: function (response) {
                    drawchart(response.d);
                },

                error: function () {
                    alert("Error loading data of weekly avg! Please try again.");
                }
            });
        }

        function active() {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                url: 'Covid_19.aspx/getactive',
                data: "{Prov:'" + $("[id*=rdbprov]").val() + "'}",
                success: function (response) {
                    monthlyactive(response.d);
                },

                error: function () {
                    alert("Error loading data of active! Please try again.");
                }
            });

        }

        function combo() {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                url: 'Covid_19.aspx/Getcombo',
                data: "{Prov:'" + $("[id*=rdbp2").val() + "'}",
                success: function (response) {
                    chartcompare(response.d);
                },

                error: function () {
                    alert("Error loading data of combo chart! Please try again.");
                }
            });

        }

        function geochart() {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                url: 'Covid_19.aspx/getgeomapdata',
                data: '{}',
                success: function (response) {
                    debugger;
                    getgeochart(response.d);
                },

                error: function () {
                    alert("Error loading data of geo chart! Please try again.");
                }
            });

        }

        function drawchart(dataValues) {
            var data = new google.visualization.DataTable();

            data.addColumn('string', 'Province');
            data.addColumn('number', 'Average Cases');

            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].province, dataValues[i].average]);
            }
            // Instantiate and draw our chart, passing in some options  
            var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));

            chart.draw(data, {
                title: "Average Weekly New Cases",
                position: "top",
                titleTextStyle: {

                    fontsize: 16,
                },
                chartArea: { width: '80%' },
                legend: { position: 'top' },
                colors: ['#f64e60'],
                opacity: 0.1,

                vAxis: {
                    0: { title: 'Average cases' },
                    viewWindowMode: 'explicit',
                    viewWindow: {
                        max: data.getColumnRange(1).max
                    }
                },
                hAxis: {
                    title: "Province",
                    direction: 1,
                    slantedText: true,
                    slantedTextAngle: 45
                },
                animation: {
                    duration: 1000,
                    easing: 'out',
                    startup: true
                }
            });

        }



        function monthlyactive(dataValues) {

            var options = {
                title: "Cases vs recovery",
                fontsize: "16px",
               // curveType: 'function',
                legend: { position: 'bottom' },
                //vAxis: { title: 'No of Deaths' },
                hAxis: { title: 'Month' },

                seriesType: 'line',
                series: {
                    1: { type: 'area'},
                    1: {
                        type:'area',
                        curveType: 'function',
                        pointSize: 5,
                    },
                    0: {
                        curveType: 'function',
                        pointSize: 5,

                    }
                },
                animation: {
                    duration: 1000,
                    easing: 'out',
                    startup: true
                }
            };

            var data = new google.visualization.DataTable();

            data.addColumn('string', 'Date');
            data.addColumn('number', 'Cases');
            data.addColumn('number', 'recovered');

            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].date, dataValues[i].cases, dataValues[i].recovered]);
            }

            var chart = new google.visualization.ComboChart(document.getElementById('chart_active'));

            chart.draw(data, options)
        }

        function chartcompare(dataValues) {

            var options = {
                title: "Mortality",
                fontsize: "16px",
                //chartArea: { height: '90%' },
                series:{
                    0: { curveType: 'function' },
                },
                

                height: 400,
                legend: { position: 'right' },
                vAxis: { minValue: 0 },
                animation: {
                    duration: 1000,
                    easing: 'out',
                    startup: true
                }

            };

            var data = new google.visualization.DataTable();
            debugger;
            data.addColumn('string', 'Date');
            data.addColumn('number', 'No of Deaths');

            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].date, dataValues[i].deaths]);
            }
            debugger;
            var chart = new google.visualization.AreaChart(document.getElementById('chart_compare'));

            chart.draw(data, options)
        }



        function getgeochart(dataValues) {
            google.load('visualization', '1', { 'packages': ['geochart'] });
            google.setOnLoadCallback(drawMarkersMap);

            function drawMarkersMap() {


                var data = new google.visualization.DataTable();

                data.addColumn('string', 'Province');
                data.addColumn('number', 'Active Cases');
                data.addColumn('number', 'Date');

                for (var i = 0; i < dataValues.length; i++) {
                    data.addRow([dataValues[i].province, dataValues[i].cases, dataValues[i].date1]);
                }

                var options = {
                    region: 'CA',
                    displayMode: 'auto',
                    // colorAxis: { colors: ['#F2DBA2', '#E3B064', '#DE894A', 'CB5323', '#6D2A17','#591702'] },
                    colorAxis: { colors: ['#00853f', 'black', '#e31b23'] },

                    backgroundColor: '#81d4fa',
                    datalessRegionColor: '#f8bbd0',
                    defaultColor: '#f5f5f5',
                    resolution: 'provinces',
                    height: '400',
                    animation: {
                        duration: 1000,
                        easing: 'out',
                        startup: true
                    }

                };

                var chart = new google.visualization.GeoChart(document.getElementById('chart_geo'));
                chart.draw(data, options);
            };

        }



    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="covid-panel">
        <div class="uppar-panel">
            <div class="uppar-header">
                <div><span class="header-title">COVID ANALYSIS</span></div>
            </div>
            <div class="uppar-panel-body">
                <div class="container">
                    <div class="row">
                        <div class="col-md-3">
                            <div class="content-card active-graph">
                                <div><span class="case-title">Total Cases</span></div>
                                <div>
                                    <asp:Label runat="server" ID="lblcases" class="case-no counter-count"></asp:Label></div>
                                <div class="case-percent">
                                    <asp:Label runat="server" ID="lblcases2" class="case-percent-no case-percent-total "></asp:Label></div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="content-card">
                                <div><span class="case-title">Active Cases</span></div>
                                <div>
                                    <asp:Label runat="server" ID="lblAcases" class="case-no counter-count"></asp:Label></div>
                                <div class="case-percent">
                                    <asp:Label runat="server" ID="lblAcases2" class="case-percent-no case-percent-active"></asp:Label></div>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="content-card active-graph">
                                <div><span class="case-title">Total Recovered</span></div>
                                <div>
                                    <asp:Label runat="server" ID="lblrec" class="case-no counter-count"></asp:Label></div>
                                <div class="case-percent">
                                    <asp:Label runat="server" ID="lblrec2" class="case-percent-no case-percent-recover"></asp:Label></div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="content-card">
                                <div><span class="case-title">Total Death</span></div>
                                <div>
                                    <asp:Label runat="server" ID="lbldeath" class="case-no counter-count"></asp:Label></div>
                                <div class="case-percent">
                                    <asp:Label runat="server" ID="lbldeath2" class="case-percent-no case-percent-deactive"></asp:Label></div>
                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div id="chart_geo" class="analysis-graph"></div>
                        </div>
                        <div class="col-md-6">
                            <div id="chart_div" class="analysis-graph"></div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">

                            <div style="margin-top: 30px">
                                <asp:DropDownList  ID="rdbprov" runat="server" class="form-control dropdown">
                                    <asp:ListItem Value="Ontario" Selected="True">Ontario</asp:ListItem>
                                    <asp:ListItem Value="Alberta">Alberta</asp:ListItem>
                                    <asp:ListItem Value="BC">British Columbia</asp:ListItem>
                                    <asp:ListItem Value="Manitoba">Manitoba</asp:ListItem>
                                    <asp:ListItem Value="New Brunswick">New Brunswick</asp:ListItem>
                                    <asp:ListItem Value="NL">Newfoundland and Labrador</asp:ListItem>
                                    <asp:ListItem Value="Nova Scotia">Nova Scotia</asp:ListItem>
                                    <asp:ListItem Value="Nunavut">Nunavut</asp:ListItem>
                                    <asp:ListItem Value="NWT">Northwest Territories	</asp:ListItem>
                                    <asp:ListItem Value="PEI">Prince Edward Island	</asp:ListItem>
                                    <asp:ListItem Value="Quebec">Quebec</asp:ListItem>
                                    <asp:ListItem Value="Saskatchewan">Saskatchewan</asp:ListItem>
                                    <asp:ListItem Value="Yukon">Yukon	</asp:ListItem>
                                    <asp:ListItem Value="Repatriated">Repatriated Travellers</asp:ListItem>

                                </asp:DropDownList>
                            </div>
                            <div id="chart_active" class="analysis-graph" style="margin-top: 0px !important"></div>
                        </div>
                        <div class="col-md-6">

                            <div style="margin-top: 30px">
                                <asp:DropDownList  ID="rdbp2" runat="server" class="form-control dropdown">
                                    <asp:ListItem Value="Ontario" Selected="True">Ontario</asp:ListItem>
                                    <asp:ListItem Value="Alberta">Alberta</asp:ListItem>
                                    <asp:ListItem Value="BC">British Columbia</asp:ListItem>
                                    <asp:ListItem Value="Manitoba">Manitoba</asp:ListItem>
                                    <asp:ListItem Value="New Brunswick">New Brunswick	</asp:ListItem>
                                    <asp:ListItem Value="Nova Scotia">Nova Scotia</asp:ListItem>
                                    <asp:ListItem Value="Nunavut">Nunavut</asp:ListItem>
                                    <asp:ListItem Value="PEI">Prince Edward Island	</asp:ListItem>
                                    <asp:ListItem Value="Quebec">Quebec</asp:ListItem>
                                    <asp:ListItem Value="Saskatchewan">Saskatchewan</asp:ListItem>
                                    <asp:ListItem Value="Yukon">Yukon	</asp:ListItem>
                                    <asp:ListItem Value="Repatriated">Repatriated Travellers</asp:ListItem>

                                </asp:DropDownList>
                            </div>
                            <div id="chart_compare" class="analysis-graph" style="margin-top: 0px !important"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

