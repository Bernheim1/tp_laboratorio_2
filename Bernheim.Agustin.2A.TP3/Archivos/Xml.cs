using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        #region Metodos

        /// <summary>
        /// Serializa en un archivo con extension .xml cualquier tipo de dato
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Datos a ser guardados</param>
        /// <returns>True si pudo cargar, de lo contrario lanza una excepcion ArchivosException</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;

            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, System.Text.Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));

                    ser.Serialize(writer, datos);

                    retorno = true;

                    return retorno;
                }
            }
            catch(ArchivosException e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Deserializa de un archivo con extension .xml cualquier tipo de dato
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Datos deserializados</param>
        /// <returns>True si pudo leer, de lo contrario lanza una excepcion ArchivosException</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;

            try
            {
                using(XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));

                    datos = (T)ser.Deserialize(reader);

                    retorno = true;

                    return retorno;
                }
            }
            catch(ArchivosException e)
            {
                throw new ArchivosException(e);
            }
        }

        #endregion
    }
}
