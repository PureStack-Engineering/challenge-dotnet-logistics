using Microsoft.EntityFrameworkCore;
using PureStackLogistics.Data;
using PureStackLogistics.Models;
using PureStackLogistics.Services;
using Xunit;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using System.Linq;

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

    // ==========================================
    // 1. BASIC CRUD & VALIDATIONS (Requirement 1)
    // ==========================================

    [Fact]
    public async Task AddProduct_ShouldSaveToDatabase_WhenValid()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var service = new InventoryService(context);
        var product = new Product 
        { 
            Name = "Gaming Laptop", 
            Price = 1200, 
            Stock = 10, 
            Category = "Electronics" 
        };

        var result = await service.AddProductAsync(product);

        result.Id.Should().BeGreaterThan(0, "the database should assign an ID");
        context.Products.Count().Should().Be(1);
    }

    [Theory] 
    [InlineData(0)]
    [InlineData(-10)]
    public async Task AddProduct_ShouldThrowException_WhenPriceIsInvalid(decimal invalidPrice)
    {

        var context = GetInMemoryDbContext();
        var service = new InventoryService(context);
        var product = new Product 
        { 
            Name = "Bad Price Item", 
            Price = invalidPrice, 
            Stock = 1, 
            Category = "Test" 
        };

        await Assert.ThrowsAsync<ArgumentException>(() => service.AddProductAsync(product));
    }

    [Fact]
    public async Task AddProduct_ShouldThrowException_WhenNameIsEmpty()
    {
      
        var context = GetInMemoryDbContext();
        var service = new InventoryService(context);
        var product = new Product 
        { 
            Name = "",
            Price = 100, 
            Stock = 1, 
            Category = "Test" 
        };

      
        await Assert.ThrowsAsync<ArgumentException>(() => service.AddProductAsync(product));
    }

    // ==========================================
    // 2. BUSINESS LOGIC (Requirement 3)
    // ==========================================

    [Theory]
    [InlineData("Industrial Chemical X", true)]
    [InlineData("Battery Acid", true)]
    [InlineData("Organic Apple", false)]
    public async Task AddProduct_ShouldSetHazardousFlag_BasedOnName(string name, bool expectedHazardous)
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var service = new InventoryService(context);
        var product = new Product 
        { 
            Name = name, 
            Price = 50, 
            Stock = 10, 
            Category = "Industrial" 
        };

      
        var result = await service.AddProductAsync(product);

       
        result.IsHazardous.Should().Be(expectedHazardous, 
            $"products containing 'Chemical' or 'Acid' must be Hazardous. Name was: {name}");
    }

    // ==========================================
    // 3. LINQ MASTERY & FILTERING (Requirement 2)
    // ==========================================

    [Fact]
    public async Task GetStock_ShouldFilterByCategory_WhenCategoryProvided()
    {
       
        var context = GetInMemoryDbContext();
        context.Products.AddRange(
            new Product { Name = "Banana", Category = "Food", Price = 1, Stock = 100 },
            new Product { Name = "Apple", Category = "Food", Price = 1, Stock = 100 },
            new Product { Name = "Mouse", Category = "Electronics", Price = 20, Stock = 50 },
            new Product { Name = "Keyboard", Category = "Electronics", Price = 50, Stock = 30 }
        );
        await context.SaveChangesAsync();

        var service = new InventoryService(context);

      
        var foodItems = await service.GetStockAsync("Food");
        var techItems = await service.GetStockAsync("Electronics");

       
        foodItems.Should().HaveCount(2);
        techItems.Should().HaveCount(2);
      
        foodItems.All(p => p.Category == "Food").Should().BeTrue();
    }

    [Fact]
    public async Task GetStock_ShouldReturnAll_WhenCategoryIsNull()
    {
      
        var context = GetInMemoryDbContext();
        context.Products.Add(new Product { Name = "A", Category = "C1", Price = 10, Stock = 1 });
        context.Products.Add(new Product { Name = "B", Category = "C2", Price = 10, Stock = 1 });
        await context.SaveChangesAsync();

        var service = new InventoryService(context);

     
        var allItems = await service.GetStockAsync(null);

        allItems.Should().HaveCount(2);
    }
}
