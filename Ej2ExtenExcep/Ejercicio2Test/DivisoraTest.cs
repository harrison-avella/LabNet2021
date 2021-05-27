using ejercicio2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Ejercicio2Test
{
    [TestClass()]
    public class DivisoraTest
    {
        [TestMethod()]
        public void DividirTest()
        {
            //arrange
            int dividendo = 100;
            int divisor = 2;
            var divisora = new Divisora();

            //act
            int resultado = divisora.Dividir(dividendo, divisor);

            //assert
            Assert.AreEqual(resultado, 50);
        }
    }
}
