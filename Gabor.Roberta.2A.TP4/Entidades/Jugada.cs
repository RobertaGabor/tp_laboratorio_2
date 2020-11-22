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
        /// <summary>
        /// constructor por default
        /// </summary>
        public Jugada(){}
        /// <summary>
        /// constructor al que se le pasa un jugador
        /// </summary>
        /// <param name="j"></param>
        public Jugada(Jugador j)
            :this()
        {
            this.victima = j;
        }
        /// <summary>
        /// constructor al que se le pasan todos los atributos
        /// </summary>
        /// <param name="j"></param>
        /// <param name="varianza"></param>
        /// <param name="transa"></param>
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
        /// <summary>
        /// metodo que calcula la varianza segun el movimiento y lo apostado
        /// </summary>
        /// <param name="m">moneda apostada</param>
        /// <param name="cantidad">cantidad apostada</param>
        /// <param name="win">movimiento</param>
        /// <returns>float de la varianza</returns>
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
        /// <summary>
        /// metodo que muestra la jugada de un usuario
        /// </summary>
        /// <returns></returns>
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
