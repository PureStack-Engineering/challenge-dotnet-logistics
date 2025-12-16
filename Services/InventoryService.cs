using PureStackLogistics.Data;
using PureStackLogistics.Models;
using Microsoft.EntityFrameworkCore;

namespace PureStackLogistics.Services;

public class InventoryService : IInventoryService
{
    private readonly AppDbContext _context;

    public InventoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Product> AddProductAsync(Product product)
    {
        // TODO: Candidate needs to implement validations here (Level 3/2)
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<IEnumerable<Product>> GetStockAsync(string? category)
    {
        // TODO: Candidate needs to implement efficient LINQ filtering here
        var query = _context.Products.AsQueryable();

        if (!string.IsNullOrEmpty(category))
        {
            query = query.Where(p => p.Category == category);
        }

        return await query.ToListAsync();
    }
}
