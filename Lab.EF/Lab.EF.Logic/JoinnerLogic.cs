using System;
using Lab.EF.Entities.ClassQuerys;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class JoinnerLogic : BaseLogic
    {
        public List<CustomerJoinOrder> CustomerJoinOrders()
        {
            var query = from cus in context.Customers
                        join ord in context.Orders
                        on cus.CustomerID equals ord.CustomerID
                        where cus.Region.Equals("WA") &&
                        ord.OrderDate > new DateTime(1997, 1, 1)
                        orderby ord.OrderDate
                        select new CustomerJoinOrder
                        {
                            CustomerID = cus.CustomerID,
                            Region = cus.Region,
                            OrderDate = ord.OrderDate
                        };

            return query.ToList();
        }
    }
}
