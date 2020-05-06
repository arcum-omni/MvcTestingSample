using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTestingSample.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvcTestingSample.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void Index_ReturnsNonNullViewResult()
        {
            // Assert.Fail(); // Default Auto Generated Code
            HomeController myController = new HomeController();

            IActionResult result = myController.Index();

            Assert.IsNotNull(result);
        }
    }
}

namespace MvcTestingSampleTests.Controllers
{
    class HomeControllerTests
    {
    }
}
