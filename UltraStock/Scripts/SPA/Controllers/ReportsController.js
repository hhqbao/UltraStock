ultraStock.controller("reportsController", function ($scope, $http) {
    var labels = [
        "January",
        "Feburary",
        "March",
        "April",
        "May",
        "June",
        "July",
        "August",
        "September",
        "October",
        "November",
        "December"
    ];

    var data = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

    $http.get("/Api/Reports?year=2017").then(function (response) {
        var values = response.data;

        for (var i = 0; i < values.length; i++) {
            var index = values[i].month - 1;
            data[index] = values[i].total.toFixed(2);
        }

        var chartsService = new ChartsService("#line-chart", labels, data);

        console.log(data);
    });
});