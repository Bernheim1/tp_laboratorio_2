using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        /// <summary>
        /// Enumerado de tipo nacionalidad para una Persona
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #region Propiedades

        /// <summary>
        /// Propiedad de lectura y escritura (validada) para el apellido de una Persona
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }
            set { 

                if(ValidarNombreApellido(value) != null)
                {
                    this.apellido = value;
                }

            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para la nacionalidad de una Persona
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura (validada) para el DNI de una Persona
        /// </summary>
        public int DNI
        {
            get { return this.dni; }
            set {

                if(ValidarDni(this.nacionalidad, value) != -1)
                {
                    this.dni = value;
                }
            
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura (validada) para el DNI en formato String de una Persona
        /// </summary>
        public string StringToDNI
        {
            set
            {

                if (ValidarDni(this.nacionalidad, value) == Convert.ToInt32(value))
                {
                    this.dni = Convert.ToInt32(value);
                }

            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura (validada) para el nombre de una Persona
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set {

                if (ValidarNombreApellido(value) != null)
                {
                    this.nombre = value;
                }

            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de Persona
        /// </summary>
        public Persona()
        {
        }

        /// <summary>
        /// Constructor parametrizado de Persona
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">DNI de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Constructor parametrizado de Persona
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">DNI de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.dni = dni;
        }

        /// <summary>
        /// Constructor parametrizado de Persona
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            : this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Valida el DNI de una persona segun su nacionalidad
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">DNI de la persona</param>
        /// <returns>El DNI validado si es correcto, sino lanza una excepcion NacionalidadInvalidaException</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {

            if ((nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999) ||
                nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999)
            {

                return dato;

            }
            else
            {
                throw new NacionalidadInvalidaException("Error. La nacionalidad no coincide con el DNI.");
            }

        }

        /// <summary>
        /// Sobrecarga del metodo ValidarDni, verifica que el DNI este dentro de los rangos y no contenga letras
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">DNI de la persona</param>
        /// <returns>El DNI validado si es correcto, sino lanza una excepcion NacionalidadInvalidaException</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {

            int numeroDni = -1;

            if (dato.Length < 1 || dato.Length > 8 || !int.TryParse(dato, out numeroDni))
            {
                throw new DniInvalidoException("El DNI no coincide con el formato");
            }
            return ValidarDni(nacionalidad, numeroDni);

        }

        /// <summary>
        /// Valida nombre o apellido de una persona
        /// </summary>
        /// <param name="dato">nombre o apellido de la persona</param>
        /// <returns>el nombre o apellido validado si es correcto, sino una cadena vacia</returns>
        private string ValidarNombreApellido(string dato)
        {
            if(dato.Any(char.IsSymbol) || dato.Any(char.IsDigit))
            {
                return "";
            }
            else
            {
                return dato;
            }
        }

        /// <summary>
        /// Sobrecarga del metodos ToString
        /// </summary>
        /// <returns>nombre, apellido y nacionalidad de una persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1} \n", this.Apellido, this.Nombre);
            sb.AppendFormat("NACIONALIDAD: {0} \n", this.Nacionalidad);

            return sb.ToString();
        }

        #endregion
    }
}
