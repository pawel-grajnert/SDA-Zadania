using ProductManagement.Mvc.Domain.Models.Base;

namespace ProductManagement.Mvc.Domain.Abstractions.Interfaces;

public interface IRepository<TEntity> where TEntity : EntityBase, new()
{
    Task<IQueryable<TEntity>> GetAllAsync();
    Task<TEntity> GetAsync(int id);
    Task Create(TEntity entity);
    Task Update(TEntity entity);
    Task DeleteAsync(TEntity entity);
}