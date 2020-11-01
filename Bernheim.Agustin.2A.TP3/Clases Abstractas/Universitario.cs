using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region Constructores

        /// <summary>
        /// Sobrecarga parametrizada del constructor de la clase Universitario
        /// </summary>
        /// <param name="legajo">Legajo del Universitario</param>
        /// <param name="nombre">Nombre del Universitario</param>
        /// <param name="apellido">Apellido del Universitario</param>
        /// <param name="dni">DNI del Universitario</param>
        /// <param name="nacionalidad">Nacionalidad del Universitario</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// Constructor por defecto de la clase Universitario que instancia los datos con valores por defecto
        /// </summary>
        public Universitario()
        {
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo virtual y protegido que retorna los datos del Universitario
        /// </summary>
        /// <returns>String con los datos del Universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendFormat("LEGAJO NUMERO: {0} \n", this.legajo);

            return sb.ToString();
        }

        /// <summary>
        /// Firma del metodo abstracto que muestra la clase que toma o da un Universitario
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Verifica si el legajo o el dni de un Universitario son iguales
        /// </summary>
        /// <param name="pg1">Universitario a ser comparado</param>
        /// <param name="pg2">Universitario a ser comparado</param>
        /// <returns>True si legajo o DNI son iguales, caso contrario false</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if(pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verifica si el legajo o el dni de un Universitario son distintos
        /// </summary>
        /// <param name="pg1">Universitario a ser comparado</param>
        /// <param name="pg2">Universitario a ser comparado</param>
        /// <returns>False si legajo o DNI son iguales, caso contrario true</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Sobrecarga del metodo Equals para la clase Universitario
        /// </summary>
        /// <param name="obj">Objeto a ser comparado</param>
        /// <returns>True si ambos son del mismo tipo, caso contrario false</returns>
        public override bool Equals(object obj)
        {
            bool rta = false;

            if (obj is Universitario)
            {
                rta = this == (Universitario)obj;
            }

            return rta;
        }

        #endregion
    }
}
