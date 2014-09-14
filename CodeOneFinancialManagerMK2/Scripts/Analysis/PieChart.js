$(function () {
    $(document).ready(function () {
        piechart = new Highcharts.Chart({
            colors: [
        '#BDCFD1',
        '#0D723C',
        '#A0A1A3',
        '#4AAA42',
            '#ec6b2f',
        '#666A70'
            ],
            chart: {
                renderTo: 'pieContainer',
                plotBackgroundColor: null,
                plotBorderWidth: null,
                plotShadow: false,
                backgroundColor: null
            },
            title: {
                text: "Last Month's Spending by Category"
            },
            tooltip: {
                enabled: false
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    dataLabels: {
                        enabled: true,
                        format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                        style: {
                            color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                        }
                    }
                }
            },
            series: [{
                type: 'pie',
                name: 'Browser share',
                data: [
                    ['Other', 45.0],
                    ['Restaurants', 26.8],
                    ['Travel', 12.8],
                    ['Grocery', 8.5],
                    ['Healthcare', 6.2],
                    ['Retail', 0.7]
                ]
            }],
            credits: false
        });
    });
});

