using Akka.Actor;
using Simulator.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simulator
{
    internal class ChatRoomManagerActor : AbstractReceiveActor
    {
        private Dictionary<string, IActorRef> _chatRooms;

        public ChatRoomManagerActor()
        {
            _chatRooms = new Dictionary<string, IActorRef>();

            Receive<JoinChat>(message =>
            {
                if (Exists(message.Chatname))
                {
                    Join(message.Chatname);
                }
                else
                {
                    Create(message.Chatname);
                }
            });

            // Leave
        }

        private bool Exists(string chatname)
        {
            return _chatRooms.Any(c => c.Key == chatname);
        }

        private void Join(string chatname)
        {
            var chatRoom = _chatRooms.First(u => u.Key == chatname);
            Sender.Tell(new ChatJoined(chatRoom.Value));
        }
        private void Create(string chatname)
        {
            var chatRoom = Context.ActorOf(Props.Create(() => new ChatRoomActor(chatname)));
            _chatRooms.Add(chatname, chatRoom);
            Sender.Tell(new ChatJoined(chatRoom));
        }
    }
}
