using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    
    public class Moto : Vehiculos
    {
        #region Constructores
        /// <summary>
        /// Constructor por defecto de la clase Moto
        /// </summary>
        public Moto()
        {

        }

        /// <summary>
        /// Constructor parametrizado de la clase Moto con ID
        /// </summary>
        /// <param name="id">ID de la Moto</param>
        /// <param name="marca">Marca de la Moto</param>
        /// <param name="precio">Precio de la Moto</param>
        /// <param name="patente">Patente de la Moto</param>
        public Moto(int id, string marca, double precio, string patente)
            :base(id, marca, precio, patente)
        {
        }


        /// <summary>
        /// Constructor parametrizado de la clase Moto
        /// </summary>
        /// <param name="marca">Marca de la Moto</param>
        /// <param name="precio">Precio de la Moto</param>
        /// <param name="patente">Patente de la Moto</param>
        public Moto(string marca, double precio, string patente)
        : base(marca, precio, patente)
        {
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Sobrecarga para clase Moto de la propiedad abstracta de Vehiculos CantAsientos
        /// </summary>
        public override int CantAsientos { get { return 1; } }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del metodo ToString() para la clase Suv
        /// </summary>
        /// <returns>String con todos los datos de la Moto</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.VehiculosToString());
            sb.AppendFormat("Cantidad de asientos: {0} \n", this.CantAsientos);

            return sb.ToString();
        }
        #endregion
    }
}
