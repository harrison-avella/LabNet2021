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
            try
            {

            return context.Orders.ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public Orders GetOne(int id)
        {
            try
            {

            return context.Orders.First(o => o.OrderID.Equals(id));
            }
            catch (Exception ex) { throw ex; }
        }

        public void Add(Orders newOrder)
        {
            try
            {

            context.Orders.Add(newOrder);
            context.SaveChanges();
            }
            catch (Exception ex) { throw ex; }
        }

        public void Delete(int id)
        {
            try
            {

            var orderDelete = context.Orders.Find(id);
            context.Orders.Remove(orderDelete);
            context.SaveChanges();
            }
            catch (Exception ex) { throw ex; }
        }


        public void Update(Orders order)
        {
            try
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
            catch (Exception ex) { throw ex; }
        }
    }
}
