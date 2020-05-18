using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTestingSample.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvcTestingSampleTests.Models
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void Name_SetToNull_ThrowsArgumentNullException()
        {
            Product p = new Product();

            Assert.ThrowsException<ArgumentNullException>
                (
                    () => p.ProductName = null
                );
        }
    }
}
