using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_NET.Models;

namespace Assignment_NET.Service
{
    interface IOrderService
    {
        int createOrder(ShoppingCart cart, OrderInformation orderInformation);
    }
}
