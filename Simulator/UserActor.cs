using Akka.Actor;
using Simulator.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simulator
{
    internal class UserActor : ReceiveActor
    {
        private IActorRef ChatRoom { get; set; }
        public string Username { get; private set; }

        public UserActor(string username)
        {
            Username = username;

            //hier nach chatroom anfragen... fürs erste jedoch...
            ChatRoom = Context.ActorOf(Props.Create(() => new ChatRoomActor("Ye banished")));

            Receive<SendMessage>(message =>
            {
                ChatRoom.Forward(message);
            });
        }
        //chatRoomActor.Tell(new TextMessage(message));
    }
}
