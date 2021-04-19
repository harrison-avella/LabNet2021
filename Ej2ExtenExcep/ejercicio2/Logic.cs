using ejercicio2.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio2
{
    public class Logic
    {
        public static void ThrowAdivinanzaException()
        {
            throw new AdivinanzaException("No coloco la respuesta correcta, se rompio todo.");
        }

        public static void ThrowExcepcion()
        {
            throw new System.Exception();
        }
    }
}
