using System;
using Bus.Api;
using Bus.Tests.Utils;

namespace Bus.Tests;

public class MyEvent(Action pAction) : Event
{
    public readonly Action Action = pAction;
}

public class MyThingWithStaticListener
{
    [SubscribeEvent]
    public static void MyEventListener(MyEvent @event)
    {
        @event.Action();
    }
}

public class MyThingWithInstanceListener
{
    [SubscribeEvent]
    public void MyEventListener(MyEvent @event)
    {
        @event.Action();
    }
}

public class SimpleEndToEndTest
{
    [Fact]
    public void TestStaticListener()
    {
        var bus = new BusConfiguration().Build();
        bus.Register(typeof(MyThingWithStaticListener));
        var spy = new Spy();
        var @event = new MyEvent(spy.Callable);
        bus.Post(@event);
        spy.VerifyCalledOnce();
    }

    [Fact]
    public void TestInstanceListener()
    {
        var bus = new BusConfiguration().Build();
        var thing = new MyThingWithInstanceListener();
        bus.Register(thing);
        var spy = new Spy();
        var @event = new MyEvent(spy.Callable);
        bus.Post(@event);
        spy.VerifyCalledOnce();
    }
}
