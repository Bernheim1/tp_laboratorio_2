using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida que el operador pasado por parametro
        /// </summary>
        /// <param name="operador"> Parametro char a ser validado </param>
        /// <returns> Operador validado tipo string 
        /// <returns> Operador "+" si se pasa un parametro no valido </returns>
        private static string ValidarOperador(char operador)
        {
            if (operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                return operador.ToString();
            }
            else
            {
                return "+";
            }
        }

        /// <summary>
        /// Valida y realiza la operacion a realizar por la clase Calculadora
        /// </summary>
        /// <param name="num1"> Parametro Numero 1 </param>
        /// <param name="num2"> Parametro Numero 2 </param>
        /// <param name="operador"> Parametro string con el operador a ser utilizado </param>
        /// <returns> Resultado double de la operacion o 0 si el parametro operador es un espacio vacio </returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;

            if (operador != "")
            {
                operador = ValidarOperador(Convert.ToChar(operador));

                switch (operador)
                {
                    case "+":
                        retorno = num1 + num2;
                        break;
                    case "-":
                        retorno = num1 - num2;
                        break;
                    case "/":
                        retorno = num1 / num2;
                        break;
                    case "*":
                        retorno = num1 * num2;
                        break;
                }

            }
            return retorno;
        }

    }
}
