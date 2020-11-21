using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Casino
    {
        private List<Jugador> jugadores;
        private List<Jugada> jugadas;
        
        public Casino()
        {
            this.jugadores = new List<Jugador>();
            this.jugadas = new List<Jugada>();
        }
        public List<Jugador> Jugadores
        {
            get { return this.jugadores; }   
            set { this.jugadores = value; }
        }
        public List<Jugada> Jugadas
        {
            get { return this.jugadas; }
            set { this.jugadas = value; }
        }

        public static bool operator ==(Casino c, Jugador j)
        {
            bool rtn = false;
            if(c.jugadores.Count>0)
            {
                foreach(Jugador item in c.jugadores)
                {
                    if(item==j)
                    {
                        rtn = true;
                    }
                }
            }
            return rtn;
        }
        public static bool operator !=(Casino c, Jugador j)
        {
            return !(c == j);
        }

        public static Casino operator +(Casino c, Jugador j)
        {
            Casino aux = new Casino();
            aux = c;
            if(c!=j)
            {
                aux.jugadores.Add(j);//si el count no aumenta no se agregó 
            }
            return aux;
        }

        public static Casino operator +(Casino c, Jugada j)
        {
            Casino aux = new Casino();
            aux = c;

            if(j!=null)
            {
                aux.jugadas.Add(j);
            }
            return aux;
        }


    }
}
