using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region Metodos

        /// <summary>
        /// Guarda en un archivo de texto datos de cualquier tipo
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Datos a ser guardados</param>
        /// <returns>True si pudo cargar, de lo contrario lanza una excepcion ArchivosException</returns>
        public bool Guardar(string archivo, string datos)
        {
            Encoding codificacion = Encoding.UTF8;
            bool retorno = false;
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo, false, codificacion))
                {
                    sw.WriteLine(datos);

                    retorno = true;

                    return retorno;
                }
            }
            catch (ArchivosException e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Lee datos de un archivo de texto pasado como parametro y los carga en un string
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">String donde cargar los datos</param>
        /// <returns>True si pudo leer, de lo contrario lanza una excepcion ArchivosException</returns>
        public bool Leer(string archivo, out string datos)
        {
            Encoding codificacion = Encoding.UTF8;
            bool retorno = false;
            try
            {
                using (StreamReader sr = new StreamReader(archivo, codificacion))
                {
                    datos = sr.ReadToEnd();

                    retorno = true;

                    return retorno;
                }
            }
            catch (ArchivosException e)
            {
                throw new ArchivosException(e);
            }
        }

        #endregion
    }
}
