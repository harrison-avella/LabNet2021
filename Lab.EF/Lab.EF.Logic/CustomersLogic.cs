using Lab.EF.Entities;
using Lab.EF.Entities.ClassQuerys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class CustomersLogic : BaseLogic
    {
        public Customers FirstCustomerByCompanyName(String companyName)
        {
            return context.Customers.Where(c => c.CompanyName.Equals(companyName)).First();
        }

        public IEnumerable<Customers> CustomersOfWashington()
        {
            return from cus in context.Customers
                   where cus.Region.Equals("WA")
                   select cus;
        }
        public IEnumerable<CustomerName> CustomersNameUPPERlower()
        {
            return from cus in context.Customers
                   select new CustomerName
                   {
                       NameUpper = cus.CompanyName.ToUpper(),
                       NameLower = cus.CompanyName.ToLower()
                   };
        }
        public IEnumerable<Customers> CustomersOfWashingtonFirstThree()
        {
            return (from cus in context.Customers
                    where cus.Region.Equals("WA")
                    select cus)
                    .Take(3);
        }
    }
}
