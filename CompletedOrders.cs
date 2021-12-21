using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Logic
{
    class CompletedOrders
    {

        public static List<Order> Orders = new List<Order>();

        public static List<Order> GetAll()
        {
            return Orders;
        }

        public static void Add(Order o)
        {
            Orders.Add(o);
        }
    }
}
