using System;
using Bus.Api;

namespace Bus.Tests;

public interface ISpecialEvent;

public class SpecialEvent: Event, ISpecialEvent;

public class NotSpecialEvent : Event;

public class MyThingWithSpecialEventListener
{
    [SubscribeEvent]
    public static void MyEventListener(SpecialEvent @event) { }
}

public class MyThingWithNotSpecialEventListener
{
    [SubscribeEvent]
    public static void MyEventListener(NotSpecialEvent @event) { }
}

public class MarkerTypetest
{
    [Fact]
    public void TestSpecialListener()
    {
        var bus = new BusConfiguration {
            MarkerType = typeof(ISpecialEvent)
        }.Build();
        bus.Register(typeof(MyThingWithSpecialEventListener));
    }

    [Fact]
    public void TestNotSpecialListener()
    {
        var bus = new BusConfiguration {
            MarkerType = typeof(ISpecialEvent)
        }.Build();
        Assert.Throws<ArgumentOutOfRangeException>(() => bus.Register(typeof(MyThingWithNotSpecialEventListener)));
    }
}
