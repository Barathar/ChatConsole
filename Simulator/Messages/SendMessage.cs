namespace Simulator.Messages
{
    internal class SendMessage
    {
        public string Username { get; private set; }
        public string Message { get; private set; }

        public SendMessage(string username, string message)
        {
            Username = username;
            Message = message;
        }
    }
}
