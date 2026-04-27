public class OrderPlacedEvent
{
    public int    OrderId     { get; set; }
    public string ProductName { get; set; }
    public int    Quantity    { get; set; }
    public double TotalAmount { get; set; }
    public DateTime PlacedAt  { get; set; }
}

public class OrderCancelledEvent
{
    public int    OrderId { get; set; }
    public string Reason  { get; set; }
    public DateTime CancelledAt { get; set; }
}