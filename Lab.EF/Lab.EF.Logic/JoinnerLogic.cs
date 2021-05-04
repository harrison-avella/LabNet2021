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
        public IEnumerable<CustomerJoinOrder> CustomerJoinOrders()
        {
            return from cus in context.Customers
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
        }

        public IEnumerable<CategoryJoinProduct> CategoryJoinProduct()
        {
            return from cat in context.Categories
                   join pro in context.Products
                   on cat.CategoryID equals pro.CategoryID
                   select new CategoryJoinProduct
                   {
                       CategoryName = cat.CategoryName,
                       ProductName = pro.ProductName
                   };
        }


        public IEnumerable<CustomerJoinOrder> CustomerCantOrders()
        {
            return from cus in context.Customers
                   join ord in context.Orders
                   on cus.CustomerID equals ord.CustomerID
                   //group ord by ord.CustomerID
                   into joi
                   select new CustomerJoinOrder
                   {
                       CustomerID = cus.CustomerID,
                       ContactName = cus.ContactName,
                       CantidadOrdenes = joi.Count()
                   };
        }
    }
}
