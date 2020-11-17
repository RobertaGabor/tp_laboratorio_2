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

        public int Cantidad
        {
            get { return this.cantidadBoletos; }
        }
        public static int operator +(Jugador j,BoletoChances b)
        {
            return j.Boletos.cantidadBoletos += 1;
        }
        public static explicit operator BoletoChances(int i)
        {
            BoletoChances bx = new BoletoChances();
            bx.cantidadBoletos = i;
            return bx;


        }
    }
}
