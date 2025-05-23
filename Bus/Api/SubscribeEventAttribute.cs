using System;

namespace Bus.Api;

[AttributeUsage(AttributeTargets.Method)]
public class SubscribeEventAttribute : Attribute
{
    public EventPriority Priority { get; }
    public bool ReceiveCancelled { get; }

    public SubscribeEventAttribute() : this(false) { }

    public SubscribeEventAttribute(bool receiveCancelled) : this(EventPriority.Normal, receiveCancelled) { }

    public SubscribeEventAttribute(EventPriority priority, bool receiveCancelled = false)
    {
        Priority = priority;
        ReceiveCancelled = receiveCancelled;
    }
}
