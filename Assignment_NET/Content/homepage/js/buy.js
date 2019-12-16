jQuery(document).ready(function () {
    jQuery('.increase').click(function () {
        var quantityInput = jQuery(this).siblings('.buy-quantity');
        var productId = jQuery(this).attr('ProductId');
        console.log(productId)
        jQuery.ajax({
            url: `/ShoppingCart/AddToCart?productId=${productId}&quantity=1`,
            method: 'GET',
        }).done(function (data) {
            console.log(data);
            quantityInput.val(parseInt(quantityInput.val()) + 1);
            jQuery('.cart-icon-quantity').text(data.TotalQuantity);
        })
    });
    jQuery('.decrease').click(function () {
        var quantityInput = jQuery(this).siblings('.buy-quantity');
        var productId = jQuery(this).attr('ProductId');
        console.log(productId)
        jQuery.ajax({
            url: `/ShoppingCart/AddToCart?productId=${productId}&quantity=-1`,
            method: 'GET',
        }).done(function (data) {
            var quantityAfter = parseInt(quantityInput.val()) - 1;
            if (quantityAfter == 0) {
                location.reload();
            } else {
                quantityInput.val(quantityAfter);
                jQuery('.cart-icon-quantity').text(data.TotalQuantity);
            }      
        })
    })
    jQuery('#reload').click(function () {
        location.reload();
    })
    jQuery('.update-item').click(function () {
        var quantityInput = jQuery(this).siblings('.product_count').children('.buy-quantity').val();
        var productId = jQuery(this).attr('ProductId');
        jQuery.ajax({
            url: `/ShoppingCart/UpdateCart?productId=${productId}&quantity=${quantityInput}`,
            method: 'GET',
        }).done(function (data) {
            location.reload();
        })
    })
    jQuery('.delete-item').click(function () {
    
        var productId = jQuery(this).attr('ProductId');
        jQuery.ajax({
            url: `/ShoppingCart/RemoveFromCart?productId=${productId}`,
            method: 'GET',
        }).done(function (data) {
            location.reload();
        })
    })
})