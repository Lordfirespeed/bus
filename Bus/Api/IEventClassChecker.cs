using System;

namespace Bus.Api;

/// <summary>
/// If the event class should be accepted for the bus, does nothing.
/// If it should not be accepted, throws an <see cref="ArgumentOutOfRangeException"/>.
/// </summary>
/// <exception cref="ArgumentOutOfRangeException">if the event class is not valid.</exception>
/// <param name="eventType"></param>
public delegate void IEventClassChecker(Type eventType);
