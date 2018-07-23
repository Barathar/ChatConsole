using System;
using System.Collections.Generic;
using System.Text;

namespace Simulator.Messages
{
    internal class CreateUser
    { 
        public string Username { get; private set; }

        public CreateUser(string username)
        {
            Username = username;
        }
    }
}
