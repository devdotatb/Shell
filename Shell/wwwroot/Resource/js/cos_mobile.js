
$(document).ready(function () {
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
});
function initQty() {
    if ($('.product-quantity').length) {
        var qtys = $('.product-quantity');

        qtys.each(function () {
            var qty = $(this);
            var sub = qty.find('.qty-sub');
            var add = qty.find('.qty-add');
            var num = qty.find('.product-num');
            var original;
            var newValue;

            sub.on('click', function () {
                original = parseFloat(qty.find('.product-num').text());
                if (original > 1) {
                    newValue = original - 1;
                }
                num.text(newValue);
            });

            add.on('click', function () {
                original = parseFloat(qty.find('.product-num').text());
                newValue = original + 1;
                num.text(newValue);
            });
        });
    }
}