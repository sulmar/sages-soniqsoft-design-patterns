using System;
using System.Text.RegularExpressions;
using ChainOfResponsibilityPattern.Models;

namespace ChainOfResponsibilityPattern.MessageHandlers
{
    // Concrete Handler
    public class TaxNumberHandler : MessageHandler
    {
        private const string pattern = @"\b(\d{10}|\d{3}-\d{3}-\d{2}-\d{2})\b";
        private Regex regex = new Regex(pattern);
     
        public override void Handle(Message message)
        {
            Match match = regex.Match(message.Body);

            if (match.Success)
            {
                string taxNumber = match.Value;
            }
            else
            {
                throw new FormatException();
            }

            base.Handle(message);
        }
    }
}
