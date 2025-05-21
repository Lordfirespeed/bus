using System;

namespace Bus.Api;

public record BusConfiguration
{
    public bool StartImmediately { get; init; } = true;

    public IEventClassChecker ClassChecker { get; init; } = (eventClass) => { };

    public Type MarkerType {
        init {
            if (!value.IsInterface) throw new ArgumentException("Marker type must be an interface.");
            ClassChecker = (eventType) => {
                if (value.IsAssignableFrom(eventType)) return;
                throw new ArgumentOutOfRangeException(
                    nameof(eventType),
                    eventType,
                    $"This bus only accepts subtypes of {value}, which {eventType} is not."
                );
            };
        }
    }

    public IEventBus Build() => new EventBus(this);
}
