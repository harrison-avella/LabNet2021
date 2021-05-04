using Lab.EF.Entities;
using Lab.EF.Entities.ClassQuerys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class CustomersLogic : BaseLogic, IABMLogic<Customers, string>
    {
        #region
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
            var categoryUpdate = context.Customers.Find(customer.CustomerID);

            categoryUpdate.CompanyName = customer.CompanyName;
            categoryUpdate.ContactName = customer.ContactName;
            categoryUpdate.ContactTitle = customer.ContactTitle;
            categoryUpdate.Address = customer.Address;
            categoryUpdate.City = customer.City;
            categoryUpdate.PostalCode = customer.PostalCode;
            categoryUpdate.Country = customer.Country;
            categoryUpdate.Phone = customer.Phone;

            context.SaveChanges();
        }
        #endregion
        public Customers FirstCustomerByCompanyName(String companyName)
        {
            return context.Customers.Where(c => c.CompanyName.Equals(companyName)).First();
        }

        public List<Customers> CustomersOfWashington()
        {
            var query = from cus in context.Customers
                        where cus.Region.Equals("WA")
                        select cus;
            return query.ToList();
        }
        public List<CustomerName> CustomersNameUPPERlower()
        {
            var query = from cus in context.Customers
                        select new CustomerName
                        {
                            NameUpper = cus.CompanyName.ToUpper(),
                            NameLower = cus.CompanyName.ToLower()
                        };
            return query.ToList();

        }

    }
}
