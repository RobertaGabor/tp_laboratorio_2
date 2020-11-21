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
