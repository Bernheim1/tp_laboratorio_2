using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #region Constructores

        /// <summary>
        /// Constructor statico de Profesor que inicializa el random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor por defecto de Profesor
        /// </summary>
        public Profesor()
            :this(default, default, default, default, default)
        {
        }

        /// <summary>
        /// Sobrecarga parametrizada del cosntructor que instancia todos los atributos
        /// </summary>
        /// <param name="id">ID del Profesor</param>
        /// <param name="nombre">Nombre del Profesor</param>
        /// <param name="apellido">Apellido del Profesor</param>
        /// <param name="dni">DNI del Profesor</param>
        /// <param name="nacionalidad">Nacionalidad del Profesor</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Genera y asigna de manera random dos clases para el Profesor
        /// </summary>
        private void _randomClases()
        {
            for(int i = 0; i < 2; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
            }
        }

        /// <summary>
        /// Retorna los datos del profesor
        /// </summary>
        /// <returns>String con los datos del Profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Override del metodo de Universitario, retorna las clases que da el Profesor
        /// </summary>
        /// <returns>String con las clases que da el Profesor</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("CLASES DEL DIA: ");
            foreach (Universidad.EClases aux in this.clasesDelDia)
            {
                sb.AppendFormat("{0} \n", aux);
            }

            sb.AppendLine();
            return sb.ToString();
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Retorna los datos del Profesor
        /// </summary>
        /// <returns>String con los datos del Profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Verifica si el Profesor pasado por parametro da una clase
        /// </summary>
        /// <param name="i">Profesor a ser comparado</param>
        /// <param name="clase">EClase a ser comparada</param>
        /// <returns>True si el Profesor da la clase, caso contrario false</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            foreach(Universidad.EClases item in i.clasesDelDia)
            {
                if(item == clase)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Verifica si el Profesor pasado por parametro da una clase
        /// </summary>
        /// <param name="i">Profesor a ser comparado</param>
        /// <param name="clase">EClase a ser comparada</param>
        /// <returns>False si el Profesor da la clase, caso contrario true</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
