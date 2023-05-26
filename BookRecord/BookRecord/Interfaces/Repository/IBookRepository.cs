using BookRecord.Domain.Model;

namespace BookRecord.Domain.Interfaces.Repository;

public interface IBookRepository
{
    public Task<IEnumerable<Book>> GetAllAsync();
    public Task<Book?> GetAsync(int id);
    
    public Task AddAsync(Book book);
    public Task EditAsync(Book book);
    public Task DeleteAsync(Book book);
    public Task<bool> Exist(int id);
}