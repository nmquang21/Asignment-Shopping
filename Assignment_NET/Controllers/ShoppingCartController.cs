using Assignment_NET.Models;
using Assignment_NET.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace Assignment_NET.Controllers
{
    public class ShoppingCartController : Controller
    {
        public static string ShoppingCartAttribute = "ShoppingCart";
        private MyDbContext db = new MyDbContext();
        private IOrderService orderService = new OrderService();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            ViewBag.ShoppingCart = LoadShoppingCart();

            return View();
        }
        public ActionResult AddToCart(int productId, int quantity)
        {
            var product = db.Products.Find(productId);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product's not found.'");
            }

            var shoppingCart = LoadShoppingCart();
            var temp = shoppingCart.AddCartItem(product, quantity);
            SaveShoppingCart(shoppingCart);
            return temp;
        }

        public ActionResult UpdateCart(int productId, int quantity)
        {
            if (quantity <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid quantity.'");
            }
            var product = db.Products.Find(productId);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product's not found.'");
            }
            var shoppingCart = LoadShoppingCart();
            shoppingCart.UpdateCartItem(product, quantity);
            SaveShoppingCart(shoppingCart);
            return Redirect("/ShoppingCart");
        }

        public ActionResult RemoveFromCart(int productId)
        {
            var product = db.Products.Find(productId);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product's not found.'");
            }
            var shoppingCart = LoadShoppingCart();
            shoppingCart.RemoveCartItem(productId);
            SaveShoppingCart(shoppingCart);
            return Redirect("/ShoppingCart");
        }
         public ActionResult TotalQuantity()
        {
            return new JsonResult()
            {
                Data = new
                {
                    TotalQuantity = LoadShoppingCart().GetTotalQuantity()
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
            };           
        }


        [HttpPost]
        public ActionResult CreateOrder(OrderInformation orderInformation)
        {
            
            Debug.WriteLine(orderInformation.ShipName);
            var shoppingCart = LoadShoppingCart();
            var status = orderService.createOrder(shoppingCart, orderInformation);
            if (status != -1)
            {
                ClearCart();
                return Redirect("/Home/Confirmation/" + status);
            }
            return Redirect("");
        }

        private void ClearCart()
        {
            Session.Remove(ShoppingCartAttribute);
        }

        /**
         * Lưu thông tin cart vào session.
         */
        private void SaveShoppingCart(ShoppingCart cart)
        {
            Session[ShoppingCartAttribute] = cart;
        }

        /**
         * Kiểm tra sự tồn tại của shopping cart trong session.
         * Nếu chưa có thì trả về một shopping cart mới.
         */
        private ShoppingCart LoadShoppingCart()
        {
            if (Session[ShoppingCartAttribute] is ShoppingCart currentShoppingCart)
            {
                return currentShoppingCart;
            }
            return new ShoppingCart();
        }
    }
}