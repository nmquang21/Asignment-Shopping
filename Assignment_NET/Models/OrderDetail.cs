using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assignment_NET.Models
{
    public class OrderDetail
    {
        public OrderDetail()
        {

        }
        public OrderDetail(int OrderId, int ProductId, decimal UnitPrice, int Quantity)
        {
            this.OrderId = OrderId;
            this.ProductId = ProductId;
            this.UnitPrice = UnitPrice;
            this.Quantity = Quantity;
        }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        [Key, Column(Order = 0)]
        public int ProductId { get; set; }
        [Key, Column(Order = 1)]
        public int OrderId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }


    }
}