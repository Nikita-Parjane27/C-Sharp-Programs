public class OrderEventHandler
{
    private readonly EventBus _eventBus;

    public OrderEventHandler(EventBus eventBus)
    {
        _eventBus = eventBus;
    }

    public void Handle(OrderPlacedEvent e)
    {
        Console.WriteLine($"Order #{e.OrderId} placed for {e.ProductName}");
        _eventBus.Publish(e);
    }

    public void Handle(OrderCancelledEvent e)
    {
        Console.WriteLine($"Order #{e.OrderId} cancelled. Reason: {e.Reason}");
        _eventBus.Publish(e);
    }
}