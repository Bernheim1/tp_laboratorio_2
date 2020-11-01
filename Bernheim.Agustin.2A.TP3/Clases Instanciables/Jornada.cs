using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Archivos;


namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region Propiedades

        /// <summary>
        /// Propiedad de lectura y escritura para la lista de Alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para la clase de la Jornada
        /// </summary>
        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para el Profesor
        /// </summary>
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto para la clase Jornada que instancia la lista de Alumnos
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Sobrecarga parametrizada del constructor de la clase Jornada que instancia los atributos 
        /// pasados por parametros y llama al constructor por defecto para instanciar la lista de Alumno
        /// </summary>
        /// <param name="clase">Clase de la Jornada</param>
        /// <param name="instructor">Profesor de la Jornada</param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Guarda los datos de la Jornada en un archivo de Texto llamado "Jornada.txt"
        /// </summary>
        /// <param name="jornada">Jornada a ser guardada</param>
        /// <returns>True si logro guardar los datos, caso contrario una excepcion ArchivosException</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto aux = new Texto();

            return aux.Guardar("Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Lee los datos del archivo de Texto "Jornada.txt"
        /// </summary>
        /// <returns>String con los datos de la Jornada</returns>
        public static string Leer()
        {
            string retorno;

            Texto aux = new Texto();

            aux.Leer("Jornada.txt", out retorno);

            return retorno;

        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Valida si el Alumno se encuentra en la clase de la Jornada
        /// </summary>
        /// <param name="j">Jornada a ser comparada</param>
        /// <param name="a">Alumno a ser comparado</param>
        /// <returns>True si el Alumno pertenece a la clase de Jornada, caso contrario false</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return (a == j.Clase);
        }

        /// <summary>
        /// Valida si el Alumno se encuentra en la clase de la Jornada
        /// </summary>
        /// <param name="j">Jornada a ser comparada</param>
        /// <param name="a">Alumno a ser comparado</param>
        /// <returns>False si el Alumno pertenece a la clase de Jornada, caso contrario true</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega alumnos a la lista de Alumno de la Jornada validando que no esten previamente cargados
        /// </summary>
        /// <param name="j">Jornada a la que agregar el Alumno</param>
        /// <param name="a">Alumno a ser agregado a la lista</param>
        /// <returns>Jornada con el Alumno agregado si no pertenecia a la lista previamente</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j == a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }

        /// <summary>
        /// Sobrecarga del metodo ToString
        /// </summary>
        /// <returns>String con todos los datos de la Jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASE DE " + this.Clase + " POR " + this.Instructor.ToString());
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno alumno in this.Alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }
            sb.AppendLine("<------------------------------------------------>");

            return sb.ToString();
        }

        #endregion
    }
}
