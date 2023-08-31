using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BridgePattern.UnitTests
{
    [TestClass]
    public class RS232CommunicationTests
    {
        [TestMethod]
        public void Send_ValidData_ShouldReturnsResponse()
        {
            // Arrange          
            ICommunicationImplementor communication = new RS232Communication();
            communication.OpenConnection();

            // Act
            var result = communication.Send("a");

            communication.CloseConnection();

            // Assert
            Assert.AreEqual("a sent by RS232", result);
        }
    }
}
