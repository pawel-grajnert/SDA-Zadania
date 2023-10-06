using Microsoft.EntityFrameworkCore;
using ProductManagement.Mvc.Domain.Models;

namespace ProductManagement.Mvc.Repository.Context;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Product> Products { get; set; }
}