using Microsoft.EntityFrameworkCore;
using ProductService.Models;
namespace ProductService.Data;
public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
    public DbSet<Product> Products => Set<Product>();
    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 75000, Stock = 10 },
            new Product { Id = 2, Name = "Mouse", Category = "Electronics", Price = 900, Stock = 100 },
            new Product { Id = 3, Name = "Keyboard", Category = "Electronics", Price = 1500, Stock = 60 }
        );
    }
}
