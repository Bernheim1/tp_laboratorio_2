using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using EntidadesAbstractas;
using Clases_Instanciables;
using Excepciones;

namespace TestUnitariosTP3
{
    [TestClass]
    public class Test
    {
        ///<summary>
        /// Verifica el correcto funcionamiento de la excepcion AlumnoRepetidoException
        /// </summary>
        [TestMethod]
        public void Verificar_AlumnoRepetidoException()
        {
            try
            {
                Universidad u = new Universidad();

                Alumno a1 = new Alumno(1, "Carlos", "Ballester", "90000000", Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD);
                Alumno a2 = new Alumno(2, "Carlos", "Ballester", "90000000", Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD);

                u += a1;
                u += a2;

            }
            catch (AlumnoRepetidoException e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }

        }

        ///<summary>
        /// Verifica el correcto funcionamiento de la excepcion NacionalidadInvalidaException
        /// </summary>
        [TestMethod]
        public void Verificar_NacionalidadInvalidaException()
        {
            try
            {

                Alumno a1 = new Alumno(1, "Pedro", "Bustos", "63450852", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);

            }
            catch (NacionalidadInvalidaException e)
            {

                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }

        }

        ///<summary>
        /// Verifica el correcto funcionamiento de la excepcion DniInvalidoException
        /// </summary>
        [TestMethod]
        public void Verificar_DniInvalidoException()
        {

            try
            {
                Alumno a1 = new Alumno(1, "Fernando", "Perez", "a", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            }
            catch (DniInvalidoException e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

        }

        ///<summary>
        /// Verifica que las listas de Universidad se hayan instanciado
        /// </summary>
        [TestMethod]
        public void Verificar_Instancia_Lista()
        {
            Universidad uni = new Universidad();

            Assert.IsNotNull(uni.Instructores);
            Assert.IsNotNull(uni.Alumnos);
            Assert.IsNotNull(uni.Jornadas);
        }

    }
}
