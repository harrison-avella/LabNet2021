using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.EF.WAPI.Models
{
    public class EmployeesView
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}