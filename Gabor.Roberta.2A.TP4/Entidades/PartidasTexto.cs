using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Entidades
{
    public class SerializacionPartidas
    {
        /// <summary>
        /// metodo que serializa los datos de una partida en txt, en un archivo con el dni de la persona
        /// si es l misma se hace append, y se guardan en una carpeta llamada Partidas
        /// </summary>
        /// <param name="juego"></param>
        /// <returns></returns>
        public static bool Guardar(Jugada juego)
        {
            bool rtn = false;
            int dni = juego.Victima.DNI;
            Texto texto = new Texto();

            try
            {
                texto.Guardar($"Partidas//{dni.ToString()}.txt", juego.ToString());//se guardan en formbase/bin/debug/partidas
                rtn = true;
            }
            catch (Excepciones.ArchivosException e)
            {
                throw new Excepciones.ArchivosException(e);
            }

            return rtn;
        }

    }
}
