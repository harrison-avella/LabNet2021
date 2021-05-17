using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class EmployeesLogic : BaseLogic, IABMLogic<Employees, int>
    {
        public List<Employees> GetAll()
        {
            try
            {
                return context.Employees.ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public Employees GetOne(int id)
        {
            try
            {
                return context.Employees.First(e => e.EmployeeID.Equals(id));
            }
            catch (Exception ex) { throw ex; }
        }

        public void Add(Employees employee)
        {
            try
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
            catch (Exception ex) { throw ex; }
        }

        public void Delete(int id)
        {
            try
            {
                var employeeDelete = GetOne(id);
                context.Employees.Remove(employeeDelete);
                context.SaveChanges();

            }
            catch (Exception ex) { throw ex; }

        }

        public void Update(Employees employee)
        {
            try
            {
                var employeeUpdate = GetOne(employee.EmployeeID);

                employeeUpdate.FirstName = employee.FirstName;
                employeeUpdate.LastName = employee.LastName;

                context.SaveChanges();
            }
            catch (Exception ex) { throw ex; }
        }
        public int IdMax()
        {
            return context.Employees.Select(e => e.EmployeeID).Max();
        }
    }
}
