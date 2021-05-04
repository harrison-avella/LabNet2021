using Lab.EF.Data;
using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class ProductsLogic : BaseLogic, IABMLogic<Products, int>
    {
        public List<Products> ProductsOutOfStock()
        {
            return context.Products.Where(p => p.UnitsInStock == 0).ToList();
        }

        public List<Products> ProductsStockCostMore3()
        {
            return context.Products.Where(p => p.UnitsInStock > 0).Where(p => p.UnitPrice > 3).ToList();
        }

        public Products FirstProductoByID(int id)
        {
            var query = from pro in context.Products
                        where pro.ProductID == id
                        select pro;
            return query.First();
        }


        #region
        public List<Products> GetAll()
        {
            return context.Products.ToList();
        }

        public Products GetOne(int id)
        {
            return context.Products.First(p => p.ProductID.Equals(id));
        }

        public void Add(Products newProduct)
        {
            context.Products.Add(newProduct);
            context.SaveChanges();
        }

        public void Delete(int id)
        {

            var productDelete = context.Products.Find(id);

            if (productDelete == null) throw new Exception("No se pudo eliminar producto");

            context.Products.Remove(productDelete);
            context.SaveChanges();


        }

        public void Update(Products product)
        {

            var productUpdate = context.Products.Find(product.ProductID);

            if (productUpdate == null) throw new Exception("No se pudo actualizar producto");

            productUpdate.ProductName = product.ProductName;
            productUpdate.SupplierID = product.SupplierID;
            productUpdate.CategoryID = product.CategoryID;
            productUpdate.QuantityPerUnit = product.QuantityPerUnit;
            productUpdate.UnitPrice = product.UnitPrice;
            productUpdate.UnitsInStock = product.UnitsInStock;
            productUpdate.UnitsOnOrder = product.UnitsOnOrder;
            productUpdate.ReorderLevel = product.ReorderLevel;
            productUpdate.Discontinued = product.Discontinued;

            context.SaveChanges();

        }
        #endregion
    }
}