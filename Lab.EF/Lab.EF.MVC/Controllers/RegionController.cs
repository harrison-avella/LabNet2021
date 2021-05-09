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
    public class RegionController : Controller
    {
        RegionLogic regionLogic = new RegionLogic();
        // GET: Region
        public ActionResult Index()
        {
            //var regiones = regionLogic.GetAll();
            List<Region> regiones = regionLogic.GetAll();
            List<RegionView> regionViews = regiones.Select(s => new RegionView
            {
                Id = s.RegionID,
                Description = s.RegionDescription,
            }).ToList();
            return View(regionViews);
        }

        public ActionResult Insert()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Insert(RegionView regionView)
        {
            try
            {
                Region regionEntity = new Region
                {
                    RegionID = regionLogic.IdMax() + 1,
                    RegionDescription = regionView.Description
                };
                regionLogic.Add(regionEntity); //arreglar lo del id autoincremental
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Delete(int id)
        {
            regionLogic.Delete(id);
            return RedirectToAction("Index");
        }

    }
}