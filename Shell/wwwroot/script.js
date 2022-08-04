var clickCount = 0;

function renderjQueryComponents() {
    //$("#accordion").accordion();
    $(".jquery-btn button").button();
    $(".jquery-btn button").click(function () {
        console.log('Clicked');
        $('.click-count')[0].innerText = ++clickCount;
    });
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