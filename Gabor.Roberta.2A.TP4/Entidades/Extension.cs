using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Extension
    {
        public static Jugador BuscarJugador(Casino c, int dni)
        {
            Jugador aux = null;
            foreach (Jugador item in c.Jugadores)
            {
                if (item.DNI==dni)
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
                dniaux=int.Parse(dni);
            }
            catch(Exception e)
            {
                throw new dniInvalidoException(e);
            }
            foreach (Jugador item in c.Jugadores)
            {
                if (item.DNI==dniaux)
                {
                    aux = item;
                    break;
                }
            }
            return aux;
        }
    }
}
