using NUnit.Framework;
using System;

namespace StringCalculatorTests
{
    public class StringCalculatorTests
    {
        [TestFixture]
        public class Cuando_Pasamos_Una_Cadena_Vacia_A_La_Calculadora {
            StringCalculator.IStringCalculator SUT = new StringCalculator.StringCalculator();
            private int resultado;

            [SetUp]
            public void Setup() {
                resultado = SUT.Add("");
            }

            [Test]
            public void Debe_Devolver_Cero() {
                Assert.AreEqual(resultado, 0);   
            }
        }

        [TestFixture]
        public class Cuando_Pasamos_Una_Numero_A_La_Calculadora
        {
            StringCalculator.IStringCalculator SUT = new StringCalculator.StringCalculator();
            private int resultado;

            [SetUp]
            public void Setup()
            {
                resultado = SUT.Add("2");
            }

            [Test]
            public void Debe_Devolver_El_Numero()
            {
                Assert.AreEqual(resultado, 2);
            }
        }

        [TestFixture]
        public class Cuando_Pasamos_Dos_Numeros_O_Mas_A_La_Calculadora_Separados_Por_Comas
        {
            StringCalculator.IStringCalculator SUT = new StringCalculator.StringCalculator();
            private int resultado;

            [SetUp]
            public void Setup()
            {
                resultado = SUT.Add("1,2,3,4,5,6");
            }

            [Test]
            public void Debe_Devolver_La_Suma()
            {
                Assert.AreEqual(resultado, 21);
            }
        }

        [TestFixture]
        public class Cuando_Pasamos_Dos_Numeros_O_Mas_A_La_Calculadora_Separados_Por_Comas_Y_Intros
        {
            StringCalculator.IStringCalculator SUT = new StringCalculator.StringCalculator();
            private int resultado;

            [SetUp]
            public void Setup()
            {
                resultado = SUT.Add("1\n2,3");
            }

            [Test]
            public void Debe_Devolver_La_Suma()
            {
                Assert.AreEqual(resultado, 6);
            }
        }

        [TestFixture]
        public class Cuando_Establecemos_Un_Nuevo_Delimitador_Y_Pasamos_Numeros_Usando_El_Nuevo_Delimitador
        {
            StringCalculator.IStringCalculator SUT = new StringCalculator.StringCalculator();
            private int resultado;
            
            [SetUp]
            public void Setup()
            {
                resultado = SUT.Add("//;\n1,2\n4;5");
            }

            [Test]
            public void Debe_Devolver_La_Suma()
            {
                Assert.AreEqual(resultado, 12);
            }
        }

        [TestFixture]
        public class Cuando_Pasamos_Numeros_Negativos_A_La_Calculadora
        {
            StringCalculator.IStringCalculator SUT = new StringCalculator.StringCalculator();
            
            [Test]
            public void Debe_Devolver_Una_Excepcion()
            {
                var excepcion = Assert.Throws<ArgumentException>(() => SUT.Add("1,-2"));
                Assert.That(excepcion, Has.Message.EqualTo("numeros negativos no permitidos"));
                
            }
        }
    }
}
