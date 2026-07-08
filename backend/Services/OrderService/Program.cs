var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var orders = new List<Order>();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapPost("/api/orders", (CreateOrderRequest request) =>
{
    var order = new Order(Guid.NewGuid(), request.UserId, request.TotalAmount, "Created", DateTime.UtcNow);
    orders.Add(order);
    // In production, publish OrderCreated event to RabbitMQ here.
    return Results.Created($"/api/orders/{order.Id}", order);
});
app.MapGet("/api/orders/{userId}", (string userId) => orders.Where(x => x.UserId == userId));
app.Run();
record CreateOrderRequest(string UserId, decimal TotalAmount);
record Order(Guid Id, string UserId, decimal TotalAmount, string Status, DateTime CreatedAt);
