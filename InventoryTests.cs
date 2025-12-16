using Microsoft.EntityFrameworkCore;
using PureStackLogistics.Data;
using PureStackLogistics.Models;
using PureStackLogistics.Services;
using Xunit;
using FluentAssertions;

namespace PureStackLogistics.Tests;

public class InventoryTests
{
    // Helper to create a fresh DB for each test
    private AppDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        return new AppDbContext(options);
    }

    [Fact]
    public async Task AddProduct_ShouldPersistData_WhenValid()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var service = new InventoryService(context);
        var product = new Product { Name = "Test Item", Price = 100, Stock = 5, Category = "General" };

        // Act
        var result = await service.AddProductAsync(product);

        // Assert (Smoke Test)
        result.Id.Should().BeGreaterThan(0);
        context.Products.Count().Should().Be(1);
    }
}
