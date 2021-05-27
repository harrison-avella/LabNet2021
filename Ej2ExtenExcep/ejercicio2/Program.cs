using ejercicio2.Exceptions;
using ejercicio2.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Ingrese dividendo: ");
                int dividendo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Ingrese divisor: ");
                int divisor = Convert.ToInt32(Console.ReadLine());
                if (divisor == 0)
                {
                    Console.WriteLine("Resuelve esta adivinanza antes de dividir por cero");
                    Console.WriteLine("¿Cuantos nueves hay del 1 al 100?");
                    Console.Write("Ingrese divisor: ");
                    int adivinanza = Convert.ToInt32(Console.ReadLine());
                    if (adivinanza != 20)
                    {
                        Logic.ThrowAdivinanzaException(); //Ejer 4
                    }
                    else
                    {
                        Console.WriteLine("Es correcto");
                        dividendo.DividirPor(divisor);// por extension
                    }
                }
                else
                {
                    Divisora divisora = new Divisora();
                    int resultado = divisora.Dividir(dividendo, divisor);
                    Console.WriteLine($"Su resultado fue {resultado}");
                }
            }
            catch (AdivinanzaException ex)
            {
                Console.WriteLine($"{ex.Message}{Environment.NewLine}La excepcion fue de tipo {ex.GetType()}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Seguro ingreso una letra o no ingreso nada! {Environment.NewLine}La excepcion fue de tipo {ex.GetType()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ups!! Algo malio sal.{ Environment.NewLine}La excepcion fue de tipo {ex.GetType().FullName}");
            }
            finally
            {
                Console.WriteLine("Finalizo la ejecucion");
            }
            Console.ReadKey();
        }
    }
}

