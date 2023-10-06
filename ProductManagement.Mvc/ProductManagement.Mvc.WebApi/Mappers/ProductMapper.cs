using ProductManagement.Mvc.Domain.Models;
using ProductManagement.Mvc.WebApi.ModelView.Products;

namespace ProductManagement.Mvc.WebApi.Mappers;

public static class ProductMapper
{
    public static ProductViewModel MapToViewModel(this Product model)
    {
        return new ProductViewModel()
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            CreateDate = model.CreateDate,
            UpdateDate = model.UpdateDate,
            Price = model.Price,
        };
    }

    public static Product MapToEntity(this ProductViewModel viewModel)
    {
        return new Product()
        {
            Id = viewModel.Id,
            Name = viewModel.Name,
            Description = viewModel.Description,
            CreateDate = viewModel.CreateDate.HasValue ? viewModel.CreateDate!.Value : default,
            UpdateDate = viewModel.UpdateDate.HasValue ? viewModel.UpdateDate!.Value : default,
            Price = viewModel.Price,
        };
    }
 }