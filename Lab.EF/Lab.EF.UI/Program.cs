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

            //Solo capture excepcion para el ejercicio 5 donde era explicito que daba vacio(null), en las demas no caputure para hacer mas legible el codigo

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
                        var query = customersLogic.FirstCustomerByCompanyName("Alfreds Futterkiste");
                        Console.WriteLine($"{query.CompanyName}");
                        break;
                    case 2:
                        var query2 = productsLogic.ProductsOutOfStock();
                        foreach (var item in query2)
                        {
                            Console.WriteLine($"Stock: {item.UnitsInStock} - {item.ProductName} - {item.QuantityPerUnit}");
                        }
                        break;
                    case 3:
                        var query3 = productsLogic.ProductsStockCostMore3();
                        foreach (var item in query3)
                        {
                            Console.WriteLine($"Nombre: {item.ProductName} - Precio: {item.UnitPrice} - Cantidad: {item.UnitsInStock}");
                        }
                        break;
                    case 4:
                        var query4 = customersLogic.CustomersOfWashington();
                        foreach (var item in query4)
                        {
                            Console.WriteLine($"Nombre: {item.CompanyName} - Ciudad: {item.City} - Estado: {item.Region}");
                        }
                        break;
                    case 5:
                        try
                        {
                            var query5 = productsLogic.FirstProductoByID(789);
                            Console.WriteLine($"{query5.ProductName}");
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine($"No existe o paso algo muy malo - {e.Message}");
                        }
                        break;
                    case 6:
                        var query6 = customersLogic.CustomersNameUPPERlower();
                        foreach (var item in query6)
                        {
                            Console.WriteLine($"Mayuscula: {item.NameUpper} - minuscula: {item.NameLower}");
                        }
                        break;
                    case 7:
                        var query7 = joinnerLogic.CustomerJoinOrders();
                        foreach (var item in query7)
                        {
                            Console.WriteLine($"Id: {item.CustomerID} - Estado: {item.Region} - Fecha: {item.OrderDate}");
                        }
                        break;
                    case 8:

                        var query8 = customersLogic.CustomersOfWashingtonFirstThree();
                        foreach (var item in query8)
                        {
                            Console.WriteLine($"Nombre: {item.CompanyName} - Ciudad: {item.City} - Estado: {item.Region}");
                        }
                        break;
                    case 9:
                        var query9 = productsLogic.ProductsOrderByStock();
                        foreach (var item in query9)
                        {
                            Console.WriteLine($"Nombre: {item.ProductName}");
                        }
                        break;
                    case 10:
                        var query10 = productsLogic.ProductsOrderByStock();
                        foreach (var item in query10)
                        {
                            Console.WriteLine($"Nombre: {item.ProductName} - Stock: {item.UnitsInStock}");
                        }
                        break;
                    case 11:
                        var query11 = joinnerLogic.CategoryJoinProduct();
                        foreach (var item in query11)
                        {
                            Console.WriteLine($"Categoria: {item.CategoryName} - Producto: {item.ProductName}");
                        }
                        break;
                    case 12:
                        var query12 = productsLogic.FirstProduct();
                        Console.WriteLine($"{query12.ProductName}");
                        break;
                    case 13:
                        var query13 = joinnerLogic.CustomerCantOrders();
                        foreach (var item in query13)
                        {
                            Console.WriteLine($"Id: {item.CustomerID} - Nombre: {item.ContactName} - Cantidad: {item.CantidadOrdenes}");
                        }
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