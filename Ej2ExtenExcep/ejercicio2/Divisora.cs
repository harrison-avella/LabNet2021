using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio2
{
    public class Divisora
    {
        public int Dividir(int? dividendo, int? divisor)
        {
            int division = 0;
            try
            {
                division = dividendo.Value / divisor.Value;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Ups!! Solo Chuck Norris divide por cero!{Environment.NewLine}La excepcion fue de tipo {ex.GetType().FullName}");
            }
            finally
            {
                Console.WriteLine("Finalizo la divisora");
            }
            return division;
        }
    }
}
