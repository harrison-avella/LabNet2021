using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio2.Exceptions
{
    public class AdivinanzaException : Exception
    {
        public AdivinanzaException(string mensaje) : base(mensaje)
        {

        }
    }
}
