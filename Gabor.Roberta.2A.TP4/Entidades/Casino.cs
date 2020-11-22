using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Casino
    {
        #region atributos
        private List<Jugador> jugadores;
        private List<Jugada> jugadas;
        #endregion atributos

        #region constructores
        public Casino()
        {
            this.jugadores = new List<Jugador>();
            this.jugadas = new List<Jugada>();
        }
        #endregion

        #region getters y setter serializacion
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
        #endregion

        #region metodos y sobrecargas
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

        public static Jugador BuscarJugador(Casino c, int dni)
        {
            Jugador aux = null;
            foreach (Jugador item in c.Jugadores)
            {
                if (item.DNI == dni)
                {
                    aux = item;
                    break;
                }
            }
            return aux;
        }
        public static Jugador BuscarJugador(Casino c, string dni)
        {
            Jugador aux = null;
            int dniaux;
            try
            {
                dniaux = int.Parse(dni);
                foreach (Jugador item in c.Jugadores)
                {
                    if (item.DNI == dniaux)
                    {
                        aux = item;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                throw new dniInvalidoException(e);
            }

            return aux;
        }
        #endregion

    }
}
