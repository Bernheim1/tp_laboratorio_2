using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    
    public class Auto : Vehiculos
    {

        #region Constructores
        /// <summary>
        /// Constructor por defecto de la clase Auto
        /// </summary>
        public Auto()
        {

        }

        /// <summary>
        /// Constructor parametrizado de la clase Auto con ID
        /// </summary>
        /// <param name="id">ID del auto</param>
        /// <param name="marca">Marca del auto</param>
        /// <param name="precio">Precio del auto</param>
        /// <param name="patente">Patente del auto</param>
        public Auto(int id, string marca, double precio, string patente)
            :base(id, marca,precio, patente)
        {
        }

        /// <summary>
        /// Constructor parametrizado de la clase Auto
        /// </summary>
        /// <param name="marca">Marca del auto</param>
        /// <param name="precio">Precio del auto</param>
        /// <param name="patente">Patente del auto</param>
        public Auto( string marca, double precio, string patente)
        : base(marca, precio, patente)
        {
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Sobrecarga para clase Auto de la propiedad abstracta de Vehiculos CantAsientos
        /// </summary>
        public override int CantAsientos { get { return 4; } }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del metodo ToString() para la clase Auto
        /// </summary>
        /// <returns>String con todos los datos del Auto</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.VehiculosToString());
            sb.AppendFormat("Cantidad asientos: {0} \n", this.CantAsientos);

            return sb.ToString();
        }
        #endregion
    }
}
