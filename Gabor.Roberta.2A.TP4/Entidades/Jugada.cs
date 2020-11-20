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
        public Jugada(Jugador j)
        {
            this.victima = j;
        }

        public ETipoTransaccion Movimiento
        {
            get { return this.movimiento; }
            set { this.movimiento = value; }
        }

        public float Varianza
        {
            get { return this.varianza; }
            set { this.varianza = value; }
        }

        public static float CalcularVarianza(Moneda m,int cantidad,ETipoTransaccion win)
        {
            float rtn = 0;

            switch(win)
            {
                case ETipoTransaccion.compra:
                    rtn = m.Precio* cantidad;
                    break;
                case ETipoTransaccion.gana:
                    rtn = m.ProbabilidadesEnGanancias(cantidad);
                    break;
                case ETipoTransaccion.pierde:
                    rtn = -(m.Precio * cantidad);
                    break;
            }
            return rtn;
        }
        //en la funcion que crear en construct??? veo que poner de win y eso en set y propiedades
    }
}
