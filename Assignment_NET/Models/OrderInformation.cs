using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assignment_NET.Models
{
    public class OrderInformation
    {
        public OrderInformation()
        {

        }
        public OrderInformation(int Id, string ShipName, string ShipAddress, string ShipPhone, int PaymentType)
        {
            this.Id = Id;
            this.ShipName = ShipName;
            this.ShipAddress = ShipAddress;
            this.ShipPhone = ShipPhone;
            this.PaymentType= PaymentType;
        }
        //[Key, ForeignKey("Order")]
        public int Id { get; set; }    
        //public int OrderId { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipPhone { get; set; }
        public int PaymentType { get; set; }
        [Required]
        public virtual Order Order { get; set; }
    }
}