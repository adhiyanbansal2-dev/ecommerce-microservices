var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var carts = new Dictionary<string, List<CartItem>>();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/api/cart/{userId}", (string userId) => carts.TryGetValue(userId, out var cart) ? cart : new List<CartItem>());
app.MapPost("/api/cart/{userId}", (string userId, CartItem item) =>
{
    if (!carts.ContainsKey(userId)) carts[userId] = new();
    carts[userId].Add(item);
    return Results.Ok(carts[userId]);
});
app.MapDelete("/api/cart/{userId}", (string userId) => { carts.Remove(userId); return Results.NoContent(); });
app.Run();
record CartItem(int ProductId, string ProductName, int Quantity, decimal Price);
