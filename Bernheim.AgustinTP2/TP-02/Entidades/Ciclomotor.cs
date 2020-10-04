using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase publica Ciclomotor que hereda de la clase Vehiculo
    /// </summary>
    public class Ciclomotor : Vehiculo
    {

        #region Constructores

        /// <summary>
        /// Constructor parametrizado que llama al constructor de la base 
        /// Para inicializar todos los atributos de la clase
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color)
            :base(chasis,marca,color)
        {
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Las motos son chicas
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Retorna un string con todos los atributos de un Ciclomotor
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
