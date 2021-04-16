using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioTransporte
{
    public class Automovil : Transporte
    {
        public Automovil(int pasajeros) : base(pasajeros)
        {
        }

        public override void Avanzar()
        {
            Console.WriteLine($"Automovil: Avanza con {Pasajeros} pasajeros.");
        }

        public override void Detenerse()
        {
            Console.WriteLine($"Automovil: Se detiene con {Pasajeros} pasajeros.");
        }
    }
}
