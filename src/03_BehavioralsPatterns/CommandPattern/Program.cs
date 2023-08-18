using System;
using System.Collections.Generic;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Command Pattern!");

            Message message = new Message("555000123", "555888000", "Hello World!");

            //if (message.CanPrint())
            //{
            //    message.Print();
            //}

            //if (message.CanSend())
            //{
            //    message.Send();
            //}    

            ICommand printCommand = new PrintCommand(message, 3);
            ICommand sendCommand = new SendCommand(message);

            Queue<ICommand> commands = new Queue<ICommand>();
            commands.Enqueue(printCommand);
            commands.Enqueue(printCommand);
            commands.Enqueue(printCommand);
            commands.Enqueue(sendCommand);
            commands.Enqueue(sendCommand);

            while( commands.Count > 0 )
            {
                ICommand command = commands.Dequeue();
                command.Execute();
            }
        }
    }

}
