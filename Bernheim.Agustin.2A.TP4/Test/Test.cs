using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Entidades;

namespace Test
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void Verificar_AutoRepetidoException()
        {
            try
            {
                Concesionario<Vehiculos> u = new Concesionario<Vehiculos>();

                Auto a1 = new Auto(1, "Peugeot", 240000.30, "AB123CS");
                Auto a2 = new Auto(1, "Peugeot", 240000.30, "AB123CS");

                u += a1;
                u += a2;

            }
            catch (AutoRepetidoException e)
            {
                Assert.IsInstanceOfType(e, typeof(AutoRepetidoException));
            }

        }

        [TestMethod]
        public void Verificar_AutoInexistenteException()
        {
            try
            {
                Concesionario<Vehiculos> u = new Concesionario<Vehiculos>();

                Auto a1 = new Auto(1, "Peugeot", 240000.30, "AB123CS");
                Auto a2 = new Auto(2, "Volkswagen", 240000.30, "AC294MS");

                u += a1;

                u -= a2;
            }
            catch(AutoInexistenteException e)
            {
                Assert.IsInstanceOfType(e, typeof(AutoInexistenteException));
            }

        }

        [TestMethod]
        public void Verificar_ConcesionarioLlenoException()
        {
            try
            {
                Concesionario<Vehiculos> u = new Concesionario<Vehiculos>(1);

                Auto a1 = new Auto(1, "Peugeot", 240000.30, "AB123CS");
                Auto a2 = new Auto(2, "Volkswagen", 240000.30, "AC294MS");


                u += a1;
                u += a2;

            }
            catch (ConcesionarioLlenoException e)
            {
                Assert.IsInstanceOfType(e, typeof(ConcesionarioLlenoException));
            }
        }

    }
}
