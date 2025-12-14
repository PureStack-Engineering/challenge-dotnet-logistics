using Microsoft.EntityFrameworkCore;
using PureStackLogistics.Data;
using PureStackLogistics.Models;
using PureStackLogistics.Services;
using Xunit;

namespace PureStackLogistics.Tests;

public class InventoryTests
{
    [Fact]
    public void AddProduct_ShouldMarkHazardous_WhenNameContainsHazardous()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb_Hazardous")
            .Options;
        
        using var context = new AppDbContext(options);
        var service = new InventoryService(context);

        // Act
        service.AddProduct(new Product { Name = "Hazardous Chemical", Price = 10, Category = "Chem" });

        // Assert
        var product = context.Products.FirstOrDefault();
        Assert.NotNull(product);
        Assert.True(product.IsHazardous, "Product should be marked as IsHazardous");
    }
}
