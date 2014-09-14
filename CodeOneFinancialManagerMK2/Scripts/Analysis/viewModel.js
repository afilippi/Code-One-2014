var linechart, barchart, piechart;
var availableAccounts = [
        { id: 1, accountName: 'John Checking' },
        { id: 2, accountName: 'Jake Checking' },
        { id: 3, accountName: 'Savings' },
];

var AnalysisViewModel = {
    availableAccount: availableAccounts,
    selectedAccount: ko.observable(this.availableAccounts[0])
};

AnalysisViewModel.selectedAccount.subscribe(function (newValue) {
    if (newValue.id === 1)
    {
        linechart.series[0].setData([1750, 2800, 3196, 3220, 3441], true);
        barchart.yAxis[0].removePlotLine('small-plot-line'),
        barchart.yAxis.plotLines = [{
            value: 426,
            color: '#ec6b2f',
            width: 3,
            zIndex: 4,
            label: { text: 'Avg.' }
        }];
        barchart.series[0].setData([400, 450, 480, 375, 150], true);
        piechart.series[0].setData([
                ['Other', 45.0],
                ['Restaurants', 26.8],
                ['Travel', 12.8],
                ['Grocery', 8.5],
                ['Healthcare', 6.2],
                ['Retail', 0.7]
        ], true);

        map.dataProvider = {
            map: "usaLow",
            areas: [{
                id: "US-AZ",
                value: 9
            }, {
                id: "US-CA",
                value: 45
            }, {
                id: "US-CO",
                value: 11
            }, {
                id: "US-CT",
                value: 1
            }, {
                id: "US-DE",
                value: 1
            }, {
                id: "US-FL",
                value: 11
            }, {
                id: "US-GA",
                value: 6
            }, {
                id: "US-ID",
                value: 2
            }, {
                id: "US-IL",
                value: 3
            }, {
                id: "US-LA",
                value: 1
            }, {
                id: "US-MD",
                value: 25
            }, {
                id: "US-MA",
                value: 2
            }, {
                id: "US-MN",
                value: 1
            }, {
                id: "US-NV",
                value: 12
            }, {
                id: "US-NJ",
                value: 1
            }, {
                id: "US-NY",
                value: 8
            }, {
                id: "US-NC",
                value: 1
            }, {
                id: "US-ND",
                value: 2
            }, {
                id: "US-OH",
                value: 3
            }, {
                id: "US-OR",
                value: 1
            }, {
                id: "US-SD",
                value: 1
            }, {
                id: "US-TN",
                value: 2
            }, {
                id: "US-TX",
                value: 4
            }, {
                id: "US-UT",
                value: 2
            }, {
                id: "US-WA",
                value: 41
            }, {
                id: "US-WI",
                value: 1
            }]
        };
        map.validateData();
        $('#chartdiv > div > div:nth-child(1) > a').remove();
        $('#chartdiv > div > div:nth-child(1) > svg > g:nth-child(16)').remove();

    } else {
        linechart.series[0].setData([1100, 1132, 960, 940, 901], true);
        barchart.yAxis[0].addPlotLine({
            value: 94,
            color: '#ec6b2f',
            width: 3,
            zIndex: 4,
            id: 'small-plot-line',
            label: { text: 'Avg.' }
        });
        barchart.series[0].setData([112, 60, 113, 90, 45], true);
        piechart.series[0].setData([
                ['Other', 35.0],
                ['Restaurants', 20.8],
                ['Travel', 35.8],
                ['Grocery', 2.5],
                ['Healthcare', 0.4],
                ['Retail', 5.5]
        ], true);

        map.dataProvider = {
            map: "usaLow",
            areas: [{
                id: "US-CO",
                value: 6
            }, {
                id: "US-KS",
                value: 5
            }, {
                id: "US-NE",
                value: 12
            }]
        };
        map.validateData();
        $('#chartdiv > div > div:nth-child(1) > a').remove();
        $('#chartdiv > div > div:nth-child(1) > svg > g:nth-child(16)').remove();
    }
});

$(document).ready(function () {
    ko.applyBindings(AnalysisViewModel, $(".body-container")[0]);
});
