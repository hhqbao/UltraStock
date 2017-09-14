var ChartsService = function(canvasId, labels, data) {
    var ctx = angular.element(document.querySelector(canvasId).getContext("2d"));

    var config = {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: "My First dataset",
                backgroundColor: "Blue",
                borderColor: "Blue",
                data: data,
                fill: false
            }]
        },
        options: {
            responsive: true,
            title: {
                display: true,
                text: 'Chart.js Line Chart'
            },
            tooltips: {
                mode: 'index',
                intersect: false
            },
            hover: {
                mode: 'nearest',
                intersect: true
            },
            elements: {
                line: {
                    tension: 0.000001
                }
            },
            scales: {
                xAxes: [{
                    display: true,
                    scaleLabel: {
                        display: true,
                        labelString: 'Month'
                    }
                }],
                yAxes: [{
                    display: true,
                    scaleLabel: {
                        display: true,
                        labelString: 'Value'
                    },
                    ticks: {
                        min: 0,
                        stepSize: 1000
                    }
                }]
            }
        }
    };

    var myChart = new Chart(ctx, config);
}