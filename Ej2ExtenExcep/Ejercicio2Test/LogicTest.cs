using ejercicio2;
using ejercicio2.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Ejercicio2Test
{
    [TestClass()]
    public class LogicTest
    {
        [TestMethod()]
        [ExpectedException(typeof(AdivinanzaException))]
        public void AdivinanzaExceptionTests()
        {
            //act
            Logic.ThrowAdivinanzaException();
            // assert is handled by the AdivinanzaEsception
        }


        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void LogicExceptionTest()
        {

            //act 
            Logic.ThrowExcepcion();
            // assert is handled by the excepcion
        }
    }
}
