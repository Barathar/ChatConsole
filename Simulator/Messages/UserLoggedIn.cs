using Akka.Actor;

namespace Simulator.Messages
{
    internal class UserLoggedIn
    { 
        public IActorRef User { get; private set; }

        public UserLoggedIn(IActorRef user)
        {
            User = user;
        }
    }
}
