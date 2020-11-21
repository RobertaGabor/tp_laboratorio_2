using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guardar datos en un archivo xml
        /// </summary>
        /// <param name="archivo">nombre del archivo</param>
        /// <param name="dato">datos a guardar</param>
        /// <returns>true si se guardo sino false</returns>
        public bool Guardar(string archivo, T dato)
        {
            bool rtn = false;
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));

                    ser.Serialize(writer, dato);
                }
                rtn = true;

            }
            catch (Exception e)
            {
                throw new Excepciones.ArchivosException(e);
            }
            return rtn;
        }
        /// <summary>
        /// lee datos dn un archivo xml
        /// </summary>
        /// <param name="archivo">nombre del archivo</param>
        /// <param name="dato">datos a leer</param>
        /// <returns>true si se leyo sino false</returns>
        public bool Leer(string archivo, out T dato)
        {
            bool rtn = false;
            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer((typeof(T)));

                    dato = (T)ser.Deserialize(reader);
                }
                rtn = true;

            }
            catch (Exception e)
            {
                throw new Excepciones.ArchivosException(e);
            }
            return rtn;
        }
    }
}
