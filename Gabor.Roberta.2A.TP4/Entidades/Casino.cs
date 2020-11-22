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
        /// <summary>
        /// constructor defaulr que inicializa las listas
        /// </summary>
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
        /// <summary>
        /// metodo que verifica si un jugador ya esta en el casino
        /// </summary>
        /// <param name="c">casino</param>
        /// <param name="j">jugador</param>
        /// <returns>true si esta sino false</returns>
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
        /// <summary>
        /// metodo que agrega un jugador al casino si este ya no esta en el
        /// </summary>
        /// <param name="c">casino</param>
        /// <param name="j">jugador</param>
        /// <returns>Casino con los jugaores modificados</returns>
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
        /// <summary>
        /// metodo que agrega jugadas al casino si esta se efectuo
        /// </summary>
        /// <param name="c">casino</param>
        /// <param name="j">jugada</param>
        /// <returns>Casino con las jugadas modificadas</returns>
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
        /// <summary>
        /// busca un jugador en el casino por dni INT, si no esta devuelve null sino al jugador
        /// </summary>
        /// <param name="c">casino</param>
        /// <param name="dni">jugador</param>
        /// <returns>null sino esta sino al Jugador</returns>
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
        /// <summary>
        /// busca un jugador en el casino por dni STRING, si no esta devuelve null sino al jugador
        /// </summary>
        /// <param name="c">casino</param>
        /// <param name="dni">jugador</param>
        /// <returns>null sino esta sino al Jugador</returns>
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
