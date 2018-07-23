using Akka.Actor;

namespace Simulator.Messages
{
    internal class UserCreated
    { 
        public IActorRef User { get; private set; }

        public UserCreated(IActorRef user)
        {
            User = user;
        }
    }
}
