using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcTestingSample.Controllers;
using MvcTestingSample.Models;
using MvcTestingSample.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MvcTestingSample.Controllers.Tests
{
    [TestClass()]
    public class ProductsControllerTests
    {
        [TestMethod()]
        public async Task Index_ReturnsViewResult_WithListOfAllProducts()
        {
            // *** Arrange *** //
            Mock<IProductRepository> mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.GetAllProductsAsync()).ReturnsAsync(GetProducts());

            var prodController = new ProductsController(mockRepo.Object);

            // *** Act     *** //
            IActionResult result = await prodController.Index();

            // *** Assert  *** //
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        private List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    ProductID = 1, ProductName = "Computer", ProductPrice = "1999.99"
                },
                new Product()
                {
                    ProductID = 2, ProductName = "Webcam", ProductPrice = "199.99"
                },
                new Product()
                {
                    ProductID = 3, ProductName = "Desk", ProductPrice = "299.99"
                },
                new Product()
                {
                    ProductID = 4, ProductName = "Linux Server", ProductPrice = "2999.99"
                }
            };
        }
    }
}