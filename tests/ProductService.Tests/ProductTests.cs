using FluentAssertions;

namespace ProductService.Tests;

public class ProductTests
{
    [Fact]
    public void Product_Total_Should_Be_Calculated()
    {
        var price = 1000m;
        var quantity = 2;
        var total = price * quantity;
        total.Should().Be(2000m);
    }
}
