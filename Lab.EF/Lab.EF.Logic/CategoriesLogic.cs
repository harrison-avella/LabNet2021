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
        public List<Categories> GetAll()
        {
            return context.Categories.ToList();
        }
        public Categories GetOne(int id)
        {
            return context.Categories.First(p => p.CategoryID.Equals(id));
        }
        public void Add(Categories newCategory)
        {
            context.Categories.Add(newCategory);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var categoryDelete = context.Categories.Find(id);
            context.Categories.Remove(categoryDelete);
            context.SaveChanges();
        }

        public void Update(Categories category)
        {
            var categoryUpdate = context.Categories.Find(category.CategoryID);

            categoryUpdate.CategoryName = category.CategoryName;
            categoryUpdate.Description = category.Description;

            context.SaveChanges();
        }


    }
}
