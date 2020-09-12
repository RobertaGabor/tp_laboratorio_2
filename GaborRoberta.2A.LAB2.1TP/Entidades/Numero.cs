using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region atributos
        private double numero;
        #endregion

        #region contructores y sobrecargas
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
        #endregion

        #region setter
        public string SetNumero
        {
            set 
            {
                this.numero = this.ValidarNumero(value);
            }
        }
        #endregion

        #region sobrecarga de operadores
        public static Double operator +(Numero num1,Numero num2)
        {
            return num1.numero + num2.numero;
        }

        public static Double operator -(Numero num1, Numero num2)
        {
            return num1.numero - num2.numero;
        }
        public static Double operator *(Numero num1, Numero num2)
        {
            return num1.numero * num2.numero;
        }
        public static Double operator /(Numero num1, Numero num2)
        {
            if(num2.numero!=0)
            {
                return num1.numero/num2.numero;
            }
            return double.MinValue;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Valida que una cadena solo tenga numeros
        /// </summary>
        /// <param name="strNumero">string a analizar</param>
        /// <returns>si el try parse es true devuelve el numero double, sino 0</returns>
        private double ValidarNumero(string strNumero)
        {
            double retorno;
            if(Double.TryParse(strNumero,out retorno))
            {
                return retorno;
            }
            return 0;
        }
        /// <summary>
        /// Verifica que un numero sea binario
        /// </summary>
        /// <param name="binario">binario a analizar</param>
        /// <returns>devuelve true si solo contiene 1 y 0, sino false</returns>
        private bool EsBinario(string binario)
        {
            bool retorno = true;
            for(int i=0;i<binario.Length;i++)
            {
                if(binario[i]!='1'&&binario[i]!='0')
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Convierte un numero binario en decimal, si no es binario devuelve "Valor invalido"
        /// </summary>
        /// <param name="binario">binario resultante de las operaciones</param>
        /// <returns>string del numero decimal o cadena de error</returns>
        public string BinarioDecimal(string binario)
        {
            string retorno = "Valor inválido";

            if (this.EsBinario(binario)&&!String.IsNullOrEmpty(binario))
            {
                Double parteEntera = 0;
                string parteEnteraString;
                Double potenciado;
                Int32 contadorIndiceInverso = binario.Length-1;

                for (int s = 0; s < binario.Length; s++)
                {
                    if (binario[s] == '0')
                    {
                        parteEntera += 0;
                    }
                    else if (binario[s] == '1')
                    {
                        potenciado = Math.Pow(2, contadorIndiceInverso);
                        parteEntera += potenciado;
                    }
                    contadorIndiceInverso--;
                }

                parteEnteraString = Convert.ToString(parteEntera);
                return parteEnteraString;

            }

            return retorno;
        }

        /// <summary>
        /// Convierte a binario numeros del 0 al 89999, mas de eso sobrepasa el tamaño de la calculadora
        /// Si no se pudo devuelve "Valor invalido"
        /// </summary>
        /// <param name="numero">valor resultante de las operaciones</param>
        /// <returns>String del binario o la cadena de error </returns>
        public string DecimalBinario(double numero)
        {
            string retorno = "Valor inválido";
            numero = Math.Round(numero);
            string stringBinario="";

            Int32 lenghtEnteroBinario;
            string enteroBinarioAlReves = "";

            if(numero>0&&numero<=89999)
            {
                while(numero!=0)
                {
                    if (numero % 2 == 0)
                    {
                        numero = numero / 2;
                        stringBinario += "0";
                    }
                    else
                    {
                        numero = (numero - 1) / 2;
                        stringBinario += "1";
                    }
                }


                lenghtEnteroBinario = stringBinario.Length;

                for (int b = lenghtEnteroBinario - 1; b >= 0; b--)
                {
                    enteroBinarioAlReves += stringBinario[b];
                }
                
               return enteroBinarioAlReves;
            }
            else if(numero==0)
            {
                return "0";
            }

            return retorno;
  
        }
        #endregion
    }
}
