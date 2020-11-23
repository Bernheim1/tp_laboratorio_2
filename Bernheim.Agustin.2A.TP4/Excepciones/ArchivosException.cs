using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException()
            : base("Error de archivos")
        {

        }

        public ArchivosException(string message)
            : base(message)
        {

        }

        public ArchivosException(Exception innerException)
            : base("Error de archivos", innerException)
        {

        }
    }
}

