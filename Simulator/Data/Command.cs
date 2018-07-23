using System;

namespace Simulator.Data
{
    internal class Command
    {
        public string Name { get; private set; }
        public string Trigger { get; private set; }
        public Action Action;

        public Command(string name, string trigger, Action action)
        {
            Name = name;
            Trigger = trigger;
            Action = action;
        }
    }
}
