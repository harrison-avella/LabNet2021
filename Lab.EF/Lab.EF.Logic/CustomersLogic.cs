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
            try
            {

                return context.Customers.ToList();
            }
            catch (Exception ex) { throw ex; }
        }
        public Customers GetOne(string id)
        {
            try
            {

                return context.Customers.First(p => p.CustomerID.Equals(id));
            }
            catch (Exception ex) { throw ex; }
        }
        public void Add(Customers newCustomer)
        {
            try
            {

                context.Customers.Add(newCustomer);
                context.SaveChanges();
            }
            catch (Exception ex) { throw ex; }
        }
        public void Delete(string id)
        {
            try
            {
                var customerDelete = context.Customers.Find(id);
                context.Customers.Remove(customerDelete);
                context.SaveChanges();

            }
            catch (Exception ex) { throw ex; }
        }
        public void Update(Customers customer)
        {
            try
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
            catch (Exception ex) { throw ex; }
        }


    }
}
