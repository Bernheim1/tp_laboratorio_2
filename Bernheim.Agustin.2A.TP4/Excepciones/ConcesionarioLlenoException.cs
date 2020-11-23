using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ConcesionarioLlenoException : Exception
    {
        public ConcesionarioLlenoException()
        : base("El concesionario está lleno")
        {

        }

        public ConcesionarioLlenoException(string message)
            : base(message)
        {

        }

        public ConcesionarioLlenoException(Exception innerException)
            : base("El concesionario está lleno", innerException)
        {

        }
    }
}
