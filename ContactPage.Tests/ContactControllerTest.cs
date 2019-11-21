using System.Threading.Tasks;
using ContactPage.Controllers;
using ContactPage.Helpers;
using ContactPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using Moq;

namespace ContactPage.Tests
{
    public class ContactControllerTest
    {
        private ContactController _controller;

        [SetUp]
        public void Setup()
        {
            // Arrange
            var mockMailHandler = new Mock<IMailHandler>();
            var messagesAreaOfInterest = new Mock<DbSet<MessagesAreaOfInterest>>();
            var mockDb = new Mock<ContactDbContext>();
            mockDb.Setup(p => p.MessagesAreaOfInterest).Returns(messagesAreaOfInterest.Object);

            var mailOptions = Options.Create(new MailHandler());
            mailOptions.Value.ReceiverEmailAddress = "test";
            mailOptions.Value.ReceiverDisplayName = "test";
            mailOptions.Value.ReceiverEmailPassword = "test";
            mailOptions.Value.Port = "";
            mailOptions.Value.Host = "";

            mockMailHandler.Setup(t => t.Configure("test", "test", "test", "", ""));
            mockMailHandler.Setup(t => t.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                null, It.IsAny<string>(), It.IsAny<string>())).Returns(Task.Delay(0));

            _controller = new ContactController(mockMailHandler.Object, mockDb.Object, mailOptions);
        }

        [Test]
        public void Contact_SendMail()
        {
            // Arrange
            var mockContactMessages = new Mock<ContactMessages>();
            mockContactMessages.Object.AreaOfInterest = 1;
            mockContactMessages.Object.ContactMessage = "test";
            mockContactMessages.Object.Email = "test";
            mockContactMessages.Object.FirstName = "tes";
            mockContactMessages.Object.LastName = "test";

            var areaOfInterestNavigation = new Mock<MessagesAreaOfInterest>();
            areaOfInterestNavigation.Object.AreaOfInterest = "1";
            areaOfInterestNavigation.Object.Id = 1;
            areaOfInterestNavigation.Object.ContactMessages = null;

            mockContactMessages.Object.AreaOfInterestNavigation = areaOfInterestNavigation.Object;

            // Act
            var result = _controller.Create(mockContactMessages.Object);

            // Assert
            Assert.AreEqual(true, result.IsCompleted);
        }

        [Test]
        public void Contact_Create()
        {
            // Act
            var result = _controller.Create() as ViewResult;

            // Assert
           Assert.AreEqual("Create", result.ViewName);
        }

        [Test]
        public void Contact_MessageSended()
        {
            // Act
            var result = _controller.MessageSended(messageSended:true) as ViewResult;

            // Assert
            Assert.AreEqual("MessageSended", result.ViewName);
        }
    }
}
