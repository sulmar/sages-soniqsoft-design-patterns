using System;

namespace AdapterPattern
{
    // Abstract Adapter
    public interface IRadioAdapter
    {
        void SendMessage(string message, byte channel);
    }

    public class RadioAdapterFactory
    {
        public static IRadioAdapter Create(string config)
        {
            switch(config)
            {
                case "Motorola": return new MotorolaRadioAdapter("1234");
                case "Hytera": return new HyteraRadioAdapter();

                default: throw new NotSupportedException();
            }
        }
    }


    // Concrete Adapter A
    public class HyteraRadioAdapter : IRadioAdapter
    {
        // Adaptee
        private readonly HyteraRadio radio = new HyteraRadio();

        public void SendMessage(string message, byte channel)
        {
            radio.Init();
            radio.SendMessage(channel, message);
            radio.Release();
        }
    }

    // Adaptee
    public sealed class HyteraRadio
    {

        private RadioStatus status;

        public void Init()
        {
            status = RadioStatus.On;
        }

        public void SendMessage(byte channel, string content)
        {
            if (status == RadioStatus.On)
            {
                Console.WriteLine($"CHANNEL {channel}, MESSAGE {content}");
            }
        }

        public void Release()
        {
            status = RadioStatus.Off;
        }

        public enum RadioStatus
        {
            On,
            Off
        }

    }
}
