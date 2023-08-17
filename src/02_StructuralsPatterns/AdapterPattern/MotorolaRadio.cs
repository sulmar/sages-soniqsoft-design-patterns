using System;

namespace AdapterPattern
{
    // Concrete Adapter B
    public class MotorolaRadioAdapter : IRadioAdapter
    {
        // Adaptee
        private MotorolaRadio radio = new MotorolaRadio();

        private string pincode;

        public MotorolaRadioAdapter(string pincode)
        {
            this.pincode = pincode;
        }

        public void SendMessage(string message, byte channel)
        {
            radio.PowerOn(pincode);
            radio.SelectChannel(channel);
            radio.Send(message);
            radio.PowerOff();
        }
    }

    public sealed class MotorolaRadio
    {
        private bool enabled;

        private byte? selectedChannel;

        public MotorolaRadio()
        {
            enabled = false;
        }

        public void PowerOn(string pincode)
        {
            if (pincode == "1234")
            {
                enabled = true;
            }
        }

        public void SelectChannel(byte channel)
        {
            this.selectedChannel = channel;
        }

        public void Send(string message)
        {
            if (enabled && selectedChannel!=null)
            {
                Console.WriteLine($"<Xml><Send Channel={selectedChannel}><Message>{message}</Message></xml>");
            }
        }

        public void PowerOff()
        {
            enabled = false;
        }



    }
}
