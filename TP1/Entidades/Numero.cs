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

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        private double ValidarNumero(string strNumero)
        {
            double retorno = 0;

            if (double.TryParse(strNumero, out retorno))
            {
                return retorno;
            }
            else
            {
                return 0;
            }
        }

        public static string BinarioDecimal(string binario)
        {
            string resultadoRetorno = "0";
            int resultado = 0;
            int j = 0;

            for (int i = binario.Length - 1; i >= 0; i--)
            {
                if (binario[i] == '0' || binario[i] == '1')
                {
                    resultado += (int)(int.Parse(binario[i].ToString()) * Math.Pow(2, j));
                }
                else
                {
                    resultadoRetorno = "Valor invalido!";
                    break;
                }
                j++;
            }

            if (resultadoRetorno == "0")
            {
                resultadoRetorno = resultado.ToString();
            }

            return resultadoRetorno;
        }

        public static string DecimalBinario(string strDecimal)
        {
            string resultado = "";
            Numero numeroDecimal = new Numero(strDecimal);
            int auxNumeroDecimal = (int)Math.Abs(numeroDecimal.numero);

            while (auxNumeroDecimal > 0)
            {
                if (auxNumeroDecimal % 2 == 0)
                {
                    resultado = "0" + resultado;
                }
                else
                {
                    resultado = "1" + resultado;
                }

                auxNumeroDecimal = (auxNumeroDecimal / 2);
            }

            if (resultado == "")
            {
                resultado = "0";
            }

            return resultado;
        }

        public static string DecimalBinario(double numeroDecimal)
        {
            return DecimalBinario(numeroDecimal.ToString());
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }
    }
}
