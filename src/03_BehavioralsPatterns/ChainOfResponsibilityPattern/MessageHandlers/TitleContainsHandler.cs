using System;
using ChainOfResponsibilityPattern.Models;

namespace ChainOfResponsibilityPattern.MessageHandlers
{
    // Concrete Handler
    public class TitleContainsHandler : MessageHandler
    {
        private readonly string text;

        public TitleContainsHandler(string text) : base()
        {
            this.text = text;
        }

        public override void Handle(Message message)
        {
            if (!message.Title.Contains(text))
            {
                throw new Exception();
            }

            base.Handle(message);
        }
    }
}
