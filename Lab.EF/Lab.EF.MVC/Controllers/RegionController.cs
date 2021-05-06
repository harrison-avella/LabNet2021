using Lab.EF.Entities;
using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.EF.MVC.Controllers
{
    public class RegionController : Controller
    {
        // GET: Region
        public ActionResult Index()
        {
            var regionLogic = new RegionLogic();
            //var regiones = regionLogic.GetAll();
            List<Region> regiones = regionLogic.GetAll();
            return View(regiones);
        }
    }
}