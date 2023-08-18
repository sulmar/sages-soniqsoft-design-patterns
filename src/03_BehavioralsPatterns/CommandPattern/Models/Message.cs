using System;
using System.Runtime.CompilerServices;

namespace CommandPattern
{
    // Abstract Command
    public interface ICommand
    {
        void Execute();
    }

    public class SendCommand : ICommand
    {
        private readonly Message message;

        public SendCommand(Message message)
        {
            this.message = message;
        }

        public void Execute()
        {
            Console.WriteLine($"Send message from <{message.From}> to <{message.To}> {message.Content}");
        }
    }

    public class PrintCommand : ICommand
    {
        private readonly Message message;
        private readonly int copies;

        public PrintCommand(Message message, int copies = 1)
        {
            this.message = message;
            this.copies = copies;
        }

        public void Execute()
        {
            for (int i = 0; i < copies; i++)
            {
                Console.WriteLine($"Print message from <{message.From}> to <{message.To}> {message.Content}");
            }
        }
    }

    public class Message
    {
        public Message(string from, string to, string content)
        {
            From = from;
            To = to;
            Content = content;
        }

        public string From { get; set; }
        public string To { get; set; }
        public string Content { get; set; }

     
      

        public bool CanSend()
        {
            return !(string.IsNullOrEmpty(From) || string.IsNullOrEmpty(To) || string.IsNullOrEmpty(Content));
        }

       
        public bool CanPrint()
        {
            return string.IsNullOrEmpty(Content);
        }



    }

}
