using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugador
    {
        protected int dni;
        protected float saldo;
        protected List<Moneda> billetera;

        //agrego ahi las primeras monedas compradas 


        public Jugador(int dni,List<Moneda>m)
        {
            this.DNI = dni;
            this.billetera = m;
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = Jugador.ValidarDni(value);
            }
        }

        public float Saldo
        {
            get { return this.saldo; }
        }

        public List<Moneda> Billetera
        {
            get { return this.billetera; }
        }
        private static int ValidarDni(int dato)
        {
                    if (dato < 1 || dato > 89999999)
                        throw new dniInvalidoException(dato.ToString());//hacer try en algun lado y catch

            return dato;
        }




    }
}
