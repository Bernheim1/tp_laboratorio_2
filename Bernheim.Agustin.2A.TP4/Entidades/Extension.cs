using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    public static class Extension
    {
        public static string InformarConcesionarioLleno(this ConcesionarioLlenoException ex)
        {
            return "El concesionario está lleno";
        }

        public static string InformarConcesionarioVacio(this ConcesionarioVacioException ex)
        {
            return "El concesionario está vacio";
        }
    }
}
