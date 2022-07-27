

function CallmeifyouReady() {
    $('#umenu > li > a').click(function () {
        var sub;
        var attr = $('#umenu > li');
        attr.each(function (index, value) {
            $(this).find('.main').removeClass('actives');
            sub = $(this).find('ul');
            if (sub.hasClass('collapse')) {
                sub.removeClass('in');
            }
        });
        $(this).addClass('actives');
    });
    $('#umenu > li > ul > li').click(function () {
        var attr = $('#umenu > li > ul > li');
        attr.each(function (index, value) {
            $(this).find('a').removeClass('actives');
        });
        $(this).find('a').addClass('actives');
    });

    $('#amenu').click(function () {
        if ($('#umenu').hasClass('hidden')) {
            $('#umenu').removeClass('hidden');
            $('#wrapper').removeAttr('style');
            $('.navber-menu').removeAttr('style');
        }
        else {
            $('#umenu').addClass('hidden');
            $('#wrapper').css('padding-left', '0');
            $('.navber-menu').css('left', '0');
        }
    });

    $('a').click(function (e) {
        if ($(this).attr('href') == '#') {
            e.preventDefault();
        }
    });

    $(".keyInteger").keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            return false;
        }
    });
    $(".keyDouble").keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which == 46 || (e.which < 48 || e.which > 57))) {
            return false;
        }
    })
    $('.keyTwoDecimal').keypress(function (e) {
        if ((e.which != 46 || $(this).val().indexOf('.') != -1) && ((e.which < 48 || e.which > 57) && (e.which != 0 && e.which != 8))) {
            e.preventDefault();
        }
        var text = $(this).val();
        if ((text.indexOf('.') != -1) && (text.substring(text.indexOf('.')).length > 2) && (e.which != 0 && e.which != 8) && ($(this)[0].selectionStart >= text.length - 2)) {
            e.preventDefault();
        }
    });

    $('.print').click(function () {
        ClickHereToPrint();
    });

    if ($('.datepicker').hasClass('datepicker')) {
        $('.datepicker').datepicker({
            autoclose: true,
            format: "dd/mm/yyyy",
            orientation: "bottom left",
            todayHighlight: true,
            disableTouchKeyboard: true
        });
    }
    if ($('.clockpicker').hasClass('clockpicker')) {
        $('.clockpicker').clockpicker({
            align: 'left',
            autoclose: true
        });
    }

    $('#ddlPageSize').change(function () {
        ChangePaging('1');
    });
    $('.pagination').on('click', 'a', function () {
        var pagenumber = 0;
        if ($(this).hasClass('Prev') || $(this).hasClass('Next')) {
            pagenumber = parseFloat($('.pagination').find('.active').find('a').attr('data-id'));
            if ($(this).hasClass('Prev')) {
                pagenumber--;
            }
            else {
                pagenumber++;
            }
        }
        else if ($(this).hasClass('Dllipsis')) {
            pagenumber = parseFloat($('.pagination').find('.active').find('a').attr('data-id')) - 5;
        }
        else if ($(this).hasClass('Ellipsis')) {
            pagenumber = parseFloat($('.pagination').find('.active').find('a').attr('data-id')) + 5;
        }
        else {
            pagenumber = parseFloat($(this).attr('data-id'));
        }
        ChangePaging(pagenumber);
    });

    $('[data-toggle="tooltip"]').tooltip();
}

function GetPaging(page, pagenumber, total) {
    var content = '';
    $('.pagination').html('');
    $('.pagination-div').html('');
    $('.span-pagination-f').html('');
    $('.span-pagination-l').html('');
    var pagetotal = Math.ceil(total / page);
    var pagestart = 1;
    var pageend = pagetotal;
    if (pagetotal > 1) {
        if (pagenumber > 1) {
            content += '<li><a aria-label="Previous" class="Prev"><span aria-hidden="true"><i class="fa fa-angle-left"></i></span></a></li>';
        }
        if (pageend > 9) {
            pagestart = parseFloat(pagenumber) - 4;
            pageend = parseFloat(pagenumber) + 4;
            if (pagestart < 1) {
                pagestart = 1;
                pageend = 9;
            }
            else if (pageend > pagetotal) {
                pagestart = pagetotal - 8;
                pageend = pagetotal;
            }
        }
        if (pagenumber > 5) {
            content += '<li><a aria-label="Ellipsis" class="Dllipsis"><span aria-hidden="true">...</span></a></li>';
        }
        for (var i = pagestart; i <= pageend; i++) {
            if (i == pagenumber) {
                content += '<li class="active"><a data-id="' + i + '">' + i + '</a></li>';
            }
            else {
                content += '<li><a data-id="' + i + '">' + i + '</a></li>';
            }
        }
        if (pagenumber <= pagetotal - 8) {
            content += '<li><a aria-label="Ellipsis" class="Ellipsis"><span aria-hidden="true">...</span></a></li>';
        }
        if (pagenumber != pagetotal && pagetotal > 1) {
            content += '<li><a aria-label="Next" class="Next"><span aria-hidden="true"><i class="fa fa-angle-right"></i></span></a></li>';
        }
        $('.span-pagination-f').html('หน้าที่ :');
        $('.span-pagination-l').html('จากทั้งหมด ' + addCommas(pagetotal) + ' หน้า');
    }
    $('.pagination').append(content);
    if (pagenumber < pagetotal) {
        content = 'รายการที่ ' + addCommas(((page * pagenumber) - (page - 1))) + ' - ' + addCommas(page * pagenumber) + ' จากทั้งหมด ' + addCommas(total) + ' รายการ';
    }
    else {
        content = 'รายการที่ ' + addCommas(((page * pagenumber) - (page - 1))) + ' - ' + addCommas(total) + ' จากทั้งหมด ' + addCommas(total) + ' รายการ';
    }
    $('.pagination-div').html(content);
}
function ChangePaging(pagenumber) {
    if ($('#ispage').hasClass('qr_customer') || $('#ispage').hasClass('bs_cust')) {
        GetTable_qr_customer($('#ddlPageSize').val(), pagenumber);
    }
    else if ($('#ispage').hasClass('bs_custcar')) {
        GetTable_bs_custcar($('#ddlPageSize').val(), pagenumber);
    }
    else if ($('#ispage').hasClass('cust_point')) {
        GetTable_cust_point($('#ddlPageSize').val(), pagenumber);
    }
}

function addCommas(nStr) {
    nStr += '';
    x = nStr.split('.');
    x1 = x[0];
    x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + ',' + '$2');
    }
    return x1 + x2;
}
function changedate(nStr) {
    if (nStr.length == 10) {
        nStr = nStr.substr(6, 4) + nStr.substr(3, 2) + nStr.substr(0, 2);
    }
    else {
        nStr = '';
    }
    return nStr;
}
function replacenull(nStr) {
    if (typeof (nStr) == 'undefined' || nStr === null) {
        return '';
    }
    return nStr;
}


function ClickHereToPrint() {
    try {
        var oIframe = document.getElementById('ifmcontentstoprint');
        var oContent = document.getElementById('divContent').innerHTML;
        var oDoc = (oIframe.contentWindow || oIframe.contentDocument);
        if (oDoc.document) oDoc = oDoc.document;
        oDoc.write('<html><head>');
        oDoc.write('<link href="Resource/css/bootstrap.min.css" rel="stylesheet" type="text/css" />');
        oDoc.write('<link href="Resource/css/sb-admin.css" rel="stylesheet" type="text/css" />');
        oDoc.write('<link href="Resource/css/font-awesome.min.css" rel="stylesheet" type="text/css" />');
        oDoc.write('<link href="Resource/css/bootstrap-select.css" rel="stylesheet" type="text/css" />');
        oDoc.write('<link href="Resource/css/bootstrap-datepicker.css" rel="stylesheet" type="text/css" />');
        oDoc.write('<link href="Resource/css/bootstrap-radio.css" rel="stylesheet" type="text/css" />');
        oDoc.write('<link href="Resource/css/cos.css" rel="stylesheet" type="text/css" />');
        oDoc.write('<style type="text/css" media="print">');
        oDoc.write('body{ margin: 0;padding: 0; }');
        oDoc.write('@media print {');
        oDoc.write('.bootstrap-select.btn-group:not(.input-group-btn), .bootstrap-select.btn-group[class*="col-"] {float:none;display:block;margin-left:0;}');
        oDoc.write('.form-control,.btn {border:0;border-radius:0;background-color:transparent;}');
        oDoc.write('.text-inline,.text-inline1,.text-inline2,.text-inline3 {display:block;}');
        oDoc.write('.dates,.caret {display:none;}');
        oDoc.write('.input-group-addon {border:0;}');
        oDoc.write('.input-daterange .input-group-addon.edit-text {width:initial;font-weight:normal;}');
        oDoc.write('}');
        oDoc.write('</style>');
        oDoc.write("</head><body onload='this.focus(); this.print();'>");
        oDoc.write(oContent + "</body></html>");
        oDoc.close();
    }
    catch (e) {
        self.print();
    }
}