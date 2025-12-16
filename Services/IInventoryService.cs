using PureStackLogistics.Models;

namespace PureStackLogistics.Services;

public interface IInventoryService
{
    Task<Product> AddProductAsync(Product product);
    Task<IEnumerable<Product>> GetStockAsync(string? category);
}
