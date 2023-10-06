using ProductManagement.Mvc.Domain.Models;

namespace ProductManagement.Mvc.Domain.Abstractions.Interfaces;

public interface IProductService
{
    Task<List<Product>> GetAllAsync();
    Task<Product> GetAsync(int id);
    Task Create(Product product);
    Task Update(Product product);
    Task DeleteAsync(int id);
}