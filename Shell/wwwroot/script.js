var clickCount = 0;


function renderjQueryComponents() {
    //$("#accordion").accordion();
    $(".jquery-btn button").button();
    $(".jquery-btn button").click(function () {
        console.log('Clicked');
        $('.click-count')[0].innerText = ++clickCount;
    });
}


function Menu_DocumentReady() {
    $('#mainorderlist').addClass('actives');
    $('#mainorder').addClass('in');
    $('#orderlist').addClass('actives');
    resizeIframe();
}
function resizeIframe() {
    var h1 = $(window).height();
    document.getElementById("divIframe").style.height = (h1 - 74) + "px";
}

function Dealerkeyjs() {
    if ($('.dataTable').hasClass('dataTable')) {
        $('.dataTable').DataTable({
            "order": [[2, 'asc']],
            "columnDefs": [{
                "orderable": false,
                "targets": 0
            }]
        });
    }
    $("#checkall").click(function () {
        var txtcopy = $('#txtcopy');
        if (txtcopy.val().length > 2) {
            txtcopy.val('||' + txtcopy.val());
        }
        if ($(this).prop('checked')) {
            $('.table-checkbox').each(function () {
                $(this).prop('checked', 'checked');
                var id = $(this).attr('data-id');
                txtcopy.val(txtcopy.val().replace('||' + id, ''));
                txtcopy.val(txtcopy.val() + '||' + id);
            });
        }
        else {
            $('.table-checkbox').each(function () {
                $(this).prop('checked', '');
                var id = $(this).attr('data-id');
                txtcopy.val(txtcopy.val().replace('||' + id, ''));
            });
        }
        if (txtcopy.val().length > 2) {
            txtcopy.val(txtcopy.val().substring(2));
        }
    });
    $("#selectall").click(function () {
        $('#txtcopy').val($('#hdfAcode').val());
    });
    $(".table-checkbox").click(function () {
        var txtcopy = $('#txtcopy');
        if (txtcopy.val().length > 2) {
            txtcopy.val('||' + txtcopy.val());
        }
        var id = $(this).attr('data-id');
        if ($(this).prop('checked')) {
            txtcopy.val(txtcopy.val().replace('||' + id, ''));
            txtcopy.val(txtcopy.val() + '||' + id);
        }
        else {
            txtcopy.val(txtcopy.val().replace('||' + id, ''));
        }
        if (txtcopy.val().length > 2) {
            txtcopy.val(txtcopy.val().substring(2));
        }
    });
}

function Productpointlist_addTooltips() {
    $('[data-toggle="tooltip"]').tooltip({
        trigger: 'hover'
    });
    $('[data-toggle="tooltip"]').on('mouseleave', function () {
        $(this).tooltip('hide');
    });
    $('[data-toggle="tooltip"]').on('click', function () {
        $(this).tooltip('dispose');
    });
}


function Shopping_DocumentReady() {
    var itemheight = $(window).height() - ($('.navbar-header').height() + $('.navbar-filter').height() + $('.navbar-footer').height() + 24);
    $('.lookup-itemlist').css('height', itemheight + 'px');
    /*
    if ($('#hdfshoppingtype').val() != '') {
        $('.navbar-filter-div').removeClass('active');
        $('#filter-' + $('#hdfshoppingtype').val()).addClass('active');
    }
    
    GetProductShoppingList('');

    $('#imgsearch').click(function () {
        $('#txtsearch').show();
    });
    $('#txtsearch').mouseout(function () {
        $(this).hide();
    });
    $('#txtsearch').keyup(function () {
        $('#ipagenum').val('1');
        timer = setTimeout(function () {
            GetProductShoppingList('');
        }, 1000);
    });*/
    $('.text-filter').click(function () {
        $('#txtsearch').val('');
        $('.navbar-filter-div').removeClass('active');
        $(this).parent().addClass('active');
        $('#hdfproductgroup').val($(this).attr('data-id'));
        $('#ipagenum').val('1');
        GetProductShoppingList('');
    });
    /*$('#loadlist').click(function () {
        $('#ipagenum').val(parseFloat($('#ipagenum').val()) + 1);
        timer = setTimeout(function () {
            GetProductShoppingList('true');
        }, 1000);
    });*/
    function GetProductShoppingList(isscroll) {

    }
}




function Basket_DocumentReady() {
    if (window.history && window.history.pushState) {
        window.history.pushState('back', null, $('#hplback').attr('href'));
    }
    var itemheight = $(window).height() - ($('.navbar-fixed-top').height() + $('.navbar-fixed-bottom').height() + 40);
    $('.lookup-itemlist').css('height', itemheight + 'px');
    $('#btnSave').click(function () {
        $('.modal').modal('hide');
        $('#loading').show();
    });
    $(window).resize(function () {
        var itemheight = $(window).height() - ($('.navbar-fixed-top').height() + $('.navbar-fixed-bottom').height() + 40);
        $('.lookup-itemlist').css('height', itemheight + 'px');
    });
}

function Orderedit_DocumentReady() {
    var itemheight = $(window).height() - ($('.navbar-fixed-top').height() + $('.navbar-fixed-bottom').height() + $('.navbar-title').height() + 40);
    $('.lookup-itemlist').css('height', itemheight + 'px');
    //GetProductInvoiceList();
    /*if ($('#hdfInvoicecheck').val() == 'TRUE' || $('#hdfact').val() == "view") {
        $('#ddlInvoiceStatus').attr('disabled', 'true');
        $('#btnsavecheck').attr('disabled', 'true');
        $('#btnsavecheck').hide();
    }
    $('#btnSave').click(function () {
        $('.modal').modal('hide');
        $('#loading').show();
    });*/
}


function Orderinsert_DocumentReady() {
    var itemheight = $(window).height() - ($('.navbar-header').height() + $('.navbar-filter').height() + $('.navbar-footer').height() + 24);
    $('.lookup-itemlist').css('height', itemheight + 'px');
    //GetProductInvoiceListAdd('');

    $('#imgsearch').click(function () {
        $('#txtsearch').show();
    });
    $('#txtsearch').mouseout(function () {
        $(this).hide();
    });
    $('#txtsearch').keyup(function () {
        $('#ipagenum').val('1');
        timer = setTimeout(function () {
            //GetProductInvoiceListAdd('');
        }, 1000);
    });
    $('.text-filter').click(function () {
        $('.navbar-filter-div').removeClass('active');
        $(this).parent().addClass('active');
        $('#hdfproductgroup').val($(this).attr('data-id'));
        $('#ipagenum').val('1');
        //GetProductInvoiceListAdd('');
    });
    $('#loadlist').click(function () {
        $('#ipagenum').val(parseFloat($('#ipagenum').val()) + 1);
        timer = setTimeout(function () {
            //GetProductInvoiceListAdd('true');
        }, 1000);
    });
}


function History_DocumentReady() {
    var itemheight = $(window).height() - ($('.navbar-fixed-top').height() + $('.navbar-fixed-bottom').height() + $('.navbar-title').height() + 40);
    $('.lookup-itemlist').css('height', itemheight + 'px');
}
function HistoryDetail_DocumentReady() {
    var itemheight = $(window).height() - ($('.navbar-fixed-top').height() + $('.navbar-fixed-bottom').height() + $('.navbar-title').height() + 40);
    $('.lookup-itemlist').css('height', itemheight + 'px');
}

window.test = {
    historyGo(value) {
        window.history.go(value);
    }
};