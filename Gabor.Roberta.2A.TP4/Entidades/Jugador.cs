using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    public class Jugador
    {
        #region atributos
        protected int dni;
        protected float saldo;
        protected BoletoChances boletos;
        protected List<Moneda> billetera;
        #endregion

        #region constructores
        /// <summary>
        /// constructor po default que inicializa boletos ylista
        /// </summary>
        public Jugador()
        {
            this.billetera = new List<Moneda>();
            this.boletos = new BoletoChances();
        }
        /// <summary>
        /// constructor con parametros int
        /// </summary>
        /// <param name="dni">dni</param>
        public Jugador(int dni)
            :this()
        {
            this.DNI = dni;
        }
        /// <summary>
        /// constructor con parametros string
        /// </summary>
        /// <param name="dni">dni</param>
        public Jugador(string dni)
            : this()
        {
            this.StringToDNI = dni;
        }
        /// <summary>
        /// Constructor que le paso todos los atributos
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="saldo"></param>
        /// <param name="boleto"></param>
        /// <param name="bolsillo"></param>
        public Jugador(int dni,float saldo,BoletoChances boleto,List<Moneda>bolsillo)
            :this(dni)
        {
            this.saldo = saldo;
            this.boletos = boleto;
            this.billetera = bolsillo;
        }
        #endregion

        #region setter y getters serializacion
        public BoletoChances Boletos
        {
            get { return this.boletos; }
            set { this.boletos = value; }
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
        public string StringToDNI
        {
            set
            {
                this.dni = Jugador.ValidarDni(value);
            }
        }
        public float Saldo
        {
            get { return this.saldo; }
            set { this.saldo = value; }
        }

        public List<Moneda> Billetera
        {
            get { return this.billetera; }
            set { this.billetera = value; }
        }

        #endregion

        #region validaciones
        /// <summary>
        /// valida que el dni sea un numero entero entre esos valores
        /// </summary>
        /// <param name="dato">dni int</param>
        /// <returns>el dni sino tira una excepcion</returns>
        private static int ValidarDni(int dato)
        {
                    if (dato < 1 || dato > 89999999)
                        throw new dniInvalidoException(dato.ToString());//hacer try en algun lado y catch

            return dato;
        }
        /// <summary>
        /// valida que un dni tipo string sea valido
        /// </summary>
        /// <param name="dato">dni string</param>
        /// <returns>el dato o tira una excepcion</returns>
        private static int ValidarDni(string dato)
        {
            dato = dato.Replace(".", "");
            int numeroDni;

            if (dato.Length < 1 || dato.Length > 8)
                throw new dniInvalidoException(dato.ToString());

            try
            {
                numeroDni = Int32.Parse(dato);
            }
            catch (Exception e)
            {
                throw new dniInvalidoException(dato.ToString(), e);
            }

            return Jugador.ValidarDni(numeroDni);
        }
        #endregion

        #region metodos y sobrecargas
        /// <summary>
        /// verifica igualdad de jugadores por dni
        /// </summary>
        /// <param name="j">jugador 1</param>
        /// <param name="jj">jugador 2</param>
        /// <returns>true si son iguales sino false</returns>
        public static bool operator ==(Jugador j, Jugador jj)
        {
            if((object)j==null&&(object)jj==null)
            {
                return true;
            }
            else if((object)j!=null&&(object)jj!=null)
            {
                if(j.dni == jj.dni)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Jugador j, Jugador jj)
        {
            return !(j == jj);
        }
        /// <summary>
        /// saca el saldo total de una lista de monedas
        /// </summary>
        /// <param name="m">lista</param>
        /// <returns>saldo total</returns>
        public float SacarSaldo(List<Moneda> m)
        {
            float total = 0;
            foreach(Moneda item in m)
            {

               total += Moneda.SacarSaldo(item);

            }
            return total;
        }
        /// <summary>
        /// suma una moneda a un jugador, siguiendo la logica de sumar una moneda a una lista de monedas
        /// </summary>
        /// <param name="j">jugador</param>
        /// <param name="m">moneda</param>
        /// <returns>Jugador con la billetera modificada</returns>
        public static Jugador operator +(Jugador j, Moneda m)
        {
            Jugador aux = new Jugador();
            aux = j;
            aux.billetera += m;
            return aux;
        }
        /// <summary>
        /// resta una moneda a la billetera d eun jugador
        /// </summary>
        /// <param name="j">jugador</param>
        /// <param name="m">moneda</param>
        /// <returns>Jugador con la billetera modificada</returns>
        public static Jugador operator -(Jugador j, Moneda m)
        {
            Jugador aux = new Jugador();        
            aux = j;
            aux.billetera -= m;
            
            return aux;
        }
        /// <summary>
        /// devuelve la cantidad de monedas segun su tipo que tiene ese jugador en la billetera
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int CantidadMonedasSegunTipo(ETipoMoneda t)
        {
            int rtn = 0;
            foreach (Moneda item in this.billetera)
            {
                if(item.Moneyda==t)
                {
                    rtn= item.Cantidad;
                    break;
                }
            }
            return rtn;

        }
        /// <summary>
        /// busca una moneda en la billetera de un jugador si no esta devuelve null, sino la moneda
        /// </summary>
        /// <param name="j">jugador</param>
        /// <param name="tipo">tipo de moneda</param>
        /// <returns>null si no esta sino la moneda</returns>
        public static Moneda BuscarMoneda(Jugador j, ETipoMoneda tipo)
        {
            Moneda aux = null;
            foreach (Moneda item in j.Billetera)
            {
                if (item.Moneyda==tipo)
                {
                    aux = item;
                    break;
                }
            }
            return aux;
        }
        /// <summary>
        /// muestra la billetera de un jugador
        /// </summary>
        /// <returns></returns>
        private string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Moneda item in this.billetera)
            {
                sb.AppendLine(item.ToString());   
            }
            sb.AppendLine("Boletos: " + this.boletos.Cantidad);
            return sb.ToString();
        }
        public override string ToString()
        {
            return this.Mostrar();
        }

        #endregion
    }
}
