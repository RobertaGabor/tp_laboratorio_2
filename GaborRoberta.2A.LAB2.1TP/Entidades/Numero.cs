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
        /*ACOMODAR POR REGIONES*/ /*no olvidar la documentacion*/
        private double numero;

        /*constructor y sobrecargas*/
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

        /*setter*/
        private Double valorIngresado;

        public string SetNumero
        {
            set 
            {
                valorIngresado = this.ValidarNumero(value);
            }
        }



        /*metodos*/
        private double ValidarNumero(string strNumero)
        {
            double retorno;
            if(Double.TryParse(strNumero,out retorno))
            {
                return retorno;
            }
            return 0;
        }

        private bool EsBinario(string binario)
        {
            bool retorno = true;
            for(int i=0;i<binario.Length;i++)
            {
                if(binario[i]!='1'&&binario[i]!='0')/*los numeros hay que leerlos como char*/
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }


        public string BinarioDecimal(string binario)
        {
            string retorno = "Valor inválido";

            if (this.EsBinario(binario))
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
    }
}
