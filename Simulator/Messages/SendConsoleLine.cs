namespace Simulator.Messages
{
    internal class SendConsoleLine
    {
        public string Text { get; private set; }

        public SendConsoleLine(string text)
        {
            Text = text;
        }
    }
}
