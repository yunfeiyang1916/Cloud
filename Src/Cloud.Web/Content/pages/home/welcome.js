$(function () {
    getSalaryChart();
    getLeaveChart();
    lazyLoading();
});
/**获取考勤图表**/
function getSalaryChart() {
    var randomScalingFactor = function () { return Math.round(Math.random() * 100) };
    var lineChartData = {
        labels: ["1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "8月", "10月", "11月", "12月"],
        datasets: [
            {
                label: "My First dataset",
                fillColor: "rgba(220,220,220,0.2)",
                strokeColor: "rgba(220,220,220,1)",
                pointColor: "rgba(220,220,220,1)",
                pointStrokeColor: "#fff",
                pointHighlightFill: "#fff",
                pointHighlightStroke: "rgba(220,220,220,1)",
                data: [randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor()]
            },
            {
                label: "My Second dataset",
                fillColor: "rgba(151,187,205,0.2)",
                strokeColor: "rgba(151,187,205,1)",
                pointColor: "rgba(151,187,205,1)",
                pointStrokeColor: "#fff",
                pointHighlightFill: "#fff",
                pointHighlightStroke: "rgba(151,187,205,1)",
                data: [randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor()]
            }
        ]
    }
    var ctx = document.getElementById("salarychart").getContext("2d");
    window.myLine = new Chart(ctx).Line(lineChartData, {
        responsive: false,
        bezierCurve: false
    });
}
/**获取请假图表**/
function getLeaveChart() {
    var randomScalingFactor = function () { return Math.round(Math.random() * 100) };
    var a_value = randomScalingFactor();
    var b_value = randomScalingFactor();
    var c_value = randomScalingFactor();
    var d_value = randomScalingFactor();
    var doughnutData = [
        {
            value: a_value,
            color: "#F7464A",
            highlight: "#FF5A5E",
            label: "事假"
        },
        {
            value: b_value,
            color: "#46BFBD",
            highlight: "#5AD3D1",
            label: "病假"
        },
        {
            value: c_value,
            color: "#FDB45C",
            highlight: "#FFC870",
            label: "公休假"
        },
        {
            value: d_value,
            color: "#949FB1",
            highlight: "#A8B3C5",
            label: "调休假"
        }
    ];
    var ctx = document.getElementById("leavechart").getContext("2d");
    window.myDoughnut = new Chart(ctx).Doughnut(doughnutData, { responsive: false });
    $("#a_value").html(a_value + "小时");
    $("#b_value").html(b_value + "小时");
    $("#c_value").html(c_value + "小时");
    $("#d_value").html(d_value + "小时");
}

/**为了减少页面加载时间，将一些不重要的数据延迟加载的**/
function lazyLoading() {
    setTimeout(function () {
        //天气信息
       // $("#weatherContainer").append('<iframe name="weather_inc" id="weather_inc" src="http://i.tianqi.com/index.php?c=code&id=1" width="330" height="35" frameborder="0" marginwidth="0" marginheight="0" scrolling="no"></iframe>');
    },1000);
}