using ChainOfResponsibilityPattern.Models;

namespace ChainOfResponsibilityPattern.MessageHandlers
{
    // Abstract Handler
    //  Abstrakcyjna klasa reprezentująca obsługę przetwarzania wiadomości email
    public abstract class MessageHandler
    {
        protected MessageHandler next;

        public MessageHandler SetNextHandler(MessageHandler next)
        {
            return this.next = next;
        }

        public virtual void Handle(Message message) => next?.Handle(message);
    }
}
