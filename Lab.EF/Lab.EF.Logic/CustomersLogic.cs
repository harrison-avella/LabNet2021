using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class CustomersLogic : BaseLogic, IABMLogic<Customers, string>
    {
        public List<Customers> GetAll()
        {
            return context.Customers.ToList();
        }
        public Customers GetOne(string id)
        {
            return context.Customers.First(p => p.CustomerID.Equals(id));
        }
        public void Add(Customers newCustomer)
        {
            context.Customers.Add(newCustomer);
            context.SaveChanges();
        }
        public void Delete(string id)
        {
            var customerDelete = context.Customers.Find(id);
            context.Customers.Remove(customerDelete);
            context.SaveChanges();
        }
        public void Update(Customers customer)
        {
            var customerUpdate = context.Customers.Find(customer.CustomerID);

            customerUpdate.CompanyName = customer.CompanyName;
            customerUpdate.ContactName = customer.ContactName;
            customerUpdate.ContactTitle = customer.ContactTitle;
            customerUpdate.Address = customer.Address;
            customerUpdate.City = customer.City;
            customerUpdate.PostalCode = customer.PostalCode;
            customerUpdate.Country = customer.Country;
            customerUpdate.Phone = customer.Phone;

            context.SaveChanges();
        }


    }
}
