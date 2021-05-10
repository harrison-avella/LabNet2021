using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.EF.MVC.Controllers
{
    public class EmployeesController : Controller

    {

        EmployeesLogic employeesLogic = new EmployeesLogic();

        public ActionResult Index()
        {
            List<Employees> employees = employeesLogic.GetAll();
            List<EmployeesView> employeesViews = employees.Select(e => new EmployeesView
            {
                EmployeeID = e.EmployeeID,
                FirstName = e.FirstName,
                LastName = e.LastName

            }).ToList();
            return View(employeesViews);
        }


        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(EmployeesView employeesView)
        {
            try
            {
                Employees employeesEntity = new Employees
                {
                    EmployeeID = employeesLogic.IdMax() + 1,
                    FirstName = employeesView.FirstName,
                    LastName = employeesView.LastName
                };
                employeesLogic.Add(employeesEntity);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                employeesLogic.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employees employee = employeesLogic.GetOne(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employees employees)
        {
            employeesLogic.Update(employees);
            return RedirectToAction("Index");
        }

    }
}