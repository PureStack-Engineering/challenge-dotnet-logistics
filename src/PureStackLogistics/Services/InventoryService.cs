using PureStackLogistics.Data;
using PureStackLogistics.Models;

namespace PureStackLogistics.Services;

public interface IInventoryService
{
    void AddProduct(Product product);
    IEnumerable<Product> GetProductsByCategory(string category);
}

public class InventoryService : IInventoryService
{
    private readonly AppDbContext _context;

    // TODO: Implement Dependency Injection via Constructor
    public InventoryService(AppDbContext context)
    {
        _context = context;
    }

    public void AddProduct(Product product)
    {
        // TODO: 
        // 1. Validate Price > 0
        // 2. If Name contains "Hazardous", set IsHazardous = true
        // 3. Add to _context and SaveChanges
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetProductsByCategory(string category)
    {
        // TODO: Use LINQ to filter by category
        throw new NotImplementedException();
    }
}
