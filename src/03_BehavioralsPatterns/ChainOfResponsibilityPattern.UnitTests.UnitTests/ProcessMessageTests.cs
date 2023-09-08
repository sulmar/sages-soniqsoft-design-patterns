using ChainOfResponsibilityPattern.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ChainOfResponsibilityPattern.MessageHandlers;

namespace ChainOfResponsibilityPattern.UnitTests.UnitTests
{
    [TestClass]
    public class FromWhiteListHandlerTests
    {
        [TestMethod]
        public void Handle_SenderFromWhiteListWithOrder_ShouldHandle()
        {
            // Arrange
            string[] whiteList = new string[] {"john@domain.com", "bob@domain.com"};
            var messageHandler = new FromWhiteListHandler(whiteList);


            Message message = new Message {From = "john@domain.com"};

            // Act
            messageHandler.Handle(message);

            // Assert            
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Handle_SenderNotFromWhiteListWithOrder_ShouldThrowsException()
        {
            // Arrange
            string[] whiteList = new string[] {"john@domain.com", "bob@domain.com"};
            var messageHandler = new FromWhiteListHandler(whiteList);


            Message message = new Message {From = "a@abc.com"};

            // Act
            messageHandler.Handle(message);

            // Assert            
        }
    }
    
    [TestClass]
    public class TitleContainsHandlerTests
    {
        [TestMethod]
        public void Handle_TitleContainsOrder_ShouldByProcess()
        {
            // Arrange
            var messageHandler = new TitleContainsHandler("Order");
            
            Message message = new Message { Title = "Order #1" };

            // Act
            messageHandler.Handle(message);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Handle_TitleNotContainsOrder_ShouldThrowException()
        {
            // Arrange
            var messageHandler = new TitleContainsHandler("Order");
            
            Message message = new Message { Title = "a" };
            
            // Act
            messageHandler.Handle(message);

            // Assert
        }
    }

    [TestClass]
    public class TaxNumberHandlerTests
    {
        [TestMethod]
        public void Handle_BodyContainsValidTaxNumber_ShouldReturnsTaxNumber()
        {
            // Arrange
            var messageHandler = new TaxNumberHandler();
            
            Message message = new Message { Body = "Lorem ipsum 953-120-45-91"};

            // Act
            messageHandler.Handle(message);

            // Assert
          
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ProcessMessage_BodyContainsInvalidTaxNumber_ShouldReturnsTaxNumber()
        {
            // Arrange
            var messageHandler = new TaxNumberHandler();
            Message message = new Message { Body = "Lorem ipsum 000-000-00-000"};
           
            // Act
            messageHandler.Handle(message);

            // Assert
        }
       
    }


}