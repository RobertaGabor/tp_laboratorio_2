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

        public Jugador Victima
        {
            get { return this.victima; }
            set { this.victima = value; }
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
                    rtn = m.Precio*m.Cantidad*m.Ganancia;
                    break;
                case ETipoTransaccion.pierde:
                    rtn = -(m.Precio * cantidad);
                    break;
            }
            return rtn;
        }

        private string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.victima.DNI}, {this.victima.Saldo}, {this.varianza}, {this.movimiento.ToString()}");
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }
        //en la funcion que crear en construct??? veo que poner de win y eso en set y propiedades
    }
}
