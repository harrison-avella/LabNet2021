using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Entities.ClassQuerys
{
    public class CustomerJoinOrder
    {
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public string Region { get; set; }
        public DateTime? OrderDate { get; set; }
        public int CantidadOrdenes { get; set; }

    }
}
