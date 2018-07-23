using Akka.Actor;
using Simulator.Data;
using Simulator.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simulator
{
    internal class ChatConsoleActor : AbstractReceiveActor
    {
        private IActorRef _userManager;
        private IActorRef _chatRoomManager;
        private CommandHandler _commandHandler;

        private IActorRef _user;
        private IActorRef _chatRoom;

        public ChatConsoleActor(IActorRef userManager, IActorRef chatRoomManager)
        {
            _userManager = userManager;
            _chatRoomManager = chatRoomManager;
            _commandHandler = new CommandHandler();

            RegisterEvents();

            Receive<SendConsoleLine>(message =>
            {
                if (_commandHandler.ContainsCommand(message.Text))
                {
                    _commandHandler.HandleCommands(message.Text);
                }
                else
                {
                    _chatRoom?.Tell(new SendMessage(_user, message.Text));
                }
            });

            Receive<UserLoggedIn>(message =>
            {
                _user = message.User;
                Log.Info($"User '{message.User}' logged in.");
            });

            Receive<ChatJoined>(message =>
            {
                _chatRoom = message.ChatRoom;
                Log.Info($"User joined chat '{message.ChatRoom}'.");
            });
        }

        private void RegisterEvents()
        {
            _commandHandler.LoginUser += OnLoginUser;
            _commandHandler.ClearConsole += OnClearConsole;
            _commandHandler.JoinChat += OnJoinChat;
        }

        private void OnLoginUser(object sender, EventArgs e)
        {
            var credentials = new UserCredentials("Barathar", "currentPass");
            _userManager.Tell(new LoginUser(credentials));
        }
        private void OnClearConsole(object sender, EventArgs e)
        {
            Console.Clear();
        }
        private void OnJoinChat(object sender, EventArgs e)
        {
            _chatRoomManager.Tell(new JoinChat("Ye banished"));
        }
    }
}
