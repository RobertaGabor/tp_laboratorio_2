﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public class Taller
    {
        private List<Vehiculo> vehiculos;
        private int espacioDisponible;

        /// <summary>
        /// constructor por defecto que inicializa la lista vehiculos
        /// </summary>
        #region "Constructores"
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        /// <summary>
        /// Constructor que inicializa la lista con el parametro espacio disponible
        /// </summary>
        /// <param name="espacioDisponible"></param>
        public Taller(int espacioDisponible):this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Taller.Listar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido. 
        /// 
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Listar(Taller t, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles",t.vehiculos.Count, t.espacioDisponible);
            sb.AppendLine("");
            string x = tipo.ToString();
            foreach (Vehiculo v in t.vehiculos)
            {
                switch(tipo)
                {
                    case ETipo.Ciclomotor:
                        if(v is Ciclomotor)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Sedan:
                        if (v is Sedan)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.SUV:
                        if (v is Suv)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                     default:

                        sb.AppendLine(v.Mostrar());
                       
                        break;
                }
                    
                
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns></returns>
        public static Taller operator +(Taller t, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in t.vehiculos)
            {
                if (v == vehiculo)
                    return t;
            }
            if(t.vehiculos.Count < t.espacioDisponible)
                t.vehiculos.Add(vehiculo);
            return t;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns></returns>
        public static Taller operator -(Taller t, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in t.vehiculos)
            {
                if (v == vehiculo)
                {
                    t.vehiculos.Remove(vehiculo);
                    break;
                }
            }
            return t;
        }
        #endregion
        public enum ETipo
        {
            Ciclomotor, Sedan, SUV, Todos
        }


    }
}
