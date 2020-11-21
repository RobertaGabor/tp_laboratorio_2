using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// firma de metodo para guardar
        /// </summary>
        /// <param name="archivo">nombre del archivo</param>
        /// <param name="datos">datos que se guardan</param>
        /// <returns>true si se grabo sino false</returns>
        bool Guardar(string archivo, T datos);
        /// <summary>
        /// firma d emetodo para leer
        /// </summary>
        /// <param name="archivo">nombre del archivo</param>
        /// <param name="datos">datos a leer</param>
        /// <returns>true si se leyo sino false</returns>
        bool Leer(string archivo, out T datos);

    }
}
