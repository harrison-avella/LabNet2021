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

            int opcion = -1;
            do
            {
                Console.Clear(); ;
                Console.WriteLine("Ejercicio Entity");
                Console.WriteLine("Precione un numero");
                Console.WriteLine("1. Mostrar consumidores, nombre de compañia y pais");
                Console.WriteLine("2. Agregue un consumidor ;)");
                Console.WriteLine("3. Agrega un producto e imprime la lista");
                Console.WriteLine("4. Actualiza un producto y lo imprime");
                Console.WriteLine("5. Borrar producto y ver cambios");
                Console.WriteLine("0.Salir");
                Console.WriteLine(" ");
                Console.WriteLine("Seleccione Opción:");

                try
                {
                    opcion = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Ingresaste mal la opcion - {e.Message}");
                }

                switch (opcion)
                {
                    case 1:
                        //Mostrar consumidores, nombre de compañia y pais
                        foreach (var customer in customersLogic.GetAll())
                        {
                            Console.WriteLine($"{customer.CompanyName} - {customer.Country}");
                        }
                        break;
                    case 2:
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
                            Console.WriteLine($"No se pudo agregar el consumidor {e.Message}");
                        }
                        Console.ReadLine();
                        break;
                    case 3:
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
                        break;
                    case 4:
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
                            Console.WriteLine($"{aProduct.ProductID} - {aProduct.ProductName} - {aProduct.UnitPrice}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);

                        }
                        break;
                    case 5:
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
                        break;
                    case 0:
                        Console.WriteLine("Finalizando, gracias.");
                        break;
                    default:
                        Console.WriteLine("No es una opcion valida");
                        break;
                }
                Console.ReadKey();
            } while (opcion != 0);
        }

    }
}
