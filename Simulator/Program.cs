using Akka.Actor;
using Simulator.Messages;
using System;

namespace Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var actorSystem = ActorSystem.Create("IDGActorSystem");
            var userManager = actorSystem.ActorOf(Props.Create(() => new UserManagerActor()));
            var chatRoomManager = actorSystem.ActorOf(Props.Create(() => new ChatRoomManagerActor()));
            var consoleActor = actorSystem.ActorOf(Props.Create(() => new ChatConsoleActor(userManager, chatRoomManager)));

            while (true)
            {
                var line = Console.ReadLine();
                consoleActor.Tell(new SendConsoleLine(line));
            }
        }
    }
}
