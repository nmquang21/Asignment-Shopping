jQuery(document).ready(function () {
    jQuery('.add-to-cart').click(function () {
        var productId = jQuery(this).attr('id');
        jQuery.ajax({
            url: `/ShoppingCart/AddToCart?productId=${productId}&quantity=1`,
            method: 'GET'
        }).done(function (data) {
            jQuery('.cart-icon-quantity').text(data.TotalQuantity)
            if (data.Exits) {
                jQuery('.modal-buy-body').text('Product already in cart, updated quantity!!');
                jQuery('#buy-confirm').modal();
            }
            else {
                jQuery('#buy-confirm').modal();
            }
        })
    })
})