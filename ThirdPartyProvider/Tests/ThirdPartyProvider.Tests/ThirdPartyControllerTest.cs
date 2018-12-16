using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThirdPartyProvider.Controllers;

namespace ThirdPartyProvider.Tests
{
    [TestClass]
    public class ThirdPartyControllerTest
    {
        [TestMethod]
        public void ThirdPartyController_Ping_Success()
        {
            var thirdPartController = new ThirdPartyController();

            var response = thirdPartController.Get();

            Assert.IsNotNull(response);
        }
    }
}
