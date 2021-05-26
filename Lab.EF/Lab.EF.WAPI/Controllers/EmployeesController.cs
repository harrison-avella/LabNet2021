using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.WAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EjercicioMVC.WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class EmployeesController : ApiController
    {

        EmployeesLogic employeesLogic = new EmployeesLogic();

        // GET api/Employees
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                IEnumerable<Employees> employees = employeesLogic.GetAll();
                IEnumerable<EmployeesView> employeesView = employees.Select(e => new EmployeesView
                {
                    EmployeeID = e.EmployeeID,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Address = e.Address,
                    City = e.City
                }).ToList();
                return Ok(employeesView);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, "No hay nadie?");
            }

        }

        // GET api/Employees/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {

                Employees e = employeesLogic.GetOne(id);
                EmployeesView employeeView = new EmployeesView
                {
                    EmployeeID = e.EmployeeID,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Address = e.Address,
                    City = e.City
                };
                return Ok(employeeView);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, "No se queria venir, se nos perdio");
            }

        }

        // POST api/Employees
        [HttpPost]
        public IHttpActionResult Add(EmployeesView e)
        {
            try
            {
                employeesLogic.Add(new Employees
                {
                    EmployeeID = e.EmployeeID,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Address = e.Address,
                    City = e.City

                });
                return Ok();
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, "No se pudo agregar lo sentimos");
            }

        }

        // POST api/Employees/5
        [HttpPost]
        public IHttpActionResult Post(int id, EmployeesView employeesView)
        {
            try
            {
                Employees employee = employeesLogic.GetOne(id);
                employee.FirstName = employeesView.FirstName;
                employee.LastName = employeesView.LastName;
                employee.Address = employeesView.Address;
                employee.City = employeesView.City;
                employeesLogic.Update(employee);
                return Ok();
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, "No se pudo actualizar, el problema no eres tu soy yo...");
            }

        }

        // DELETE api/Employees/5
        public IHttpActionResult Delete(int id)
        {

            try
            {
                employeesLogic.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, "Algo malo paso no se pudo borrar");
            }

        }
    }
}