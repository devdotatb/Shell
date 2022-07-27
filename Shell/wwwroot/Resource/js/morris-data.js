// Morris.js Charts sample data for SB Admin template

$(function () {
    var monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];

    $('#slideb').slider({ id: 'slideb'
        , min: -100
        , max: 100
        , value: 36
        , tooltip: 'always'
        , enabled: false
        , formatter: function (value) {
            return value + '%';
        }
    });
    $("#slideb").append('<label style="left: 0%;">-100%</label><label style="left: 50%;">0%</label><label style="left: 100%;">100%</label><div class="div-left"></div><div class="div-center"></div><div class="div-right"></div>');

    $('#slidef').slider({ id: 'slidef'
        , min: -100
        , max: 100
        , value: -36
        , tooltip: 'always'
        , enabled: false
        , formatter: function (value) {
            return value + '%';
        }
    });
    $("#slidef").append('<label style="left: 0%;">-100%</label><label style="left: 50%;">0%</label><label style="left: 100%;">100%</label><div class="div-left"></div><div class="div-center"></div><div class="div-right"></div>');

    // Bar Chart
    Morris.Bar({
        element: 'barchartb',
        data: [{
            y: 'a',
            a: 10
        }, {
            y: 'b',
            a: 1
        }, {
            y: 'n',
            a: 2
        }, {
            y: '3',
            a: 3
        }, {
            y: '4',
            a: 4
        }, {
            y: '5',
            a: 5
        }, {
            y: '6',
            a: 6
        }, {
            y: '7',
            a: 7
        }, {
            y: '8',
            a: 8
        }, {
            y: '9',
            a: 9
        }, {
            y: '10',
            a: 10
        }],
        xkey: 'y',
        ykeys: ['a'],
        labels: ['Rating'],
        hideHover: 'auto',
        resize: true,
        gridTextSize: 10
    });
    Morris.Bar({
        element: 'barchartf',
        data: [{
            y: 'a',
            a: 10
        }, {
            y: 'b',
            a: 1
        }, {
            y: 'n',
            a: 2
        }, {
            y: '3',
            a: 3
        }, {
            y: '4',
            a: 4
        }, {
            y: '5',
            a: 5
        }, {
            y: '6',
            a: 6
        }, {
            y: '7',
            a: 7
        }, {
            y: '8',
            a: 8
        }, {
            y: '9',
            a: 9
        }, {
            y: '10',
            a: 10
        }],
        xkey: 'y',
        ykeys: ['a'],
        labels: ['Rating'],
        hideHover: 'auto',
        resize: true,
        gridTextSize: 10
    });

    // Line Chart
    Morris.Line({
        element: 'linechartb',
        data: [{
            d: '2012-10',
            feedback: 18
        }, {
            d: '2012-11',
            feedback: 21
        }, {
            d: '2012-12',
            feedback: 32
        }, ],
        xkey: 'd',
        ykeys: ['feedback'],
        labels: ['Feedback'],
        hideHover: 'auto',
        smooth: false,
        resize: true,
        lineColors: ['#d9534f'],
        hoverCallback: function (index, options, content) {
            var data = options.data[index];
            var txt = $('.morris-hover').html('<div class="morris-hover-point"><b>' + data.feedback + '%</b></div>');
            return txt.html();
        },
        xLabelFormat: function (d) {
            return monthNames[d.getMonth()] + ' ' + d.getFullYear();
        },
        gridTextSize: 10
    });
    Morris.Line({
        element: 'linechartf',
        data: [{
            d: '2012-10',
            feedback: 18
        }, {
            d: '2012-11',
            feedback: 21
        }, {
            d: '2012-12',
            feedback: 32
        }, ],
        xkey: 'd',
        ykeys: ['feedback'],
        labels: ['Feedback'],
        hideHover: 'auto',
        smooth: false,
        resize: true,
        lineColors: ['#d9534f'],
        hoverCallback: function (index, options, content) {
            var data = options.data[index];
            var txt = $('.morris-hover').html('<div class="morris-hover-point"><b>' + data.feedback + '%</b></div>');
            return txt.html();
        },
        xLabelFormat: function (d) {
            return monthNames[d.getMonth()] + ' ' + d.getFullYear();
        },
        gridTextSize: 10
    });


    // Line Chart
    Morris.Line({
        element: 'linechartbb',
        data: [{
            d: '2012-10',
            responese: 271,
            rating: 60
        }, {
            d: '2012-11',
            responese: 123,
            rating: 60
        }, {
            d: '2012-12',
            responese: 68,
            rating: 60
        }, ],
        xkey: 'd',
        ykeys: ['responese', 'rating'],
        labels: ['# Responses', 'Rating'],
        hideHover: 'auto',
        smooth: false,
        resize: true,
        lineColors: ['#0B62A4', '#f0ad4e'],
        hoverCallback: function (index, options, content) {
            var data = options.data[index];
            var txt = $('.morris-hover').html('<div class="morris-hover-point" style="color: #0B62A4"># Responses : ' + data.responese + '</div><div class="morris-hover-point" style="color: #f0ad4e">Rating : ' + data.rating + '</div>');
            return txt.html();
        },
        xLabelFormat: function (d) {
            return monthNames[d.getMonth()] + ' ' + d.getFullYear();
        },
        gridTextSize: 10
    });
    Morris.Line({
        element: 'linechartbf',
        data: [{
            d: '2012-10',
            responese: 271,
            rating: 60
        }, {
            d: '2012-11',
            responese: 123,
            rating: 60
        }, {
            d: '2012-12',
            responese: 68,
            rating: 60
        }, ],
        xkey: 'd',
        ykeys: ['responese', 'rating'],
        labels: ['# Responses', 'Rating'],
        hideHover: 'auto',
        smooth: false,
        resize: true,
        lineColors: ['#0B62A4', '#f0ad4e'],
        hoverCallback: function (index, options, content) {
            var data = options.data[index];
            var txt = $('.morris-hover').html('<div class="morris-hover-point" style="color: #0B62A4"># Responses : ' + data.responese + '</div><div class="morris-hover-point" style="color: #f0ad4e">Rating : ' + data.rating + '</div>');
            return txt.html();
        },
        xLabelFormat: function (d) {
            return monthNames[d.getMonth()] + ' ' + d.getFullYear();
        },
        gridTextSize: 10
    });
});
