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
                if(binario[i]!=1&&binario[i]!=0)
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }
    }
}
