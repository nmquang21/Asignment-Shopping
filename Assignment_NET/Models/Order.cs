using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_NET.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        //public int MemberId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long DeletedAt { get; set; }
        public int Status { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual OrderInformation OrderInformation { get; set; }

        public Order()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Status = (int) OrderStatus.Pending;
        }

        public enum PaymentType
        {
            Cod = 1,
            InternetBanking = 2,
            DirectTransfer = 3
        }

        public enum OrderStatus
        {
            Pending = 5,
            Confirmed = 4,
            Shipping = 3,
            Paid = 2,
            Done = 1,
            Cancel = 0,
            Deleted = -1
        }

        
    }
}