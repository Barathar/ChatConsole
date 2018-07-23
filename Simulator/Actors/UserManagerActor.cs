using Akka.Actor;
using Simulator.Data;
using Simulator.Messages;
using System.Collections.Generic;
using System.Linq;

namespace Simulator
{
    internal class UserManagerActor : AbstractReceiveActor
    {
        private Dictionary<string, IActorRef> _users;

        public UserManagerActor()
        {
            _users = new Dictionary<string, IActorRef>();

            Receive<LoginUser>(message =>
            {
                if (Exists(message.Credentials))
                {
                    Login(message.Credentials);
                }
                else
                {
                    Create(message.Credentials);
                }
            });

            // LogoutUser
            // RenameUser           
        }



        private bool Exists(UserCredentials credentials)
        {
            return _users.Any(u => u.Key == credentials.Name);
        }

        private void Login(UserCredentials credentials)
        {
            var user = _users.First(u => u.Key == credentials.Name);
            Sender.Tell(new UserLoggedIn(user.Value));
        }

        private void Create(UserCredentials credentials)
        {
            var user = Context.ActorOf(Props.Create(() => new UserActor(credentials)));
            _users.Add(credentials.Name, user);
            Sender.Tell(new UserLoggedIn(user));
        }

        // TODO Events persistieren -> UserCreated
    }
}
