using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    public class Moneda
    {
        #region atributos
        protected ETipoMoneda moneda;
        protected int precio;
        protected int cantidad;
        protected int ganancia;
        #endregion

        #region constructores
        /// <summary>
        /// constructor por default para serializacion
        /// </summary>
        public Moneda() { }
        /// <summary>
        /// constructor con parametros
        /// </summary>
        /// <param name="precio">precio de la moneda</param>
        /// <param name="canti">cantidad de esa moneda</param>
        /// <param name="tipo">Tipo de moneda</param>
        /// <param name="ganancia">ganancia el promedio de cuanto se gana (cuantas veces se gana)</param>
        public Moneda(int precio, int canti, ETipoMoneda tipo, int ganancia)
        {
            this.precio = precio;
            this.cantidad = canti;
            this.moneda = tipo;
            this.ganancia = ganancia;
        }
        #endregion

        #region setter y getters serializacion
        public int Cantidad
        {
            get { return this.cantidad; }
            set { this.cantidad = ValidarCantidad(value); }
        }
        public int Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }
        public ETipoMoneda Moneyda
        {
            get { return this.moneda; }
            set { this.moneda = value; }
        }
        public int Ganancia
        {
            get { return this.ganancia; }
            set { this.ganancia = value; }
        }

        #endregion

        #region metodos y sobrecargas
        /// <summary>
        /// metodo que a una moneda le suma la cantidad
        /// </summary>
        /// <param name="m">moneda</param>
        /// <param name="numero">cantidad a sumar</param>
        /// <returns>devuelve la moneda con la cantidad modificada</returns>
        public static Moneda operator +(Moneda m,int numero)
        {
            m.cantidad += numero;
            return m;

        }
        /// <summary>
        /// metodo que a una moneda le resta la cantidad
        /// </summary>
        /// <param name="m">moneda</param>
        /// <param name="numero">cantidad a restar</param>
        /// <returns>devuelve la moneda con la cantidad modificada</returns>
        public static Moneda operator -(Moneda m, int numero)
        {
            m.cantidad -= numero;
            return m;

        }
        /// <summary>
        /// metodo que obtiene saldo de una moneda
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static float SacarSaldo(Moneda e)
        {
            return e.cantidad * e.precio;
        }
        /// <summary>
        /// metodo que verifica igualda de dos monedas por tipo
        /// </summary>
        /// <param name="m"></param>
        /// <param name="mm"></param>
        /// <returns></returns>
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
        /// <summary>
        /// metodo que agrega una moneda a la lista de monedas si no existes, sino suma su cantidad
        /// </summary>
        /// <param name="l">lista d emonedas</param>
        /// <param name="m">moneda a sumar</param>
        /// <returns></returns>
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
        /// <summary>
        /// resta la cantidad de una moneda en una lista
        /// </summary>
        /// <param name="l"></param>
        /// <param name="m"></param>
        /// <returns></returns>
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

        public override string ToString()
        {
            return moneda.ToString()+$": {this.cantidad}";
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
        /// <summary>
        /// valida una cantidad de numero nattural
        /// </summary>
        /// <param name="cant"></param>
        /// <returns></returns>
        private static int ValidarCantidad(int cant)
        {
            if (cant < 0)
                throw new cantidadInvalidaException(cant.ToString());

            return cant;
        }
        /// <summary>
        /// devuelve la ganancia que genera cada moneda
        /// </summary>
        /// <param name="tipo">tipo de moneda</param>
        /// <returns></returns>
        public static int SacarGanancia(ETipoMoneda tipo)
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
        /// <summary>
        /// devuelve el precio de cada moneda
        /// </summary>
        /// <param name="tipo">tipo de moneda</param>
        /// <returns></returns>
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
        #endregion
    }
}
