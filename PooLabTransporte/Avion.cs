﻿using System;

namespace PooLabTransporte
{
    public class Avion : Transporte
    {
        public Avion(int pasajeros) : base(pasajeros)
        {
        }

        public override void Avanzar()
        {
            Console.WriteLine(string.Format("Avion: Avanza con {0} pasajeros", Pasajeros));
        }

        public override void Detenerse()
        {
            Console.WriteLine(string.Format("Avion: Se detiene con {0} pasajeros", Pasajeros));
        }

    }
}
