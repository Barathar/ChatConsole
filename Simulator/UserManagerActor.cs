using Akka.Actor;
using Simulator.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simulator
{
    internal class UserManagerActor : ReceiveActor
    {
        private List<UserActor> Users { get; set; }

        public UserManagerActor()
        {
            Receive<CreateUser>(message =>
            {
                var user = Context.ActorOf(Props.Create(() => new UserActor(message.Username)));
                Sender.Tell(new UserCreated(user));
            });
            // kommert sich um die verwaltung der user... 
            // handelt user einlogg anfragen und erzeugt ggf neuen useractor.

            // event create user....
        }
    }
}
