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
            actorSystem.ActorOf(Props.Create(() => new ChatConsoleActor()));

            while(true)
            {
                
            }
        }
    }
}
