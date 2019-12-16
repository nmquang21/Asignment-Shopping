jQuery(document).ready(function () {
    jQuery.each(jQuery('.format-money'), function (index, item) {
        var formatItem = jQuery(item);
        formatItem.text(format_curency(formatItem.text()))
    });
    function format_curency(data) {
        return isNaN(data) ? "" : data.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".") +"đ";
    }
})