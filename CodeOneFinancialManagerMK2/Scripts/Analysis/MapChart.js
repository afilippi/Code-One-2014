var map = AmCharts.makeChart("chartdiv", {
    type: "map",
    "theme": "none",
    pathToImages: "http://www.amcharts.com/lib/3/images/",
    

    colorSteps: 10,

    dataProvider: {
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
    },

    //areasSettings: {
    //    autoZoom: true
    //},

    //valueLegend: {
    //    right: 10,
    //    minValue: "little",
    //    maxValue: "a lot!"
    //}

});

//map.addTitle("Spending by State", 18, '#000000' , 1,false);
//map.titles = {
//    'text': 'Spending by State',
//    'size': '18px',
//};
map.fontFamily = "'Lucida Grande', 'Lucida Sans Unicode', Arial, Helvetica, sans - serif";
map.areasSettings = {
    alpha: 1,
    color: "#afdeab",
    colorSolid: "#0D723C",
    unlistedAreasAlpha: 0.4,
    unlistedAreasColor: "#BDCFD1",
    outlineColor: "#666A70",
    outlineAlpha: 0.5,
    outlineThickness: 0.5,
    rollOverColor: "#ec6b2f",
    rollOverOutlineColor: "#FFFFFF",
    selectedOutlineColor: "#FFFFFF",
    selectedColor: "#f15135",
    unlistedAreasOutlineColor: "#666A70",
    unlistedAreasOutlineAlpha: 0.5
};
map.validateData();
window.onload = function() {
    $('#chartdiv > div > div:nth-child(1) > a').remove();
    $('#chartdiv > div > div:nth-child(1) > svg > g:nth-child(17)').remove();
};