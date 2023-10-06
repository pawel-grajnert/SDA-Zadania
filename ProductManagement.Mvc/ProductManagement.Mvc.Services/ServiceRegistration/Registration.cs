using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Mvc.Domain.Abstractions.Interfaces;
using ProductManagement.Mvc.Services.Products;

namespace ProductManagement.Mvc.Services.ServiceRegistration;

public static class Registration
{
    public static void AddServiceLayerServices(this IServiceCollection services)
    {
        services.AddTransient<IProductService, ProductService>();
    }
}