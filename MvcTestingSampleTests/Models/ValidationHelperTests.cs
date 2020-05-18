using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTestingSample.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvcTestingSample.Models.Tests
{
    [TestClass()]
    public class ValidationHelperTests
    {
        [TestMethod()]
        [DataRow("9.99")]
        [DataRow("$9.99")]
        [DataRow(".99")]
        [DataRow("0.99")]
        [DataRow("0")]
        public void IsValidPriceTest_ValidPrice_ReturnsTrue(string input)
        {
            bool result = ValidationHelper.IsValidPrice(input);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("nine")]
        [DataRow("9.99.99")]
        [DataRow("9.99$")]
        public void IsValidPriceTest_InvalidPrice_ReturnFalse(string input)
        {
            bool result = ValidationHelper.IsValidPrice(input);
            Assert.IsFalse(result);
        }
    }
}