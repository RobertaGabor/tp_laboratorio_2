using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugada
    {
        #region atributos
        protected Jugador victima;
        protected float varianza;
        protected ETipoTransaccion movimiento;
        #endregion

        #region constructores
        public Jugada(){}
        public Jugada(Jugador j)
            :this()
        {
            this.victima = j;
        }

        public Jugada(Jugador j, float varianza, ETipoTransaccion transa)
            :this(j)
        {
            this.varianza = varianza;
            this.movimiento = transa;
        }
        #endregion

        #region setter y getter serializacion
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
        #endregion

        #region metodos y sobrecargas
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
        #endregion
    }
}
