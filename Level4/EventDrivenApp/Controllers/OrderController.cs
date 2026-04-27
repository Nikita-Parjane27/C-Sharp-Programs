using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly OrderEventHandler _handler;
    private readonly EventBus          _eventBus;
    private static int _nextOrderId = 1;

    public OrderController(OrderEventHandler handler, EventBus eventBus)
    {
        _handler  = handler;
        _eventBus = eventBus;
    }

    [HttpPost("place")]
    public IActionResult PlaceOrder(string productName, int quantity, double totalAmount)
    {
        var e = new OrderPlacedEvent
        {
            OrderId     = _nextOrderId++,
            ProductName = productName,
            Quantity    = quantity,
            TotalAmount = totalAmount,
            PlacedAt    = DateTime.Now
        };
        _handler.Handle(e);
        return Ok(new { Message = "Order placed!", OrderId = e.OrderId });
    }

    [HttpPost("cancel/{orderId}")]
    public IActionResult CancelOrder(int orderId, string reason)
    {
        var e = new OrderCancelledEvent
        {
            OrderId     = orderId,
            Reason      = reason,
            CancelledAt = DateTime.Now
        };
        _handler.Handle(e);
        return Ok(new { Message = "Order cancelled!", OrderId = orderId });
    }

    [HttpGet("events")]
    public IActionResult GetEvents()
        => Ok(_eventBus.GetEventLog());
}