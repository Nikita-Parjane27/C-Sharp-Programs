public class EventBus
{
    private static List<string> _eventLog = new();

    public void Publish(object eventData)
    {
        string log = $"[{DateTime.Now}] Event: {eventData.GetType().Name} | Data: {System.Text.Json.JsonSerializer.Serialize(eventData)}";
        _eventLog.Add(log);
        Console.WriteLine(log);
    }

    public List<string> GetEventLog() => _eventLog;
}