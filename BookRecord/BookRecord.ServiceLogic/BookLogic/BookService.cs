using System.Net;
using BookRecord.Domain.Exceptions;
using BookRecord.Domain.Interfaces.Logic;
using BookRecord.Domain.Interfaces.Repository;
using BookRecord.Domain.Model;

namespace BookRecord.ServiceLogic.BookLogic;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Book>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }

    public async Task<Book> GetAsync(int id)
    {
        if (!await _repository.Exist(id))
        {
            throw new RecordOperationException($"There is no book with id: {id}", HttpStatusCode.NotFound);
        }

        return await _repository.GetAsync(id);
    }

    public async Task AddAsync(Book book)
    {
        if (book is null)
        {
            throw new RecordOperationException("There was no data delivered to add Book.", HttpStatusCode.InternalServerError);
        }

        if (string.IsNullOrEmpty(book.Isbn) || string.IsNullOrEmpty(book.Title) || book.GenreId <= 0 ||
            book.AuthorId <= 0)
        {
            throw new RecordOperationException("Delivered data are incorrect", HttpStatusCode.BadRequest);
        }

        await _repository.AddAsync(book);
    }

    public async Task EditAsync(Book book)
    {
        if (!await _repository.Exist(book.Id))
        {
            throw new RecordOperationException($"There is no book with id: {book.Id}. you cannot edit not existing book.", HttpStatusCode.NotFound);
        }

        if (book.GenreId <= 0)
        {
            throw new RecordOperationException("Delivered data are incorrect", HttpStatusCode.BadRequest);
        }

        var bookToUpdate = await _repository.GetAsync(book.Id);

        bookToUpdate.GenreId = book.GenreId;
        bookToUpdate.Description = book.Description;

        await _repository.EditAsync(bookToUpdate);
    }

    public async Task DeleteAsync(int id)
    {
        if (!await _repository.Exist(id))
        {
            throw new RecordOperationException($"There is no book with id: {id}. you cannot edit not existing book.", HttpStatusCode.NotFound);
        }
        
        var bookToDelete = await _repository.GetAsync(id);

        await _repository.DeleteAsync(bookToDelete);
    }
}