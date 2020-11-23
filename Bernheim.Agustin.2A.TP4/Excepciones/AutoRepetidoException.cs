using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AutoRepetidoException : Exception
    {
        public AutoRepetidoException()
        : base("El auto ingresado ya está en el concesionario")
        {

        }

        public AutoRepetidoException(string message)
            : base(message)
        {

        }

        public AutoRepetidoException(Exception innerException)
            : base("El auto ingresado ya está en el concesionario", innerException)
        {

        }
    }
}
