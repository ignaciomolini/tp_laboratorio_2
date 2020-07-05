using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTestCorreo
{
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// Metodo que verifica que al instanciar un correo se intancie la lista de paquetes
        /// </summary>
        [TestMethod]
        public void ListaPaquetesInstanciada()
        {
            //Arrange
            Correo correo;

            //Act
            correo = new Correo();

            //Assert
            Assert.IsNotNull(correo.Paquetes);
        }

        /// <summary>
        /// Metodo que verifica que no se puedan agregar dos paquetes con el mismo TrackingID
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void TrackingIdRepetido()
        {
            //Arrange
            Correo correo;
            Paquete p1;
            Paquete p2;

            //Act
            correo = new Correo();
            p1 = new Paquete("Madariaga 354", "245-587-4578");
            p2 = new Paquete("Salta 835", "245-587-4578");

            correo += p1;
            correo += p2;

            //Assert
        }
    }
}
