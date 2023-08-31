using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BridgePattern.UnitTests
{

    [TestClass]
    public class XMLProtocolTests
    {
        private ProtocolImplementor protocol;

        [TestInitialize]
        public void TestInitialize()
        {
            protocol = new XMLProtocol();
        }


        [TestMethod]
        public void SwitchOn_WhenCalled_ShouldReturnsOnMessage()
        {
            // Arrange          

            // Act
            var result = protocol.SwitchOn();

            // Assert
            Assert.AreEqual("<command><action>on</action></command>", result);
        }

        [TestMethod]
        public void SwitchOff_WhenCalled_ShouldReturnsOffMessage()
        {
            // Arrange 

            // Act
            var result = protocol.SwitchOff();

            // Assert
            Assert.AreEqual("<command><action>off</action></command>", result);
        }

    }
}
