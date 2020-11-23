using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Entidades
{
    public class Concesionario<T> where T : Vehiculos
    {
        #region Atributos
        protected int capacidad;
        protected List<T> elementos;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto para concesionario
        /// </summary>
        public Concesionario()
        {
            elementos = new List<T>();
        }

        /// <summary>
        /// Constructor parametrizado para concesionario
        /// </summary>
        /// <param name="capacidad">Capacidad del concesionario</param>
        public Concesionario(int capacidad)
            : this()
        {
            this.capacidad = capacidad;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad que retorna la lista de elementos del concesionario
        /// </summary>
        public List<T> Elementos { get { return this.elementos; } }

        /// <summary>
        /// Propiedad que retorna el precio total del concesionario
        /// </summary>
        public double PrecioTotal
        {
            get
            {
                double total = 0;

                foreach(T item in this.elementos)
                {
                    total += item.Precio;
                }

                return total;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Retorna un string con todos los datos de la lista de vehiculos
        /// </summary>
        /// <returns>String con todos los datos de la lista de vehiculos</returns>
        public string MostrarVehiculos()
        {
            StringBuilder sb = new StringBuilder();

            foreach (T item in this.elementos)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();

        }

        /// <summary>
        /// Guarda los datos del concesionario en un archivo de texto
        /// </summary>
        /// <param name="v">Concesionario a ser guardado</param>
        /// <returns>True si pudo guardar, sino false</returns>
        public static bool Guardar(Concesionario<Vehiculos> v)
        {
            Texto aux = new Texto();

            return aux.Guardar(Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + @"\Concesionario.txt", v.MostrarVehiculos());
        }

        /// <summary>
        /// Lee los datos de un concesionario de un archivo de texto
        /// </summary>
        /// <returns>True si pudo leer, sino false</returns>
        public static string Leer()
        {
            string retorno;

            Texto aux = new Texto();

            aux.Leer(Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + @"\Concesionario.txt", out retorno);

            return retorno;
        }

        /// <summary>
        /// Guarda todos los datos del concesionario en un archivo XML
        /// </summary>
        /// <param name="conse">concesionario a ser guardado</param>
        /// <returns>True si pudo guardar, sino false</returns>
        public static bool GuardarXml(Concesionario<T> conse)
        {
            Xml<Concesionario<T>> aux = new Xml<Concesionario<T>>();
            
            return aux.Guardar(Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + @"\Concesionario.xml", conse);
        }

        /// <summary>
        /// Lee los datos de un concesionario desde un archivo XML
        /// </summary>
        /// <returns>True si pudo leer, sino false</returns>
        public static Concesionario<T> LeerXml()
        {
            Xml<Concesionario<T>> aux = new Xml<Concesionario<T>>();

            aux.Leer(Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + @"\Concesionario.xml", out Concesionario<T> consecionario);

            return consecionario;
        }
        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga del operador == para la clase concesionario y un vehiculos
        /// </summary>
        /// <param name="c">Concesionario a ser comparado</param>
        /// <param name="v">Vehiculo a ser comparado</param>
        /// <returns>True si son iguales, sino false</returns>
        public static bool operator ==(Concesionario<T> c, T v)
        {
            bool retorno = false;

            foreach(T item in c.elementos)
            {
                if(item == v)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador == para la clase concesionario y un vehiculos
        /// </summary>
        /// <param name="c">Concesionario a ser comparado</param>
        /// <param name="v">Vehiculo a ser comparado</param>
        /// <returns>False si son iguales, sino true</returns>
        public static bool operator !=(Concesionario<T> c, T v)
        {
            return !(c == v);
        }

        /// <summary>
        /// Sobrecarga del operador + para la clase concesionario y un vehiculos
        /// </summary>
        /// <param name="c">Concesionario a ser usado</param>
        /// <param name="v">Vehiculos a ser agregado</param>
        /// <returns>Concesionario con el vehiculo agregado si pudo</returns>
        public static Concesionario<T> operator +(Concesionario<T> c, T v)
        {
            try
            {
                if (c.elementos.Count < c.capacidad)
                {
                    if(c != v)
                    {
                        c.elementos.Add(v);
                    }
                    else
                    {
                        throw new AutoRepetidoException();
                    }
                   
                }
                else if (c.elementos.Count >= c.capacidad)
                {
                    throw new ConcesionarioLlenoException();
                }
            }
            catch(ConcesionarioLlenoException ex)
            {
                Console.WriteLine(ex.InformarConcesionarioLleno());
            }
            catch(AutoRepetidoException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return c;
        }

        /// <summary>
        /// Sobrecarga del operador - para la clase concesionario y un vehiculos
        /// </summary>
        /// <param name="c">Concesionario a ser usado</param>
        /// <param name="v">Vehiculos a ser eliminado</param>
        /// <returns>Concesionario con el vehiculo eliminado si pudo</returns>
        public static Concesionario<T> operator -(Concesionario<T> c, T v)
        {
            try
            {
                if (c.elementos.Count > 0)
                {
                    if (c == v)
                    {
                        c.elementos.Remove(v);
                    }
                    else
                    {
                        throw new AutoInexistenteException();
                    }
                }
                else
                {
                    throw new ConcesionarioVacioException();
                }
            }
            catch(ConcesionarioVacioException ex)
            {
                Console.WriteLine(ex.InformarConcesionarioVacio());
            }
            catch(AutoInexistenteException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return c;
        }

        /// <summary>
        /// Sobrecarga del metodo ToString para la clase concesionario 
        /// </summary>
        /// <returns>String con todos los datos del concesionario</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Concesionario \n");
            sb.AppendFormat("Capacidad: {0} \n", this.capacidad);
            sb.AppendFormat("Cantidad de vehiculos: {0} \n", this.elementos.Count);
            sb.AppendFormat("Precio total: {0} \n", this.PrecioTotal);
            sb.AppendLine("Lista de elementos: \n");

            sb.Append(this.MostrarVehiculos());

            return sb.ToString();
        }
        #endregion
    }
}
