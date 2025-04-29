using Bus.Api;

namespace Bus.Listener;

public abstract class EmittedEventListener : IEventListener
{
    public abstract void Invoke(Event message);
}
