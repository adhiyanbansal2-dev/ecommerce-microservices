using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/api/products", async (ProductDbContext db, string? search, string? category, int page = 1, int pageSize = 10) =>
{
    var query = db.Products.AsQueryable();
    if (!string.IsNullOrWhiteSpace(search)) query = query.Where(x => x.Name.Contains(search));
    if (!string.IsNullOrWhiteSpace(category)) query = query.Where(x => x.Category == category);
    var total = await query.CountAsync();
    var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
    return Results.Ok(new { total, page, pageSize, items });
});

app.MapGet("/api/products/{id:int}", async (ProductDbContext db, int id) =>
    await db.Products.FindAsync(id) is Product p ? Results.Ok(p) : Results.NotFound());

app.MapPost("/api/products", async (ProductDbContext db, Product product) =>
{
    db.Products.Add(product);
    await db.SaveChangesAsync();
    return Results.Created($"/api/products/{product.Id}", product);
});

app.Run();
