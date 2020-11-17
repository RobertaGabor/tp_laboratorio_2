﻿using System;
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
        protected BoletoChances boletos;
        protected List<Moneda> billetera;

        private Jugador()
        {
            this.billetera = new List<Moneda>();
        }
        public Jugador(int dni)
            :this()
        {
            this.DNI = dni;
        }
        public Jugador(string dni)
            : this()
        {
            this.StringToDNI = dni;
        }
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
        }
        private static int ValidarDni(int dato)
        {
                    if (dato < 1 || dato > 89999999)
                        throw new dniInvalidoException(dato.ToString());//hacer try en algun lado y catch

            return dato;
        }
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

        public static bool operator ==(Jugador j, Jugador jj)
        {
            if(j.dni==jj.dni)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Jugador j, Jugador jj)
        {
            return !(j == jj);
        }

        public float SacarSaldo(List<Moneda> m)
        {
            float total = 0;
            foreach(Moneda item in m)
            {
                
                if(item.Moneyda==ETipoMoneda.oro)
                {
                    total += item.Cantidad * item.Precio;
                }
                if(item.Moneyda==ETipoMoneda.plata)
                {
                    total += item.Cantidad * item.Precio;
                }
                if(item.Moneyda==ETipoMoneda.bronce)
                {
                    total += item.Cantidad * item.Precio;
                }
            }
            return total;
        }
        public static Jugador operator +(Jugador j, Moneda m)
        {
            Jugador aux = new Jugador();
            aux = j;
            aux.billetera += m;
            return aux;
        }
    }
}
