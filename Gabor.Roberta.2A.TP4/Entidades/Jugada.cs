using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugada
    {
        /*atributos*/ /*hacer propiedades para serializar*/
        protected Jugador victima;
        protected float varianza;
        protected ETipoTransaccion movimiento;

        public Jugada(){}

        public ETipoTransaccion Movimiento
        {
            get { return this.movimiento; }
            set { this.movimiento = value; }
        }

        public float Varianza
        {
            get { return this.varianza; }
            set { //hago el calculo
            }
        }

        private static float CalcularVarianza(Jugador j, int cantidadApostada, ETipoMoneda monedaApostada,bool win)
        {
            float rtn = j.Saldo;

            switch(win)
            {
                case true:
                    //sumo al saldo
                    break;
                case false:
                    //resto al saldo
                    break;
            }


            return rtn;
        }

    }
}
