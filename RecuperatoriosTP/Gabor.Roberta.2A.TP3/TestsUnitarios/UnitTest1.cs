using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using Excepciones;
using ClasesAbstractas;

namespace TestsUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(Excepciones.AlumnoRepetidoException))]
        public void TestAgregarALumnoYaIngresado()
        {
            Profesor prof1 = new Profesor(12, "Juan", "Carlos", "23434", Persona.ENacionalidad.Argentino);
            Jornada jorn1 = new Jornada(Universidad.EClases.Laboratorio,prof1);
            Alumno alum1 = new Alumno(23, "Pedro", "Lua", "24545", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);

            jorn1 += alum1;

            Alumno alum2 = new Alumno(23, "Pedro", "Lua", "24545", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);

            jorn1 += alum2;
        }

        [TestMethod]
        [ExpectedException(typeof(Excepciones.NacionalidadInvalidaException))]
        public void TestDNIInvalidoArgentinoAlto()
        {  
            string dniStringPunto = "95.000.555";           

            Profesor prof4 = new Profesor(15, "lucia", "lampara", dniStringPunto, Persona.ENacionalidad.Argentino);
        }

        [TestMethod]
        public void TestJornadaInstanciarAlumnos()
        {
            Jornada jorna1 = new Jornada(Universidad.EClases.Laboratorio, new Profesor(12, "juan", "perez", "1234455", Persona.ENacionalidad.Argentino));
            Assert.IsNotNull(jorna1.Alumnos);
        }


    }
}
