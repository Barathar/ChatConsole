using System;
using System.Collections.Generic;
using System.Text;

namespace Simulator.Messages
{
    internal class JoinChat
    { 
        public string Chatname { get; private set; }
        // better use User class here
        public string Username { get; private set; }

        public JoinChat(string chatname, string username)
        {
            Chatname = chatname;
            Username = username;
        }
    }
}
