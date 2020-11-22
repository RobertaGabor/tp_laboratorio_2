using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    public class BoletoChances/*A TOTAL SCAM no hace nada mas que robarte plata como la vida misma*/
    {
        #region atributos
        private int cantidadBoletos;
        #endregion

        #region constructores
        /// <summary>
        /// construct default
        /// </summary>
        public BoletoChances()
        {
        }
        /// <summary>
        /// constructor al que le paso la cantidad
        /// </summary>
        /// <param name="cantidad"></param>
        public BoletoChances(int cantidad)
        {
            this.cantidadBoletos = cantidad;
        }
        #endregion

        #region setter y getter serializacion
        public int Cantidad
        {
            get { return this.cantidadBoletos; }
            set { this.cantidadBoletos = value; }
        }
        #endregion

        #region metodos y sobrecargas
        /// <summary>
        /// genera un nuevo boleto por casteo
        /// </summary>
        /// <param name="i"></param>
        public static explicit operator BoletoChances(int i)
        {
            BoletoChances bx = new BoletoChances();
            bx.cantidadBoletos = i;
            return bx;

        }
        /// <summary>
        /// devuelve cuanto se gastó la compra d eboletos
        /// </summary>
        /// <param name="b">cantidad de boletos</param>
        /// <param name="precio">precio de moenda de bronce</param>
        /// <returns>devuelve cuanto se gastó</returns>
        public static int GastoBoleto(int b,int precio)
        {
            return -(precio * b * 5);
        }
        /// <summary>
        /// agrega boletos a un jugador solo si este tiene la cantidad de monedas de bronce suficientes para comprar
        /// </summary>
        /// <param name="j">jugador</param>
        /// <param name="b">boletos a comprar</param>
        /// <returns>Jugador, sino lanza una excepcion</returns>
        public static Jugador operator +(Jugador j, BoletoChances b)
        {
            int cantidadRecuperada=0;
            bool hay = false;

            foreach(Moneda item in j.Billetera)
            {
                if(item.Moneyda == ETipoMoneda.bronce&&item.Cantidad>=b.Cantidad*5)
                {
                    cantidadRecuperada = item.Cantidad;
                    cantidadRecuperada -= b.Cantidad * 5;
                    j.Boletos.cantidadBoletos += b.Cantidad;
                    item.Cantidad = cantidadRecuperada;
                    hay = true;
                    break;
                }
                
            }
            if(!hay)
            {
                throw new insuficienteParaBoletoException();
            }
            return j;
        }
        /// <summary>
        /// resta cantidad de boletos a un jugador
        /// </summary>
        /// <param name="j"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Jugador operator -(Jugador j, BoletoChances b)
        {
            j.Boletos.cantidadBoletos -= b.cantidadBoletos;
            return j;
        }
        #endregion
    }
}
