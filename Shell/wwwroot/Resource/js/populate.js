
function GetDealer() {
    var all = 'ศูนย์บริการทั้งหมด';
    $('#dealer').empty().append('<option value="">' + all + '</option>');
    $.ajax({
        type: 'POST',
        url: 'Webservice/pass_icard.asmx/GetDealer',
        dataType: 'json',
        success: function (response) {
            if (response != '') {
                $.each(response, function (index, value) {
                    $('#dealer').append('<option value="' + value.ID + '">' + value.Name + '</option>');
                });
            }
        },
        failure: function (response) {
            alert("ไม่สามารถโหลดข้อมูลได้ !");
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("ไม่สามารถโหลดข้อมูลได้ !");
        }
    });
}
function GetMeetingStatus() {
    var all = 'สถานะทั้งหมด';
    $('#meeting_status').empty().append('<option value="">' + all + '</option>');
    $.ajax({
        type: 'POST',
        url: 'Webservice/pass_icard.asmx/GetMeetingStatus',
        dataType: 'json',
        success: function (response) {
            if (response != '') {
                $.each(response, function (index, value) {
                    $('#meeting_status').append('<option value="' + value.ID + '">' + value.Name + '</option>');
                });
            }
        },
        failure: function (response) {
            alert("ไม่สามารถโหลดข้อมูลได้ !");
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("ไม่สามารถโหลดข้อมูลได้ !");
        }
    });
}