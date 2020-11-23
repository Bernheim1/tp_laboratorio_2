using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace VehiculosTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creo nuevo Concesionario
            Concesionario<Vehiculos> conce = new Concesionario<Vehiculos>(10);

            //Creo nuevos Vehiculos
            Auto a1 = new Auto(1, "Peugeot", 240000.30, "AB123CS");
            Auto a2 = new Auto(2, "Volkswagen", 539222.22, "AF532GD");

            Suv s1 = new Suv(3, "Jeep", 632994.15, "AB928MS");
            Suv s2 = new Suv(4, "Chevrolet", 958322.99, "AC999IS");

            Moto m1 = new Moto(5, "Suzuki", 998432, "FN883MS");
            Moto m2 = new Moto(6, "Kawasaki", 882888, "AJ821OS");

            //Agrego los Vehiculos al Concesionario
            conce += a1;
            conce += a2;

            conce += s1;
            conce += s2;

            conce += m1;
            conce += m2;

            //Intento agregar repetidos
            conce += a1;
            conce += s1;
            conce += m1;

            //Muestro por consola
            Console.WriteLine(conce.ToString());

            Console.ReadLine();

            //Elimino 3 Vehiculos del Concesionario
            conce -= a1;
            conce -= s1;
            conce -= m1;

            Console.Clear();

            //Muestro por consola
            Console.WriteLine(conce.ToString());

            Console.ReadLine();

            Console.Clear();

            //Me fijo si el Vehiculo esta en el Concesionario
            if (conce == a1)
            {
                Console.WriteLine("Está en el concesionario");
            }
            else
            {
                Console.WriteLine("No está en el concesionario");
            }

            //Me fijo si el Vehiculo no esta en el Concesionario
            if (conce != a2)
            {
                Console.WriteLine("No está en el concesionario");
            }
            else
            {
                Console.WriteLine("Está en el concesionario");
            }

            //Guardo el Concecionario en un archivo XML en el escritorio
            if (Concesionario<Vehiculos>.Guardar(conce))
            {
                Console.WriteLine("Concesionario serializado");
            }
            else
            {
                Console.WriteLine("No se pudo serializar el concesionario");
            }
            Console.ReadLine();

            Console.Clear();

            //Leo el Concesionario desde el archivo XML
            conce = Concesionario<Vehiculos>.LeerXml();

            //Muestro por consola
            Console.WriteLine(conce.ToString());

            Console.ReadLine();
        }
    }
}
