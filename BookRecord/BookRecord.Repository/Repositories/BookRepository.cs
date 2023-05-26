using BookRecord.Domain.Interfaces.Repository;
using BookRecord.Domain.Model;
using BookRecord.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace BookRecord.Repository.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BookRecordContext _context;

    public BookRepository(BookRecordContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<Book>> GetAllAsync()
    {
        var books =  _context.Books
            .Include(b => b.Genre)
            .Select(book => new Book { Isbn = book.Isbn, Title = book.Title, Genre = book.Genre})
            .AsEnumerable();
        
        return Task.FromResult(books);
    }

    public Task<Book?> GetAsync(int id)
    {
        return _context.Books
            .Include(b => b.Author)
            .Include(b => b.Genre)
            .SingleOrDefaultAsync(b => b.Id == id);
    }

    public async Task AddAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
    }

    public async Task EditAsync(Book book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Book book)
    {
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
    }

    public Task<bool> Exist(int id)
    {
        return Task.FromResult(_context.Books.Any(x => x.Id == id));
    }
}