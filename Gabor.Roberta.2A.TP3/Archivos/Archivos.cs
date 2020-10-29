using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
using System.Xml.Serialization;
using System.Xml;

namespace Archivos
{
    public class Texto:IArchivo<string>
    {
        public bool Guardar(string archivo, string texto)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo,true))
                {
                    sw.WriteLine(texto); 
                }
                return true;

            }
            catch (Exception e)
            {
                throw new Excepciones.ArchivosException(e);
            }
        }
        public bool Leer(string archivo, out string texto)
        {
            try
            {
                using (StreamReader sr = new StreamReader(archivo,true))
                {
                    texto = sr.ReadToEnd();   
                }
                return true;

            }
            catch (Exception e)
            {
                throw new Excepciones.ArchivosException(e);
            }
        }
    }
    public class Xml<T>: IArchivo<T>
    {
        public bool Guardar(string archivo, T dato)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));

                    ser.Serialize(writer, dato);
                }
                return true;

            }
            catch (Exception e)
            {
                throw new Excepciones.ArchivosException(e);
            }
        }
        public bool Leer(string archivo, out T dato)
        {
            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer((typeof(T)));

                    dato = (T)ser.Deserialize(reader);
                }
                return true;

            }
            catch (Exception e)
            {
                throw new Excepciones.ArchivosException(e);
            }
        }
    }
    public interface IArchivo<T>
    {
        bool Guardar(string archivo, T datos);
        bool Leer(string archivo, out T datos);

    }
}
