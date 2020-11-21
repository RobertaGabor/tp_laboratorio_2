using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Entidades
{
    public class SerializacionJugadores
    {
        public static bool Guardar(Casino jugadores)
        {
            bool rtn = false;

            Xml<Casino> aux = new Xml<Casino>();

            try
            {
                aux.Guardar("Casino.xml", jugadores);
                rtn = true;
            }
            catch (Excepciones.ArchivosException e)
            {
                throw new Excepciones.ArchivosException(e);
            }

            return rtn;
        }


        public static Casino Leer()
        {
            Casino informacion = new Casino();

            Xml<Casino> aux = new Xml<Casino>();

            try
            {
                aux.Leer("Casino.xml", out informacion);
            }
            catch (Excepciones.ArchivosException e)
            {
                throw new Excepciones.ArchivosException(e);
            }

            return informacion;
        }

    }

}
