using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;



namespace MainConsolaDePrueba
{
    class Program
    {
        static void Main(string[] args)
        {
            //Numero ejemplo3 = new Numero();
            //Numero ejemplo4 = new Numero();

            //Calculadora.Operar(ejemplo3,ejemplo4, "23+*");


            double num = 0134.8;
            num = Math.Round(num);
            Console.WriteLine(num);

            Numero ejemplo = new Numero();
            string decimale;
            decimale=ejemplo.BinarioDecimal("10110");
            Console.WriteLine(decimale);
            
            decimale = ejemplo.DecimalBinario(22);
            Console.WriteLine(decimale);

            Numero ejemplo2 = new Numero();
            Calculadora.Operar(ejemplo, ejemplo2, "*");

            Console.ReadKey(true);
        }
    }
}
