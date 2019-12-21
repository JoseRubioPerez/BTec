<%@ Page Title="BTec - Panel General" Language="C#" MasterPageFile="~/Administrador/Second.Master" AutoEventWireup="true" CodeBehind="PanelGeneral.aspx.cs" Inherits="Aplicacion.Administrador.PanelGeneral1" Culture="es-MX" UICulture="es-MX" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid py-5 px-5">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header text-center"><h3>Movimientos del Centro de Informaci&oacute;n del ITD</h3></div>
                    <div class="card-body">
                        <canvas id="myChart" width="400" height="100"></canvas>
                    </div>
                    <div class="card-footer">
                        <h5 id="TotalRegistros"></h5>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var chartData = {};

        function respondCanvas() {
            var ctx = document.getElementById('myChart').getContext('2d');
            var chart = new Chart(ctx, {
                type: 'bar',
                data: chartData
            });
        }

        var GetChartData = function () {
            $.ajax({
                url: "PanelGeneral.aspx/CargarGrafica",
                method: 'POST',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    chartData = {
                        labels: result.d.data.Servicio,
                        responsive: true,
                        maintainAspectRatio: true,
                        datasets: [
                            {
                                data: result.d.data.Total,
                                label: 'Movimientos',
                                backgroundColor: [
                                    'rgba(255, 99, 132, 0.2)',
                                    'rgba(54, 162, 235, 0.2)',
                                    'rgba(255, 206, 86, 0.2)',
                                    'rgba(75, 192, 192, 0.2)',
                                    'rgba(153, 102, 255, 0.2)',
                                    'rgba(255, 159, 64, 0.2)',
                                    'rgba(54, 162, 235, 0.2)'
                                ],
                                borderColor: [
                                    'rgba(255, 99, 132, 1)',
                                    'rgba(54, 162, 235, 1)',
                                    'rgba(255, 206, 86, 1)',
                                    'rgba(75, 192, 192, 1)',
                                    'rgba(153, 102, 255, 1)',
                                    'rgba(255, 159, 64, 1)',
                                    'rgba(54, 162, 235, 0.2)'
                                ],
                                borderWidth: 3
                            }
                        ],
                        options:
                        {
                            scales:
                            {
                                yAxes:
                                    [
                                        {
                                            ticks:
                                            {
                                                beginAtZero: true
                                            }
                                        }
                                    ]
                            }
                        }
                    };
                    respondCanvas();
                    var sum = 0;
                    result.d.data.Total.forEach((value, index) => {
                        sum += value;
                    });
                    $('#TotalRegistros').html(`Total de Registros: ${sum}`);
                }
            });
        };

        $(document).ready(function () {
            $(window).resize(respondCanvas);
            GetChartData();
        });
        //$.ajax({
        //    type: "POST",
        //    url: "PanelGeneral.aspx/CargarGrafica",
        //    data: null,
        //    contentType: "application/json; charset=utf-8",
        //    dataType: "json",
        //    cache: true,
        //    success: function (result) {
        //        var ctx = document.getElementById('myChart').getContext('2d');
        //        var myChart = new Chart(ctx, {
        //            type: 'bar',
        //            responsive: true,
        //            maintainAspectRatio: true,
        //            labels: result.d.data.Servicio,
        //            datasets: [
        //                {
        //                    data: result.d.data.Total,
        //                    label: 'Movimientos',
        //                    backgroundColor: [
        //                        'rgba(255, 99, 132, 0.2)',
        //                        'rgba(54, 162, 235, 0.2)',
        //                        'rgba(255, 206, 86, 0.2)',
        //                        'rgba(75, 192, 192, 0.2)',
        //                        'rgba(153, 102, 255, 0.2)',
        //                        'rgba(255, 159, 64, 0.2)',
        //                        'rgba(54, 162, 235, 0.2)'
        //                    ],
        //                    borderColor: [
        //                        'rgba(255, 99, 132, 1)',
        //                        'rgba(54, 162, 235, 1)',
        //                        'rgba(255, 206, 86, 1)',
        //                        'rgba(75, 192, 192, 1)',
        //                        'rgba(153, 102, 255, 1)',
        //                        'rgba(255, 159, 64, 1)',
        //                        'rgba(54, 162, 235, 0.2)'
        //                    ],
        //                    borderWidth: 3
        //                }
        //            ],
        //            options:
        //            {
        //                scales:
        //                {
        //                    yAxes:
        //                        [
        //                            {
        //                                ticks:
        //                                {
        //                                    beginAtZero: true
        //                                }
        //                            }
        //                        ]
        //                }
        //            }
        //        });
        //    }
        //});
    </script>
</asp:Content>
