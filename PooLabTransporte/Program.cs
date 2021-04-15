using System;
using System.Collections.Generic;

namespace PooLabTransporte
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Transporte> transportes = new List<Transporte>
            {
                new Avion(100),
                new Avion(30),
                new Avion(20),
                new Avion(400),
                new Avion(50),
                new Automovil(1),
                new Automovil(3),
                new Automovil(4),
                new Automovil(5),
                new Automovil(2),
            };
            foreach (var item in transportes)
            {
                item.Avanzar();
                item.Detenerse();
                Console.WriteLine("");
            }
            Console.ReadLine();

        }
    }
}
