using NUnit.Framework;
using ContactPage.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ContactPage.Tests
{
    public class HomeControllerTests
    {
        private HomeController _controller;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _controller = new HomeController();
        }

        [Test]
        public void Index_ViewName()
        {
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void Index_Model()
        {
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual(null, result.Model);
        }
    }
}