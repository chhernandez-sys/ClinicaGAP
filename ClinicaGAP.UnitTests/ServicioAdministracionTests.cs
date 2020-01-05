using ClinicaGAP.Models;
using ClinicaGAP.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClinicaGAP.UnitTests
{
    [TestClass]
    public class ServicioAdministracionTests
    {
        [TestMethod]
        public void ObjetoEstadoEsValido_ReturnTrue()
        {
            //Arrange
            var Servicio = new ServicioAdministracion();
            ESTADO Estado = new ESTADO
            {
                ID_ESTADO = 1,
                DESCRIPCION = "Cerrada"
            };

            //Act
            var Resultado = Servicio.ObjetoEstadoEsValido(Estado);

            //Assert
            Assert.IsTrue(Resultado);
        }
    }
}