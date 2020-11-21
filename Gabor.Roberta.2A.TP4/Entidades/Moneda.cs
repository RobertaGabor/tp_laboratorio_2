using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moneda
    {
        protected ETipoMoneda moneda;
        protected int precio;
        protected int cantidad;
        protected int ganancia;

        public int Cantidad
        {
            get { return this.cantidad; }
            set { this.cantidad = ValidarCantidad(value); }
        }
        public int Precio
        {
            get { return this.precio; }
        }
        public ETipoMoneda Moneyda
        {
            get { return this.moneda; }
        }
        public int Ganancia
        {
            get { return this.ganancia; }
        }
        public Moneda(int precio,int canti,ETipoMoneda tipo,int ganancia)
        {
            this.precio = precio;
            this.cantidad = canti;
            this.moneda = tipo;
            this.ganancia = ganancia;
        }
        public Moneda(ETipoMoneda tipo,int cant)//eliminar
        {
            this.cantidad = cant;
            this.moneda = tipo;
        }

        public static Moneda operator +(Moneda m,int numero)
        {
            m.cantidad += numero;
            return m;

        }
        public static Moneda operator -(Moneda m, int numero)
        {
            m.cantidad -= numero;
            return m;

        }

        public static float SacarSaldo(Moneda e)//si gana gana la ganancia en monedas y eso se traduce en el saldo, si pierde pierde la cantidad apostada nada mas
        {
            return e.cantidad * e.precio;
        }

        public static bool operator ==(Moneda m,Moneda mm)
        {
            if(m.moneda==mm.moneda)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Moneda m, Moneda mm)
        {
            return !(m == mm);
        }

        public static List<Moneda> operator +(List<Moneda> l, Moneda m)
        {
            List<Moneda> aux = new List<Moneda>();
            aux = l;//ver de usar o no aux
            int indice = 0;
            bool esta = false;
            foreach (Moneda item in l)
            {
                if (item.Equals(m))
                {
                    esta = true;
                    break;                
                }
                indice++;
            }
            
            if(!esta)
            {
                l.Add(m);
            }
            else
            {
                l[indice] += m.Cantidad;
            }
            return l;
        }
        public static List<Moneda> operator -(List<Moneda> l, Moneda m)
        {
            List<Moneda> aux = new List<Moneda>();
            aux = l;
    
            foreach (Moneda item in aux)
            {
                if (item.Equals(m))
                {
                    item.cantidad -= m.cantidad;
                }
                
            }
            return aux;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            bool rtn = false;
            if(obj is Moneda)
            {
                rtn = this == (Moneda)obj;
            }
            return rtn;
        }

        private static int ValidarCantidad(int cant)
        {
            if (cant < 0)
                throw new cantidadInvalidaException(cant.ToString());

            return cant;
        }

        public static int SacarGanancia(ETipoMoneda tipo)//puedo hacerlos gets sin static
        {
            int rtn=0;
            switch(tipo)
            {
                case ETipoMoneda.bronce:
                    rtn=3;
                        break;
                case ETipoMoneda.oro:
                    rtn=10;
                    break;
                case ETipoMoneda.plata:
                    rtn=7;
                    break;
            }
            return rtn;
        }
        public static int SacarPrecio(ETipoMoneda tipo)
        {
            int rtn = 0;
            switch (tipo)
            {
                case ETipoMoneda.bronce:
                    rtn = 20;
                    break;
                case ETipoMoneda.oro:
                    rtn = 65;
                    break;
                case ETipoMoneda.plata:
                    rtn = 45;
                    break;
            }
            return rtn;
        }

    }
}
