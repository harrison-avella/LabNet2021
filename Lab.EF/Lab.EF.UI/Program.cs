using Lab.EF.Entities;
using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.UI
{
    class Program
    {
        static void Main(string[] args)
        {

            ProductsLogic productsLogic = new ProductsLogic();
            CustomersLogic customersLogic = new CustomersLogic();

            //Mostrar consumidores, nombre de compañia y pais
            foreach (var customer in customersLogic.GetAll())
            {
                Console.WriteLine($"{customer.CompanyName} - {customer.Country}");
            }

            Console.ReadLine();



            //Agregar Consumidor
            try
            {
                customersLogic.Add(new Customers
                {
                    CustomerID = "CHARRO",
                    CompanyName = "La Manzana",
                    Country = "Mexico"
                });

            }

            catch (DbEntityValidationException e)
            {
                Console.WriteLine("No se pudo agregar el consumidor");
            }
            Console.ReadLine();


            //Agregar producto
            productsLogic.Add(new Products
            {
                ProductName = "Zapasho",
                UnitPrice = 200
            });

            foreach (var product in productsLogic.GetAll())
            {
                Console.WriteLine($"{product.ProductName} - {product.UnitPrice}");
            }
            Console.ReadLine();

            //Actualizar producto
            try
            {
                productsLogic.Update(new Products
                {
                    ProductID = 10,
                    ProductName = "Carne",
                    UnitPrice = 2500
                });
                var aProduct = productsLogic.GetOne(10);
                Console.WriteLine($"{aProduct.ProductName} - {aProduct.UnitPrice}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            Console.ReadLine();

            //Borrar producto
            try
            {
                productsLogic.Delete(82);
                foreach (var product in productsLogic.GetAll())
                {
                    Console.WriteLine($"{product.ProductID} - {product.ProductName} - {product.UnitPrice}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadLine();
        }

    }
}
