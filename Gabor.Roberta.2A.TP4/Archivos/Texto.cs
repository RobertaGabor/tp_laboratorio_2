using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda los datos en un archivo txt  
        /// </summary>
        /// <param name="archivo">archivo a guardar</param>
        /// <param name="texto">datos a guardar</param>
        /// <returns>true si se guardo sino false</returns>
        public bool Guardar(string archivo, string texto)
        {
            bool rtn = false;
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo, true))
                {
                    sw.WriteLine(texto);
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
        /// Lee los datos dn un archivo txt en una variable  
        /// </summary>
        /// <param name="archivo">archivo a gleer</param>
        /// <param name="texto">datos a guardar</param>
        /// <returns>true si se leyo sino false</returns>
        public bool Leer(string archivo, out string texto)
        {
            bool rtn = false;
            try
            {
                using (StreamReader sr = new StreamReader(archivo, true))
                {
                    texto = sr.ReadToEnd();
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
