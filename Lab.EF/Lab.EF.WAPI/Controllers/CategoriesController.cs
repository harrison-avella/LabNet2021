using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Lab.EF.Data;
using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.WAPI.Models;

namespace Lab.EF.WAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class CategoriesController : ApiController
    {
        CategoriesLogic categoriesLogic = new CategoriesLogic();

        // GET: api/Categories
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                IEnumerable<Categories> categories = categoriesLogic.GetAll();
                IEnumerable<CategoriesView> categoriesView = categories.Select(c => new CategoriesView
                {
                    CategoryID = c.CategoryID,
                    CategoryName = c.CategoryName,
                    Description = c.Description,
                }).ToList();
                return Ok(categoriesView);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, "No hay nadie?");
            }
        }

        // GET: api/Categories/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Categories c = categoriesLogic.GetOne(id);
                CategoriesView categoriesView = new CategoriesView
                {
                    CategoryID = c.CategoryID,
                    CategoryName = c.CategoryName,
                    Description = c.Description,
                };
                return Ok(categoriesView);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, "No hay nadie?");
            }
        }

        // POST api/Categories
        [HttpPost]
        public IHttpActionResult Add(CategoriesView c)
        {
            try
            {
                categoriesLogic.Add(new Categories
                {
                    CategoryID = c.CategoryID,
                    CategoryName = c.CategoryName,
                    Description = c.Description,
                });
                return Ok();
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, "No se pudo agregar lo sentimos");
            }

        }

        // POST api/Categories/5
        [HttpPost]
        public IHttpActionResult Post(int id, CategoriesView c)
        {
            try
            {
                Categories category = categoriesLogic.GetOne(id);
                category.CategoryID = c.CategoryID;
                category.CategoryName = c.CategoryName;
                category.Description = c.Description;
                categoriesLogic.Update(category);
                return Ok();
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, "No se pudo actualizar, el problema no eres tu soy yo...");
            }

        }

        // DELETE api/Categories/5
        public IHttpActionResult Delete(int id)
        {

            try
            {
                categoriesLogic.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, "Algo malo paso no se pudo borrar");
            }

        }
    }
}