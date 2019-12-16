using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment_NET.Models;
using WebApplication2.Models;

namespace Assignment_NET.Service
{
    public class OrderService: IOrderService
    {
        private MyDbContext db = new MyDbContext();
        public int createOrder(ShoppingCart cart,OrderInformation orderInformation)
        {
            if (cart.GetCartItems().Count == 0)
            {
                return -1;
            }
            var order = new Order();
            
         
            order.TotalPrice = cart.GetTotalPrice();
            var orderDetails = new List<OrderDetail>();
            bool existError = false;
            foreach (var item in cart.GetCartItems())
            {
                Product product = db.Products.Find(item.ProductId);
                if (product == null)
                {
                    existError = true;
                    break;
                }
                var orderDetail = new OrderDetail(order.Id, product.Id, item.UnitPrice, item.Quantity);
                //orderDetail.ProductId = product.Id;
                //orderDetail.OrderId = order.Id;
                //orderDetail.Quantity = item.Quantity;
                //orderDetail.UnitPrice = item.UnitPrice;
                orderDetails.Add(orderDetail);
            }
            if (!existError)
            {
                order.OrderDetails = orderDetails;
                orderInformation.Id = order.Id;
                order.OrderInformation = orderInformation;
                order.OrderInformation.Id = order.Id;
                db.Orders.Add(order);
                db.SaveChanges();
                return order.Id;
            }
            return -1;
        }
    }
}