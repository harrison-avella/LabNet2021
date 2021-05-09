using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class CategoriesLogic : BaseLogic, IABMLogic<Categories, int>
    {
        public void Add(Categories newCategory)
        {
            try
            {
                context.Categories.Add(newCategory);
                context.SaveChanges();
            }
            catch (Exception ex) { throw ex; }
        }

        public void Delete(int id)
        {
            try
            {
                var categoryDelete = context.Categories.Find(id);
                context.Categories.Remove(categoryDelete);
                context.SaveChanges();
            }
            catch (Exception ex) { throw ex; }
        }
        public List<Categories> GetAll()
        {
            try
            {
                return context.Categories.ToList();
            }
            catch (Exception ex) { throw ex; }

        }

        public Categories GetOne(int id)
        {
            try
            {
                return context.Categories.First(p => p.CategoryID == id);
            }
            catch (Exception ex) { throw ex; }
        }

        public void Update(Categories category)
        {
            try
            {
                var categoryUpdate = context.Categories.Find(category.CategoryID);

                categoryUpdate.CategoryName = category.CategoryName;
                categoryUpdate.Description = category.Description;
                categoryUpdate.Picture = category.Picture;

                context.SaveChanges();
            }
            catch (Exception ex) { throw ex; }
        }
    }
}

