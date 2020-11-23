using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Archivos;

namespace Entidades
{
    [XmlInclude(typeof(Vehiculos))]
    [XmlInclude(typeof(Auto))]
    [XmlInclude(typeof(Moto))]
    [XmlInclude(typeof(Suv))]
    public abstract class Vehiculos
    {
        #region Atributos
        private int id;
        private string marca;
        private double precio;
        private string patente;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de la clase Vehiculos
        /// </summary>
        public Vehiculos()
        {

        }

        /// <summary>
        /// Constructor con parametro ID para la clase Vehiculos
        /// </summary>
        /// <param name="id">Id del Vehiculo</param>
        /// <param name="marca">Marca del Vehiculo</param>
        /// <param name="precio">Precio del Vehiculo</param>
        /// <param name="patente">Patente del Vehiculo</param>
        public Vehiculos(int id, string marca, double precio, string patente)
        {
            this.id = id;
            this.marca = marca;
            this.precio = precio;
            this.patente = patente;
        }

        /// <summary>
        /// Constructor parametrizado para la clase Vehiculos
        /// </summary>
        /// <param name="marca">Marca del Vehiculo</param>
        /// <param name="precio">Precio del Vehiculo</param>
        /// <param name="patente">Patente del Vehiculo</param>
        public Vehiculos(string marca, double precio, string patente)
        {
            this.marca = marca;
            this.precio = precio;
            this.patente = patente;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Firma para la propiedad abstracta CantAsientos
        /// </summary>
        public abstract int CantAsientos { get; }

        /// <summary>
        /// Propiedad de lectura y escritura para el campo id
        /// </summary>
        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para el campo marca
        /// </summary>
        public string Marca
        {
            get { return this.marca; }
            set { this.marca = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para el campo precio
        /// </summary>
        public double Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para el campo patente
        /// </summary>
        public string Patente
        {
            get { return this.patente; }
            set { this.patente = value; }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que retorna toda la informacion del vehiculo
        /// </summary>
        /// <returns>String con todos los datos del vehiculo</returns>
        protected virtual string VehiculosToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Marca: {0} \n", this.marca);
            sb.AppendFormat("Precio: {0} \n", this.precio);
            sb.AppendFormat("Patente: {0} \n", this.patente);

            return sb.ToString();
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del metodo ToString() para la clase Vehiculo
        /// </summary>
        /// <returns>String con todos los datos del vehiculo</returns>
        public override string ToString()
        {
            return this.VehiculosToString();
        }

        /// <summary>
        /// Sobrecarga del operador == para la clase Vehiculo, que compara por marca y patente
        /// </summary>
        /// <param name="v1">Primer vehiculo a ser comparado</param>
        /// <param name="v2">Segundo vehiculo a ser comparado</param>
        /// <returns>True si son iguales, sino false</returns>
        public static bool operator ==(Vehiculos v1, Vehiculos v2)
        {
            bool retorno = false;

            if(v1.marca == v2.marca && v1.patente == v2.patente)
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador != para la clase Vehiculo, que compara por marca y patente
        /// </summary>
        /// <param name="v1">Primer vehiculo a ser comparado</param>
        /// <param name="v2">Segundo vehiculo a ser comparado</param>
        /// <returns>False si son iguales, sino true</returns>
        public static bool operator !=(Vehiculos v1, Vehiculos v2)
        {
            return !(v1 == v2);
        }
        #endregion

    }
}
