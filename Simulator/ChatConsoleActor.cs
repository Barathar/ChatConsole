using Akka.Actor;
using Simulator.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simulator
{
    internal class ChatConsoleActor : ReceiveActor
    {
        IActorRef User;

        public ChatConsoleActor()
        {
            var userManager = Context.ActorOf(Props.Create(() => new UserManagerActor()));
            userManager.Tell(new CreateUser("Barathar"));

            Receive<UserCreated>(message =>
            {
                User = message.User;
                Become(LoggedIn);
            });

        }

        private void LoggedIn()
        {
            while (true)
            {
                var message = Console.ReadLine();
                if (ContainsCommand(message))
                {
                    HandleCommand(message);
                }
                else
                {
                    User.Tell(new SendMessage("Me", message));
                }
            }
        }

        private static void HandleCommand(string message)
        {
            if (message.Contains("\\clear"))
            {
                Console.Clear();
            }
        }

        private static bool ContainsCommand(string message)
        {
            // better use regular expression here!

            if (message.Contains("\\clear"))
                return true;

            //if (message.Contains("\\whois"))

            return false;

        }
    }
}
