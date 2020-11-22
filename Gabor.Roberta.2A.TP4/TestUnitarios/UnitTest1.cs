using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test de validacion de DNI
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(dniInvalidoException))]
        public void DNI_InvalidoArgentino_Alto()
        {
            string dni = "hola";

            Jugador player = new Jugador(dni);
        }
        /// <summary>
        /// Test que verifica desigualdad de jugadores
        /// </summary>
        [TestMethod]
        public void IgualdadJugadores()
        {
            Jugador uno = new Jugador(12);
            Jugador dos = new Jugador(11);

            bool rta = uno == dos;
            Assert.IsFalse(rta);
        }
        /// <summary>
        /// Test que corrobora que no se agreguen 2 jugadores iguales
        /// </summary>
        [TestMethod]
        public void Agregar_JugadorCasino()
        {
            Casino casino = new Casino();
            Jugador player = new Jugador(1);
            casino += player;
            casino += player;

            Assert.AreEqual(casino.Jugadores.Count, 1);

        }
    }
}
