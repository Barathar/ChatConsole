using Akka.Actor;

namespace Simulator.Messages
{
    internal class JoinChat
    {
        public string Chatname { get; private set; }

        public JoinChat(string chatname)
        {
            Chatname = chatname;
        }
    }
}
