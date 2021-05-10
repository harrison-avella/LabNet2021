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
    public class CategoriesController : Controller
    {
        CategoriesLogic categoriesLogic = new CategoriesLogic();

        public ActionResult Index()
        {
            List<Categories> categories = categoriesLogic.GetAll();
            List<CategoriesView> categoriesViews = categories.Select(c => new CategoriesView
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,
                Description = c.Description

            }).ToList();
            return View(categoriesViews);
        }


        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(CategoriesView categoriesView)
        {
            try
            {
                Categories categoriesEntity = new Categories
                {
                    CategoryName = categoriesView.CategoryName,
                    Description = categoriesView.Description
                };
                categoriesLogic.Add(categoriesEntity);
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
                categoriesLogic.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }

        }
    }
}