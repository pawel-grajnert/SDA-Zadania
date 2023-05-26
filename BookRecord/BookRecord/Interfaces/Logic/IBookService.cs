using BookRecord.Domain.Model;

namespace BookRecord.Domain.Interfaces.Logic;

public interface IBookService
{
    public Task<IEnumerable<Book>> GetAllAsync();
    public Task<Book> GetAsync(int id);

    public Task AddAsync(Book book);
    public Task EditAsync(Book book);
    public Task DeleteAsync(int id);
}