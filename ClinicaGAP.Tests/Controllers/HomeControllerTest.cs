using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClinicaGAP.Controllers;

namespace ClinicaGAP.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            CitaController controller = new CitaController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}