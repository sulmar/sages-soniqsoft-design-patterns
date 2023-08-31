using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BridgePattern.UnitTests
{
    [TestClass]
    public class TextProtocolTests
    {
        private ProtocolImplementor protocol;

        [TestInitialize]
        public void TestInitialize()
        {
            protocol = new TextProtocol();
        }


        [TestMethod]
        public void SwitchOn_WhenCalled_ShouldReturnsOnMessage()
        {
            // Arrange          

            // Act
            var result = protocol.SwitchOn();

            // Assert
            Assert.AreEqual("ON", result);
        }

        [TestMethod]
        public void SwitchOff_WhenCalled_ShouldReturnsOffMessage()
        {
            // Arrange 

            // Act
            var result = protocol.SwitchOff();

            // Assert
            Assert.AreEqual("OFF", result);
        }

    }
}
