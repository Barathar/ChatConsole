using Akka.Actor;
using Simulator.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simulator
{
    internal class ChatRoomManager : ReceiveActor
    {
        private List<ChatRoomActor> ChatRooms { get; set; }

        public ChatRoomManager()
        {
            Receive<JoinChat>(message =>
            {
                if (ChatExists(message.Chatname))
                {
                    JoinExistingChat(message.Chatname);
                }
                else
                {
                    CreateChat(message.Chatname);
                }
            });
        }

        private bool ChatExists(string chatname)
        {
            return ChatRooms.Exists(c => c.Chatname == chatname);
        }

        private void JoinExistingChat(string chatname)
        {
            throw new NotImplementedException();
        }
        private void CreateChat(string chatname)
        {
            var chatRoom = Props.Create(() => new ChatRoomActor(chatname));
            //ChatRooms.Add(chatRoom);
        }
    }
}
