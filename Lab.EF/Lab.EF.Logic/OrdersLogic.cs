using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class OrdersLogic : BaseLogic, IABMLogic<Orders, int>
    {
        public List<Orders> GetAll()
        {
            return context.Orders.ToList();
        }

        public Orders GetOne(int id)
        {
            return context.Orders.First(o => o.OrderID.Equals(id));
        }

        public void Add(Orders newOrder)
        {
            context.Orders.Add(newOrder);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var orderDelete = context.Orders.Find(id);
            context.Orders.Remove(orderDelete);
            context.SaveChanges();
        }


        public void Update(Orders order)
        {
            var orderUpdate = context.Orders.Find(order.OrderID);

            orderUpdate.CustomerID = order.CustomerID;
            orderUpdate.EmployeeID = order.EmployeeID;
            orderUpdate.OrderDate = order.OrderDate;
            orderUpdate.RequiredDate = order.RequiredDate;
            orderUpdate.ShipVia = order.ShipVia;
            orderUpdate.Freight = order.Freight;
            orderUpdate.ShipName = order.ShipName;
            orderUpdate.ShipAddress = order.ShipAddress;
            orderUpdate.ShipCity = order.ShipCity;
            orderUpdate.ShipPostalCode = order.ShipPostalCode;
            orderUpdate.ShipCountry = order.ShipCountry;

            context.SaveChanges();
        }
    }
}
