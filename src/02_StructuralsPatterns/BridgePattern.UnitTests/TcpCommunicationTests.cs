using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BridgePattern.UnitTests
{
    [TestClass]
    public class TcpCommunicationTests
    {
        [TestMethod]
        public void Send_ValidData_ShouldReturnsResponse()
        {
            // Arrange          
            ICommunicationImplementor communication = new TCPCommunication();
            communication.OpenConnection();

            // Act
            var result = communication.Send("a");

            communication.CloseConnection();

            // Assert
            Assert.AreEqual("a sent by TCP", result);
        }
    }
}
