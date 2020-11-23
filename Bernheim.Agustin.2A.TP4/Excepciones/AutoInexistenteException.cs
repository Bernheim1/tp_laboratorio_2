using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AutoInexistenteException : Exception
    {
        public AutoInexistenteException()
        : base("El auto no se encuentra en el concesionario")
        {

        }

        public AutoInexistenteException(string message)
            : base(message)
        {

        }

        public AutoInexistenteException(Exception innerException)
            : base("El auto no se encuentra en el concesionario", innerException)
        {

        }
    }
}
