using Lab.EF.Data;
using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class ProductsLogic : BaseLogic
    {
        public IEnumerable<Products> ProductsOutOfStock()
        {
            return context.Products.Where(p => p.UnitsInStock == 0).ToList();
        }

        public IEnumerable<Products> ProductsStockCostMore3()
        {
            return context.Products.Where(p => p.UnitsInStock > 0).Where(p => p.UnitPrice > 3).ToList();
        }

        public Products FirstProductoByID(int id)
        {
            return (from pro in context.Products
                    where pro.ProductID == id
                    select pro)
                    .First();
        }

        public IEnumerable<Products> ProductsOrderByStock()
        {
            return context.Products.OrderByDescending(p => p.UnitsInStock);
        }

        public IEnumerable<Products> ProductsOrderByName()
        {
            return context.Products.OrderBy(p => p.ProductName);
        }

        public Products FirstProduct()
        {
            return (from pro in context.Products
                    select pro)
                    .First();
        }
    }
}