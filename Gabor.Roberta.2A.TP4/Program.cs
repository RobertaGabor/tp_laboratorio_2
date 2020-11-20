using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Gabor.Roberta._2A.TP4
{
    class Program
    {
        static void Main(string[] args)
        {
            Jugador uno = new Jugador();
            Jugador dos = new Jugador(12);
            Casino casi = new Casino();
            casi += dos;

            Extension.BuscarJugador(casi, uno.DNI.ToString());

            Console.ReadKey();
        }
    }
}
