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
        public Moneda(int precio,int canti,ETipoMoneda tipo,int ganancia)
        {
            this.precio = precio;
            this.cantidad = this.Cantidad;
            this.moneda = tipo;
            this.ganancia = ganancia;
        }

        public static Moneda operator +(Moneda m,int numero)
        {
            m.cantidad += numero;
            return m;

        }

        public static float SacarSaldo(Moneda e)
        {
            return e.cantidad * e.precio;
        }

        public float ProbabilidadesEnGanancias(int cantidadMonedasApostadas)
        {
            return cantidadMonedasApostadas * this.ganancia * this.precio;
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
            aux = l;
            int indice = 0;
            foreach (Moneda item in l)
            {
                if (item.Equals(m))
                {
                    break;

                }
                indice++;
            }
            l[indice] += m.Cantidad;
            return l;
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

        public static explicit operator int(Moneda m)
        {
            int aux = 0;
            foreach (ETipoMoneda item in Enum.GetValues(typeof(ETipoMoneda)))
            {
                if (m.Moneyda == item)
                {
                    aux = m.Precio;
                    break;
                }
            }
            return aux;
        }
    }
}
