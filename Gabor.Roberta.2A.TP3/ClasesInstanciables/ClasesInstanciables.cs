using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;


namespace ClasesInstanciables
{
    public sealed class Alumno:Universitario
    {
        #region atributos 
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region constructores
        public Alumno()//DEFAULT SIN HACER
        {
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = clasesQueToma;
        }
        #endregion

        #region metodos
        protected override string ParticiparEnClase()
        {
            return $"TOMA CLASE DE: {this.claseQueToma.ToString()}";
        }
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            sb.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta.ToString()}");
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Alumno a, Universidad.EClases clase)//CHEQUEAR SI DEBE SER != NULL
        {
            bool rtn = false;
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                rtn = true;
            }
            return rtn;
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }
        #endregion



        #region enumerados
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion
    }



    public sealed class Profesor : Universitario
    {
        #region atributos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region constructores
        public Profesor()//PORQUE?????
        {
        }
        static Profesor()//PRIVADA X DEFAULT
        {
            Profesor.random = new Random();
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            this.randomClase();
            this.randomClase();
        }
        #endregion

        #region metodos
        public void randomClase()
        {
            int numeroIndice;
            numeroIndice = Profesor.random.Next(0, 3);      
            this.clasesDelDia.Enqueue((Universidad.EClases)numeroIndice);
        }
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CLASES DEL DIA: ");
            foreach (Universidad.EClases clases in this.clasesDelDia)
            {
                sb.Append($"{clases.ToString()}, ");
            }
            return sb.ToString();
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool rtn = false;
            if (i.clasesDelDia.Contains(clase))//NO HACE FALTA VER NULL PORQUE VA A TENER 2 CLASES MINIMO
            {
                rtn = true;
            }
            return rtn;
        }
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }



    public class Jornada 
    {
        #region atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region constructores
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion
        #region propiedades
        public List<Alumno>  Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion
        #region metodos
        /*Una Jornada será igual a un Alumno si el mismo participa de la clase.
        • Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente
        cargados.
        • ToString mostrará todos los datos de la Jornada*/








        #endregion

    }




    public class Universidad
    {
        #region atributos
        private List<Alumno> alumnos;
        private List<Profesor> profesores;
        private List<Jornada> jornadas;
        #endregion



        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
    }
}
