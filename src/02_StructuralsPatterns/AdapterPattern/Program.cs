using NGeoHash;
using System;

namespace AdapterPattern
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Adapter Pattern!");

            MotorolaRadioTest();

            HyteraRadioTest();

        }

        private static void MotorolaRadioTest()
        {
            IRadioAdapter radio = RadioAdapterFactory.Create("Motorola");
            radio.SendMessage("Hello World!", 10);
        }

        private static void HyteraRadioTest()
        {
            IRadioAdapter radio = RadioAdapterFactory.Create("Hytera");           
            radio.SendMessage("Hello World!", 10);
            
        }
    }

    


}
