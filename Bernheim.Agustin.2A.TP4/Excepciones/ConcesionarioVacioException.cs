using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ConcesionarioVacioException : Exception
    {
        public ConcesionarioVacioException()
        : base("El concesionario está vacio")
        {

        }

        public ConcesionarioVacioException(string message)
            : base(message)
        {

        }

        public ConcesionarioVacioException(Exception innerException)
            : base("El concesionario está vacio", innerException)
        {

        }
    }
}
