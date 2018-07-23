using Akka.Actor;
using Akka.Event;
using Simulator.Log;

namespace Simulator
{
    internal abstract class AbstractReceiveActor : ReceiveActor
    {
        protected ILoggingAdapter Log { get; private set; }

        protected AbstractReceiveActor()
        {
            Log = new Logger(Context);
        }
    }
}
