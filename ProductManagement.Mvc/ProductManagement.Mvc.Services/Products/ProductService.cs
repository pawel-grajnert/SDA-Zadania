using System.Net;
using ProductManagement.Mvc.Domain.Abstractions.Interfaces;
using ProductManagement.Mvc.Domain.Models;
using ProductManagement.Mvc.Domain.Types;

namespace ProductManagement.Mvc.Services.Products;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _repository;

    public ProductService(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        var products = await _repository.GetAllAsync();

        return products.ToList();
    }

    public async Task<Product> GetAsync(int id)
    {
        var product = await _repository.GetAsync(id);

        if (product == null)
        {
            throw new ProductManagementException(HttpStatusCode.NotFound, $"There is no product with id: {id} in DataBase");
        }

        return product;
    }

    public async Task Create(Product product)
    {
        if (string.IsNullOrWhiteSpace(product.Name))
        {
            throw new ProductManagementException(HttpStatusCode.NotAcceptable, "Product name cannot be null or empty!");
        }

        product.IsActive = true;
        product.CreateDate = DateTime.Now;
        product.UpdateDate = default;

        await _repository.Create(product);
    }

    public async Task Update(Product product)
    {
        if (string.IsNullOrWhiteSpace(product.Name))
        {
            throw new ProductManagementException(HttpStatusCode.NotAcceptable, "Product name cannot be null or empty!");
        }

        var productToUpdate = await _repository.GetAsync(product.Id);

        if (productToUpdate == null)
        {
            throw new ProductManagementException(HttpStatusCode.NotFound, $"Product with id {product.Id} not exists!");
        }

        productToUpdate.Name = product.Name;
        productToUpdate.Description = product.Description;
        productToUpdate.Price = product.Price;
        productToUpdate.UpdateDate = DateTime.Now;

        await _repository.Update(productToUpdate);
    }

    public async Task DeleteAsync(int id)
    {
        var productToDelete = await _repository.GetAsync(id);

        if (productToDelete == null)
        {
            throw new ProductManagementException(HttpStatusCode.NotFound, $"Product with id {id} not exists!");
        }

        await _repository.DeleteAsync(productToDelete);
    }
}