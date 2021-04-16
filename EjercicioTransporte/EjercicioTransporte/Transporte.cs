using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioTransporte
{
    public abstract class Transporte
    {
        private int pasajeros;

        public Transporte(int pasajeros)
        {
            this.pasajeros = pasajeros;
        }

        public int Pasajeros
        {
            get
            {
                return this.pasajeros;
            }
        }

        public abstract void Avanzar();
        public abstract void Detenerse();

    }
}
