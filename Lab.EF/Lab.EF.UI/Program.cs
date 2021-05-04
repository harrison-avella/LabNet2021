using Lab.EF.Data;
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
            var customersLogic = new CustomersLogic();
            var productsLogic = new ProductsLogic();
            var joinnerLogic = new JoinnerLogic();
            int opcion = -1;
            do
            {
                Console.Clear(); ;
                Console.WriteLine("Ejercicio LINQ");
                Console.WriteLine("Precione el numero de ejercicio para hacer la respectiva consulta");
                Console.WriteLine("1. Query para devolver objeto customer");
                Console.WriteLine("2. Query para devolver todos los productos sin stock");
                Console.WriteLine("3. Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad");
                Console.WriteLine("4. Query para devolver todos los customers de Washington");
                Console.WriteLine("5. Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789");
                Console.WriteLine("6. Query para devolver los nombres de los Customers. Mostrarlos en Mayuscula y en Minuscula.");
                Console.WriteLine("7. Query para devolver Join entre Customers y Orders donde los customers sean de Washington y la fecha de orden sea mayor a 1/1/1997.");
                Console.WriteLine("8. Query para devolver los primeros 3 Customers de Washington");
                Console.WriteLine("9. Query para devolver lista de productos ordenados por nombre");
                Console.WriteLine("10.Query para devolver lista de productos ordenados por unit in stock de mayor a menor.");
                Console.WriteLine("11.Query para devolver las distintas categorías asociadas a los productos");
                Console.WriteLine("12.Query para devolver el primer elemento de una lista de productos");
                Console.WriteLine("13.Query para devolver los customer con la cantidad de ordenes asociadas");
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
                        try
                        {
                            var query = customersLogic.FirstCustomerByCompanyName("Alfreds Futterkiste");
                            Console.WriteLine($"{query.CompanyName}");
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine($"Error - {e.Message}");
                        }
                        Console.ReadLine();
                        break;
                    case 2:
                        try
                        {
                            var query = productsLogic.ProductsOutOfStock();
                            foreach (var item in query)
                            {
                                Console.WriteLine($"Stock: {item.UnitsInStock} - {item.ProductName} - {item.QuantityPerUnit}");
                            }
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine($"Error - {e.Message}");
                        }
                        Console.ReadLine();
                        break;
                    case 3:
                        try
                        {
                            var query = productsLogic.ProductsStockCostMore3();
                            foreach (var item in query)
                            {
                                Console.WriteLine($"Nombre: {item.ProductName} - Precio: {item.UnitPrice} - Cantidad: {item.UnitsInStock}");
                            }
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine($"Error - {e.Message}");
                        }
                        Console.ReadLine();
                        break;
                    case 4:
                        try
                        {
                            var query = customersLogic.CustomersOfWashington();
                            foreach (var item in query)
                            {
                                Console.WriteLine($"Nombre: {item.CompanyName} - Ciudad: {item.City} - Estado: {item.Region}");
                            }
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine($"Error - {e.Message}");
                        }
                        Console.ReadLine();
                        break;
                    case 5:
                        try
                        {
                            var query = productsLogic.FirstProductoByID(789);
                            Console.WriteLine($"{query.ProductName}");
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine($"No existe o paso algo muy malo - {e.Message}");
                        }
                        Console.ReadLine();
                        break;
                    case 6:
                        try
                        {
                            var query = customersLogic.CustomersNameUPPERlower();
                            foreach (var item in query)
                            {
                                Console.WriteLine($"Mayuscula: {item.NameUpper} - minuscula: {item.NameLower}");
                            }
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine($"Error - {e.Message}");
                        }
                        Console.ReadLine();
                        break;
                    case 7:
                        try
                        {
                            var query = joinnerLogic.CustomerJoinOrders();
                            foreach (var item in query)
                            {
                                Console.WriteLine($"Id: {item.CustomerID} - Estado: {item.Region} - Fecha: {item.OrderDate}");
                            }
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine($"Error - {e.Message}");
                        }
                        Console.ReadLine();
                        break;

                    case 8:
                        try
                        {
                            var query = customersLogic.CustomersOfWashingtonFirstThree();
                            foreach (var item in query)
                            {
                                Console.WriteLine($"Nombre: {item.CompanyName} - Ciudad: {item.City} - Estado: {item.Region}");
                            }
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine($"Error - {e.Message}");
                        }
                        Console.ReadLine();
                        break;

                    case 9:



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