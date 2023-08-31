using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BridgePattern.UnitTests
{
    [TestClass]
    public class ControlDeviceTests
    {
        [TestMethod]
        public void SwitchOn_TCPCommunicationAndXMLProtocol_Should()
        {
            // Arrange 
            IControlDevice controlDevice = new ControlDevice(new TCPCommunication(), new XMLProtocol());
            controlDevice.Connect();

            // Act
            controlDevice.SwitchOn();
            controlDevice.Disconnect();

            // Assert
        }

    }
}
