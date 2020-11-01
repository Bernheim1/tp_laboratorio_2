using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        /// <summary>
        /// Enumerado de tipo Estado Cuenta para un Alumno
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        #region Constructores

        /// <summary>
        /// Constructor por defecto para la clase Alumno que instancia los datos con valores por defecto
        /// </summary>
        public Alumno()
            :base()
        {

        }

        /// <summary>
        /// Sobrecarga parametrizada del constructor de la clase Alumno
        /// </summary>
        /// <param name="id">ID del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">DNI del alumno</param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clase que toma el alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Sobrecarga parametrizada del constructor de la clase Alumno
        /// </summary>
        /// <param name="id">ID del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">DNI del alumno</param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clase que toma el alumno</param>
        /// <param name="estadoCuenta">Estado de la cuenta del alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            :this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }


        #endregion

        #region Metodos

        /// <summary>
        /// Retona los datos del Alumno
        /// </summary>
        /// <returns>String con los datos del Alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            if (this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                sb.AppendLine("ESTADO DE CUENTA: Cuota al dia");
            }
            else
            {
                sb.AppendLine("ESTADO DE CUENTA: " + this.estadoCuenta);
            }
            sb.Append(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Override del metodo de Universitario, retorna la clase que toma el Alumno
        /// </summary>
        /// <returns>String con la clase que toma el Alumno</returns>
        protected override string ParticiparEnClase()
        {
            return ("TOMA CLASE DE: " + this.claseQueToma);
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga del metodo ToString
        /// </summary>
        /// <returns>String con todos los datos del Alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Valida si un Alumno toma una Clase y su estado de cuenta
        /// </summary>
        /// <param name="a">Alumno a ser comparado</param>
        /// <param name="clase">Clase a ser comparada</param>
        /// <returns>True si el alumno pertenece a la clase y su estado de cuenta no es deudor, caso contrario false</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Valida si un Alumno toma una Clase 
        /// </summary>
        /// <param name="a">Alumno a ser comparado</param>
        /// <param name="clase">Clase a ser comparada</param>
        /// <returns>True si el alumno pertenece a la clase, caso contrario false</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if(a.claseQueToma != clase)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

    }
}
