using Akka.Actor;
using Simulator.Data;
using System;

namespace Simulator
{
    internal class UserActor : AbstractReceiveActor
    {
        private UserCredentials _userCredentials;

        public string Username => _userCredentials.Name;
        public ConsoleColor Color = ConsoleColor.White;

        public UserActor(UserCredentials userCredentials)
        {
            _userCredentials = userCredentials;
        }

        // change color
    }
}
