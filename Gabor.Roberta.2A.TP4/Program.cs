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
            Casino casi = new Casino();//jugadores y jugadas

            BoletoChances boleto = new BoletoChances(2);
            List<Moneda> monedas = new List<Moneda>();
            Moneda moni = new Moneda(34, 6, ETipoMoneda.bronce, 2);
            Moneda moni2 = new Moneda(50, 2, ETipoMoneda.plata, 4);

            monedas += moni;
            monedas += moni;

            if (monedas.Count==1)
            {
                Console.WriteLine("No se agregó");
            }

            monedas += moni2;

            if (monedas.Count > 1)
            {
                Console.WriteLine("Se agregó");
            }

            Jugador uno = new Jugador(11,100,boleto,monedas);
            Jugador dos = new Jugador(12,3000,boleto,monedas);
            Jugador tres = new Jugador(13, 3000, boleto, monedas);

            casi += dos;
            casi += uno;



            if(Casino.BuscarJugador(casi, uno.DNI.ToString())!=null)
            {
                Console.WriteLine($"{uno.DNI.ToString()} se encuentra en el casino");
            }
            if (Casino.BuscarJugador(casi, tres.DNI.ToString()) == null)
            {
                Console.WriteLine($"{tres.DNI.ToString()} no se encuentra en el casino");
            }

            Jugada juego = new Jugada(uno, -20, ETipoTransaccion.pierde);

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Billetera de Jugadores: ");
            foreach(Jugador item in casi.Jugadores)
            {
                Console.WriteLine(item.DNI);
                Console.WriteLine(item.ToString());
                Console.WriteLine("");
            }

            casi += juego;

            Console.WriteLine("Partidas: ");
            foreach(Jugada item in casi.Jugadas)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }
    }
}
