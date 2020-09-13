using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Valida y setea el atributo numero de la clase Numero
        /// </summary>
        public string SetNumero
        {
            set
            {

                double auxNum;

                auxNum = ValidarNumero(value);

                if (auxNum != 0)
                {
                    numero = auxNum;
                }
            }
        }

        #region Constructores

        /// <summary>
        /// Constructor de la clase Numero sin parametros, inicializa el atributo numero en 0
        /// </summary>
        public Numero()
        {
            this.SetNumero = "0";
        }

        /// <summary>
        /// Constructor de la clase Numero con paramatro double
        /// </summary>
        /// <param name="numero"> Parametro a ser asignado al atributo numero de la clase</param>
        public Numero(double numero)
        {
            this.SetNumero = numero.ToString();
        }

        /// <summary>
        /// Constructor de la clase Numero con parametro string
        /// </summary>
        /// <param name="strNumero"> Parametro a ser asignado al atributo numero de la clase </param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Valida si el parametro string es un numero
        /// </summary>
        /// <param name="strNumero"> Parametro string a ser validado </param>
        /// <returns> Numero validado 
        /// <returns> 0 si no es un numero </returns>
        private double ValidarNumero(string strNumero)
        {
            double auxNum;
            bool aux = double.TryParse(strNumero, out auxNum);

            if (aux)
            {
                return auxNum;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Valida si un numero es binario comprabando que este compuesto de unos y ceros
        /// </summary>
        /// <param name="binario"> Parametro string a ser validado </param>
        /// <returns> True si es binario
        /// <returns> False si no es binario </returns>
        private bool EsBinario(string binario)
        {
            bool retorno = false;

            foreach (var caracter in binario)
            {
                if (caracter == '0' || caracter == '1')
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                    return retorno;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Transforma un numero binario a decimal
        /// </summary>
        /// <param name="binario"> Parametro string a ser transformado a decimal</param>
        /// <returns> Numero transformado a decimal
        /// <returns> Valor Invalido no es posible transformarlo </returns>
        public string BinarioDecimal(string binario)
        {
            bool isBinario;

            isBinario = EsBinario(binario);

            if (isBinario)
            {
                char[] array = binario.ToCharArray();

                Array.Reverse(array);

                int sum = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == '1')
                    {
                        if (i == 0)
                        {
                            sum += 1;
                        }
                        else
                        {
                            sum += (int)Math.Pow(2, i);
                        }
                    }

                }

                return Convert.ToString(sum);
            }
            else
            {
                return "Valor Invalido";
            }

        }



        /// <summary>
        /// Transforma un numero decimal a binario
        /// </summary>
        /// <param name="numero"> Numero a ser validado y transformado en binario </param>
        /// <returns> Numero transformado a binario 
        /// <returns> 0 si no se puede convertir a binario 
        /// <returns> Valor Invalido si no es un numero </returns>
        public string DecimalBinario(double numero)
        {
            int auxNum;
            bool isNumero;


            isNumero = int.TryParse(numero.ToString(), out auxNum);


            if (isNumero)
            {
                if (auxNum < 0)
                {
                    auxNum = auxNum * -1;
                }
                    int aux = 0;
                    string auxString = "";
                    string retorno = "";

                    while (auxNum > 0)
                    {
                        aux = auxNum % 2;
                        auxString = Convert.ToString(aux);
                        retorno = auxString + retorno;
                        auxNum = auxNum / 2;
                    }

                    return retorno;
            }
            else
            {
                return "Valor Invalido";
            }

        }

        /// <summary>
        /// Transforma un numero decimal a binario a travez del metodo DecimalBinario
        /// </summary>
        /// <param name="numero"> Parametro string a ser transformado </param>
        /// <returns> Numero transformado por el metodo DecimalBinario(double numero)
        /// <returns> "Valor invalido" Si no es un numero </returns>
        public string DecimalBinario(string numero)
        {
            double auxNum;
            string auxString;
            bool isNumero;

            isNumero = double.TryParse(numero, out auxNum);

            if (isNumero)
            {
                auxString = DecimalBinario(auxNum);

                return auxString;
            }
            else
            {
                return "Valor Invalido";
            }


        }

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Sobrecarga del operador "-" para la clase Numero
        /// </summary>
        /// <param name="n1"> Parametro Numero 1 </param>
        /// <param name="n2"> Parametro Numero 2 </param>
        /// <returns> La resta del atributo numero de la clase Numero </returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador "*" para la clase Numero
        /// </summary>
        /// <param name="n1"> Parametro Numero 1 </param>
        /// <param name="n2"> Parametro numero 2 </param>
        /// <returns> La multiplicacion del atributo numero de la clase Numero </returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador "+" para la clase Numero
        /// </summary>
        /// <param name="n1"> Parametro numero 1 </param>
        /// <param name="n2"> Parametro numero 2 </param>
        /// <returns> La suma del atributo numero de la clase Numero</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador "/" para la clase Numero
        /// </summary>
        /// <param name="n1"> Parametro numero 1 </param>
        /// <param name="n2"> Parametro numero 2 </param>
        /// <returns> Division del atributo numero de la clase Numero
        /// <returns> Double.MinValue si el divisor es 0</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            else
            {
                return double.MinValue;
            }
        }

        #endregion


    }
}
