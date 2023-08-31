using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{

    // Abstraction interface
    public interface IControlDevice
    {
        void Connect();
        void SwitchOn();
        void SwitchOff();
        void Disconnect();
    }

    // Implementor interface for communication
    public interface ICommunicationImplementor
    {
        void OpenConnection();
        string Send(string data);
        void CloseConnection();
    }

    // Implementor interface for protocol
    public interface ProtocolImplementor
    {
        string SwitchOn();
        string SwitchOff();
    }

    // Concrete ControlDevice implementation
    public class ControlDevice : IControlDevice
    {
        protected ICommunicationImplementor _communication;
        protected ProtocolImplementor _protocol;

        public ControlDevice(ICommunicationImplementor communication, ProtocolImplementor protocol)
        {
            _communication = communication;
            _protocol = protocol;
        }

        public void Connect()
        {
            _communication.OpenConnection();
        }

        public void SwitchOff()
        {
            _communication.Send(_protocol.SwitchOff());
        }

        public void SwitchOn()
        {
            _communication.Send(_protocol.SwitchOn());
        }

        public void Disconnect()
        {
            _communication.CloseConnection();
        }
    }

    // Concrete CommunicationImplementor implementations
    public class RS232Communication : ICommunicationImplementor
    {
        public void OpenConnection() { }
        public void CloseConnection() { }

        public string Send(string data)
        {
            return $"{data} sent by RS232";
        }
    }

    public class TCPCommunication : ICommunicationImplementor
    {
        public void OpenConnection() { }
        public void CloseConnection() { }

        public string Send(string data)
        {
            return $"{data} sent by TCP";
        }
    }

    // Concrete ProtocolImplementor implementations
    public class TextProtocol : ProtocolImplementor
    {

        public string SwitchOn()
        {
            return "ON"; // Replace with actual message format for switching on
        }

        public string SwitchOff()
        {
            return "OFF"; // Replace with actual message format for switching off
        }
    }

    public class XMLProtocol : ProtocolImplementor
    {
        public string SwitchOn()
        {
            // Generate XML message for switching on
            return "<command><action>on</action></command>";
        }

        public string SwitchOff()
        {
            // Generate XML message for switching off
            return "<command><action>off</action></command>";
        }
    }


}
