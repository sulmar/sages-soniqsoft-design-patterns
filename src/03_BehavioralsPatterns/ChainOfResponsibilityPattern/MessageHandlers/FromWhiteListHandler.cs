using System;
using System.Linq;
using ChainOfResponsibilityPattern.Models;

namespace ChainOfResponsibilityPattern.MessageHandlers
{
    // Concrete Handler
    public class FromWhiteListHandler : MessageHandler
    {
        private readonly string[] whiteList;

        public FromWhiteListHandler(string[] whiteList) : base()
        {
            this.whiteList = whiteList;
        }

        public override void Handle(Message message)
        {
            if (!whiteList.Contains(message.From))
            {
                throw new Exception();
            }

            base.Handle(message);
        }
    }
}
