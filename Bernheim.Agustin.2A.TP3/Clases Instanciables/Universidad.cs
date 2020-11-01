using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        /// <summary>
        /// Enumerado de tipo Clase para la Universidad
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        #region Propiedades

        /// <summary>
        /// Propiedad de lectura y escritura para la lista de Alumno
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para la lista de Jornada
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para la lista de Profesor
        /// </summary>
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        /// <summary>
        /// Propiedad del indexador de Jornada
        /// </summary>
        /// <param name="i">Indice</param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this.Jornadas.Count)
                {
                    return this.jornada[i];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if(i >= 0 && i < this.Jornadas.Count)
                {
                    this.jornada[i] = value;
                }
                else if(i == this.Jornadas.Count)
                {
                    this.Jornadas.Add(value);
                }
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de Universidad
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>(); 
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Retorna todos los datos de una Universidad
        /// </summary>
        /// <param name="uni">Universidad para devolver los datos</param>
        /// <returns>String con los datos de una Universidad</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");

            foreach (Jornada item in uni.Jornadas)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Guarda los datos de la Universidad en un archivo Xml llamado "Universidad.xml"
        /// </summary>
        /// <param name="uni">Universidad a ser guardada</param>
        /// <returns>True si logro guardar, caso contrario una excepcion ArchivosException</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> aux = new Xml<Universidad>();

            return aux.Guardar("Universidad.xml", uni);
        }

        /// <summary>
        /// Lee los datos del archivo Xml "Universidad.xml"
        /// </summary>
        /// <returns>String con los datos de la Universidad</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> aux = new Xml<Universidad>();

            aux.Leer("Universidad.xml", out Universidad universidad);

            return universidad;
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Verifica si un alumno esta inscripto en una universidad
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>True si pertenece a la universidad, de lo contrario false</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach(Alumno item in g.alumnos)
            {
                if(item.Equals(a))
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Verifica si un alumno esta inscripto en una universidad
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>False si pertenece a la universidad, de lo contrario true</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Verifica si un profesor esta dando clases en una universidad
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="i">Alumno a comparar</param>
        /// <returns>True si esta dando clases en la universidad, caso contrario false</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            foreach(Profesor item in g.profesores)
            {
                if (item.Equals(i))
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Verifica si un profesor esta dando clases en una universidad
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="i">Alumno a comparar</param>
        /// <returns>False si esta dando clases en la universidad, caso contrario true</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Busca al primer Profesor de la Universidad capaz de dar la EClase pasada como parametro
        /// </summary>
        /// <param name="u">Universidad a comparar</param>
        /// <param name="clase">EClase pasada como parametro</param>
        /// <returns>Profesor capaz de dar la clase, sino lanza una excepcion SinProfesorException</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            bool flag = false;
            Profesor aux = null;

            foreach (Profesor item in u.profesores)
            {
                if(item == clase)
                {
                    aux = item;
                    flag = true;
                    break;
                }
            }

            if (!flag)
            {
                throw new SinProfesorException();
            }

            return aux;
        }

        /// <summary>
        /// Verifica si un profesor no esta dando clases en una universidad
        /// </summary>
        /// <param name="u">Universidad a comparar</param>
        /// <param name="clase">EClase pasada como parametro</param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor aux = null;

            foreach (Profesor item in u.profesores)
            {
                if (item != clase)
                {
                    aux = item;
                    break;
                }
            }

            return aux;
        }

        /// <summary>
        /// Agrega un Alumno si no pertenece a la Universidad
        /// </summary>
        /// <param name="u">Universidad a ser comparada</param>
        /// <param name="a">Alumno a ser comparado</param>
        /// <returns>Universidad con el alumno agregado, caso contrario lanza una excepcion AlumnoRepetidoException</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u != a)
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return u;
        }

        /// <summary>
        /// Agrega un Profesor si no pertenece a la Universidad
        /// </summary>
        /// <param name="u">Universidad a ser comparada</param>
        /// <param name="i">Profesor a ser comparado</param>
        /// <returns>Universidad con el Profesor agregado</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesores.Add(i);
            }

            return u;
        }

        /// <summary>
        /// Agrega a la Universidad una nueva Jornada con la clase pasada como parametro, un profesor que pueda
        /// dar dicha clase y la lista de Alumnos que la toman
        /// </summary>
        /// <param name="g">Universidad a ser comparada</param>
        /// <param name="clase">Clase a ser comparada</param>
        /// <returns>Universidad con la jornada agregada a la Lista de Jornada</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada aux = new Jornada(clase, g == clase);

            foreach (Alumno item in g.Alumnos)
            {
                if (item == clase)
                {
                    aux += item;
                }
            }
            if (aux.Alumnos.Count > 0)
            {
                g.Jornadas.Add(aux);
            }

            return g;
        }

        /// <summary>
        /// Retorna todos los datos de una Universidad
        /// </summary>
        /// <returns>String con todos los datos de una Universidad</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        #endregion
    }
}
