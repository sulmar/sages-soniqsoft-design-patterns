using ChainOfResponsibilityPattern.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ChainOfResponsibilityPattern.UnitTests.UnitTests
{
    [TestClass]
    public class ProcessMessageTests
    {
        [TestMethod]
        public void ProcessMessage_SenderFromWhiteListWithOrder_ShouldByProcess()
        {
            string[] whiteList = new string[] { "john@domain.com", "bob@domain.com" };

            // Arrange
            Message message = new Message { From = "john@domain.com", Title = "Order #1", Body = "Lorem ipsum 953-120-45-91" };

            // Act
            if (!whiteList.Contains(message.From))
            {
                throw new Exception();
            }

            if (!message.Title.Contains("Order"))
            {
                throw new Exception();
            }

            string pattern = @"\b(\d{10}|\d{3}-\d{3}-\d{2}-\d{2})\b";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(message.Body);

            if (match.Success)
            {
                string taxNumber = match.Value;
            }
            else
            {
                throw new Exception();
            }

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ProcessMessage_SenderFromNotWhiteListWithOrder_ShouldNotByProcess()
        {
            string[] whiteList = new string[] { "john@domain.com", "bob@domain.com" };

            // Arrange
            Message message = new Message { From = "a@b.pl", Title = "Order #1" };

            // Act
            if (!whiteList.Contains(message.From))
            {
                throw new Exception();
            }

            if (!message.Title.Contains("Order"))
            {
                throw new Exception();
            }

            // Assert

        }
    }
}
