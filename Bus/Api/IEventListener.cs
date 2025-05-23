namespace Bus.Api;

/// <summary>
/// Represents a message subscription
/// </summary>
public interface IEventListener
{
    /// <summary>
    /// Invoke the message
    /// </summary>
    /// <param name="message">Message to deliver</param>
    void Invoke(Event message);
}
