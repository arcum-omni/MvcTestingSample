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
            // Arrange
            Mock<IProductRepository> mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.GetAllProductsAsync()).ReturnsAsync(GetProducts());

            var prodController = new ProductsController(mockRepo.Object);

            // Act
            IActionResult result = await prodController.Index();

            // Assert, Ensure View Returned
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = result as ViewResult;

            // Assert, List<Product> passed to view
            var model = viewResult.ViewData.Model;
            Assert.IsInstanceOfType(model, typeof(List<Product>));

            // Assert, Ensure all products ar passed to view
            List<Product> productModel = model as List<Product>;
            Assert.AreEqual(4, productModel.Count);
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

        [TestMethod()]
        public void Add_Get_ReturnsViewResult()
        {
            // Arrange
            Mock<IProductRepository> mockRepo = new Mock<IProductRepository>();
            var controller = new ProductsController(mockRepo.Object);

            // Act
            var result = controller.Add();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task AddPost_ReturnsRedirectAddsProduct_WhenModelstateIsValid()
        {
            String assertMessageOne = "Return value should be a RedirectToAction";
            String assertMessageTwo = "Controller name should not be specifiec in the redirect";
            String assertMessageThree = "User should be redirected to index";

            Product p = new Product()
            {
                ProductName = "microController",
                ProductPrice = "14.99"
            };

            // Arrange
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.AddProductAsync(It.IsAny<Product>()))
                    .Returns(Task.CompletedTask)
                    .Verifiable();
            // Act
            var controller = new ProductsController(mockRepo.Object);
            var result = await controller.Add(p);

            // Assert, Ensure user is redirected after successfully adding a product
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult), assertMessageOne);

            // Assert, Ensure controller name is not specified in RTA
            var redirectResult = result as RedirectToActionResult;
            Assert.IsNull(redirectResult.ControllerName,assertMessageTwo);

            // Assert, Ensrue redirect to Index Action
            Assert.AreEqual("Index", redirectResult.ActionName, assertMessageThree);

            mockRepo.Verify();
        }
    }
}