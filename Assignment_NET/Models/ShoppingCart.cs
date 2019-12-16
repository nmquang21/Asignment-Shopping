
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_NET.Models
{
    public class ShoppingCart
    {
        private Dictionary<int, CartItem> _cartItems = new Dictionary<int, CartItem>();
        public decimal _totalPrice = 0;
        public decimal _totalQuantity = 0;

        public decimal GetTotalPrice()
        {
            this._totalPrice = 0;
            foreach (var item in _cartItems.Values)
            {
                this._totalPrice += item.UnitPrice * item.Quantity;
            }
            return this._totalPrice;
        }

        public decimal GetTotalQuantity()
        {
            this._totalQuantity = 0;
            foreach (var item in _cartItems.Values)
            {
                this._totalQuantity += item.Quantity;
            }
            return _totalQuantity;
        }

        public List<CartItem> GetCartItems()
        {
            return _cartItems.Values.ToList();
        }

        public ActionResult AddCartItem(Product product, int quantity)
        {
            // Kiểm tra xem sản phẩm có tồn tại trong cart hay không?
            if (_cartItems.ContainsKey(product.Id))
            {
                var existItem = _cartItems[product.Id];
                // trong trường hợp tồn tại thì update số lượng và dừng xử lý.
                existItem.Quantity += quantity;
                if (existItem.Quantity <= 0)
                {
                    _cartItems.Remove(product.Id);
                }
                else
                {
                    _cartItems[product.Id] = existItem;
                }
                return new JsonResult()
                {
                    Data = new
                    {
                        Exits = existItem.Quantity,
                        TotalQuantity = GetTotalQuantity()
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                }; ;
            }
            // Trong trường hợp không tồn tại sản phẩm trong giỏ hàng thì thêm mới.
            _cartItems.Add(product.Id, new CartItem(product, quantity));
            return new JsonResult()
            {
                Data = new
                {
                    TotalQuantity = GetTotalQuantity()
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
            };
        }

        public void UpdateCartItem(Product product, int quantity)
        {
            // Kiểm tra xem sản phẩm có tồn tại trong cart hay không?
            if (_cartItems.ContainsKey(product.Id))
            {
                var existItem = _cartItems[product.Id];
                // trong trường hợp tồn tại thì update số lượng và dừng xử lý.
                existItem.Quantity = quantity;
                _cartItems[product.Id] = existItem;
                return;
            }
            // Trong trường hợp không tồn tại sản phẩm trong giỏ hàng thì thêm mới.
            _cartItems.Add(product.Id, new CartItem(product, quantity));
        }

        public void RemoveCartItem(int productId)
        {
            // Kiểm tra xem sản phẩm có tồn tại trong cart hay không?
            if (_cartItems.ContainsKey(productId))
            {
                _cartItems.Remove(productId);
                return;
            }
        }



    }
}