using Microsoft.EntityFrameworkCore;
using ProductManagement.Mvc.Domain.Abstractions.Interfaces;
using ProductManagement.Mvc.Domain.Models.Base;
using ProductManagement.Mvc.Repository.Context;

namespace ProductManagement.Mvc.Repository.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
{
    private readonly ProductDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(ProductDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }
    public async Task<IQueryable<TEntity>> GetAllAsync()
    {
        return await Task.Factory.StartNew(() => _dbSet.Where(e => e.IsActive).AsQueryable());
    }

    public async Task<TEntity> GetAsync(int id)
    {
        return await _dbSet.SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task Create(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(TEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        entity.IsActive = false;
        await _context.SaveChangesAsync();
    }
}