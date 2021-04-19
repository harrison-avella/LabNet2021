using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio2.Extensions
{
    public static class IntegerExtensions
    {
        public static int DividirPor(this int numero, int divisor)
        {
            int division = 0;
            try
            {
                division = numero / divisor;

            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Ups!! Solo Chuck Norris divide por cero!{Environment.NewLine}La excepcion fue de tipo {ex.GetType().FullName}");
            }
            finally
            {
                Console.WriteLine("Finalizo el metodo por extension");
            }
            return division;
        }
    }
}
