using Akka.Actor;

namespace Simulator.Messages
{
    internal class ChatJoined
    {
        public IActorRef ChatRoom { get; private set; }

        public ChatJoined(IActorRef chatRoom)
        {
            ChatRoom = chatRoom;
        }
    }
}
