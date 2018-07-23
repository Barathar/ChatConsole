using Akka.Actor;

namespace Simulator.Messages
{
    internal class SendMessage
    {
        public IActorRef User { get; private set; }
        public string Message { get; private set; }

        public SendMessage(IActorRef user, string message)
        {
            User = user;
            Message = message;
        }
    }
}
