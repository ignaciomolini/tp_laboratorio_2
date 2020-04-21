using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        private static string ValidarOperador(string operador)
        {
            string retorno = "+";

            switch (operador)
            {
                case "-":
                    retorno = "-";
                    break;

                case "*":
                    retorno = "*";
                    break;

                case "/":
                    retorno = "/";
                    break;
            }

            return retorno;
        }

        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;
            string auxOperador = ValidarOperador(operador);

            switch (auxOperador)
            {
                case "+":
                    retorno = num1 + num2;
                    break;

                case "-":
                    retorno = num1 - num2;
                    break;

                case "*":
                    retorno = num1 * num2;
                    break;

                case "/":
                    retorno = num1 / num2;
                    break;
            }

            return retorno;
        }
    }
}
