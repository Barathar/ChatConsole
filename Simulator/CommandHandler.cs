using System;
using System.Collections.Generic;
using System.Linq;
using Simulator.Data;

namespace Simulator
{
    internal class CommandHandler
    {
        private List<Command> _commands;
     
        public event EventHandler LoginUser;
        public event EventHandler LogoutUser;
        public event EventHandler ClearConsole;
        public event EventHandler ShowUsers;
        public event EventHandler JoinChat;

        public CommandHandler()
        {
            _commands = new List<Command>();

            RegisterCommands();
        }

        public bool ContainsCommand(string text)
        {
            // better use regexpression here.
            return _commands.Any(c => text.Contains(c.Trigger));
        }
        public void HandleCommands(string text)
        {
            // better use regexpression here.
            _commands.First(c => text.Contains(c.Trigger)).Action();            
        }

        private void RegisterCommands()
        {
            _commands.Add(new Command("LoginUser", "\\login", () => LoginUser?.Invoke(this, new EventArgs())));
            _commands.Add(new Command("LogoutUser", "\\logout", () => LogoutUser?.Invoke(this, new EventArgs())));
            _commands.Add(new Command("ClearConsole", "\\clear", () => ClearConsole?.Invoke(this, new EventArgs())));
            _commands.Add(new Command("ShowUsers", "\\whois", () => ShowUsers?.Invoke(this, new EventArgs())));
            _commands.Add(new Command("JoinChat", "\\join", () => JoinChat?.Invoke(this, new EventArgs())));
        }
    }
}
