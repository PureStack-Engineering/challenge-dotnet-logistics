using Microsoft.EntityFrameworkCore;
using PureStackLogistics.Data;
using PureStackLogistics.Models;
using PureStackLogistics.Services;
using Xunit;
using FluentAssertions;

namespace PureStackLogistics.Tests;

public class InventoryTests
{
    private AppDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        return new AppDbContext(options);
    }

    [Fact]
    public async Task AddProduct_ShouldSaveToDatabase()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var service = new InventoryService(context);
        var product = new Product 
        { 
            Name = "Laptop", 
            Price = 1200, 
            Stock = 10, 
            Category = "Electronics" 
        };

        // Act
        var result = await service.AddProductAsync(product);

        // Assert
        result.Id.Should().BeGreaterThan(0);
        context.Products.Count().Should().Be(1);
    }
}
