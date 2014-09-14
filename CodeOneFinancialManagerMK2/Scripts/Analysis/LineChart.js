$(function () {
    $(document).ready(function () {
         linechart = new Highcharts.Chart({
            title: {
                text: 'Balance History',
                x: -20 //center
            },
            chart: {
                renderTo: 'lineContainer',
                backgroundColor: null
            },
            xAxis: {
                categories: ['May', 'June', 'July', 'August', 'MTD']
            },
            credits: false,
            yAxis: {
                title: {
                    text: ''
                },
                plotLines: [{
                    value: 0,
                    width: 1,
                    color: '#808080'
                }]
            },
            legend: {
                enabled: false
            },
            tooltip: {
                enabled: false
            },
            series: [{
                name: 'Tokyo',
                data: [1750, 2800, 3196, 3220, 3441],
                color: '#0D723C'
            }]
        });
    });
});