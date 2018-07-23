using Akka.Actor;
using Simulator.Messages;
using System;

namespace Simulator
{
    internal class ChatRoomActor : ReceiveActor
    {
        public string Chatname { get; private set; }

        public ChatRoomActor(string chatname)
        {
            Chatname = chatname;
            Console.WriteLine($"Chatroom '{chatname}' created.");

            Receive<SendMessage>(message =>
            {
                ShowMessage(message);
            });
        }

        private void ShowMessage(SendMessage message)
        {

            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] {message.Username}: {message.Message}");
        }
    }
}