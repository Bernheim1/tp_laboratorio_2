using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    
    public class Suv : Vehiculos
    {
        #region Constructores
        /// <summary>
        /// Constructor por defecto de la clase Suv
        /// </summary>
        public Suv()
        {

        }

        /// <summary>
        /// Constructor parametrizado de la clase Suv con ID
        /// </summary>
        /// <param name="id">ID del Suv</param>
        /// <param name="marca">Marca del Suv</param>
        /// <param name="precio">Precio del Suv</param>
        /// <param name="patente">Patente del Suv</param>
        public Suv(int id, string marca, double precio, string patente)
            : base(id,marca, precio, patente)
        {
        }

        /// <summary>
        /// Constructor parametrizado de la clase Suv
        /// </summary>
        /// <param name="marca">Marca del Suv</param>
        /// <param name="precio">Precio del Suv</param>
        /// <param name="patente">Patente del Suv</param>
        public Suv(string marca, double precio, string patente)
        : base(marca, precio, patente)
        {
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Sobrecarga para clase Suv de la propiedad abstracta de Vehiculos CantAsientos
        /// </summary>
        public override int CantAsientos { get { return 5; } }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del metodo ToString() para la clase Suv
        /// </summary>
        /// <returns>String con todos los datos del Suv</returns>
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
