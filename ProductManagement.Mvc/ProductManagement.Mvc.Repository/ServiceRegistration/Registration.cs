using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Mvc.Domain.Abstractions.Interfaces;
using ProductManagement.Mvc.Repository.Context;
using ProductManagement.Mvc.Repository.Repository;

namespace ProductManagement.Mvc.Repository.ServiceRegistration;

public static class Registration
{
    public static void AddRepositoryServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProductDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ProductDB")));
        services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
    }
}