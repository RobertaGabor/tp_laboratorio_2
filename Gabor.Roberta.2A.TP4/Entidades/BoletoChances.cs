using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    public class BoletoChances/*A TOTAL SCAM*/
    {
        #region atributos
        private int cantidadBoletos;
        #endregion

        #region constructores
        public BoletoChances()
        {
        }
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
        public static explicit operator BoletoChances(int i)
        {
            BoletoChances bx = new BoletoChances();
            bx.cantidadBoletos = i;
            return bx;

        }

        public static int GastoBoleto(int b,int precio)
        {
            return -(precio * b * 5);
        }

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
        public static Jugador operator -(Jugador j, BoletoChances b)
        {
            j.Boletos.cantidadBoletos -= b.cantidadBoletos;
            return j;
        }
        #endregion
    }
}
