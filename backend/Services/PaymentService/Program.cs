var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapPost("/api/payments", (PaymentRequest request) => Results.Ok(new { paymentId = Guid.NewGuid(), request.OrderId, status = "Success" }));
app.Run();
record PaymentRequest(Guid OrderId, decimal Amount, string PaymentMode);
