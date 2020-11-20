using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class BoletoChances/*A TOTAL SCAM*/
    {
        private int cantidadBoletos;

        public BoletoChances()
        {
            this.cantidadBoletos = 0;
        }
        public BoletoChances(int cantidad)
        {
            this.cantidadBoletos = cantidad;
        }
        public int Cantidad
        {
            get { return this.cantidadBoletos; }
        }


        public static explicit operator BoletoChances(int i)///ver
        {
            BoletoChances bx = new BoletoChances();
            bx.cantidadBoletos = i;
            return bx;

        }

        public static int GastoBoleto(int b)
        {
            return -(b * 5);
        }

        public static Jugador operator +(Jugador j, BoletoChances b)
        {
            int cantidadRecuperada=0;

            foreach(Moneda item in j.Billetera)
            {
                if(item.Moneyda == ETipoMoneda.bronce&&item.Cantidad>b.Cantidad*5)
                {
                    cantidadRecuperada = item.Cantidad;
                    cantidadRecuperada -= b.Cantidad * 5;
                    j.Boletos.cantidadBoletos += b.Cantidad;
                    item.Cantidad = cantidadRecuperada;     
                }
                else
                {
                    throw new insuficienteParaBoletoException();
                }
            }
            return j;
            //debe tener mas de 5 bronce
        }
    }
}
