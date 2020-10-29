using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;


namespace ClasesAbstractas
{
    public abstract class Persona
    {
        #region atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region constructores
        public Persona()
        {
        }
        public Persona(string nombre,string apellido,ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre,string apellido, int dni, ENacionalidad nacionalidad)
            :this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region propiedades

        public int DNI
        {
            get 
            {
                return this.dni;
            }
            set
            {
                this.dni = Persona.ValidarDni(this.nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = Persona.ValidarNombreApellido(value);
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = Persona.ValidarNombreApellido(value);
            }
        }
        public string StringToDNI
        {
            set
            {
                this.dni = Persona.ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region validaciones
        private static int ValidarDni(ENacionalidad nacionalidad,int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                        throw new NacionalidadInvalidaException(dato.ToString());
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 89999999 || dato > 99999999)
                        throw new NacionalidadInvalidaException();
                    break;
            }
            return dato; 
        }
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            dato = dato.Replace(".", "");
            int numeroDni;

            if (dato.Length < 1 || dato.Length > 8)
                throw new DniInvalidoException(dato.ToString());
            
            try
            {
                numeroDni = Int32.Parse(dato);
            }
            catch (Exception e)
            {
                throw new DniInvalidoException(dato.ToString(), e);
            }

            return Persona.ValidarDni(nacionalidad, numeroDni);
        }
        private static string ValidarNombreApellido(string dato)
        {
            bool pudo = Regex.IsMatch(dato, @"^[a-zA-Z]+$");
            if(pudo)
            {
                return dato;
            }

                return "";
        }
        #endregion

        #region metodos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"NOMBRE COMPLETO: {this.apellido}, {this.nombre}");
            sb.AppendLine($"NUMERO DNI: {this.dni}");
            sb.AppendLine($"NACIONALIDAD: {this.nacionalidad.ToString()}");
            return sb.ToString();
        }
        #endregion

        #region enumerado
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion
    }

    public abstract class Universitario:Persona
    {
        #region atributos
        private int legajo;
        #endregion

        #region constructores
        public Universitario(int legajo, string nombre,string apellido,string dni, ENacionalidad nacionalidad)
            :base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        public Universitario()
        {
        }
        #endregion

        #region metodos
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"LEGAJO: {this.legajo}");
            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool rtn = false;
            if(pg1.GetType()==pg2.GetType()&&(pg1.legajo==pg2.legajo||pg1.DNI==pg2.DNI))
            {
                rtn = true;
            }
            return rtn;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1==pg2);
        }

        public override bool Equals(object obj)
        {
            bool rtn = false;
            if(obj is Universitario)
            {
                rtn = this == (Universitario)obj;
            }

            return rtn;
        }
        #endregion

    }
}
