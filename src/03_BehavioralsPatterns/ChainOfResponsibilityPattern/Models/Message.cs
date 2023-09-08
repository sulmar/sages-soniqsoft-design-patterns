using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ChainOfResponsibilityPattern.MessageHandlers;

namespace ChainOfResponsibilityPattern.Models
{
    public class Message
    {
        public string From { get; set; }
        public string Title { get; set; }   
        public string Body { get; set; }
    }

    public class MessageProcessor
    {
        private readonly MessageHandler messageHandler;

        public MessageProcessor()
        {
            string[] whiteList = new string[] { "john@domain.com", "bob@domain.com" };

            // Inicjalizacja łańcucha odpowiedzialności
            messageHandler = new FromWhiteListHandler(whiteList);
            var titleContainsMessageHandler = new TitleContainsHandler("Order");
            var taxNumberMessageHandler = new TaxNumberHandler();

            messageHandler
                .SetNextHandler(titleContainsMessageHandler)
                .SetNextHandler(taxNumberMessageHandler);

        }

        public string Process(Message message)
        {
            messageHandler.Handle(message);

            return string.Empty;
        }
    }
}
