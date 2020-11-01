using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException()
            :base("Formato del DNI invalido")
        {

        }

        public DniInvalidoException(Exception ex)
            :base("Formato del DNI invalido", ex)
        {

        }

        public DniInvalidoException(string message)
            :base(message)
        {

        }

        public DniInvalidoException(string message, Exception ex)
            :base(message,ex)
        {

        }
    }
}
