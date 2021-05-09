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
        public List<Products> GetAll()
        {
            try
            {
                return context.Products.ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public Products GetOne(int id)
        {
            try
            {

                return context.Products.First(p => p.ProductID.Equals(id));
            }
            catch (Exception ex) { throw ex; }
        }

        public void Add(Products newProduct)
        {
            try
            {

                context.Products.Add(newProduct);
                context.SaveChanges();
            }
            catch (Exception ex) { throw ex; }
        }

        public void Delete(int id)
        {
            try
            {

                var productDelete = context.Products.Find(id);

                context.Products.Remove(productDelete);
                context.SaveChanges();

            }
            catch (Exception ex) { throw ex; }

        }

        public void Update(Products product)
        {
            try
            {
                var productUpdate = context.Products.Find(product.ProductID);

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
            catch (Exception ex) { throw ex; }

        }
    }
}