$(function () {
    $(document).ready(function () {
        var chart = new Highcharts.Chart({
            chart: {
                renderTo: 'container',
                type: 'column',
            },
            title: {
                text: 'Your Spending History',
                style: {
                    color: '#353638'
                }
            },
            xAxis: {
                categories: ['May', 'June', 'July', 'August', 'This Month']
            },
            yAxis: {
                plotLines: [{
                    value: 426,
                    color: '#ec6b2f',
                    width: 3,
                    zIndex: 4,
                    label: { text: 'Avg.' }
                }],
                title: { text: "Amount Spent" }
            },
            series: [{
                name: 'Year 1800',
                data: [400, 450, 480, 375, 150],
                color: {
                    linearGradient: { x1: 0, x2: 0, y1: 0, y2: 1 },
                    stops: [
                        [0, '#4AAA42'],
                        [1, '#0D723C']
                    ]
                }
            },
                    {
                        name: 'Goal',
                        type: 'scatter',
                        marker: {
                            enabled: false
                        },
                        data: [371]
                    }],
            credits: false,
            legend: { enabled: false },
            tooltip: { enabled: false },
        });
    });

});