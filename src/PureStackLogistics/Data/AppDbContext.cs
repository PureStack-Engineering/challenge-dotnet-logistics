using Microsoft.EntityFrameworkCore;
using PureStackLogistics.Models;

namespace PureStackLogistics.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }
}
