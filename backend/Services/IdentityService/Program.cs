using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/api/auth/login", (LoginRequest request) =>
{
    if (request.Email == "admin@shop.com" && request.Password == "Admin@123")
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("THIS_IS_DEMO_SECRET_KEY_CHANGE_IT_12345"));
        var token = new JwtSecurityToken(claims: new[] { new Claim(ClaimTypes.Email, request.Email), new Claim(ClaimTypes.Role, "Admin") }, expires: DateTime.UtcNow.AddHours(2), signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
        return Results.Ok(new { accessToken = new JwtSecurityTokenHandler().WriteToken(token), refreshToken = Guid.NewGuid().ToString() });
    }
    return Results.Unauthorized();
});
app.MapPost("/api/auth/register", (RegisterRequest request) => Results.Ok(new { message = "User registered successfully", request.Email }));
app.Run();
record LoginRequest(string Email, string Password);
record RegisterRequest(string Name, string Email, string Password);
